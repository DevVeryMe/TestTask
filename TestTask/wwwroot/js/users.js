$('#csv-input').change(function () {

    let file = $(this)[0].files[0];

    Papa.parse(file,
        {
            skipEmptyLines: true,
            header: true,
            complete: function(results) {
                console.log("Finished:", results.data);

                createEntries(results.data);
            }
        });
});

function createEntries(model) {
    let url = "CreateMultiple";

    for (let i = 0; i < model.length; i++) {
        model[i].salary = Number(model[i].salary);
        model[i].isMarried = (model[i].isMarried == 'true');
    }

    $.ajax({
        cache: false,
        url: url,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditional: true,
        data: JSON.stringify(model)
    }).done(function (res) {
        console.log("success");
    });
}

function deleteRow(id) {
    let url = "DeleteById/" + id;

    $.ajax({
        url: url,
        type: "DELETE"
    }).done(function (res) {
        console.log("success");
    });
}

$('.delete-row').click(function() {
    $(this).closest('tr').remove();
});

$('#users-table input').change(function() {
    let parentTr = $(this).closest('tr');
    let id = Number(parentTr.find("td:first").html());

    let rowIndex = parentTr.index() + 1;
    let table = document.getElementById('users-table');

    var updateModel = {
        'id': Number(table.rows[rowIndex].cells[0].innerText),
        'name': table.rows[rowIndex].cells[1].firstChild.value,
        'birthDate': table.rows[rowIndex].cells[2].firstChild.value,
        'isMarried': (table.rows[rowIndex].cells[3].firstChild.value == 'True'),
        'phoneNumber': table.rows[rowIndex].cells[4].firstChild.value,
        'salary': Number(table.rows[rowIndex].cells[5].firstChild.value.replace(/,/g, '.'))
    }

    let url = "Update";

    $.ajax({
        cache: false,
        url: url,
        type: "PUT",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        traditional: true,
        data: JSON.stringify(updateModel)
    }).done(function (res) {
        console.log("success");
    });
});
