(function () {
    "use strict";

    angular
        .module("app")
        .controller("restaurantAddController", ["$scope", "$http", "$uibModal", "serviceBase", "$window", "$location", restaurantAddController]);
    function restaurantAddController($scope, $http, serviceBase, $window, $location) {

        var api = "/restaurant/";

        $scope.restaurant = {
             name : ""
        };

        $scope.add = function () {

            $.LoadingOverlay("show");

            var url = api + "save";

            $http.post(url,  $scope.restaurant)
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
        $scope.cancel = function() {
            $scope.restaurant.name = "";
            window.location = "#/restaurants";
        }

    }
})();