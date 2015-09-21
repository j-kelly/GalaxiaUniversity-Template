var app = angular.module('myApp');

app.controller('bookController', ['$scope', '$cookies', function ($scope, $cookies) {
    $scope.current = {stage:1};


    $scope.$watch('current.stage', function () {
    }, true);

}]);