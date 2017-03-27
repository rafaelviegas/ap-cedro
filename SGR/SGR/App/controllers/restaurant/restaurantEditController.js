(function () {
    "use strict";

    angular
        .module("app")
        .controller("restaurantEditController", ["$scope", "$http", "serviceBase", "$window", "$location", restaurantEditController]);
    function restaurantEditController($scope, $http, serviceBase, $window, $location) {

        var api = "/restaurant/";

        $scope.restaurant = {};

        $.LoadingOverlay("show");

        var url = api +"getbyId?id=" +$location.search().id;

        serviceBase.get(url).success(function (result) {
            if (result.Sucesso) {

                $scope.restaurant = {
                    name: result.Dados[0].Name,
                    restaurantId : result.Dados[0].RestaurantId
                }

            }
        }).finally(function () {
            $.LoadingOverlay("hide");
        });


        $scope.edit = function () {

            $.LoadingOverlay("show");

            var url = api + "edit";

            $http.post(url, $scope.restaurant)
                .success(function (result) {
                    if (result.Sucesso) {
                        window.location = "#/restaurants";

                    } else {
                        alertnotify(false, result.message);
                    }
                }).finally(function () {
                    $.LoadingOverlay("hide");
                });
        }
        $scope.cancel = function () {
            $scope.restaurant.name = "";
            window.location = "#/restaurants";
        }

    }
})();