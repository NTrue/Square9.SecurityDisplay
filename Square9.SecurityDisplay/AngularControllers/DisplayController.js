(function () {
    'use strict';

    angular
        .module('app')
        .controller('DisplayController', DisplayController);

    DisplayController.$inject = ['$location', 'DisplayService', '$scope', '$rootScope', '$cookieStore']; 

    function DisplayController($location, DisplayService, $scope, $rootScope, $cookieStore) {

        (function initController() {
            // reset login status
            $rootScope.globals = $cookieStore.get('globals') || {};
            $scope.DatabaseName = $rootScope.globals.currentUser.DatabaseName;
            DisplayService.GetSecurityInfo(function (response) {
                $scope.SecurityData = response.data;
            });
        })();
    }
})();
