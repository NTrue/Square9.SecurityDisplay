(function () {
    'use strict';

    angular
        .module('app')
        .factory('DatabaseService', DatabaseService);

    DatabaseService.$inject = ['$http', '$cookieStore', '$rootScope'];

    function DatabaseService($http, $cookieStore, $rootScope) {
        var service = {};
        service.GetDatabases = getDatabases;
        return service;

        function getDatabases(callback) {
            $rootScope.globals = $cookieStore.get('globals') || {};
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
            $http.get('/api/databases/list')
                .then(function (response) {
                    callback(response)
                });
        }
    }
})();