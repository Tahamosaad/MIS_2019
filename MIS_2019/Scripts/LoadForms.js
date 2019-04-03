$(".dropdown-menu li a").click(function () {
    //alert();
    //console.log($(".dropdown-menu li a option:selected").index());

    if (document.getElementById('forms').style.display != "none" && this.id > 0)
        //if ( this.id > 0)
    {
        //$("#VoucherNo").text(this.id);
        // now user select report
        $("#main_Image").hide();
        $("#Mytable").show();
        console.log("true" + this.id);
        //console.log($('#idkey').text());
        //var name = $(this).text();
        //var obj = { ReportName: name, ReportId: this.id };//pass repname and id to controller to get ddlfield list
        //$('#lblTitle span').text(name);
        //$('#txtRepID').text();

        //AjaxCall('/Report/SetReport', JSON.stringify(obj), 'POST').done(function (response) {

        //    if (response.Criterialist.length > 0) {
        //        var op_list = '';
        //        $('#ddlFields').html('');
        //        var options = '';
        //        options += '<option value="Select">Select</option>';
        //        for (var i = 0; i < response.Criterialist.length; i++) {
        //            options += '<option value="' + response.Criterialist[i] + '">' + response.Criterialist[i] + '</option>';
        //        }
        //        $('#ddlFields').append(options);
        //        if (response.RepCriteria != "") {
        //            if (Crit.options.length > 0) {
        //                var is_selected = [];
        //                for (var i = 0; i < Crit.options.length; ++i) {
        //                    is_selected[i] = Crit.options[i];
        //                }
        //                i = Crit.options.length;
        //                while (i--) {
        //                    if (is_selected[i]) {
        //                        Crit.remove(i);
        //                    }
        //                }
        //            }
        //            Line = response.RepCriteria_val;
        //            op_list += '<option value="' + Line.trim() + '">' + response.RepCriteria + '</option>';
        //            $('#lstCriteria').append(op_list);//add new criteria to criteria list
        //        }
        //    }
        //}).fail(function (error) {
        //    alert(error.StatusText);
        //});
    }
    
}
);
$(document).ready(function () {
    console.log("am ready");
    $("#Mytable").hide();
});