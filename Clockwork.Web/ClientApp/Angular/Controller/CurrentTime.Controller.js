(function () {
    'use strict';

    angular
        .module('App')
        .controller('CurrentTimeController', CurrentTimeController);

    CurrentTimeController.$inject = ['CurrentTimeService', 'TimeZoneService'];

    function CurrentTimeController(CurrentTimeService, TimeZoneService) {
        /* jshint validthis:true */
        var vm = this;

        vm.CurrentTime = null;
        vm.SelectedBaseUtcOffset = null;
        vm.CurrentTimeQueries = [];
        vm.TimeZones = [];

        vm.GetCurrentTime = GetCurrentTime;
        vm.GetCurrentTimeQueries = GetCurrentTimeQueries;
        vm.PopulateTimeZones = PopulateTimeZones;

        function GetCurrentTime() {
            CurrentTimeService.Read(vm.SelectedBaseUtcOffset)
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

        function PopulateTimeZones() {
            TimeZoneService.Read()
                .then(function (response) {
                    vm.TimeZones = response.data;
                },
                    function (result) {
                        console.log(result);
                    });
        }

    }

})();
