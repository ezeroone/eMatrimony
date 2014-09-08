(function () {
    'use strict';
    var controllerId = 'register';
    angular
        .module('app')
        .controller(controllerId, register);

    register.$inject = ['$location', 'common', 'datacontext'];

    function register($location, common, datacontext) {
        /* jshint validthis:true */
        var vm = this;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        var logError = common.logger.getLogFn(controllerId, 'error');
        vm.profile = {};
        vm.title = 'register';
        vm.register = registerProfile;


        activate();

        function registerProfile() {
            datacontext.register(vm.profile).then(function (res) {
                var response = res.data;
                if (response.status)
                    logSuccess('Successfully registered');
                else {
                    logError(response.message);
                }
            });
        }

        function activate() {
        }
    }
})();
