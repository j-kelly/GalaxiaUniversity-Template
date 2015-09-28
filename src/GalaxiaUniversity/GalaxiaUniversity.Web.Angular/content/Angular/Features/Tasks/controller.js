var app = angular.module('myApp');

app.controller('TaskController', ['$scope', '$routeParams', function ($scope, $routeParams) {

    $scope.taskId = $routeParams.taskId

}]);