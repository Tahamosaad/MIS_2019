/// <reference path="C:\Users\taha.mosaad\Documents\Visual Studio 2015\Projects\MIS_2019\MIS_2019\AspNetForms/popuphost.aspx" />
var Crit = document.getElementById('lstCriteria');
var Title = document.getElementById('lblTitle');
var Link = document.getElementById('ddlLink');
var Dest = document.getElementById('ddlDest');
var Sort = document.getElementById('ddlSort');
var Ops = document.getElementById('ddlOps');
var Flds = document.getElementById('lstFields');
var DataField = document.getElementById('ddlFields');
var DataValue = document.getElementById('txtValue');
var Repid = document.getElementById('txtRepID');
var Lan = document.getElementById('Language');
var Line = "";
$("#btnGo").click(function (e) {

    //Line = $("#lstCriteria").val();
    //e.preventDefault();
    if (Line == "") { alert("you must add Criteria"); return; }
    $.ajax({
        type: "POST",
        url: "/Report/ViewReport",
        data: {
            RepTitle: Title.innerText,
            ReportID: Repid.innerText, // < note use of 'this' here
            RepCriteria: Line,
            RepCap: Link.value,
            RepDest: Dest.value,
            RepSort: Sort.value,
            RepLanguage:Lan.innerText
        },
        success: function () {
            window.open("../GenericReportViewer/ShowGenericRpt", 'mywindow', 'fullscreen=yes, scrollbars=auto');
            resetForm($('#form1'));
        },
        error: function (result) {
            alert('error');
        }
    });
});
$(document).ready(function () {
    console.log("am ready");
    $("#table1").hide();
});
$(".dropdown-menu li a").click(function () {
    //alert();
    //console.log($(".dropdown-menu li a option:selected").index());

    if (document.getElementById('form1').style.display != "none" && this.id > 0)
        //if ( this.id > 0)
    {
        $("#txtRepID").text(this.id);
        // now user select report
        $("#main_Image").hide();
        $("#table1").show();
        console.log("true");
        //console.log($('#idkey').text());
        var name = $(this).text();
        var obj = { ReportName: name, ReportId: this.id };//pass repname and id to controller to get ddlfield list
        $('#lblTitle span').text(name);
        $('#txtRepID').text();

        AjaxCall('/Report/SetReport', JSON.stringify(obj), 'POST').done(function (response) {
                
            if (response.Criterialist.length > 0) {
                var op_list = '';
                $('#ddlFields').html('');
                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.Criterialist.length; i++) {
                    options += '<option value="' + response.Criterialist[i] + '">' + response.Criterialist[i] + '</option>';
                }
                $('#ddlFields').append(options);
                if ( response.RepCriteria != "")
                {
                    if (Crit.options.length > 0) {
                        var is_selected = [];
                        for (var i = 0; i < Crit.options.length; ++i) {
                            is_selected[i] = Crit.options[i];
                        }
                        i = Crit.options.length;
                        while (i--) {
                            if (is_selected[i]) {
                                Crit.remove(i);
                            }
                        }
                    }
                    Line = response.RepCriteria_val;
                    op_list += '<option value="' + Line.trim()+ '">' + response.RepCriteria + '</option>';
                    $('#lstCriteria').append(op_list);//add new criteria to criteria list
                }
            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    }
    else {//now you are choose form
        
        console.log("now you are choose" +$(this).context["innerText"])
      

        //change page language 
       
        //if (this.id != null) {
        //    document.getElementById('page2').setAttribute('dir', this.id);
        //    //here we just change page direction but you must change style (CSS) of all html tags (file menuAR.css and menuEN.css already created) 
        //}
        
       

    }

 

});

function resetForm($form) {
    Line = "";
    //$form.find('input:radio, input:checkbox').removeAttr('checked').removeAttr('selected');
}
function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });

}
function AddLine() {
    if (DataValue.value == "" || DataField.selectedIndex <1) { alert("you must select the field"); return; }
    var _Crit = (DataField.value + Ops.value + DataValue.value + Link.value);
    Line = DataField.value.split("^^^")[0] + "^^^" + Ops.value + "^^^" + DataValue.value + "^^^" + Sort.value + "^^^" + Link.value;

    console.log(_Crit);
    console.log(Line);


    var options = "";
    options += '<option value="' + Line.trim() + '">' + _Crit + '</option>';
    $('#lstCriteria').append(options);//add new criteria to criteria list
}

