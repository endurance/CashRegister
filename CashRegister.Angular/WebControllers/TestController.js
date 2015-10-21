(function () {
    var app = angular.module("TestModule", []);
    var TestController = function ($scope, $http) {
        $scope.title = "This is it!";
        var onItemRequest = function (response) {
            $scope.items = response.data;
        }
        $http.get("http://localhost:88/api/items/").then(onItemRequest);
    };
    app.controller("TestController", TestController);
}());
