(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', '$scope', 'LoginService']; 

    function LoginController($location, $scope, LoginService) {
        /* jshint validthis:true */

            $scope.login = function login() {
                $scope.dataLoading = true;
                LoginService.login( $scope.username, $scope.password, function(response) {
                    if(response.success) {
                        console.log(response);
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
