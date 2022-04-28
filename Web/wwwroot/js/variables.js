var pageSize = 13;
var pageIndex = 1;
var filter;
var tableData;
var totalPages;
//var global;
var adress;
var urlAdded = 0;
var deleteId;
var userType;

const url = { url: "", projectId: "", urlTypeId: "" };
const urlArray = new Array();

function ResetVariable() {
    pageSize = 13;
    pageIndex = 1;
    filter = null;
    tableData = null;
    totalPages = null;
    //var global;
    adress = null;
    urlAdded = 0;
    deleteId = null;
    userType = null;
}