(function () {
    "use strict";

    angular
        .module("app")
        .controller("dishController", ["$scope", "$http", "serviceBase", dishController]);

    function dishController($scope, $http, serviceBase) {

        var api = "/dish/";

        $scope.gridOptions = {};
        $scope.gridOptions.data = [];


        $.LoadingOverlay("show");

        serviceBase.get(api).success(function (result) {
            if (result.Sucesso) {
                angular.forEach(result.Dados, function (value, key) {
                    value.edit = true;
                    $scope.gridOptions.data.push(value);
                });

            }
        }).finally(function () {
            $.LoadingOverlay("hide");
        });

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
                '<button type="button" class="btn btn-xs btn-danger" ng-click="$parent.$parent.$parent.$parent.$parent.$parent.$parent.delete(row.entity.DishId)">' +
                '<i class="fa fa-times"></i>' +
                '</button> ' +
                '<button type="button" class="btn btn-xs btn-primary" ng-click="$parent.$parent.$parent.$parent.$parent.$parent.$parent.editRestaurant(row.entity.DishId)">' +
                '<i class="fa fa-pencil"></i>' +
                '</button>' +
            '</div>'
        },
            {
                field: "Restaurant",
                name: "Restaurante",
                width: "15%"
            },
        {
            field: "Name",
            name: "Prato",
            width: "15%"
        },
        {
            field: "Price",
            name: "Preço",
            width: "15%"
        }
        ];


        $scope.addDish = function () {
            window.location = "#/addDish";
        }

        $scope.editRestaurant = function (id) {
            window.location = "#/editDish?id=" + id;
        }
    }

})();