﻿(function () {
    "use strict";

    var app = angular.module("app");

    //tradução Angular
    app.config(["$translateProvider", function ($translateProvider) {
        $translateProvider.preferredLanguage("pt-BR");
    }]);


    app.config([
        "$httpProvider", function ($httpProvider) {

            //initialize get if not there
            if (!$httpProvider.defaults.headers.get) {
                $httpProvider.defaults.headers.get = {};
            }

            //disable IE ajax request caching
            $httpProvider.defaults.headers.get["If-Modified-Since"] = "Mon, 26 Jul 1997 05:00:00 GMT";

            // extra
            $httpProvider.defaults.headers.get["Cache-Control"] = "no-cache";
            $httpProvider.defaults.headers.get["Pragma"] = "no-cache";

        }
    ]);

})();