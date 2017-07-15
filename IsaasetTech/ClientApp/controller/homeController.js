(function (module) {
    // inject params
    ctrl.$inject = ['$scope', 'weatherService'];

    // create instance
    module.controller('homeController', ctrl);

    function ctrl($scope, weatherService) {

        $scope.title = 'Weather';

        //country name from user input
        $scope.countryName = '';

        //cites of given country.
        $scope.cities = [];

        // selected city
        $scope.selectedCity = '';

        //weather result data
        $scope.resultData = '';

        //handle button onclick event, to get cities from server.
        $scope.getCities = function () {

            if ($scope.countryName === '') {
                alert('Please input a valid name.');
                return;
            }

            //call the api in weather service.
            weatherService.getCitiesByCountry($scope.countryName)
                .success(function (data) {   //when the call is successful

                    $scope.cities = data;

                    if ($scope.cities.length > 0) {
                        $scope.selectedCity = $scope.cities[0]; //first city as selected
                    } else {
                        alert('Invalid country name.');
                    }
                })
                .error(function (error) {  //when the call failed
                    console.log(error);
                    alert(error);
                });
            
        }

        $scope.getWeather = function () {

            //construct the data model for query
            var model = {
                cityName: $scope.selectedCity,
                countryName: $scope.countryName
            };
            //call the api in weather service.
            weatherService.getWeatherByCity(model)
                .success(function (data) {   //when the call is successful
                    $scope.resultData = data;
                })
                .error(function (error) {  //when the call failed
                    alert(error);
                });
        }
    }
})(angular.module('weather'));