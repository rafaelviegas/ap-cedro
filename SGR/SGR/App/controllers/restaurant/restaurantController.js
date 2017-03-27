(function () {
    "use strict";

    angular
        .module("app")
        .controller("restaurantController", ["$scope", "$http", "$uibModal", "serviceBase", "$window", "$location", restaurantController]);

    function restaurantController($scope, serviceBase, $window, $location) {

        var api = "/restaurant/";

        $scope.search_term = "";
        $scope.gridOptions = {};


        $.LoadingOverlay("show");
        serviceBase.get(api).success(function (result) {
            if (result.Sucesso) {
                angular.forEach(result.Dados, function (value, key) {
                    $scope.gridOptions.data.push(value);
                });

            }
        }).finally(function () {
            $.LoadingOverlay("hide");
        });

        $scope.search = function () {
            $.LoadingOverlay("show");
            var url = api + "search?term=" + $scope.search_term;

            serviceBase.get(url)
                .success(function (result) {
                    if (result.Sucesso) {
                        $scope.gridOptions.data = [];
                        angular.forEach(result.Dados, function (value, key) {
                            $scope.gridOptions.data.push(value);
                        });
                    }

                }).finally(function () {
                    $.LoadingOverlay("hide");
                });
        }

        $scope.delete = function (id) {

            $.LoadingOverlay("show");

            var url = api + "delete?id=" + id;

            serviceBase.get(url).success(function (result) {
                if (result.Sucesso) {
                    $.LoadingOverlay("show");
                    serviceBase.get(api).success(function (result) {
                        if (result.Sucesso) {
                            $scope.gridOptions.data = result.Dados;
                        }
                    }).finally(function () {
                        $.LoadingOverlay("hide");
                    });
                }
            }).finally(function () {
                $.LoadingOverlay("hide");
            });
        }

        $scope.gridOptions.columnDefs = [
        {
            field: "RestaurantId",
            name: "RestaurantId",
            visible: false
        },
        {
            name: "Opções",
            width: "10%",
            cellTemplate:
            '<div class="ui-grid-cell-contents">' +
                '<button type="button" class="btn btn-xs btn-danger" ng-click="$parent.$parent.$parent.$parent.$parent.$parent.$parent.delete(row.entity.RestaurantId)">' +
                '<i class="fa fa-times"></i>' +
                '</button> ' +
                '<button type="button" class="btn btn-xs btn-primary" ng-click="$parent.$parent.$parent.$parent.$parent.$parent.$parent.editRestaurant(row.entity.RestaurantId)">' +
                '<i class="fa fa-pencil"></i>' +
                '</button>' +
            '</div>'
        },
            {
                field: "Name",
                name: "Restaurantes",
                width: "15%"
            }
        ];


        $scope.addRestaurant = function () {
            window.location = "#/addRestaurants";
        }
        $scope.editRestaurant = function (id) {
            window.location = "#/editRestaurant?id=" + id;
        }
    }

})();