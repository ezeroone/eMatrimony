(function () {
    'use strict';
    var controllerId = 'register';
    angular
        .module('app')
        .controller(controllerId, register);

    register.$inject = ['$location', 'common', 'datacontext', '$http'];

    function register($location, common, datacontext, $http) {

        var uploadUrl = '/api/profile/files';

        /* jshint validthis:true */
        var vm = this;
        var $q = common.$q;
        var logSuccess = common.logger.getLogFn(controllerId, 'success');
        var logError = common.logger.getLogFn(controllerId, 'error');
        vm.profile = {};
        vm.title = 'register';
        vm.register = registerProfile;
        vm.lookups = [];

        activate();

        function registerProfile() {

            var profileFileInfo = null;
            var horoscopeFileInfo = null;

            var profileFile = vm.profile.profilePicture;
            var horoscopeFile = vm.profile.horoscope;

            var profileUploadFd = new FormData();
            profileUploadFd.append('file', profileFile);

            var profileUploadPromise = $http.post(uploadUrl, profileUploadFd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            }).success(function (rep) {
                profileFileInfo = rep;
                return rep;
            });

            var horoscopeFileUploadFb = new FormData();
            horoscopeFileUploadFb.append('file', horoscopeFile);

            var horoscopeUploadPromise = $http.post(uploadUrl, horoscopeFileUploadFb, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            }).success(function (rep) {
                horoscopeFileInfo = rep;
                return rep;
            });

            var promise = $q.all([profileUploadPromise, horoscopeUploadPromise]);
            promise.then(function () {
                if (profileFileInfo != null) {
                    var profile = profileFileInfo;
                    vm.profile.profileFilePath = profile.fileNames[0];
                    vm.profile.profileFileContentType = profile.contentTypes[0];
                }
                if (horoscopeFileInfo != null) {
                    var horoscope = horoscopeFileInfo;
                    vm.profile.horoscopeFilePath = horoscope.fileNames[0];
                    vm.profile.horoscopeFileContentType = horoscope.contentTypes[0];
                }
                datacontext.register(vm.profile).then(function (res) {
                    var response = res.data;
                    if (response.status)
                        logSuccess('Successfully registered');
                    else {
                        logError(response.message);
                    }
                });
            });
        }

        function activate() {
            return datacontext.getLookups().then(function (res) {
                vm.lookups = res.data;
                return res.data;
            });
        }
    }
})();
