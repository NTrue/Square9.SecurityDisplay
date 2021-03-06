﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('DatabaseController', DatabaseController);

    DatabaseController.$inject = ['$scope', 'DatabaseService', '$location', '$cookieStore', '$rootScope']; 

    function DatabaseController($scope, DatabaseService, $location, $cookieStore, $rootScope) {

        $scope.SelectDB = SelectDB;

        (function initController() {
            // reset login status
            DatabaseService.GetDatabases(function (response) {
                $scope.DatabaseList = response.data;
            });
        })();          

        function SelectDB(databaseid, databasename) {
            $rootScope.globals = $cookieStore.get('globals') || {};
            $rootScope.globals.currentUser.DatabaseID = databaseid;
            $rootScope.globals.currentUser.DatabaseName = databasename;
            $cookieStore.put('globals', $rootScope.globals);
            $location.path('/securitydisplay');
        }
    }
})();