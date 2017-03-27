(function () {
    "use strict";

    angular
        .module("app")
        .controller("dishEditController", ["$scope", "$http", "serviceBase", "$window", "$location", dishEditController]);
    function dishEditController($scope, $http, serviceBase, $window, $location) {

        var api = "/dish/";

        $.LoadingOverlay("show");

        var url = api + "getbyId?id=" + $location.search().id;

        $.LoadingOverlay("show");

        serviceBase.get(url).success(function (result) {
            if (result.Sucesso) {

                $scope.dish = {
                    dishId: result.Dados[0].DishId,
                    name: result.Dados[0].Name,
                    price: result.Dados[0].Price,
                    restaurantId: result.Dados[0].RestaurantId
                }

                $http.get("/restaurant/").success(function (result) {
                    if (result.Sucesso)
                        $scope.dish.restaurants = result.Dados;
                }).finally(function () {
                    $.LoadingOverlay("hide");
                });

            }
        }).finally(function () {
            $.LoadingOverlay("hide");
        });


        $scope.edit = function () {

            $.LoadingOverlay("show");

            var url = api + "edit";

            $http.post(url, $scope.dish)
                .success(function (result) {
                    if (result.Sucesso) {
                        window.location = "#/dishes";

                    } else {
                        alertnotify(false, result.message);
                    }
                }).finally(function () {
                    $.LoadingOverlay("hide");
                });
        }
        $scope.cancel = function () {
            window.location = "#/dishes";
        }

    }
})();