angular.module("umbraco").controller("RickAndMortyAngularDashboardController", function ($scope, rickandmortyResource) {
    var vm = this;
    rickandmortyResource.getCharacters().then(function(response){
        $scope.charactersAdded = response.data;
    });
});