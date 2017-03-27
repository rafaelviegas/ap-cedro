/// <reference path="../views/dish/﻿dish.html" />
/// <reference path="../views/dish/﻿dish.html" />
/// <reference path="../views/dish/﻿dish.html" />

(function () {
    "use strict";

    function routeRestaurants($routeProvider) {
        $routeProvider
            .when("/restaurants", {
                templateUrl: "/app/views/restaurant/restaurant.html"
            })
            .when("/addRestaurants", {
                templateUrl: "/app/views/restaurant/add-restaurant.html"
            })
            .when("/editRestaurant", {
                templateUrl: "/app/views/restaurant/edit-restaurant.html"
            });
        
    }

    function routeDishes($routeProvider) {
        $routeProvider
        .when("/dishes", {
            templateUrl: "/app/views/dish/﻿dish.html"
        })
        .when("/addDish", {
            templateUrl: "/app/views/dish/add-dish.html"
        })
        .when("/editDish", {
            templateUrl: "/app/views/dish/edit-dish.html"
        });
    }
    
    function routeHome($routeProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "/app/views/home.html"
            });
    }

    angular
        .module("app")
        .config(function($routeProvider) {
            $routeProvider.otherwise({
                redirectTo: "/home"
            });
        })
        .config(routeRestaurants)
        .config(routeDishes)
        .config(routeHome);
})();