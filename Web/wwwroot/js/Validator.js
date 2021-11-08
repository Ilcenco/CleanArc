function ProjectValidator() {
    var updateProj = {
        Name: $('#name').val(),
        DepartmentId: $('#departmentDD option:selected').val(),
        CedacriInternationalRUser: $('#userInterDD option:selected').val(),
        CedacriItalyRUser: $('#userItalyDD option:selected').val(),
    };

    var valid = new Boolean(true);

    for (const key in updateProj) {
        if (updateProj[key] == "") {
            valid = false;
        }
    }

    if (valid) {
        createProject();
    }
}
