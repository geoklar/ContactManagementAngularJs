angular
	.module('contacts.resource.string', [])
	.factory('StringExtensions', [
		function () {
		    "use strict";
		    return {
		        format: function (format, args) {
		            var formatted = format;
		            for (var i = 0; i < args.length; i++) {
		                var regexp = new RegExp('\\{' + i + '\\}', 'gi');
		                formatted = formatted.replace(regexp, args[i]);
		            } return formatted;
		        }
		    };
		}]);
