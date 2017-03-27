(function () {

    var app = angular.module("app");

    app.factory("serviceBase", ["$http", function ($http) {

        var get = function (api, id) {
            return $http.get(api + (id || ""));
        };

        var save = function(api, model) {
            if (model.id) {
                return $http.put(api + model.id, model);
            }
            return $http.post(api + "save", model);
        };

        var remove = function(api, id) {
            return $http.delete(api + id);
        };

        var upload = function(api, model) {
            var fd = new FormData();
            if (model != null) {
                var keys = Object.keys(model);
                angular.forEach(keys, function(key) {
                    fd.append(key, model[key]);
                });
            }

            return $http.post(api, fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        };

        return {
            get: get,
            save: save,
            remove: remove,
            upload:upload
        };
    }]);
})();