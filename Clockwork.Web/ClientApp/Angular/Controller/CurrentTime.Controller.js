(function () {
    'use strict';

    angular
        .module('App')
        .controller('CurrentTimeController', CurrentTimeController);

    CurrentTimeController.$inject = ['CurrentTimeService'];

    function CurrentTimeController(CurrentTimeService) {
        /* jshint validthis:true */
        var vm = this;

        vm.CurrentTime = null;
        vm.CurrentTimeQueries = [];

        vm.GetCurrentTime = GetCurrentTime;
        vm.GetCurrentTimeQueries = GetCurrentTimeQueries;

        function GetCurrentTime() {
            CurrentTimeService.Read()
                .then(function (response) {
                    vm.CurrentTime = response.data;
                },
                    function (result) {
                        console.log(result);
                    });
        }

        function GetCurrentTimeQueries() {
            CurrentTimeService.Queries()
                .then(function (response) {
                    vm.CurrentTimeQueries = response.data;
                },
                    function (result) {
                        console.log(result);
                    });
        }
    }

})();
