angular
	.module('contacts.main', ['ngAnimate', 'ui.bootstrap'])
    .controller('MainCtrl', ['$scope', 'CategoryResource', 'ContactResource', 
    function ($scope, CategoryResource, ContactResource) {
        "use strict";

        // Scope Variables
        $scope.categories = [];
        $scope.contacts = [];
        $scope.currentCategory = null;
        $scope.editedContact = null;
        $scope.isEditMode = false;
        $scope.EMAIL_REGEXP = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
        $scope.errors = [];

        // Scope Methods
        $scope.setCurrentCategory = setCurrentCategory;
        $scope.isCurrentCategory = isCurrentCategory;
        $scope.createContact = createContact;
        $scope.editContact = editContact;
        $scope.deleteContact = deleteContact;
        $scope.saveContact = saveContact;
        $scope.isSelectedContact = isSelectedContact;
        $scope.isCreating = isCreating;

        init();

        function init() {
            loadCatagories();
            loadContacts();
        };

        function loadCatagories() {
            CategoryResource.getAll()
                .then(function (data) {
                    $scope.categories = data;
                });
        };

        function loadContacts() {
            ContactResource.getAll()
                .then(function (data) {
                    $scope.contacts = data;
                });
        };

        function setCurrentCategory(category) {
            $scope.currentCategory = category;
            $scope.isEditMode = false;
        };

        function isCurrentCategory(category) {
            return $scope.currentCategory !== null && category.CategoryId === $scope.currentCategory.CategoryId;
        };

        function createContact() {
            $scope.errors = [];
            $scope.editedContact = newContact();
            $scope.isEditMode = true;
        };

        function editContact(contact) {
            $scope.errors = [];
            $scope.editedContact = angular.copy(contact);
            $scope.isEditMode = true;
        };

        //Method for delete action
        function deleteContact(contact) {
            ContactResource.remove(contact)
                        .then(function (data) {
                            if (data) {
                                var index = $scope.contacts.indexOf(contact);
                                $scope.contacts.splice(index, 1);
                            }
                        });
            $scope.isEditMode = false;
        };

        function saveContact(contact) {
            if (!$scope.contactForm.$valid) return false;
            
            if (contact.ContactId == 0) {
                ContactResource.post(contact)
                    .then(function (data) {
                        $scope.contacts.push(data);
                        $scope.isEditMode = false;
                        $scope.editedContact = null;
                    },
                    //Showing errors from ModelState Object
                        function (err) {
                            var errors = [];
                            for (var key in err.ModelState) {
                                for (var i = 0; i < err.ModelState[key].length; i++) {
                                    $scope.isEditMode = true;
                                    errors.push(err.ModelState[key][i]);
                                }
                            }
                            $scope.errors = [];
                            $scope.errors = errors;
                            
                            // error callback
                            console.log(err);
                        });
            } else {
                ContactResource.put(contact)
                    .then(function (data) {
                        var idx = -1;
                        for (var i = 0; i < $scope.contacts.length && idx == -1; i++) {
                            if ($scope.contacts[i].ContactId == contact.ContactId)
                                idx = i;
                        };
                        if (idx != -1)
                            $scope.contacts[idx] = contact;

                        $scope.isEditMode = false;
                        $scope.editedContact = null;
                    },
                    //Showing errors from ModelState Object
                        function (err) {
                            var errors = [];
                            for (var key in err.ModelState) {
                                for (var i = 0; i < err.ModelState[key].length; i++) {
                                    $scope.isEditMode = true;
                                    errors.push(err.ModelState[key][i]);
                                }
                            }
                            $scope.errors = [];
                            $scope.errors = errors;
                            
                            // error callback
                            console.log(err);
                    });

                //$scope.editedContact = null;
            }
		        
            //$scope.isEditMode = false;
        };


        function isSelectedContact(contactId) {
            return $scope.editedContact !== null && $scope.editedContact.ContactId === contactId;
        };

        function isCreating() {
            return angular.isObject($scope.editedContact) &&
                $scope.editedContact.ContactId == 0;
        };

        function newContact() {
            return {
                ContactId: 0,
                FirstName: '',
                MiddleName: '',
                LastName: '',
                Email: '',
                CompanyName: '',
                WorkPhone: '',
                CellPhone: '',
                Category: $scope.currentCategory,
                BirthDate: null
            };
        };
    }])
    

    .filter('phoneNumber', function () {
        //Filter created to format phone numbers
        return function (phoneNumber) {
            if (!phoneNumber) { return ''; }

            var value = phoneNumber.toString().trim().replace(/^\+/, '');

            //Checking for numeric characters
            if (value.match(/[^0-9]/)) {
                return phoneNumber;
            }

            var city, number;

            switch (value.length) {
                case 10: // PPP####### -> (PPP) ###-####
                    city = value.slice(0, 3);
                    number = value.slice(3);
                    break;

                default:
                    return phoneNumber;
            }

            number = number.slice(0, 3) + '-' + number.slice(3);

            return ("(" + city + ") " + number).trim();
        };
    })

    //filter for formating the birthdate value of a contact
    .filter('dateFormat', function ($filter) {
        return function (dateValue) {
            if (!dateValue) { return "N/A"; }
            var _date = $filter('date')(new Date(dateValue), 'MMMM dd, yyyy');
            return _date;
        };
    })
    //Settings for DatepickerCtrl controller
    .controller('DatepickerCtrl', function ($scope) {
        $scope.today = function () {
            $scope.BirthDate = new Date();
        };
        $scope.today();
        //$scope.BirthDate = '';

        $scope.clear = function () {
            $scope.BirthDate = null;
        };

        // Disable weekend selection
        $scope.disabled = function (date, mode) {
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        };

        $scope.toggleMin = function () {
            $scope.minDate = new Date(1900, 1, 1);
        };

        $scope.toggleMin();
        $scope.maxDate = new Date();

        $scope.open1 = function () {
            $scope.popup.opened = true;
        };

        $scope.setDate = function (year, month, day) {
            $scope.BirthDate = new Date(year, month, day);
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.formats = ['dd/MM/yyyy', 'yyyy-MM-dd'];
        $scope.format = $scope.formats[0];
        $scope.altInputFormats = ['M!/d!/yyyy'];

        $scope.popup = {
            opened: false
        };

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        $scope.events =
            [
            {
                date: tomorrow,
                status: 'full'
            },
            {
                date: afterTomorrow,
                status: 'partially'
            }
            ];

        $scope.getDayClass = function (date, mode) {
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        };
    });