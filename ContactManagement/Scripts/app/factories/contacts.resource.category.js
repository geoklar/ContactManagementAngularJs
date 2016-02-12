angular
    .module('contacts.resource.category', [])
    .constant('CategoryResourceUrl', {
        getAll: "/api/category"
    })
    .factory('CategoryResource', ['CategoryResourceUrl', '$http', 'ResourceUtils',
        function (CategoryResourceUrl, $http, ResourceUtils) {
            "use strict";
            return {
                getAll: function () {
                    var request = $http({
                        method: "GET",
                        url: CategoryResourceUrl.getAll,
                        params: {},
                        data: null,
                        cache: false
                    });

                    return (request.then(ResourceUtils.handleSuccess, ResourceUtils.handleError));
                }
            };
        }
    ]);
