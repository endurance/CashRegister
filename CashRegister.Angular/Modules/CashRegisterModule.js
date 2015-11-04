(function () {
    var app = angular.module("CashRegister", ['ui.grid', 'ui.router']);

    app.config(['$stateProvider', function ($stateProvider) {

        $stateProvider
            .state('ViewAllItems', {
                url: "ViewItems",
                controller: 'ItemController',
                templateUrl: '/ViewTemplates/ViewItems.html'
            })
            .state('AddAnItem', {
                url:"AddItem",
                controller: 'ItemController',
                templateUrl:'/ViewTemplates/AddItemView.html'
            })
            .state('AddAnItem.AddItemForm', {
                url:"AddItemForm",
                controller: 'ItemController',
                templateUrl:'/ViewTemplates/AddItemForm.html'
            });
        $stateProvider.html5Mode = true;
    }]);
})();