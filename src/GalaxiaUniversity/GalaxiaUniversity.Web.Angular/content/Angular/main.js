var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']);

app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/', {
        title: 'Index',
        controller: function () { },
        templateUrl: 'content/angular/features/FrontPage/index.html',
    }).when('/Products', {
        title: 'Products',
        controller: 'productsController',
        templateUrl: 'content/angular/features/Products/index.html',
        caseInsensitiveMatch: true
    }).when('/Products/:code', {
        title: 'Products',
        controller: 'productsController',
        templateUrl: 'content/angular/features/Products/index.html',
        caseInsensitiveMatch: true
    }).when('/Books', {
        controller: 'bookController',
        templateUrl: 'content/angular/features/Books/index.html',
        caseInsensitiveMatch: true
    }).when('/Books/:isbn', {
        controller: 'bookController',
        templateUrl: 'content/angular/features/Books/index.html',
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

    factory.saveStuff = function (commandModel, onSuccess, onFailure) {
        $http.post(
          urlBase + 'SaveStuff',
          JSON.stringify(commandModel), { headers: { 'Content-Type': 'application/json' } }).
          success(onSuccess).
          error(onFailure);
    };

    return factory;
});


