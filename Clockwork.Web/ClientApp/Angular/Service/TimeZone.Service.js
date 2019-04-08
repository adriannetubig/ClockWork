(function () {
    'use strict';

    angular
        .module('App')
        .factory('TimeZoneService', TimeZoneService);

    TimeZoneService.$inject = ['$http'];

    function TimeZoneService($http) {
        return {
            Read: Read
        };

        function Read() {
            return $http({
                method: 'POST',
                url: 'http://localhost:14168/api/TimeZones',
                headers: { 'Content-Type': 'application/json' }
            });
        }

    }
})();