function ResponseToForm(data, PreFormName) {
    var responseObjectColumn = Object.getOwnPropertyNames(data);
    responseObjectColumn.forEach(function (column) {
        $("input[name='" + PreFormName + column + "']").val(data[column])
    });
}