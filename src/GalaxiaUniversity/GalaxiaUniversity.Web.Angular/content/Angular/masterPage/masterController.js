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

        $scope.initMenu();
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

    $scope.initMenu = function () {
        $('#menu ul').hide();
        $('#menu ul').children('.current').parent().show();
        //$('#menu ul:first').show();
        $('#menu li a').click(
          function () {
              var checkElement = $(this).next();
              if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
                  return false;
              }
              if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
                  $('#menu ul:visible').slideUp('normal');
                  checkElement.slideDown('normal');
                  return false;
              }
          });
    };

}]);