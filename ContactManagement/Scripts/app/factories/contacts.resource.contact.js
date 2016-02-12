angular
    .module('contacts.resource.contact', [])
    .constant('ContactResourceUrl', {
        getAll: "/api/contact",
        post: "/api/contact",
        put: "/api/contact",
        remove: "/api/contact"
    })
    .factory('ContactResource', ['ContactResourceUrl', '$http', 'ResourceUtils',
        function (ContactResourceUrl, $http, ResourceUtils) {
            "use strict";
            return {
                getAll: function () {
                    var request = $http({
                        method: "GET",
                        url: ContactResourceUrl.getAll,
                        params: {},
                        data: null,
                        cache: false
                    });

                    return (request.then(ResourceUtils.handleSuccess, ResourceUtils.handleError));
                },
                post: function (model) {
                    var request = $http({
                        method: "POST",
                        url: ContactResourceUrl.post,
                        params: {},
                        data: model,
                        cache: false
                    });

                    return (request.then(ResourceUtils.handleSuccess, ResourceUtils.handleError));
                },
                put: function (model) {
                    var request = $http({
                        method: "PUT",
                        url: ContactResourceUrl.post,
                        params: {},
                        data: model,
                        cache: false
                    });

                    return (request.then(ResourceUtils.handleSuccess, ResourceUtils.handleError));
                },
                remove: function (model) {
                    var request = $http({
                        method: "DELETE",
                        url: ContactResourceUrl.remove,
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        params: {},
                        data: model,
                        cache: false
                    });

                    return (request.then(ResourceUtils.handleSuccess, ResourceUtils.handleError));
                }
            };
        }
    ]);