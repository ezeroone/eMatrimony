(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;

        var service = {
            register: register
        };

        return service;

        function register(profile) {
            $http.post('/api/profile', profile).success(function(data) {
                alert('OK');
            });
        }

    }
})();