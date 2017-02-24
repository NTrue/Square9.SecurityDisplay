(function () {
    'use strict';

    angular
        .module('app')
        .factory('DisplayService', DisplayService);

    DisplayService.$inject = ['$http', '$rootScope', '$cookieStore'];

    function DisplayService($http, $rootScope, $cookieStore) {
        var service = {};
        service.GetSecurityInfo = GetSecurityInfo;
        return service;

        function GetSecurityInfo(callback) {
            $rootScope.globals = $cookieStore.get('globals') || {};
            var authdata = $rootScope.globals.currentUser.authdata;
            var DatabaseID = $rootScope.globals.currentUser.DatabaseID;
            var isDomain = $rootScope.globals.currentUser.isDomain;
            $http.defaults.headers.common['Authorization'] = 'Basic ' + authdata;
            $http.get('/api/users/permissions?DatabaseID=' + DatabaseID + '&isDomain=' + isDomain)
                .then(function (response) {
                    callback(response);
                });
        }
    }
})();