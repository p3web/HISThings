//------ Global
function sorteBy(elem) {
    var PropertyName = elem.getAttribute('data-name');
    var SortDirection = elem.getAttribute('data-sortDir');
    if (SortDirection == null) {
        SortDirection = 'Ascending';
    }
    if (SortDirection == 'Ascending') {
        elem.setAttribute('data-sortDir', 'Descending');
    } else {
        elem.setAttribute('data-sortDir', 'Ascending');
    }
    Trans.transEntry.gridParam.current['SortedColumns'] = [
        {
            Direction: SortDirection,
            PropertyName: PropertyName

        }
    ]

    ajax.sender_data_json_by_url_callback('/Trans/GetCreatedTransList', Trans.transEntry.gridParam.current , Trans.transEntry.setSearchingData, 'POST');

}
function searchOnserver() {
    var inputs = document.querySelectorAll('#collapsePGrid input:checked');
    var param = {}
    for (var i = 0 ; i < inputs.length ; i++) {
        var key = inputs[i].getAttribute('data-id');
        var value = document.getElementById(key).value;
        param[key] = value;
    }
    param['StartIndex'] = 0;
    param['PageSize'] = 2;
    ///////Temp
    Trans.transEntry.grid.currentPage = 1;
    Trans.transEntry.gridParam.StartIndex = 0;
    ajax.sender_data_json_by_url_callback('/Trans/GetCreatedTransList', param, Trans.transEntry.setSearchingData , 'POST');

}
//_________ Transaction Functions
var Trans = {
    transEntry: {
        grid: {},
        gridParam: {
            first:{},
            current:{}
        }
    }
}

// _____ create and config Grid
Trans.transEntry.setGrid = function () {

    Trans.transEntry.grid = new PSCO_grid('Trans.transEntry.grid');
    Trans.transEntry.grid.RowIDName = 'TransId';
    Trans.transEntry.grid.cols = [
        { name: 'id', thname: 'شناسه', hidden: true, searchMode: 'select' },
        { name: 'CompanyName', thname: 'نام شرکت', hidden: true },
        { name: 'Description', thname: 'توضیحات', hidden: true },
        { name: 'FileNumber', hidden: true },
        { name: 'FormattedTransAmount', hidden: true },
        { name: 'InsuredTypeId', hidden: true },
        { name: 'InsuredTypeTitle', hidden: true },
        { name: 'LetterDate', hidden: true },
        { name: 'LetterNumber', hidden: true },
        { name: 'MainName', thname: 'نام', hidden: false, type: 'text' },
        { name: 'MainNationalCode', thname: 'کدملی بیمار', hidden: false, type: 'text' },
        { name: 'PageCount', hidden: true },
        { name: 'PatientName', thname: 'نام پرسنل', hidden: false, type: '' },
        { name: 'PatientNationalCode', thname: 'کدملی پرسنل', hidden: false, type: 'text' },
        { name: 'RelationId', hidden: true },
        { name: 'RelationTitle', thname: 'نسبت', hidden: false, type: '' },
        { name: 'RowNumber', hidden: true },
        { name: 'TariffCategoryId', hidden: true },
        { name: 'TariffCategoryTitle', thname: '????', hidden: false, type: 'text' },
        { name: 'TransAmount', thname: 'مبلغ', hidden: false, type: 'text' },
        { name: 'TransDate', hidden: true },
        { name: 'TransDateFa', thname: 'تاریخ', hidden: false, type: '' },
        { name: 'TransId', hidden: true }
    ];
    Trans.transEntry.grid.serverSorted = 'sorteBy';
    Trans.transEntry.grid.serverSerch = 'searchOnserver';
    Trans.transEntry.grid.button = [
        { name: 'افزودن', attribute: { name: 'onclick', value: "alert('add')" } },
    ];

    Trans.transEntry.grid.actions = [
        { name: 'delete', ClassName: 'glyphicon glyphicon-remove', attribute: [{ name: 'onclick', value: 'Trans.transEntry.deleteIt(this)' }] }
        // { name: 'edit', ClassName: 'glyphicon glyphicon-edit', attribute: { onclick: 'edit()' } }
    ];

    Trans.transEntry.grid.serverPagingfuncName = 'Trans.transEntry.GoToPage';

    Trans.transEntry.gridParam.first = Trans.transEntry.gridParam.current = {
        StartIndex: 0,
        PageSize: 2,
        //SortedColumns:[
        //    {
        //        Direction: 'Ascending',
        //        PropertyName: 'TransAmount'
        //    }
        //]
    };
    Trans.transEntry.grid.paging_row_count = 2;

    ajax.sender_data_json_by_url_callback('/Trans/GetCreatedTransList', Trans.transEntry.gridParam.first, Trans.transEntry.SetGridData ,'POST');

}
//________ Paging func
Trans.transEntry.GoToPage = function (pageNum) {
    Trans.transEntry.grid.currentPage = pageNum;
    Trans.transEntry.gridParam.current.StartIndex = (pageNum - 1) * Trans.transEntry.gridParam.current.PageSize;
    ajax.sender_data_json_by_url_callback('/Trans/GetCreatedTransList', Trans.transEntry.gridParam.current, Trans.transEntry.setPagingData, 'POST');
}
Trans.transEntry.setPagingData = function (data) {
    Trans.transEntry.grid.create_otherPageRows(data.Items);
}
//_______ search Func
Trans.transEntry.setSearchingData = function (data) {
    Trans.transEntry.grid.serverPaging = data.TotalCount;
    Trans.transEntry.grid.create_otherPageRows(data.Items);
}
// ______ set Grid Data
Trans.transEntry.SetGridData = function (data) {
    Trans.transEntry.grid.data = data.Items;
    Trans.transEntry.grid.serverPaging = data.TotalCount;
    Trans.transEntry.grid.render();
}
//______ DeleteTrans
Trans.transEntry.deleteIt = function (elem) {
    var TransID = Trans.transEntry.grid.get_field_of_row(elem, 'TransId'); // ___ getTrans Id
    ajax.sender_data_json_by_url_callback('/Trans/Delete', { transId: TransID }, console.log, "POST");
}

