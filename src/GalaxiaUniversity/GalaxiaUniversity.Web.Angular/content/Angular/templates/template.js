var app = angular.module('myApp');

app.directive('guTextbox', function () {
    return {
        restrict: 'EA',
        scope: { model: '=', label: '@', placeholder: '@' },
        templateUrl: "/content/angular/templates/guTextBox.html",
        compile: function (element, attrs) {
            if (!attrs.hidehelp) { attrs.hideHelp = false; }
            if (!attrs.titlelength) { attrs.titlelength = 2; }
        },
    };
});

app.directive('guNumberbox', function () {
    return {
        restrict: 'EA',
        scope: { model: '=', label: '@', min: '@'},
        templateUrl: "/content/angular/templates/guNumberBox.html",
        compile: function (element, attrs) {
            if (!attrs.hidehelp) { attrs.hideHelp = false; }
            if (!attrs.titlelength) { attrs.titlelength = 2; }
        },
    };
});
