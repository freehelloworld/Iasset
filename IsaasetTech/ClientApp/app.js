// angular module
(function () {
   

    // injection
    config.$inject = ['$routeProvider', '$httpProvider'];

    // add ng-route, ng-animate modules
    angular.module('weather', ['ngRoute', 'ngAnimate']).config(config);

    function config($routeProvider, $httpProvider) {
        //use $routeProvider to do routing for SPA.
    }

})();