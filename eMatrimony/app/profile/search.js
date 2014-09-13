(function () {
    'use strict';

    angular
        .module('app')
        .controller('search', search);

    search.$inject = ['$location', 'datacontext'];

    function search($location, datacontext) {
        /* jshint validthis:true */
        var vm = this;
        vm.profiles = [];
        vm.title = 'search';
        vm.predicate = 'displayName';
        vm.seachText = '';
        activate();

        function activate() {

            datacontext.getProfiles().then(function (res) {
                vm.profiles = res.data;
            });

        }
    }
})();
