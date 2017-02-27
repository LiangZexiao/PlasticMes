// JScript 文件

   function lTrim(str)//TRIM掉字串左邊空白   {
      var i0;
      var retstr = "";
      var trimfg = true;
      if (str == null) return "";
      for (i0 = 0;i0 <= str.length-1;i0 ++) 
      {
         if (trimfg) 
         {
            if (str.substr(i0,1) != " ") 
            {
               retstr += str.substr(i0,1);
               trimfg = false;
            }
         } 
         else
         {
            retstr += str.substr(i0,1);
         }
      }
      return retstr;
   }
   function rTrim(str)//TRIM掉字串右邊空白   {
      var i0;
      var retstr = "";
      if (str == null) return "";
      for (i0 = str.length-1;i0 >= 0;i0--)
      {
         if (str.substr(i0,1) != " ") {
            retstr = str.substring(0,i0+1);
            break;
         }
      }
      return retstr;
   }

   function allTrim(str)//TRIM掉字串左右邊空白
   {
      if (str == null) return "";
      return lTrim(rTrim(str));
   }
   
    function isValidateInt(obj)
    {
        var tempStr = allTrim(document.getElementById(obj).value);
        var express = /^\d+$/;
        if(!express.test(tempStr) && tempStr != "")
        {
            if(!window.alert(tempStr + "不对,请输入数字!"))
                return event.returnValue = false;
        }
    }

    function isValidateDec(obj)
    {
	    var tempStr = allTrim(document.getElementById(obj).value);
	    var express = /^\d+(\.\d+)?$/;
	    if(!express.test(tempStr) && tempStr != "")
	    {
		    if(!window.alert(tempStr + "不对,请输入数字!"))
		        return event.returnValue = false;
	    }
    }



