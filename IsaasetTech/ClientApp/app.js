// angular module
(function () {
   

    // injection
    config.$inject = ['$routeProvider', '$httpProvider'];

    // add ng-route, ng-animate modules
    angular.module('weather', ['ngRoute', 'ngAnimate']).config(config);

    function config($routeProvider, $httpProvider) {
        //$routeProvider
        //    .when('', // Home
        //    {
        //        templateUrl: VIEW_ROOT_PATH + '/home.html',
        //        controller: 'homeController',
        //        caseInsensitiveMatch: true
        //    })

            //add more router if needed

    }

})();