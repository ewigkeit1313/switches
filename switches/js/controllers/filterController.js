var Switches = angular.module('Switches');

Switches.controller('filterController', function ($scope, $http) {
    $scope.switchesOnPage = 5;
    $scope.pages = 0;
    $scope.curentPage = 0;

    var options = {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    };

    $scope.parseJsonDate = function (date) {
        var CleanDate = new Date(parseInt(date.substr(6)));
        return CleanDate.toLocaleString("ru", options);
    }

    $scope.DateOut = function (array) {
        if (array != null) {
            for (d in array) {
                array[d]['DateInstallation'] = $scope.parseJsonDate(array[d]['DateInstallation']);
            }
            return array;
        }
    }


    $scope.totalPage = function (arrSwitches) {
        if (arrSwitches == null) {
            return;
        }
        var ostatok = Math.floor(arrSwitches / $scope.switchesOnPage);

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
                    $scope.pageFilter($scope.DateOut(response.data), curentPage, $scope.switchesOnPage);
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