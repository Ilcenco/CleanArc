// Generic Functions
function GetData(url, cb) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: `/api/${url}/GetPage`,
        data: { 'pageSize': pageSize, 'pageIndex': pageIndex, 'filter': filter },
        success: function (data) {
            cb(data)
        },
        error: (err) => console.error(err)
    })
}

function getDropDown(id, url, cb) {
    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: `/api/${url}/GetDropDown`,
        success: function (data) {
            cb(data);
        },
        error: (err) => console.error(err)
    })
}

function DeleteData(id,url, cb) {
    $.ajax({
        type: 'DELETE',
        url: `/api/${url}/Delete/` + id,
        dataType: 'JSON',
        success: function (data) {
            cb(data)
        }
    })  
}

function GetByID(id, url, cb) {
    $.ajax({
        type: 'GET',
        url: `/api/${url}/GetById/` + id,
        dataType: 'JSON',
        success: function (data) {
            cb(data);
        },
        error: (err) => console.error(err)
    })
}


// User Service
function updateUser(id) {

    var updCategory = {
        Id: id,
        UserName: $('#userName').val(),
        PhoneNumber: $('#phoneNumber').val(),
        Email: $("#email").val(),
    };
    if (checkUser(updCategory)) {
        $.ajax({
            type: 'PUT',
            dataType: 'JSON',
            data: updCategory,
            url: '/api/users/Update',
            success: function (data) {
                refresh();
            },
            error: (err) => console.error(err)
        })
        //$("form").serializeArray();
    }
}

// Project Service
function createProject() {
    var updateProj = {
        Name: $('#name').val(),
        DepartmentId: $('#departmentDD option:selected').val(),
        CedacriInternationalRUser: $('#userInterDD option:selected').val(),
        CedacriItalyRUser: $('#userItalyDD option:selected').val(),
    };

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        data: updateProj,
        url: '/api/projects/Add',
        success: function(data) {
            refresh();
        },
        error: (err) => console.error(err)
    });
}
function updateProject(id) {
    var updateProj = {
        Id: id,
        Name: $('#name').val(),
        DepartmentId: $('#departmentDD option:selected').val(),
        CedacriInternationalRUser: $('#userInterDD option:selected').val(),
        CedacriItalyRUser: $('#userItalyDD option:selected').val(),
    };
    $.ajax({
        type: 'PUT',
        dataType: 'JSON',
        data: updateProj,
        url: '/api/projects/Update',
        success: function (data) {
            refresh();
        },
        error: (err) => console.error(err)
    })
}

// Check input fields
function checkUser(user) {
    if (user.UserName == "" || user.Email == "") {
        alert("Plese fill required fields");
        return false;
    }
    return true;
}
