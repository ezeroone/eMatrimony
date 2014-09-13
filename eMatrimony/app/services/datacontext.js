(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;
        var logger = common.logger;

        var service = {
            register: register,
            getProfiles : getProfiles
        };

        return service;

        function register(profile) {
            return $http.post('/api/profile', profile).success(function (res) {
                return $q.when(res);
            });
        }

        function getProfiles() {
            return $http.get('/api/profile').success(function (res) {
                return $q.when(res);
            });
        }

    }
})();