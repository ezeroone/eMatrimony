(function () {
    'use strict';

    angular
        .module('app')
        .controller('register', register);

    register.$inject = ['$location','datacontext']; 

    function register($location,datacontext) {
        /* jshint validthis:true */
        var vm = this;
        vm.profile = {};
        vm.title = 'register';
        vm.register = registerProfile;

        activate();

        function registerProfile() {
            datacontext.register(vm.profile);
        }

        function activate() {
        }
    }
})();
