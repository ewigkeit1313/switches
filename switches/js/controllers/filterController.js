var Switches = angular.module('Switches');

Switches.controller('filterController', function ($scope, $http) {
    $scope.switchesOnPage = 5;
    $scope.pages = 0;
    $scope.curentPage = 0;

    $scope.pageFilter = function (array, curentPage, switchesOnPage) {
        var start = curentPage * switchesOnPage;
        $scope.switches = array.slice(start, start + switchesOnPage);
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
            $scope.pages = ostatok + 1;
        }
    }

    $scope.Work = function (arraySwitches, curentPage) {
        if (arraySwitches == 'init') {
            $http.get("/home/getListSwitches").then(
                function (response) {
                    $scope.AllSwitches = response.data;
                    $scope.pageFilter(response.data, curentPage, $scope.switchesOnPage);
                    $scope.totalPage(response.data.length);
                },
                function (response) {
                    console.log("Error loading data...");
                }
            );
        } else {
            $scope.pageFilter(arraySwitches, curentPage, $scope.switchesOnPage);
            $scope.totalPage(arraySwitches.length);
        }

    }

    $scope.getModels = function () {
        $http.get("/home/getModels").then(
            function (response) {
                $scope.models = response.data;
            }
        )
    }

    $scope.getFloors = function () {
        $http.get("/home/getFloors").then(
            function (response) {
                $scope.floors = response.data;
            }
        )
    }

    $scope.getFilterSwitches = function (model, floor) {

        if (floor == undefined) {
            floor = $scope.floors;
        }

        if (model == undefined) {
            model = $scope.models;
        }

        $http({
            url: "/home/getFilterSwitches",
            method: "GET",
            params: {
                'models': model,
                'floors': floor
            }
        }).then(
            function (response) {
                    $scope.AllSwitches = response.data;
                    $scope.Work(response.data, $scope.curentPage);

                    if (response.data == '') {
                          $scope.pages = 0;
                    }
                },
                function (response) {
                    console.log("Error loading data...");
                }
            );
    }

    $scope.Work("init", $scope.curentPage);
    $scope.getModels();
    $scope.getFloors();

});



Switches.filter('range', function () {
    return function (input, total) {
        total = parseInt(total);

        for (var i = 0; i < total; i++) {
            input.push(i);
        }

        return input;
    };
});
