    $(function () {
        $(".dropdown-menu li a").click(function () {
            //alert();
            //console.log($(".dropdown-menu li a option:selected").index())
            var name = $(this).text();
            var obj = { ReportName: name };
            $('#lblTitle span').text(name);
            $('#txtRepID').text();

            AjaxCall('/Report/SetReport', JSON.stringify(obj), 'POST').done(function (response) {
                if (response.length > 0) {
                    $('#ddlFields').html('');
                    var options = '';
                    options += '<option value="Select">Select</option>';
                    for (var i = 0; i < response.length; i++) {
                        options += '<option value="' + response[i] + '">' + response[i] + '</option>';
                    }
                    $('#ddlFields').append(options);

                }
            }).fail(function (error) {
                alert(error.StatusText);
            });
        })

        //AjaxCall('/Report/GetCriteria', null).done(function (response) {
        //    if (response.length > 0) {
        //        $('#ddlFields').html('');
        //        var options = '';
        //        options += '<option value="Select">Select</option>';
        //        for (var i = 0; i < response.length; i++) {
        //            options += '<option value="' + response[i] + '">' + response[i] + '</option>';
        //        }
        //        $('#ddlFields').append(options);

        //    }
        //}).fail(function (error) {alert(error.StatusText);});

        //$('#ddlFields').on("change", function () {
        //    var criteria = $('#ddlFields').val();
        //    var obj = { Criteria: criteria };
        //    AjaxCall('/Report/GetOperation', JSON.stringify(obj), 'POST').done(function (response) {
        //        if (response.length > 0) {
        //            $('#ddlOps').html('');
        //            var options = '';
        //            options += '<option value="Select">Select</option>';
        //            for (var i = 0; i < response.length; i++) {
        //                options += '<option value="' + response[i] + '">' + response[i] + '</option>';
        //            }
        //            $('#ddlOps').append(options);

        //        }
        //    }).fail(function (error) {
        //        alert(error.StatusText);
        //    });
        //});

    });

function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    })
}
