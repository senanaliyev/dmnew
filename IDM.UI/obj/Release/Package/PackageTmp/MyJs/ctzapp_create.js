$(function () {
    $("#docRegNo").mask("99-99-99-999");
    $("#dfPageCount").mask("999");
    $("#docRegDate").datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $("#docFinishDate").datepicker({
        dateFormat: 'dd/mm/yy'
    });
});

var AddFile = function () {
    //var url = "/InternalDoc/Attachment";
    var mymodal = $('#myModalServAttachFile');
    mymodal.find('.modal-title').text('Yeni sənəd əlavə et');
    //$("#myModalBody").load(url, function () {
    $("#myModalServAttachFile").show();
    //});
};

$(document).ready(function () {

    $("#cityID").empty();
    $("#townID").empty();
    $("#cityID").prop("disabled", true);
    $("#townID").prop("disabled", true);

    $("#countryID").change(function () {
        if ($("#countryID").val() > 0) {
            $("#cityID").prop("disabled", false);
            $.get("/CtzApp/FillCities", { id: $("#countryID").val() }, function (data) {
                $("#cityID").empty();
                $("#townID").empty();
                $("#cityID").append("<option value='0'>Seçin</option>");
                $.each(data, function (index, row) {
                    $("#cityID").append("<option value='" + row.id + "'>" + row.title + "</option>");
                });
            });
        }
        else {
            $("#cityID").empty();
            $("#townID").empty();
            $("#cityID").prop("disabled", true);
            $("#townID").prop("disabled", true);
        }
    });

    $("#cityID").change(function () {
        if ($("#cityID").val() > 0) {
            $("#townID").prop("disabled", false);
            $.get("/CtzApp/FillCities", { id: $("#cityID").val() }, function (data) {
                $("#townID").empty();
                $("#townID").append("<option value='0'>Seçin</option>");
                $.each(data, function (index, row) {
                    $("#townID").append("<option value='" + row.id + "'>" + row.title + "</option>");
                });
            });
        }
        else {
            $("#townID").empty();
            $("#townID").prop("disabled", true);
        }
    });

    var oTable = $("#attachTable").DataTable({
        destroy: true,
        searching: false,
        paging: false,
        "ajax": {
            "url": "/CtzApp/GetAttachedFiles?str=" + $("#dfGUID").val(),
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "dfTitle", "render": function (data, type, row, meta) {
                    return '<a href="/DocumentFiles/' + row.dfName + '" target="_blank">' + row.dfTitle + '</a>';
                }
            },
            { "data": "attFileTypeTitle" },
            { "data": "dfPageCount" },
            {
                "data": "dfID", "width": "50px", "render": function (data) {
                    return '<a href="#" id="' + data + '" class="delete"><i class="fa fa-trash-o"></i></a>';
                }
            }
        ]
    });

    $('#attachTable tbody').on('click', 'tr a.delete', function () {

        $.ajax({
            type: "POST",
            url: "/CtzApp/Delete",
            data: { docid: $(this).attr('id') },
            success: function (success) {
                oTable.ajax.reload();

            }
        });
    });

    $("#btnAttachFile").click(function () {
        var data = new FormData();
        var file = $("#file").get(0).files;
        data.append("Files", file[0]);
        data.append("dfGUID", $("#dfGUID").val());
        data.append("dfTitle", $("#dfTitle").val());
        data.append("attFileTypeID", $("#attFileTypeID").val());
        data.append("dfPageCount", $("#dfPageCount").val());
        data.append("dfContent", $("#dfContent").val());
        $.ajax({
            type: "POST",
            url: "/CtzApp/SaveAttachment",
            contentType: false,
            processData: false,
            data: data,
            success: function (response) {
                $("#myModalServAttachFile").modal('hide');
                oTable.ajax.reload();
            }
        });
    });

});