(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;
        var logger = common.logger;

        var service = {
            register: register
        };

        return service;

        function register(profile) {
            return $http.post('/api/profile', profile).success(function(res) {
                return $q.when(res);
            });
        }

    }
})();