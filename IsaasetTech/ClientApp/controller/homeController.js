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
        //an data loading indicator 
        $scope.isLoading = false;

        //handle button onclick event, to get cities from server.
        $scope.getCities = function () {

            if ($scope.countryName === '') {
                alert('Please input a valid name.');
                return;
            }
            //start to load data
            $scope.isLoading = true;

            //call the api in weather service.
            weatherService.getCitiesByCountry($scope.countryName)
                .success(function (data) {   //when the call is successful
                    //loading data finished
                    $scope.isLoading = false;
                    $scope.cities = data;

                    if ($scope.cities.length > 0) {
                        $scope.selectedCity = $scope.cities[0]; //first city as selected
                    } else {
                        alert('Invalid country name.');
                    }
                })
                .error(function (error) {  //when the call failed
                    //loading data finished
                    $scope.isLoading = false;
                    alert(error);
                });
            
        }

        //handle button onclick, get current weather.
        $scope.getWeather = function () {

            //construct the data model for query
            var model = {
                cityName: $scope.selectedCity,
                countryName: $scope.countryName
            };

            //start to load data
            $scope.isLoading = true;

            //call the api in weather service.
            weatherService.getWeatherByCity(model)
                .success(function (data) {   //when the call is successful
                    $scope.resultData = data;
                    //loading data finished
                    $scope.isLoading = false;
                })
                .error(function (error) {  //when the call failed
                    //loading data finished
                    $scope.isLoading = false;
                    alert(error);
                });
        }

        //handle the key up event of country name input
        $scope.onEnterKeyUp = function (event) {
            if (event.keyCode === 13) {
                $scope.getCities();
            }
        }
    }
})(angular.module('weather'));