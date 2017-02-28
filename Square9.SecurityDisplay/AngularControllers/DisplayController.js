(function () {
    'use strict';

    angular
        .module('app')
        .controller('DisplayController', DisplayController);

    DisplayController.$inject = ['$location', 'DisplayService', '$scope', '$rootScope', '$cookieStore', '$uibModal'];

    function DisplayController($location, DisplayService, $scope, $rootScope, $cookieStore, $uibModal) {

        (function initController() {
            $scope.openModal = function () {
                        $rootScope.modalInstance = $uibModal.open({
                    templateUrl: 'partials/loading.view.html',
                    controller: 'ModalInstanceCtrl',
                    size: 'sm',
                    backdrop: 'static',
                    keyboard: false,
                    resolve: {
                        items: function () {
                            return null;
                        }
                    }
                });

            }

            $scope.openModal();
            // reset login status
            $rootScope.globals = $cookieStore.get('globals') || {};
            $scope.DatabaseName = $rootScope.globals.currentUser.DatabaseName;
            DisplayService.GetSecurityInfo(function (response) {
                $scope.SecurityData = response.data;
                $rootScope.modalInstance.close();
            });
        })();
    }

    angular.module('app').controller('ModalInstanceCtrl', function ($uibModalInstance, $scope) {
        $scope.close = function () {
            $uibModalInstance.close()
        }
    });
})();
