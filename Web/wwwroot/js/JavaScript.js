

// Executed every page loaded
$(document).ready(function () {
    adress = window.location.search.split('=')[1];

   
    $("#addNewsForm").submit(function (event) {
        event.preventDefault();

        if ($("#addNewsForm").valid()) {

            var formData = $("#addNewsForm").serializeArray();

            // Push each url parameter to form.A


            $.ajax({
                url: "/news",
                method: "POST",
                data: formData,
                success: function (data) {
                    $('#addmodal').modal('hide');
                    $('#dataTable').DataTable().ajax.reload()
                },
                error: function (xhr, status, error) {
                }
            });
        }

    });

    $("#editNewsForm").submit(function (event) {
        event.preventDefault();

        if ($("#editNewsForm").valid()) {

            var formData = $("#editNewsForm").serializeArray();

            // Push each url parameter to form.A

            var actionURL = $(this).attr('action');

            $.ajax({
                url: actionURL,
                method: "POST",
                data: formData,
                success: function (data) {
                    $('#editmodal').modal('hide');
                    $('#dataTable').DataTable().ajax.reload()
                },
                error: function (xhr, status, error) {
                }
            });
        }

    });

    $("#addProjectForm").submit(function (event) {
        
        $(".urlValueInput").each(function (item) {
            $(this).rules('add', {
                required: true,
                messages: { required: 'Url field is required.' }
            });
        })
        $(".urlTypeDD").each(function (item) {
            $(this).rules('add', {
                required: true,
                messages: { required: 'Choose Url Type' }
            });
        })

        $("#addProjectForm").validate({
            errorPlacement: function (error, element) {
                error.insertAfter(element)
            }
        });

        event.preventDefault();

        if ($("#addProjectForm").valid()) {
            // Get all dynamic elements id
            var ids = [];
            var urlIds = document.getElementById("urlList").children;
            for (var i = 0, len = urlIds.length; i < len; i++) {
                ids.push(urlIds[i].id);
            }

            // Get dynamic elements values using their id
            var urlArray = [];
            for (var i = 0; i < ids.length; i++) {
                if (ids[i].includes("url")) {
                    //console.log($('#Input' + ids[i]).valid());
                    var url = { Url: $('#Input' + ids[i]).val(), UrlTypeId: $('#DD' + ids[i]).val() };
                    urlArray.push(url);
                }
            }
            var formData = $("#addProjectForm").serializeArray();

            // Push each url parameter to form.A
            for (var i = 0; i < urlArray.length; i++) {
                formData.push({ name: "URLs[" + i + "].Url", value: urlArray[i].Url });
                formData.push({ name: "URLs[" + i + "].UrlTypeId", value: urlArray[i].UrlTypeId });
            }

            $.ajax({
                url: "/projects",
                method: "POST",
                data: formData,
                success: function (data) {
                    $('#addmodal').modal('hide');
                    $('#dataTable').DataTable().ajax.reload()
                },
                error: function (xhr, status, error) {
                }
            });
        }

    });
})


$(".modal").on("hidden.bs.modal", function () {
    $(".modal-body").html("");
});




