var app = angular.module('myApp');

app.controller('CountriesController', ['$scope', 'WebApi', function ($scope, WebApi) {

    $scope.newCountry = {};

    $scope.submit = function () {
        WebApi.submit(
            "/api/country/addCountry",
            { Name: $scope.name, population: $scope.population },
            function (data) {

                if (data.ErrorMessages.length === 0) {
                    $scope.main.countries.push({ name: $scope.name, population: $scope.population});
                    $scope.name = $scope.population = null;
                    
                    $scope.addAlert(
                        'success', 
                        'Record Added', 
                        $scope.name + ' has been successfully added to the database.(Id: ' + data.Id + ')');
                }
                else
                    alert(data.BigErrorMessage);
            },
            function () { $scope.addAlert('danger', 'Add Failed', 'Please try again'); });
    };
}]);