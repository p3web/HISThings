function onSelectableDataTableButton(dataTableId, message) {

    var loopCounter = 0;
    var rows = $('#' + dataTableId).dataTable().fnGetNodes();
    $(rows).each
        (
          function () {
              if ($(this).find(':checkbox').is(":checked") == true) {
                  loopCounter += 1;
              }
          }
        );
    if (loopCounter == 0) {
        warningNotify(message);
        return false;
    }
    return true;
}

function getSelectableRowIds(dataTableId) {
    var idList = new Array();
        var loopCounter = 0;
        //find all the checked checkboxes
        var rows = $('#' + dataTableId).dataTable().fnGetNodes();
        $(rows).each
        (
          function () {
              if ($(this).find(':checkbox').is(":checked") == true) {
                  //fill the array with the values
                  idList[loopCounter] = $(this).find('td:nth-child(2)').text()
                  loopCounter += 1;
              }
          }
        );
        return idList;
}

function selectAllCheckBoxes(dataTableId) {

    var rows = $('#' + dataTableId).dataTable().fnGetNodes();
    var $checkBox = $('#' + dataTableId + ' thead th input[type=checkbox]');

    var checked = $checkBox.is(":checked");
    $(rows).each(function () {
        if (checked) {
            $(this).find(':checkbox').prop("checked", true);
        } else {
            $(this).find(':checkbox').prop("checked", false);
        }
    });
    return true;
}


function ShowModal() {
    $('#modal-container').modal('show');
}

function HideModal() {
    $('#modal-container').modal('hide');
}

function setModalTitle(title) {
    $('.modal .modal-dialog #modal-title').text(title);
}

function showLoading() {
    $("#LoadingImage").show();
    $("#BackPannel").show();
}

function hideLoading() {
    $("#LoadingImage").hide();
    $("#BackPannel").hide();
}

String.prototype.allReplace = function (obj) {
    var retStr = this;
    for (var x in obj) {
        retStr = retStr.replace(new RegExp(x, 'g'), obj[x]);
    }
    return retStr;
};