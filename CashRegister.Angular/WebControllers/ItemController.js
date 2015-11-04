(function () {
    var ItemController = function ($scope, $http) {
        var onItemRequest = function (response) {
            $scope.items = response.data;
        }
        $http.get("http://localhost:88/api/items/").then(onItemRequest);
    };
    angular.module("CashRegister").controller("ItemController", ItemController);
}());
