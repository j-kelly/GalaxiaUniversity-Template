var app = angular.module('products', ['ngRoute']);

app.run(["$rootScope", function ($rootScope) {
}]);

app.value('defaultValues', {
    'Countries': [
        { country: 'Ireland', population: 2353 },
        { country: 'Spain', population: 12353 },
        { country: 'Italy', population: 12353 },
        { country: 'Uk', population: 12353 },
        { country: 'Usa', population: 123453 },
        { country: 'France', population: 53453 },
        { country: 'Germany', population: 63453 }],
});

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/', {
        controller: function () { },
        template: '<div>Hello from default'
    }).when('/Page2', {
        controller: 'Page2Controller',
        templateUrl: 'angular/templates/page2.html',
        caseInsensitiveMatch: true
    }).when('/Page3', {
        controller: 'simpleController',
        templateUrl: 'angular/templates/page3.html',
        caseInsensitiveMatch: true 
    }).otherwise({ redirectTo: '/' });
}]);


app.controller('Page2Controller', ['$scope', '$routeParams', 'countryFactory', function ($scope, $routeParams, countryFactory) {

    $scope.filter = $routeParams.filter;
    $scope.countries = null;
    countryFactory.GetOnlineCountries(function (data) {
        $scope.countries = data;
    });

    console.log($scope.countries);
    $scope.reverse = false;
    $scope.sortFiled = 'country';

    $scope.orderTable = function (column) {
        $scope.sortField = column;
        $scope.reverse = !$scope.reverse;
    };
}]);

app.factory('countryFactory', ['$http', 'countryService', function ($http, countryService) {
    return {
        GetAllCountries: function (callback) {
            countryService.GetAllCountries(callback);
        },
        GetOnlineCountries: function (callback) {
            $http.get('api/country/GetAllCountries').
              success(function (data, status, headers, config) {
                  callback(data);
              }).
              error(function (data, status, headers, config) {
                  // called asynchronously if an error occurs
                  // or server returns response with an error status.
              });
        },
    };
}]);

app.service('countryService', ['defaultValues', function (defaultValues) {

    this.GetAllCountries = function (callback) {
        callback(defaultValues.Countries);
    }
}]);

app.directive('myHeader', function () {
    return {
        scope: { title: '@' },
        template: "<div><div ng-click='toggle()'>{{title}}</div><div id='xx' ng-show='isOpen' ng-transclude></div></div>",
        transclude: true,
        link: function (scope, element) {
            scope.counter = 1;
            scope.toggle = function () {
                scope.isOpen = !scope.isOpen;
            };

            //setInterval(function () {
            //    scope.$apply(function () {
            //        scope.title = scope.title + scope.counter;
            //        scope.counter++;
            //    });
            //}, 1000);
        }
    };
});


