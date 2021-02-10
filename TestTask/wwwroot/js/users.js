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
        'isMarried': (table.rows[rowIndex].cells[3].firstChild.value.toUpperCase == 'TRUE'),
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

$("#search-input").keyup(function () {
    // Declare variables
    let td, i, txtValue;
    let input = document.getElementById("search-input");
    let filter = input.value.toUpperCase();
    let table = document.getElementById("users-table");
    let tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        let filtered = false;
        let tds = tr[i].getElementsByTagName("td");
        for (let t = 0; t < tds.length-1; t++) {
            let td = tds[t];
            if (td) {
                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                    filtered = true;
                }
            }
        }
        if (filtered === true) {
            tr[i].style.display = '';
        }
        else {
            tr[i].style.display = 'none';
        }
    }
});

function sortTable(n) {
    var rows, switching, i, x, y, shouldSwitch, dir, switchCount = 0;
    var table = document.getElementById("users-table");
    switching = true;

    dir = "asc";

    while (switching) {

        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {

            shouldSwitch = false;

            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];

            if (dir == "asc") {

                let firstValue;
                let secondValue;

                if (n != 5) {
                    firstValue = x.firstChild.value.toLowerCase();
                    secondValue = y.firstChild.value.toLowerCase();
                } else {
                    firstValue = Number(x.firstChild.value.replace(/,/g, '.'));
                    secondValue = Number(y.firstChild.value.replace(/,/g, '.'));
                }

                if (firstValue > secondValue) {

                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {

                let firstValue;
                let secondValue;

                if (n != 5) {
                    firstValue = x.firstChild.value.toLowerCase();
                    secondValue = y.firstChild.value.toLowerCase();
                } else {
                    firstValue = Number(x.firstChild.value.replace(/,/g, '.'));
                    secondValue = Number(y.firstChild.value.replace(/,/g, '.'));
                }

                if (firstValue < secondValue) {

                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {

            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;

            switchCount++;
        } else {

            if (switchCount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}