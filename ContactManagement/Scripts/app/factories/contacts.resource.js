angular
    .module('contacts.resource', [])
    .factory('ResourceUtils', ['$http', '$q',
        function ($http, $q) {
            return {
                handleSuccess: function (response) {
                    return response.data;
                },
                handleError: function (response) {
                    if (!angular.isObject(response.data)) {
                        return ($q.reject("An unknown error occurred."));
                    }
                    return ($q.reject(response.data));
                }
            };
        }]);