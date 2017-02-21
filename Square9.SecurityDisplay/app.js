var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider
.when('/home', {
    templateUrl: 'partials/home.view.html'
})
.when('/login', {
    controller: 'LoginController',
    templateUrl: 'partials/login.view.html',
})
.otherwise({
    redirectTo: '/login'
})

});
