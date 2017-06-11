var successNotify = function (text) {
    $.Notification.notify('success', 'top left', text)
}

var infoNotify = function (text) {
    $.Notification.notify('info', 'top left', text)
}

var errorNotify = function (text) {
    $.Notification.notify('error', 'top left', text)
}

var warningNotify = function (text) {
    $.Notification.notify('warning', 'top left', text)
}