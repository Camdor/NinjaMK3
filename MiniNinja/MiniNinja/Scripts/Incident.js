var app = angular.module("incidentApp",[]);

app.controller("IncidentController", ["$scope", "$http", function ($scope, $http) {
    $scope.someboolean = false;
}]);