var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']);

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/', {
        title: 'Index',
        controller: function () { },
        templateUrl: 'angular/Features/FrontPage/index.html',
    }).when('/Products', {
        title: 'Products',
        controller: 'productsController',
        templateUrl: 'angular/Features/Products/index.html',
        caseInsensitiveMatch: true
    }).when('/Products/:code', {
        title: 'Products',
        controller: 'productsController',
        templateUrl: 'angular/Features/Products/index.html',
        caseInsensitiveMatch: true
    }).when('/Books', {
        controller: 'bookController',
        templateUrl: 'angular/Features/Books/index.html',
        caseInsensitiveMatch: true
    }).when('/Books/:isbn', {
        controller: 'bookController',
        templateUrl: 'angular/Features/Books/index.html',
        caseInsensitiveMatch: true
    }).otherwise({ redirectTo: '/' });
}]);

// Required as ng-view nested in ng-include
app.run(['$route', function ($route) {
    $route.reload();
}]);


app.factory('WebApi', function ($http) {

    var factory = {};
    var urlBase = '/api/Main/';

    factory.startUp = function (onSuccess, onFailure) {
        $http.get(urlBase + 'LoadDetails').
          success(onSuccess).
          error(onFailure);
    };

    return factory;
});


