(function () {
    'use strict';

    angular
        .module('App')
        .factory('CurrentTimeService', CurrentTimeService);

    CurrentTimeService.$inject = ['$http'];

    function CurrentTimeService($http) {
        return {
            Read: Read,
            Queries: Queries
        };

        function Read(offSet) {
            return $http({
                method: 'GET',
                url: 'http://localhost:14168/api/CurrentTime/' + offSet,
                headers: { 'Content-Type': 'application/json' }
            });
        }

        function Queries() {
            return $http({
                method: 'POST',
                url: 'http://localhost:14168/api/CurrentTime/Queries',
                headers: { 'Content-Type': 'application/json' }
            });
        }

    }
})();