// JavaScript Document

/**
 * @author Swati Jagtap
 * @date 8 April 2011
 */
/*
 * This functions checks where an entered date is valid or not.
 * It also works for leap year feb 29ths.
 * @year: The Year entered in a date
 * @month: The Month entered in a date
 * @day: The Day entered in a date
 */
 
 // Removes leading whitespaces
function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) {
	
	return LTrim(RTrim(value));
	
}


function capitalizeMe(obj) {
	val = obj.value;
	val = val.toLowerCase(); 
	if(val != "")
	{
		newVal = '';
		val = val.split(' ');
		for(var c=0; c < val.length; c++) {
			if(c == (val.length-1))
			{
				newVal += val[c].substring(0,1).toUpperCase() +
				val[c].substring(1,val[c].length);
			}
			else
			{
				newVal += val[c].substring(0,1).toUpperCase() +
				val[c].substring(1,val[c].length)+' ';
			}
		}
		obj.value = newVal;
	}
}

   function nameValidation(e){
		var key;
		var keychar;
		var reg;
		
		if(window.event) {
		  key = e.keyCode;
		} else if(e.which) {
		  key = e.which;
		} else {
		  return true;
		}
		
		keychar = String.fromCharCode(key);
		if ( (key>=65 &&  key<=90) || (key>=97 &&  key<=122) || (key==8) || (key==127) || (key==32)  || (key==46) || (key==40) || (key==41)) {
		  return true;
		} else {
		  return false;
		}
	}
	
	function blockForTelephoneValueAbstract(e){
		var key;
		  var keychar;
		  var reg;
	
		  if(window.event) {
			  key = e.keyCode;
		  } else if(e.which) {
			  key = e.which;
		  } else {
			  return true;
		  }
	      
		  keychar = String.fromCharCode(key);
		  if ((key>=48 &&  key<=57) || (key==8) || (key==127) || (key==45)  || (key==46)) {
			  return true;
		  } 
		  else
		  {
			  return false;
		  }
	}
	
function blockForTelephoneValueAbstractrating(e){
		var key;
		  var keychar;
		  var reg;
	
		  if(window.event) {
			  key = e.keyCode;
		  } else if(e.which) {
			  key = e.which;
		  } else {
			  return true;
		  }
	
		  keychar = String.fromCharCode(key);
		  if ( (key>=48 &&  key<=53) || (key==8) || (key==127) || (key==45) ) {
			  return true;
		  } else {
			  return false;
		  }
	}

function letternumber(e)
{
	var key;
	var keychar;
	
	if (window.event)
	   key = window.event.keyCode;
	else if (e)
	   key = e.which;
	else
	   return true;
	keychar = String.fromCharCode(key);
	keychar = keychar.toLowerCase();
	
	// control keys
	if ((key==null) || (key==0) || (key==8) || 
		(key==9) || (key==13) || (key==27) )
	   return true;
	
	// alphas and numbers
	else if ((("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789").indexOf(keychar) > -1))
	   return true;
	else
	   return false;
}
function checkForBlank(ids){
	    var data = document.getElementById(ids).value;
		var msg=document.getElementById(ids).getAttribute("errmsg");
	    if(ids=="ssc_grade")
		{
		  document.getElementById('ssc_obtain_marks').className='';
		  document.getElementById('ssc_max_marks').className='';
		  document.getElementById('ssc_percentage').className='';
		  document.getElementById('ssc_grade').className = 'form_item_accepted';
		}
		else if(ids=='ssc_max_marks')
		{
		   document.getElementById('ssc_grade').className='';
		   document.getElementById('ssc_max_marks').className='form_item_accepted';
		
		}
		else
		{	
		   if(data == ''){
				document.getElementById(ids).className = 'form_item_rejected';
			}else{
				document.getElementById(ids).className = 'form_item_accepted';
			}
		}
	}
function checkEmailValidation(ids){
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		var address = document.getElementById(ids).value;
		address = address.toLowerCase(); 
		document.getElementById(ids).value =  address ;
		
		if(reg.test(address) == false) {
			alert('Please enter a valid email address!');
			 var msg='Please enter a valid email address!';
			document.getElementById(ids).className = 'form_item_rejected';
			return false;
		}else{
			document.getElementById(ids).className = 'form_item_accepted';
			return true;
		}
	}
	
function GetRadioButtonValue(id)

        {
            var radio = document.getElementsByName(id);
			var flag=false;

            for (var ii = 0; ii < radio.length; ii++)
            {
                if (radio[ii].checked){
				   flag=true;
				   var chk=radio[ii].value;
				 }
            }
			if(flag){
				return (chk);
				}
			 else return("");	
}

function clearInput(e){ 
		if(e.value=='SECOND LANG')e.value=""; 
		if(e.value=='OTHER SUBJECT 1')e.value=""; 
		if(e.value=='OTHER SUBJECT 2')e.value=""; 
		if(e.value=='OTHER SUBJECT 3')e.value=""; 
		if(e.value=='OTHER SUBJECT 4')e.value=""; 
		if(e.value=='OTHER SUBJECT 5')e.value="";
		if(e.value=='STREAM')e.value="";
  }
  
function disableCtrlKeyCombination(e)
  {
        //list all CTRL + key combinations you want to disable
        var forbiddenKeys = new Array('a', 'n', 'x', 'v', 'j');
        var key;
        var isCtrl;
		
        if(window.event)
        {
                
				key = window.event.keyCode;     //IE
                //alert(key);
				if(window.event.ctrlKey)
                        isCtrl = true;
                else
                        isCtrl = false;
        }
        else
        {
                key = e.which;     //firefox
                if(e.ctrlKey)
                        isCtrl = true;
                else
                        isCtrl = false;
        }
		//if ctrl is pressed check if other key is in forbidenKeys array
        if(isCtrl)
        {
				for(i=0; i<forbiddenKeys.length; i++)
                {
					   //case-insensitive comparation
                        if(forbiddenKeys[i].toLowerCase() == String.fromCharCode(key).toLowerCase())
                        {
                                /*alert('Key combination CTRL' + 
                                        +String.fromCharCode(key)
                                        +' has been disabled.');*/
                                return false;
                        }
                }
        }
        return true;
}

function killEnter(evt)
{
	if(evt.keyCode == 13 || evt.which == 13)
	{
		return false;
	}
	return true;
}		