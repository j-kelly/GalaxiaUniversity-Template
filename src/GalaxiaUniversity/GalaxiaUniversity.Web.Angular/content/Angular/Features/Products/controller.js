var app = angular.module('myApp');

app.controller('productsController', ['$scope', '$cookies','$routeParams', 'WebApi', function ($scope, $cookies, $routeParams, WebApi) {
    $scope.productCode = $routeParams.code;
}]);