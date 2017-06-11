
/**
 * Created by peymanvalikhanli on 4/17/17 AD.
 */
var ajax = {
    url: ""
    , data: {}
};

ajax.get_data = function (data, callback) {

    if (callback == undefined || callback == null) {
        switch (data.act) {
            case 'login':
                switch (data.Result) {
                    case 'valid':
                        //TODO: set modal message
                        break;
                    case 'login':
                        var url = "index.html"
                        window.location.href = url;
                        window.location = url;
                        break;
                }
                //console.log(data);
                break;
            case 'location':
                var url = data.Result;
                window.location.href = url;
                window.location = url;
                console.log(data.Result);
                break;
            case 'get_user':
                user = data;
                break;
            case 'message':
                message.show(data.msg, data.title, data.type, data.btn);
                break;
            case 'Error':
                console.log(data);
                break;
            default:
                //alert(data);
        }
    } else {
        if (data.act != undefined || data.act != null) {
            switch (data.act) {
                case 'location':
                    var url = data.Result;
                    window.location.href = url;
                    window.location = url;
                    console.log(data.Result);
                    break;
                case 'message':
                    message.show(data.msg, data.title, data.type, data.btn);
                    break;
                case 'Error':
                    console.log(data);
                    break;
            }
        } else {
            callback(data);
        }
    }

};

ajax.sender_data = function (param) {

    var d = new Date();
    var baseUrl = this.url + '?killcatch=' + d.getMilliseconds() + '0' + d.getSeconds();

    var data_request = {};

    if (param != null) {

        var keys_param = Object.keys(param);

        for (i = 0; i < keys_param.length; i++) {
            data_request[keys_param[i]] = param[keys_param[i]];
        }
    }

    $.ajax({
        headers: { 'Access-Control-Allow-Origin': '*' },
        crossDomain: true,
        url: baseUrl,
        //type: 'POST',
        type: 'GET',
        data: data_request,
        statusCode: {
            404: function () {
                message.show("404", "error", "error");
            },
            403: function () {
                message.show("403", "error", "error");
            }
        },
        success: function (data) {
            var dd = JSON.parse(data);
            ajax.get_data(dd);

        },
        error: function () { message.show("AJAX error", "error", "error"); }
    });

};

ajax.getJSON = function (index, url) {
    var JSONdata = '';
    $.getJSON(url, function (data) {
        ajax.data[index] = data;
    });
};

ajax.sender_data_callback = function (param, callback) {

    var d = new Date();
    var baseUrl = this.url + '?killcatch=' + d.getMilliseconds() + '0' + d.getSeconds();

    var data_request = {};

    if (param != null) {

        var keys_param = Object.keys(param);

        for (i = 0; i < keys_param.length; i++) {
            data_request[keys_param[i]] = param[keys_param[i]];
        }
    }

    $.ajax({
        headers: { 'Access-Control-Allow-Origin': '*' },
        crossDomain: true,
        url: baseUrl,
        //type: 'POST',
        type: 'GET',
        data: data_request,
        statusCode: {
            404: function () {
                message.show("404", "error", "error");
            },
            403: function () {
                message.show("403", "error", "error");
            }
        },
        success: function (data) {
            var dd = JSON.parse(data);
            ajax.get_data(dd, callback);

        },
        error: function () { message.show("AJAX error", "error", "error"); }
    });

};


ajax.sender_data_json_by_url_callback = function (url, param, callBack, Method) {
    if (Method == null || Method == undefined) {
        Method = 'GET'
    }
    $.ajax({
        url: url,
        type: Method,
        dataType: "json",
        data: param,
        success: function (data) {            
            ajax.get_data(data, callBack);
        }
    });
}

ajax.cllback_getJSON = function (url, callBack) {
    $.getJSON(url, callBack(data));
}