$("#editProjectForm").submit(function (event) {
    $(".urlValueInput").each(function (item) {
        $(this).rules('add', {
            required: true,
            messages: { required: 'Url field is required.' }
        });
    })
    $(".urlTypeDD").each(function (item) {
        $(this).rules('add', {
            required: true,
            messages: { required: 'Choose Url Type' }
        });
    })

    $("#editProjectForm").validate({
        errorPlacement: function (error, element) {
            error.insertAfter(element)
        }
    });
    event.preventDefault();

    if ($("#editProjectForm").valid()) {
        var ids = [];
        var urlIds = document.getElementById("urlList").children;
        for (var i = 0, len = urlIds.length; i < len; i++) {
            ids.push(urlIds[i].id);
        }

        // Get dynamic elements values using their id
        var urlArray = [];
        for (var i = 0; i < ids.length; i++) {
            var url = { Url: $('#Input' + ids[i]).val(), UrlTypeId: $('#DD' + ids[i]).val(), Id: $('#IdInput' + ids[i]).val() };
            urlArray.push(url);
        }
        var formData = $("#editProjectForm").serializeArray();

        // Push each url parameter to form.A
        for (var i = 0; i < urlArray.length; i++) {
            if (urlArray[i].Id == "") {
                formData.push({ name: "URLs[" + i + "].Id", value: null });
            }
            else {
                formData.push({ name: "URLs[" + i + "].Id", value: urlArray[i].Id });

            }
            formData.push({ name: "URLs[" + i + "].Url", value: urlArray[i].Url });
            formData.push({ name: "URLs[" + i + "].UrlTypeId", value: urlArray[i].UrlTypeId });
        }

        var actionURL = $(this).attr('action');
        $.ajax({
            url: actionURL,
            method: "POST",
            data: formData,
            success: function (data) {
                $('#editmodal').modal('hide');
                $('#dataTable').DataTable().ajax.reload()
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    // Get all dynamic elements id
    

});


function CallDeleteModal(id, adress) {
    switch (adress) {
        case "users":
            break;
        case "projects":
            $.ajax({
                type: 'DELETE',
                dataType: 'html',
                url: `/projects/DeleteConfirmation/` + id,
                success: function (data) {
                    $('#delete_text').html(data);
                },
                error: (err) => console.error(err)
            })
            break;
    }
}

function deleteFunc2(id) {
    $.ajax({
        type: 'DELETE',
        url: `/projects/Delete/` + id,
        dataType: 'json',
        success: function (data) {
            cb(data)
        }
    })
}
// edit
function editFunc(id) {
    
    $("#edit_text").html("");
    GetByID(id, adress, function (data) {
        switch (adress) {
            case "users":
                drawUserEditContent(data.responseValue);
                break;
            case "projects":
                drawProjectEditContent(data.responseValue);
        }
    });
}
function checkUserEdit(id) {
    $.ajax({
        type: 'Get',
        url: `/news/CheckUser`,
        success: function (data) {
            userType = data;
            if (data != "Editor") {
                $('#edit_text').html("Please LogIn as Editor to see this content!")
            }
            else {
                editNews(id);
            }
        },
        error: (err) => console.error(err)
    })
}
function editNewsCheck(id) {
    checkUserEdit(id);
}

function editNews(id) {
    $("#edit_text").html("");
    switch (adress) {
        case "news":
            $.ajax({
                type: 'GET',
                dataType: 'html',
                url: `/news/Upsert/` + id,
                success: function (data) {
                    $('#edit_text').html(data);
                },
                error: (err) => console.error(err)
            })
            break;
    }
}

function editFunc1(id) {

    $("#edit_text").html("");
    GetByID(id, adress, function (data) {
        switch (adress) {
            case "users":
                drawUserEditContent(data.responseValue);
                break;
            case "projects":
                $.ajax({
                    type: 'GET',
                    dataType: 'html',
                    url: `/projects/Upsert/` + id,
                    success: function (data) {
                        $('#edit_text').html(data);
                    },
                    error: (err) => console.error(err)
                })
                break;
            case "news":
                debugger;
                $.ajax({
                    type: 'GET',
                    dataType: 'html',
                    url: `/news/Upsert/` + id,
                    success: function (data) {
                        $('#edit_text').html(data);
                    },
                    error: (err) => console.error(err)
                })
                break;
        }
    });
}

function detailsFunc1(id) {

    $("#details_text").html("");
    GetByID(id, adress, function (data) {
        switch (adress) {
            case "users":
                drawUserEditContent(data.responseValue);
                break;
            case "projects":
                $.ajax({
                    type: 'GET',
                    dataType: 'html',
                    url: `/projects/Details/` + id,
                    success: function (data) {
                        $('#details_text').html(data);
                    },
                    error: (err) => console.error(err)
                })
                break;
            case "news":
                $.ajax({
                    type: 'GET',
                    dataType: 'html',
                    url: `/news/Details/` + id,
                    success: function (data) {
                        $('#details_text').html(data);
                    },
                    error: (err) => console.error(err)
                })
                break;
        }
    });
}
function detailsFuncNews(id, isPrivate) {
    checkUserDetails(id, isPrivate)
}

function GetNewsDetails(id) {
    $.ajax({
        type: 'GET',
        dataType: 'html',
        url: `/news/Details/` + id,
        success: function (data) {
            $('#details_text').html(data);
            console.log(userType);
        },
        error: (err) => console.error(err)
    })
}


function checkUserDetails(id, isPrivate) {
    $.ajax({
        type: 'Get',
        url: `/news/CheckUser`,
        success: function (data) {
            userType = data;
            if (data == "Anonim" && isPrivate) {
                $('#details_text').html("Please LogIn to see this content!")
            }
            else {
                GetNewsDetails(id);
            }
        },
        error: (err) => console.error(err)
    })
}


function editFuncNews(id) {
    $.ajax({
        type: 'Post',
        dataType: 'html',
        url: `/api/news/GetEdit/` + id,
        success: function (data) {
            $('#edit_text').html(data);
        },
        error: (err) => console.error(err)
    })
}
// add
function addFunc() {
    $("#add_text").html("");
    switch (adress) {
        case "projects":
            drawProjectCreateContent();
            break;
    }

}
function addFunc1() {
    $.ajax({
        async: true,
        type: 'GET',
        dataType: 'html',
        url: `/projects`,
        success: function (data) {
            $('#add_text').html(data);
        },
        error: (err) => console.error(err)
    })
}


// Changes the items/page number 
$(function () {
    $("#maxRows").change(function () {
    
        pageSize = $("#maxRows option:selected").val();
        pageIndex = 1;
        refresh();
    })
})
// Calls refresh with the input filter
$(function () {
    $("#searchInput").keyup(function () {
        refresh();
    })
})

function filterFunc() {
    var input = document.getElementById("searchInput");
    filter = input.value;
}



//Page Manipulations
function nextPage() {
    pageIndex++;
    if (pageIndex > totalPages) {
        pageIndex = 1;
    }
    refresh();
}

function previousPage() {
    pageIndex--;
    if (pageIndex < 1) {
        pageIndex = totalPages;
    }
    refresh();
}

function SetPage(page) {
    pageIndex = page;
    refresh();
}



// Draw functions
function DrawPageButtons() {
    $('#paginationButtons').append(
        '<button onclick="previousPage()" id="previousButton"><i class="fas fa-arrow-left"></i></button>'
    )
    for (var i = 0; i < totalPages; i++) {
        $('#paginationButtons').append(
            '<button onclick="SetPage('+ (i+1) + ')" " class="'+'page' + (i+1) +'" id="pageButtonItem">' + (i + 1) + '</button>'
        )
        if (pageIndex == i + 1) {

            $(".page" + (1 + i)).css('background-color', 'rgb(52 58 74)');

        }
    }
    $('#paginationButtons').append(
        '<button onclick="nextPage()" id ="nextButton"><i class="fas fa-arrow-right"></i></button>'
    )

}


function DrawTable(data) {
    tableData = data;
    if (maxRows > tableData.length) {
        maxRows = tableData.length;
    }

    var index = 1;
    for (var i = 0; i < data.length; i++) {
        $("#pagedTable").append('<tr id="row"><td>' +
            index++ + '</td >'
        );

        var obj = data[i];
        var cedacriInternational;
        var cedacriItaly;

        for (key in obj) {

            if (key != 'id' && key != 'cedacriInternationalRUser' && key != 'cedacriItalyRUser' && key != 'departmentId') {
                $("#pagedTable tr:last").append('<td>' +
                    obj[key] + "</td >"
                );
            }            
        }

        var id = JSON.stringify(obj.id).replace(/\"/g, "'");

        $("#pagedTable tr:last").append(
            '<td>' +
            '<a id="editBtn" onclick="editFunc1 (' + id + ')" data-toggle="modal" data-target="#exampleModal1"><i class="fas fa-edit"></i>Edit</a></td>' +

            '<td><button id="deleteBtn" onclick="deleteFunc(' + id + ')" ><i class="fas fa-trash-alt"></i>Delete</button ></td>'
        );

    }
}

function drawUserEditContent(data) {
    data = JSON.parse(JSON.stringify(data).replace(/\:null/gi, "\:\"\"")); 
    var userName = JSON.stringify(data.userName).replace(/\"/g, "");
    var email = JSON.stringify(data.email).replace(/\"/g, "");
    var phoneNumber = JSON.stringify(data.phoneNumber).replace(/\"/g, "");
    var id = JSON.stringify(data.id).replace(/\"/g, "'");

    $(".modal-footer").html("");
    $(".modal-title").text("Create new Project");

    $("#popup_text").append(
        '<label for="userName">User name:</label><br>' +
        '<input type = "text" id = "userName" name = "userName" value = "' + userName + '" class="form-control"> <br>' +
        '<label for="email">Email:</label><br>' +
        '<input type = "text" id = "email" name = "email" value = "' + email + '" class="form-control"> <br>' +
        '<label for="phoneNumber">Phone Number:</label><br>' +
        '<input type = "text" id = "phoneNumber" name = "phoneNumber" value = "' + phoneNumber + '" class="form-control"> <br>' +
        '<br>'
        
    );

    $("#popup_buttons").append(
        '<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' +
        '<button type = "button" class= "btn btn-primary" onclick = "updateUser(' + id + ')" > Save changes</button >'
    );
}

function drawProjectCreateContent() {
    $(".modal-footer").html("");
    $(".modal-title").text("Create new Project");

    $("#popup_text").append(
        '<form class="needs-validation" id="test">' +
        '<div class="form-group">' +
            '<label for="name">Project  name:</label><br>' +
            '<input type = "text" id = "name" name = "name" required> <br>' +
        '</div>' +

        '<br>' +
        '<div class="form-group">' +
            '<label for="departmentDD">Department name:</label><br>' +
            '<select class="form-control" name="departmentDD" id="departmentDD" required></select>' +
        '</div>' + 
        '<br>' +

        '<div class="form-group">' +
            '<label for="userInterDD">Internnational resp User name:</label><br>' +
            '<select class="form-control" name="userInterDD" id="userInterDD" required></select>' +
        '</div>' +
        '<br>' +

        '<div class="form-group">' +
            '<label for="userItalyDD">Italy resp User name:</label><br>' +
            '<select class="form-control" name="userItalyDD" id="userItalyDD" required></select>' +
        '</div>' +
        '<button type = "button" class= "btn btn-primary" onclick = "ProjectValidator()" > Save changes</button >'

    );
    $("#popup_buttons").append(
        '<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' 
    );
    
    getDropDown(null, "departments", function (data) {
        appendDataDropDown(data.responseValue, null, "#departmentDD")
    });
    getDropDown(null, "users", function (data) {
        appendDataDropDown(data.responseValue, null, "#userInterDD")
    });
    getDropDown(null, "users", function (data) {
        appendDataDropDown(data.responseValue, null, "#userItalyDD")
    });
}

function drawProjectEditContent(data) {
    $(".modal-footer").html("");
    $(".modal-title").text("Edit existing project")

    data = JSON.parse(JSON.stringify(data).replace(/\:null/gi, "\:\"\""));
    var name = JSON.stringify(data.name).replace(/\"/g, "");
    var departmentName = JSON.stringify(data.departmentName).replace(/\"/g, "");
    var id = JSON.stringify(data.id).replace(/\"/g, "'");
    var department_Id = JSON.stringify(data.departmentId).replace(/\"/g, "'");
    var cedacriInterUserId = JSON.stringify(data.cedacriInternationalRUser).replace(/\"/g, "'");
    var cedacriItalyUserId = JSON.stringify(data.cedacriItalyRUser).replace(/\"/g, "'");
    $("#popup_text").append(
        '<label for="name">Project  name:</label><br>' +
        '<input type = "text" id = "name" name = "name" value = "' + name + '" > <br>' +
        '<br>' +
        '<label for="name">Department name:</label><br>' +
        '<select class="form-control" name="state" id="departmentDD">' +
        '</select>' +
        '<br>' +
        '<label for="name">Internnational resp User name:</label><br>' +
        '<select class="form-control" name="state" id="userInterDD">' +
        '</select>' +
        '<br>' + '<label for="name">Italy resp User name:</label><br>' +
        '<select class="form-control" name="state" id="userItalyDD">' +
        '</select>' 
        //'<br>' +
        //'<a href="#sidenav"><input type="submit" value="Submit" onclick="updateProject(' + id + ')" class="submitBTN"></a>'
    );
    $("#popup_buttons").append(
        '<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' +
        '<button type = "button" class= "btn btn-primary" onclick = "updateProject(' + id + ')" > Save changes</button >'
    );
    getDropDown(department_Id, "departments", function (data) {
        appendDataDropDown(data.responseValue, department_Id, "#departmentDD")
    });
    getDropDown(cedacriInterUserId, "users", function (data) {
        appendDataDropDown(data.responseValue, cedacriInterUserId, "#userInterDD")
    });
    getDropDown(cedacriItalyUserId, "users", function (data) {
        appendDataDropDown(data.responseValue, cedacriItalyUserId, "#userItalyDD")
    });
    
}

function appendDataDropDown(data, idCurrentDep, dropDownId) {
    $(dropDownId).append(
        '<option value="" selected>none</option>'
    )
    console.log(dropDownId + " " +  idCurrentDep);


    for (var i = 0; i < data.length; i++) {
        var name = JSON.stringify(data[i].name).replace(/\"/g, "");
        if (idCurrentDep != null) {
            idCurrentDep = idCurrentDep.replace(/'/g, '');
        }
        var id = JSON.stringify(data[i].id).replace(/\"/g, "");
        if (idCurrentDep == id) {
            $(dropDownId).append(
                '<option value="' + id + '" selected>' + name + '</option>'
            )
        }
        else {
            $(dropDownId).append(
                '<option value="' + id + '">' + name + '</option>'
            )
        }
    }
}

var appendValidationErrors = function () {
    $('[data-valmsg-for]').each(function (index, item) {
        var $currentItem = $(item);
        if (!$currentItem.is(':empty')) {
            var inputId = $currentItem.attr('data-valmsg-for');
            $('#' + inputId).addClass('is-invalid');

            var $span = $('<span>')
                .addClass('is-invalid invalid-feedback')
                .css('display', 'block')
                .attr('id', inputId + '-error')
                .text($currentItem.text());
            $currentItem.empty().append($span);
        }
    });
};
