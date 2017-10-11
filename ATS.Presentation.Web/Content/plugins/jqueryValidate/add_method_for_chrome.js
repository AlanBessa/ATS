$(function () {
    $.validator.methods.date = function (value, element) {
        //Fix chrom Asp.Net MVC jQuery validation: The field "Myfield" must be a date.
        var ischrom = /chrom(e|ium)/.test(navigator.userAgent.toLowerCase());
        if (ischrom) {
            var bits = value.match(/([0-9]+)/gi), str;
            if (!bits)
                return this.optional(element) || false;
            str = bits[1] + '/' + bits[0] + '/' + bits[2];
            return this.optional(element) || !/Invalid|NaN/.test(new Date(str));
        }
        else {
            return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
        }
    };

});