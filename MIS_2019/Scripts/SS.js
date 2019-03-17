function AddCriteria(){
	//var MyL=document.all("L");
	alert("Ahmed");
	//document.Form1.T2.value=document.Form1.B.value;
	document.Form1("T").value=document.Form1("B").value;
	document.all("L").add(new Option("Server" + document.all("L").length,1));
}
function RunReport(Dest){
	document.all("txtDest").value=Dest;
	Form1.submit
}

function AddCriteriaLine(){
	var d=[],MyL= new Object,i,FldsT=new Object,Flds=new Object,Crit=new Object,Ops=[],Exist,Line ="",T,V
		MyL=document.all("LstCriteria");
		Flds=document.all("lstFields");
		FldsT=document.all("ddlFields");
		Crit=document.all("txtCriteria");
		if (FldsT.value==""){alert("you must select the field");return;}
		Ops=[">","<"];
		Flds.selectedIndex=FldsT.selectedIndex;
		Ops=Flds.value.split("^^^")[3].split(";");
		//alert(" '"+Ops[0]+"' " + Ops.length);
		//alert(strtrim("   4543534   "));
		if (strtrim(Ops[0]) != ""){
			for (i=0;i<Ops.length;i++){
				if (document.all("ddlOps").value==Ops[i]){Exist=1;}
			}
		}
		else{	Exist=1;
		}
		if (Exist != 1){alert("operator must be " + Ops);return;}
		if (strtrim(document.all("TxtValue").value)=="" && strtrim(document.all("ddlSort").value) == ""){alert("you must enter the value " );return;}
		T=Flds.value.split("^^^")[1]
		V=document.all("TxtValue").value
		if (T=="7"){
			if (Date.parse(V)==NaN){alert("invalid date");return;}
			if(V.indexOf("/")>=0){d=V.split("/")}
			if(V.indexOf("\\")>=0){d=V.split("\\")}
			if(V.indexOf(" ")>=0){d=V.split(" ")}
			if(d[1]>12){alert("invalid date");return;}
		}
		Line=document.all("ddlFields").value +" " + document.all("ddlOps").value +" " + V + " " + document.all("ddlSort").value + " " + document.all("ddlLink").value
		if ((T=="3" || T=="7") && document.all("ddlOps").value=="Like"){alert("Like operator must be used with string fields");return;}
		MyL.add(new Option(Line,1));
		CriteriaCap[CriteriaCap.length]=Line;
		Line=Flds.value.split("^^^")[0] + "^^^" + document.all("ddlOps").value + "^^^" +  document.all("TxtValue").value + "^^^" + document.all("ddlSort").selectedIndex + "^^^" +  document.all("ddlLink").value ;
		Criteria[Criteria.length]=Line;
		document.all("txtValue").value=""
}
function DelCriteriaLine(){
	var MyL= new Object;
	var i
		MyL=document.all("LstCriteria");
		s=MyL.value;
		if (s==""){alert("you must select the criteria line");return}
		i=MyL.selectedIndex
		MyL.remove(MyL.selectedIndex);
		Criteria.splice(i,1);
		CriteriaCap.splice(i,1);
		if (MyL.length>0){
			if (i>0){i=i-1;}
			MyL.selectedIndex=i;
		}
}
function Preview(){
	document.all("txtCriteria").value=Criteria;
}
function strtrim(s) {
return (s.replace(/^\s+/,'')).replace(/\s+$/,'');
}
function RepFldSQL()
{
	var Flds=new Object, FldsT=new Object;
	//alert(Index);
	Flds=document.all("lstFields");
	FldsT=document.all("ddlFields");
	Flds.selectedIndex=FldsT.selectedIndex;
	return(Flds.value.split("^^^")[5]);
}
function OpenSearchList(strField)
{
	var url, retval="",SQL="";
	SQL=RepFldSQL();
	if(SQL!="")
	{
		url='Popuphost.aspx?txtTarget=' + strField + '&SQL=' + SQL + '&Random=' + Math.random();
		//alert(url);
		//window.open(url,'Lookup','resizable=yes')
		//window.open(url,'calendarPopup','width=250,height=190,resizable=yes');
		//alert(strField);
		retval=window.showModalDialog(url,window);
		//alert(strField);
		//alert(retval);
		if(retval!="" && retval!=null)
		{
			document.getElementById(strField).value=retval;
		}
	}
}
function findControl(ControlID)
{ var ret=null;
var aControls = document.getElementsByTagName("input");
if (aControls)
{ for (var i=0; i< aControls.length ; i++)
{
if (aControls[i].id.lastIndexOf(ControlID) == aControls[i].id.length -
ControlID.length &&
aControls[i].id.length != ControlID.length &&
aControls[i].id.lastIndexOf(ControlID) > 0 )
{
ret =aControls[i];
break;
}
}
}
return ret;
}
