function TryInt(data) {
    return parseInt(data) || 0;
}
function TryFloat(data, digit) {
    if (digit != null)
        return parseFloat(data).toFixed(4);
    return parseFloat(data) || 0.0000;
}
function TryString(data) {
    return (data === data.Trim) ? null : data;
}