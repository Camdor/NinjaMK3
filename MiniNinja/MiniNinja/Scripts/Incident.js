var app = angular.module("incidentApp",[]);

app.controller("IncidentController", ["$scope", "$http", "$window", function ($scope, $http, $window) {
    $scope.someboolean = false;
    $scope.somecat = [{ 'key': 1, 'value': 'Blister' }, { 'key': 2, 'value': 'Fight' }, { 'key': 3, 'value': 'Ache/Pain' }, { 'key': 4, 'value': 'Death' }, { 'key': 5, 'value': 'Unexpected Scale' }]
    $scope.Data = { 'Location': '', 'Description': '', 'Active': false, 'Category': 0, 'LogContent': '', };

    $scope.SendData = function (data) {
        var token = $window.sessionStorage.getItem('tokenKey');
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }
        var config = { headers: headers };
        console.log(data);
        $http.post('/api/Values', data, config).then(function (response) { console.log(response) }, function (response) { alert("AFUERA"); });
    }

}]);

app.controller("AccountController", ["$scope", "$http", '$window', function ($scope, $http, $window) {
    $scope.login = { 'Email': '', 'Password': '' };
    $scope.register = { 'Email': '', 'Password': '', 'ConfirmPassword': '' };
    $scope.registered = false;
    $scope.RegisterUser = function () {
        $http.post('/api/Account/Register', $scope.register).then(function (promise) {
            $scope.result = promise.status;
            $scope.register = { 'Email': '', 'Password': '', 'ConfirmPassword': '' };
            $scope.registered = true;

        })
    }

    $scope.LogIn = function () {
        var data = "grant_type=password&username=" + $scope.login.Email + "&password=" + $scope.login.Password;
        $http.post('/Token', data).then(function (promise) {
            $scope.user = data.userName;
            $window.sessionStorage.setItem('tokenKey', promise.data.access_token);
            $scope.login.Password = '';
        })
    }


}]);