function DelLine() {
    var action_list = Crit;
    if (Crit.value == "") { alert("you must select the criteria line"); return }
    // Remember selected items.
    var is_selected = [];
    for (var i = 0; i < action_list.options.length; ++i) {
        is_selected[i] = action_list.options[i].selected;
    }
    //console.log(Crit.find('option').selectedIndex);
    //console.log(Crit.selectedIndex);
    i = action_list.options.length;
    while (i--) {
        if (is_selected[i]) {
            action_list.remove(i);
        }
    }
    //$('#lstCriteria').remove(Crit.selectedIndex);
}


function OpenSearchList(strField) {
    var url, retval = "", SQL = "";
    SQL = RepFldSQL();
    if (SQL != "") {
        url = 'Popuphost.aspx?txtTarget=' + strField + '&SQL=' + SQL + '&Random=' + Math.random();
        //alert(url);
        //window.open(url,'Lookup','resizable=yes')
        //window.open(url,'calendarPopup','width=250,height=190,resizable=yes');
        //alert(strField);
        retval = window.showModalDialog(url, window);
        //alert(strField);
        //alert(retval);
        if (retval != "" && retval != null) {
            document.getElementById(strField).value = retval;
        }
    }
}
function OpenPopup() {
    var url, retval = '', i, ddl = new Object(), T = new Object(), SQL;
    SQL = "SELECT ItemCode, ItemName, PartNumber From ItemsDirectory ORDER BY ItemsDirectory.ItemCode; SELECT ItemName From ItemsDirectory ORDER BY ItemName; SELECT Cat1Code,Cat1Name From ItemCategory1 ORDER BY Cat1Code; SELECT Cat1Name From ItemCategory1 ORDER BY Cat1Name; SELECT Cat2Code,Cat2Name From ItemCategory2 ORDER BY Cat2Code; SELECT Cat2Name From ItemCategory2 ORDER BY Cat2Name; SELECT Cat3Code,Cat3Name From ItemCategory3 ORDER BY Cat3Code; SELECT Cat3Name From ItemCategory3 ORDER BY Cat3Name; SELECT Cat4Code,Cat4Name From ItemCategory4 ORDER BY Cat4Code; SELECT Cat4Name From ItemCategory4 ORDER BY Cat4Name; SELECT PersonCode As VendCode,PersonName As VendName FROM Persons Where(Active=1 AND PersonType=2) Order By PersonCode; SELECT PartNumber From ItemsDirectory ORDER BY PartNumber; SELECT GroupID, ItemGroup FROM ItemsGroups ORDER BY GroupID; SELECT ManufacturerCode,Manufacturer FROM Manufacturers ORDER BY ManufacturerCode; Select BranchCode, BranchName From BranchCodes Order By BranchCode;";
    ddl = DataField;
    i = ddl.selectedIndex;
    T = DataValue;
    SQL = SQL.split(';')[i];
    if (SQL != '') {

        url = '../AspNetForms/Popuphost.aspx?SQL=' + SQL + '&Random=' + Math.random();
        retval = window.open(url, 'retval', 'fullscreen=yes, scrollbars=auto,location=no,addressbar=no ,toolbar=no,menubar=no,resizable=yes');
        if (retval != '' && retval != null) {
        }
    }
}
function OpenPopup2() {
    $.ajax({
        type: "POST",
        url: "/Report/OpenPopup",
        data: {
            RepTitle: Title.innerText
          
        },
        success: function () {
            
         
        },
        error: function (result) {
            alert('error');
        }
    });
}
function findControl(ControlID) {
    var ret = null;
    var aControls = document.getElementsByTagName("input");
    if (aControls) {
        for (var i = 0; i < aControls.length ; i++) {
            if (aControls[i].id.lastIndexOf(ControlID) == aControls[i].id.length -
            ControlID.length &&
            aControls[i].id.length != ControlID.length &&
            aControls[i].id.lastIndexOf(ControlID) > 0) {
                ret = aControls[i];
                break;
            }
        }
    }
    return ret;
}

