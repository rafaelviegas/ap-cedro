(function () {
    "use strict";

    angular
        .module("app")
        .controller("dishAddController", ["$scope", "$http", "$uibModal", "serviceBase", dishAddController]);
    function dishAddController($scope, $http, serviceBase) {

        var api = "/dish/";

        $scope.dish = {
            restaurantId: 0,
            name: "",
            price: 0

        }; 
        

        $.LoadingOverlay("show");

        $http.get("/restaurant/").success(function (result) {
            if (result.Sucesso)
                $scope.dish.restaurants = result.Dados;
         
        }).finally(function () {
            $.LoadingOverlay("hide");
        });


        $scope.add = function () {

            $.LoadingOverlay("show");

            var url = api + "save";

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