var Trans = {};
var Ajax = {};

Ajax.SendRequest = function (Url, CallBackFunc) {
    $.ajax({
        url: Url,
        type: 'GET',
        statusCode: {
            404: function () {
                alert("404");
            },
            403: function () {
                alert("403");
            }
        },
        success: function (data) {
            CallBackFunc(data);

        }
    });
}

Trans.AutoComplete = function () {
    var CompanyInsuranceId = document.getElementById('CompanyInsuranceId').value;
    var PatientName = document.getElementById('PatientName').value;
    var Url = '/Trans/GetCompanyUsers?CompanyInsuranceId=' + CompanyInsuranceId + '&PatientName=' + PatientName;
    Ajax.SendRequest(Url, alert())

}