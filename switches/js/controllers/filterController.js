var Switches = angular.module('Switches');

Switches.controller('filterController', function ($scope, $http) {
    $scope.Work = function () {
        $http.get("/home/getListSwitches").then(
                function (response) {
                    $scope.switches = response.data;
                },
                function (response) {
                    // failure call back
                }
        );
    }
    $scope.Work();

})