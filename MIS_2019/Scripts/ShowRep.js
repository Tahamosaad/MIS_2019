		var Criteria=[];
		var CriteriaCap=[];
		var CritSaved=[]
		
		CritSaved= document.all("txtValue").value.split(";");
		if (CritSaved!=""){
			for(var i=0;i<CritSaved.length;i++){
				for (var J=0;J<document.all("lstFields").length;J++)
				{
					if(document.all("lstFields").options[J].value.split("^^^")[0]==CritSaved[i].split("^^^")[0])
					{
						 document.all("lstFields").selectedIndex=J
					}
				}
				document.all("ddlFields").selectedIndex=document.all("lstFields").selectedIndex;
				document.all("ddlOps").value=CritSaved[i].split("^^^")[1];
				document.all("TxtValue").value=CritSaved[i].split("^^^")[2];
				document.all("ddlSort").listIndex=CritSaved[i].split("^^^")[3];
				document.all("ddlLink").value=CritSaved[i].split("^^^")[4];
				AddCriteriaLine();
			}
		}
	
	function GoReport(){
		//document.all("txtCriteria").value=Criteria;
		//document.all("txtCriteriaCap").value=CriteriaCap;
		//alert(Criteria);
		var url="ViewReport.aspx?Criteria=" + Criteria.join(";") + "&CriteriaCap=" + CriteriaCap +"&ReportID=" + document.all("txtRepID").value + "&Dest=" + document.all("ddlDest").selectedIndex;
		//alert(url);
		//var W=window.open(url, '',"toolbar=0,location=0,directories=0,status=0,menubar=0,left=0,top=0,width=" + screen.width + ",height=" + screen.height-50);//void('');
		//var W=window.open(url, '',"toolbar=0,location=0,directories=0,status=0,menubar=0");//void('');
		var W=window.open(url, '');//void('');
		//var h=W.document.outerhtml
		//W.document.write("<Input Type='
		//alert(W.outerWidth + ",height=" + window.outerHeight)
		//alert(window.innerWidth + ",height=" + window.innerHeight)
		//W.resizeTo(screen.width,screen.height-50)
		//W.moveTo(0,0)

		//,width=" + screen.width + ",height=" + screen.height + "
		//W.
	}
