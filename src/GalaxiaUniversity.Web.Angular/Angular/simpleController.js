var app = angular.module('products');

app.controller('simpleController', ['$scope', function ($scope) {
    $scope.countries = [
        { country: 'Germany', population: 123 },
        { country: 'Spain', population: 456 },
        { country: 'Uk', population: 789 },
        { country: 'Greece', population: 129 },
    ];
}]);