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

    let json = JSON.stringify(model);

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

    console.log("Finished 2:", model);
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
