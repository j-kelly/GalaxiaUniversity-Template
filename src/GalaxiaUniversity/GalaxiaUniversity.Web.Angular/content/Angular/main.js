var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        title: 'Index',
        controller: function () { },
        templateUrl: 'content/angular/features/FrontPage/index.html',
    }).when('/crm', {
        controller: 'CrmController',
        templateUrl: 'content/angular/features/Crm/index.html',
        caseInsensitiveMatch: true
    }).when('/crm/:section', {
        controller: 'CrmController',
        templateUrl: 'content/angular/features/Crm/index.html',
        caseInsensitiveMatch: true
    }).when('/bookings', {
        controller: function () { },
        templateUrl: 'content/angular/features/bookings/index.html',
        caseInsensitiveMatch: true
    }).when('/admin', {
        controller: function () { },
        templateUrl: 'content/angular/features/admin/index.html',
        caseInsensitiveMatch: true
    }).when('/enquires', {
        controller: function () { },
        templateUrl: 'content/angular/features/enquires/index.html',
        caseInsensitiveMatch: true
    }).when('/settings', {
        controller: function () { },
        templateUrl: 'content/angular/features/settings/index.html',
        caseInsensitiveMatch: true
    }).when('/clients', {
        controller: function () { },
        templateUrl: 'content/angular/features/clients/index.html',
        caseInsensitiveMatch: true
    }).when('/tasks/:taskId', {
        controller: 'TaskController',
        templateUrl: 'content/angular/features/tasks/index.html',
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

    factory.submit = function (url, commandModel, onSuccess, onFailure) {
        $http.post(
          url,
          JSON.stringify(commandModel), { headers: { 'Content-Type': 'application/json' } }).
          success(onSuccess).
          error(onFailure);
    };

    return factory;
});


