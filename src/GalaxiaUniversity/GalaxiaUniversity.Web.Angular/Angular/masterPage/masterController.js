var app = angular.module('myApp');

app.controller('masterController', ['$scope', '$routeParams', '$cookies', 'WebApi', function ($scope, $routeParams, $cookies, _WebApi) {

    $scope.main = null;
 
    $scope.$watch('main ', function () {
    }, true);

    // Table sorting and filtering
    $scope.sortField = 'name';
    $scope.reverse = false;
    $scope.orderTable = function (column) {
        $scope.sortField = column;
        $scope.reverse = !$scope.reverse;
    };


    $scope.initialise = function () {
        _WebApi.startUp(
            function (data) { $scope.main = data; },
            function () { alert('failed'); })
    }

    // debugger func
    $scope.alert = function (msg) {
        alert(msg);
    };
}]);