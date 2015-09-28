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

        var cookies = $cookies.getAll();
        angular.forEach(cookies, function (v, k) {
            $cookies.remove(k);
        });
    }

    // debugger func
    $scope.alert = function (msg) {
        alert(msg);
    };

    // should be service
    $scope.addAlert = function (type, header, body) {
        var alertHtml = '<div class="alert alert-' + type + ' fade in">' +
                            '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>' +
                            '<strong>' + header + '!</strong> ' + body +
                        '</div>';

        $('#alert-container').append(alertHtml);
    };
}]);