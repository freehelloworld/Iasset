(function (module) {
    // inject the params
    service.$inject = ['$http'];

    // add service to module
    module.service('weatherService', service);

    function service($http) {
        return {
            getCitiesByCountry: getCitiesByCountry, //get list of cities
            getWeatherByCity: getWeatherByCity //get weather data.
        };

        function getCitiesByCountry(model) {
            var name = {
                name:model
            };
            return $http.post('/api/Weather/cities', name);
        }

        function getWeatherByCity(model) {
            return $http.post('/api/Weather/display', model);
        }

    }
})(angular.module('weather'));
