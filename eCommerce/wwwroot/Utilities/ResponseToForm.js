function ResponseToForm(data, PreFormName) {
    var responseObjectColumn = Object.getOwnPropertyNames(data);
    responseObjectColumn.forEach(function (column) {
        let columnName = column.charAt(0).toUpperCase() + column.slice(1);
        $("input[name='" + PreFormName + columnName + "']").val(data[column])
    });
}