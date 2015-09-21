var app = angular.module('myApp');

app.controller('productsController', ['$scope', '$cookies', 'WebApi', function ($scope, $cookies, WebApi) {


    $scope.productCode = $routeParams.code;


}]);