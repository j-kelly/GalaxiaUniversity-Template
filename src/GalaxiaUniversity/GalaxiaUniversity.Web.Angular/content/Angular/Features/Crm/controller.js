var app = angular.module('myApp');

app.controller('CrmController', ['$scope', '$routeParams', function ($scope, $routeParams) {

    $scope.page = $routeParams.section

}]);