$.fn.serializeObject = function (preDeleteName) {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (preDeleteName != null)
            this.name=this.name.replace(preDeleteName, "");
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};