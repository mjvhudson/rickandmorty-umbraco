angular.module('umbraco.resources').factory('rickandmortyResource',
    function ($q, $http, umbRequestHelper) {
        return {
            getCharacters: function () {
                return umbRequestHelper.resourcePromise(
                    $http.get("backoffice/RickAndMortyProject/GetCharactersApi/LoadCharacters"),
                    "Failed to get characters!");
            }
        };
    }
);