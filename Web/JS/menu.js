	
	
	
	// "muMonitor", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould"
	// "monitor", "muMonitor", "muTechnics", "muQuality", "muProduct", "muReport", "muStorage", "muCollect", "muMaintain", "muOrdermstr", "muBaseinfo", "muSysmould"
	
	function menu(name,muMonitor, muTechnics, muQuality, muProduct, muReport, muStorage, muCollect, muMaintain, muOrdermstr, muBaseinfo, muSysmould,muManHour)
	{
		var titleName   = name;
		var vMonitor    = document.getElementById(muMonitor);
		var vCollect    = document.getElementById(muCollect);
		var vMaintain   = document.getElementById(muMaintain);
		var vOrdermstr  = document.getElementById(muOrdermstr);
		var vProduct    = document.getElementById(muProduct);
		var vTechnics   = document.getElementById(muTechnics);
		var vQuality    = document.getElementById(muQuality);
		var vStorage    = document.getElementById(muStorage);
		var vReport     = document.getElementById(muReport);
		var vBaseinfo   = document.getElementById(muBaseinfo);
		var vSysmould   = document.getElementById(muSysmould);
		var vManHour  =document.getElementById(muManHour);
		if (titleName == "monitor")
		{
			if (vMonitor.style.display == "none")
			{
				if(vMonitor != null)
			        vMonitor.style.display  = "block";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vMonitor.style.display  = "none";
			}
		}
		if (titleName == "collect")
		{
			if (vCollect.style.display == "none")
			{
			    			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "block";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vCollect.style.display  = "none";
			}
		}
		if (titleName == "maintain")
		{
			if (vMaintain.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "block";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vMaintain.style.display = "none";
			}
		}
		if (titleName == "ordermstr")
		{
			if (vOrdermstr.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "block";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vOrdermstr.style.display  = "none";
			}
		}
		if (titleName == "product")
		{
			if (vProduct.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "block";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vProduct.style.display  = "none";
			}
		}
		
		if (titleName == "technics")
		{
			if (vTechnics.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "block";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vTechnics.style.display  = "none";
			}
		}
		
		if (titleName == "quality")
		{
			if (vQuality.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "block";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vQuality.style.display  = "none";
			}
		}
		if (titleName == "storage")
		{
			if (vStorage.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "block";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vStorage.style.display  = "none";
			}
		}
		if (titleName == "report")
		{
			if (vReport.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "block";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vReport.style.display   = "none";
			}
		}
		if (titleName == "baseinfo")
		{
			if (vBaseinfo.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "block";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vBaseinfo.style.display = "none";
			}
		}
		if (titleName == "sysmould")
		{
			if (vSysmould.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "block";
				if(vManHour != null)
				    vManHour.style.display = "none";
			}
			else
			{
				vSysmould.style.display = "none";
			}
		}
		
		if (titleName == "orManHour")
		{
			if (vManHour.style.display == "none")
			{
			
				if(vMonitor != null)
			        vMonitor.style.display  = "none";
			    if(vCollect != null)
			        vCollect.style.display  = "none";
			    if(vMaintain != null)
				    vMaintain.style.display = "none";
				if(vOrdermstr != null)
				    vOrdermstr.style.display= "none";
				if(vProduct != null)
					vProduct.style.display  = "none";
				if(vTechnics != null)
					vTechnics.style.display = "none";
                if(vQuality != null)
                	vQuality.style.display  = "none";
                if(vStorage != null)
				    vStorage.style.display  = "none";
				if(vReport != null)
				    vReport.style.display   = "none";
				if(vBaseinfo != null)
				    vBaseinfo.style.display = "none";
				if(vSysmould != null)
				    vSysmould.style.display = "none";
				if(vManHour != null)
				    vManHour.style.display = "block";
			}
			else
			{
				vManHour.style.display = "none";
			}
		}
	}
	
	
	function ExitSystem()
	{
       if(top!=self)
          top.location.href = self.location.href
	}