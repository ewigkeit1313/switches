var Switches = angular.module('Switches');

Switches.controller('filterController', function ($scope, $http) {
    $scope.switchesOnPage = 5;
    $scope.pages = 0;
    $scope.curentPage = 0;

    $scope.totalPage = function (arrSwitches) {
        if (arrSwitches == null) {
            return;
        }
        var ostatok = Math.floor(arrSwitches / $scope.switchesOnPage);
        //var drob = getDecimal(arrSwitches / $scope.switchesOnPage);
        if (ostatok >= 1) {
            $scope.pages = ostatok;
        }
                
        if (arrSwitches % $scope.switchesOnPage > 0) {
            $scope.pages = ostatok+1;
        }
    }

    $scope.Work = function (curentPage) {
        $http.get("/home/getListSwitches").then(
                function (response) {
                    $scope.pageFilter(response.data, curentPage, $scope.switchesOnPage);
                    $scope.totalPage(response.data.length);
                },
                function (response) {
                    // failure call back
                }
        );
    }
    $scope.Work($scope.curentPage);



    // filter for ng-repeat

    $scope.pageFilter = function (array,curentPage, switchesOnPage) {
        var start = curentPage * switchesOnPage;
        $scope.switches = array.slice(start, start + switchesOnPage);
    }
})

Switches.filter('range', function () {
    return function (input, total) {
        total = parseInt(total);

        for (var i = 0; i < total; i++) {
            input.push(i);
        }

        return input;
    };
});