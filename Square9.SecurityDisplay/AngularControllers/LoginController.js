(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', '$scope', 'LoginService', '$cookies']; 
    function LoginController($location, $scope, LoginService, $cookies) {
        /* jshint validthis:true */

        $scope.login = login;

        (function initController() {
            // reset login status
            LoginService.ClearCredentials();
        })();

        function login() {
            $scope.dataLoading = true;
            LoginService.login($scope.username, $scope.password, $scope.domain, function (response) {
            if (response.data.Token != null) {
                LoginService.SetCredentials($scope.username, $scope.password, $scope.domain, $scope.isDomain, response.data.Token);
                $location.path('/');
            }
            else
            {
                $scope.error = response.message;
                $scope.dataLoading = false;
            }
});
        }
    }
})();
