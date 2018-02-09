var Switches = angular.module('Switches', ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when('/index',
            {
                templateUrl: '/',
                controller: 'filterController'
            });
    });