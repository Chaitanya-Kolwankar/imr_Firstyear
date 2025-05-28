// JavaScript Document
function check_email_id(email_value)
{
	var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
   	if(reg.test(email_value) == false) {
		document.getElementById("emailadd").className = "form_item_rejected";
		document.getElementById('error_email_id').className = "requiredfield";
		document.getElementById('error_email_id').innerHTML = 'Please enter a valid email address.';
		document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
   	}
	else
	{
		document.getElementById("emailadd").className = "cm_textfield_white_accepted";
		document.getElementById('error_email_id').className = "";
		document.getElementById('error_email_id').innerHTML = '';
		document.getElementById('emailadd_error').innerHTML='<img src="images/common/icon_accepted.gif" align="absmiddle">';
		
	}
}

function check_email_id_login(email_value)
{
	
	var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
   	if(reg.test(email_value) == false || email_value=="") {
		
		document.getElementById("emailadd").className = "form_item_rejected";
		document.getElementById('error_email_id').className = "requiredfield";
		document.getElementById('error_email_id').innerHTML = 'Please enter a valid email address.';
		document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
   	}
	else 
	{
		
		document.getElementById("emailadd").className = "cm_textfield_white_accepted";
		document.getElementById('error_email_id').className = "";
		document.getElementById('error_email_id').innerHTML = '';
		document.getElementById('emailadd_error').innerHTML='<img src="images/common/icon_accepted.gif" align="absmiddle">';
	}
}

function check_password(password_value)
{
	if((password_value == "Password") || (trim(password_value) == '')) {
		document.getElementById("password").className = "form_item_rejected";
		document.getElementById('error_password').className = "require_red";
		document.getElementById('error_password').innerHTML = 'Please enter your password.';
    } else if((password_value != "Password") || (trim(password_value) != '')) {
		document.getElementById("password").className = "cm_textfield_white_accepted";
		document.getElementById('error_password').className = "";
		document.getElementById('error_password').innerHTML = '';
	}
}
function check_password1(password_value)
{
	if((password_value == "Password") || (trim(password_value) == '')) {
		document.getElementById("epassword").className = "form_item_rejected";
		document.getElementById('error_password').className = "require_red";
		document.getElementById('error_password').innerHTML = 'Please enter your password.';
		document.getElementById('epassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">'
    } else if((password_value != "Password") || (trim(password_value) != '')) {
		document.getElementById("epassword").className = "cm_textfield_white_accepted";
		document.getElementById('error_password').className = "";
		document.getElementById('error_password').innerHTML = '';
		document.getElementById('epassword_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">'
	}
}


//function submitfrmLogin(obj) {
function submitfrmLogin() {
	//var frm = obj;
	var req1 = new XMLHttpRequest();
	var email_id_val = document.getElementById('emailadd').value;
	alert(email_id_val);
	var password_val = document.getElementById('password').value;
	alert(password_val);
	var err = 0;
	var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
   	if(reg.test(email_id_val) == false) {
		document.getElementById("emailadd").className = "form_item_rejected";
		document.getElementById('error_email_id').className = "requiredfield";
		document.getElementById('error_email_id').innerHTML = 'Please enter a valid email address.'+'<br>';
		err = 1;
   	}
	else
	{
		document.getElementById("emailadd").className = "cm_textfield_white_accepted";
		document.getElementById('error_email_id').className = "";
		document.getElementById('error_email_id').innerHTML = '';
	}
	
	if((password_val == "Password") || (trim(password_val) == '')) {
		document.getElementById("password").className = "form_item_rejected";
		document.getElementById('error_password').className = "requiredfield";
		document.getElementById('error_password').innerHTML = 'Please enter your password.';
		err = 1;
    } else if((password_val != "Password") && (trim(password_val) != '')) {
		document.getElementById("password").className = "cm_textfield_white_accepted";
		document.getElementById('error_password').className = "";
		document.getElementById('error_password').innerHTML = '';
	}
	
	if(err)
	{
		return false;
	}
	else
	{
		return true;
	}
	
	/*req1.onreadystatechange = function ()
    {
		if (req1.readyState == 4) {
			if (req1.status == 200) {  //alert(req1.responseText);return false;
				var respose_text_val = trim(req1.responseText);
				if(respose_text_val == 1) {
					document.getElementById("password").className = "form_item_rejected";
					document.getElementById('loginpwd_error').className = "requiredfield";
					document.getElementById('loginpwd_error').innerHTML = 'Password is incorrect';
					document.getElementById('loginid_error').className = "he10";
					document.getElementById('loginid_error').innerHTML = '';
					document.getElementById("emailadd").className = "cm_textfield_white_accepted";
					document.getElementById("password").value = "";
					setfocus(frm.password);
				} else if(respose_text_val == 2) {
					document.getElementById("emailadd").className = "form_item_rejected";
					document.getElementById('loginid_error').className = "requiredfield";
					document.getElementById('loginid_error').innerHTML = 'Incorrect email id';
					document.getElementById('loginpwd_error').className = "he10";
					document.getElementById('loginpwd_error').innerHTML = '';
					document.getElementById("password").className = "form_item_rejected";
					setfocus(frm.emailadd);
				} else {
					
					alert(req1.responseText);return false;
					alert("Meaw Meaw");return false
					frm.submit();
				}
			}
		}
	}
	var pars = "emailadd=" + escape(frm.emailadd.value) + "&password=" + escape(frm.password.value) + "&action=passwordcheck";
	req1.open("GET", "student_login_process.php?" + pars, true);
	req1.send("");
    return false;*/
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
		if ( (key>=65 &&  key<=90) || (key>=97 &&  key<=122) || (key==8) || (key==127) || (key==32) ) {
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
		  if ( (key>=48 &&  key<=57) || (key==8) || (key==127) || (key==45) ) {
			  return true;
		  } else {
			  return false;
		  }
	}
	
	function checkEmailValidation(ids){
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		var address = document.getElementById(ids).value;
		if(reg.test(address) == false) {
			//alert('Please enter a valid email address!');
			document.getElementById(ids+'_error_msg').innerHTML = 'Please enter valid email address';
			document.getElementById(ids).className = 'form_item_rejected';
			if (document.getElementById(ids+'_error')) document.getElementById(ids+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			//document.register_student.Email.focus();
			return false;
		}else{
			document.getElementById(ids+'_error_msg').innerHTML = '';
			document.getElementById(ids).className = 'cm_textfield_white_accepted';
			document.getElementById(ids+'_error').innerHTML = '<img src="images/icon_accepted.gif" align="absmiddle">';
			return true;
		}
	}
	
	function checkVerifyPassword(data){
		var password = document.getElementById('Password').value;
		var verify_password = data;//document.getElementById('instVerifyPassword');
		if(password !== verify_password){
			document.getElementById('VerifyPassword').className = 'form_item_rejected';
			if (document.getElementById('VerifyPassword_error')) 
			{
				document.getElementById('VerifyPassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
				document.getElementById('VerifyPassword_error_msg').innerHTML = 'Password doesn\'t match';
			}
		}else{
			document.getElementById('VerifyPassword_error_msg').innerHTML = '';
			document.getElementById('VerifyPassword').className = 'cm_textfield_white_accepted';
			document.getElementById('VerifyPassword_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
		}
	}


function checkmobileExsist(str)
	{
			
			var strval = document.getElementById(str).value;
			if (strval=="")
			{
			  	document.getElementById(str+"_error_msg").innerHTML="Please enter Mobile";
			  	document.getElementById(str).className = 'form_item_rejected';
				return false;  
			} 
			if (window.XMLHttpRequest)
			  {// code for IE7+, Firefox, Chrome, Opera, Safari
			  xmlhttp=new XMLHttpRequest();
			  }
			else
			  {// code for IE6, IE5
			  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
			  }
			xmlhttp.onreadystatechange=function()
			  {
			  if (xmlhttp.readyState==4 && xmlhttp.status==200)
				{ 
					if(xmlhttp.responseText=='fail'){
						alert('YOU HAVE ALREADY APPLIED TO ITM ONCE, KINDLY CONTACT THE INFORMATION CENTRE ON 1800 209 9727 TO PROCEED FURTHER')
						document.getElementById(str+'_error_msg').innerHTML = '';
						document.getElementById(str).className = 'form_item_rejected';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						document.getElementById('mobileExist').value = 1;
						document.getElementById(str).value = '';
					}
					if(xmlhttp.responseText=='success'){
						document.getElementById(str+'_error_msg').innerHTML = '';
						document.getElementById(str).className = 'cm_textfield_white_accepted';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle"> ';
						document.getElementById('mobileExist').value = 0;
						
					}
				}
			  }
			xmlhttp.open("GET","check_mobile_exsistant.php?q="+strval,true);
			xmlhttp.send();
		}

	



	function submitUserAllData(){
		var name_val = document.getElementById('name').value;
		var Email_val = document.getElementById('Email').value;
		var Password_val = document.getElementById('Password').value;
		var VerifyPassword_val = document.getElementById('VerifyPassword').value;
		var security_code_val = document.getElementById('security_code').value;
		var cellphone_val = document.getElementById('cellphone').value;
		var emailExist = document.getElementById('emailExist').value;
		var mobileExist = document.getElementById('mobileExist').value;
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		
		var error_value = 0;
		if(name_val == "")
		{
			document.getElementById('name').className = 'form_item_rejected';
			document.getElementById('name_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('name_error_msg').innerHTML="Please enter your full name";
			error_value = 1;
		}
		else
		{
			document.getElementById('name_error_msg').innerHTML = '';
			document.getElementById('name').className = 'cm_textfield_white_accepted';
			document.getElementById('name_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
		}
		
		if(Password_val == "")
		{
			document.getElementById('Password').className = 'form_item_rejected';
			document.getElementById('Password_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('Password_error_msg').innerHTML="Please enter password";
			error_value = 1;
		}
		else
		{
			document.getElementById('Password_error_msg').innerHTML = '';
			document.getElementById('Password').className = 'cm_textfield_white_accepted';
			document.getElementById('Password_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
		}
		
		if(Email_val == "" || (reg.test(Email_val) == false) )
		{
			document.getElementById('Email').className = 'form_item_rejected';
			document.getElementById('Email_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('Email_error_msg').innerHTML="Please enter valid email address";
			error_value = 1;
		}
		else
		{
			if(Email_val != "")
			{
					
					if(emailExist==1)
					{
						error_value = 1;
						document.getElementById('Email').className = 'form_item_rejected';
						document.getElementById('Email_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						document.getElementById('Email_error_msg').innerHTML="Email already registered with us";
					}
				
			}
		}
		
		if(VerifyPassword_val == "")
		{
			document.getElementById('VerifyPassword').className = 'form_item_rejected';
			document.getElementById('VerifyPassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('VerifyPassword_error_msg').innerHTML="Please confirm password";
			error_value = 1;
		}
		else
		{
			if(VerifyPassword_val != Password_val)
			{
				document.getElementById('VerifyPassword').className = 'form_item_rejected';
				document.getElementById('VerifyPassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
				document.getElementById('VerifyPassword_error_msg').innerHTML="Please confirm password";
				error_value = 1;
			}
			else
			{
				document.getElementById('VerifyPassword_error_msg').innerHTML = '';
				document.getElementById('VerifyPassword').className = 'cm_textfield_white_accepted';
				document.getElementById('VerifyPassword_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
			}
		}
		if(cellphone_val == "")
		{
			document.getElementById('cellphone').className = 'form_item_rejected';
			document.getElementById('cellphone_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('cellphone_error_msg').innerHTML="Please enter valid mobile number";
			error_value = 1;
		}
		else
		{
			if(cellphone_val.length < 10)
			{
				document.getElementById('cellphone').className = 'form_item_rejected';
				document.getElementById('cellphone_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
				document.getElementById('cellphone_error_msg').innerHTML="Please enter valid mobile number";
				error_value = 1;
			}
			else
			{
				document.getElementById('cellphone_error_msg').innerHTML = '';
				document.getElementById('cellphone').className = 'cm_textfield_white_accepted';
				document.getElementById('cellphone_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
			}
		}
		
		if(cellphone_val != "")
			{ 
					
					
					if(mobileExist==1)
					{
						error_value = 1;
						document.getElementById('cellphone').className = 'form_item_rejected';
						document.getElementById('cellphone_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						document.getElementById('cellphone_error_msg').innerHTML="Mobile already exists";
					}

			}
		
		if(security_code_val == "")
		{
			document.getElementById('security_code').className = 'form_item_rejected';
			document.getElementById('security_code_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.getElementById('security_code_error_msg').innerHTML="Please enter security code";
			error_value = 1;
		}
		else
		{
			if(security_code_val != "")
			{
				if (window.XMLHttpRequest)
				{// code for IE7+, Firefox, Chrome, Opera, Safari
					xmlhttp=new XMLHttpRequest();
				}
				else
				{// code for IE6, IE5
					xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
				}
				xmlhttp.onreadystatechange=function()
				{
					if (xmlhttp.readyState==4 && xmlhttp.status==200)
					{ 
					    //alert(xmlhttp.responseText);   
						if(xmlhttp.responseText=='fail'){	
							document.getElementById('security_code').className = 'form_item_rejected';
							document.getElementById('security_code_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
							document.getElementById('security_code_error_msg').innerHTML = 'Type the characters you see in the picture';
							error_value = 1;
						}
						if(xmlhttp.responseText=='success'){
							document.getElementById('security_code').className = 'cm_textfield_white_accepted';
							document.getElementById('security_code_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
							document.getElementById('security_code_error_msg').innerHTML = '';
						}
					}
				}
				xmlhttp.open("GET","student_xaviers_registration_process.php?imageTXT="+security_code_val+"&action=checkCaptchaImage",true);
				xmlhttp.send();
			}
		}
		if(error_value == 1)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	
	
	function submitAllData(frmNm,captchaval){
		var obj = frmNm;
		var frmLength = obj.length;
		var fldnam;
		var frm ;
		var err = 0;
		var errMsg = '';
		var spc = "&nbsp;&nbsp;&nbsp;&nbsp;";
		var numb = 1;
		var comp = 0;
		var totreq = 0;
		var pending = 0;
		var progressbar;
		var total_obtain_marks1=0;
		var total_maxx_marks1=0;
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		for(var i=0; i<frmLength-1; i++){
				fldnam = obj.elements[i].id;
				frmAttrVal = document.getElementById(fldnam).getAttribute("required");
				frmVal = document.getElementById(fldnam).value;
				
				if(frmAttrVal == "true"){ totreq++; }
				
				if((obj.elements[i].value == '' && frmAttrVal == "true")){
					document.getElementById(fldnam).className = 'form_item_rejected';
					if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					if(fldnam=="name"){
										
						document.getElementById(fldnam+'_error_msg').innerHTML="Please enter Your Name";
						
					}else if(fldnam=="Email"){
						document.getElementById(fldnam+'_error_msg').innerHTML="Please enter valid email address";
					}
					else if(fldnam=="cellphone"){
						document.getElementById(fldnam+'_error_msg').innerHTML="Please enter valid Cell Phone";
					}
					else if(fldnam=="Password"){
						document.getElementById(fldnam+'_error_msg').innerHTML="Password must contain atleast 4 characters";
					}
					else if(fldnam=="VerifyPassword"){
						document.getElementById(fldnam+'_error_msg').innerHTML="Please enter confirm password";
					}
										
					else if(fldnam=="security_code"){
						document.getElementById(fldnam+'_error_msg').innerHTML="Please enter security code";
					}
					
					errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
					numb++;
					err = 1;
				} else if(obj.elements[i].value != '' && frmAttrVal == "true"){
					if(fldnam=="name"){
						document.getElementById(fldnam+'_error_msg').innerHTML="";
					}else if(fldnam=="Email"){
						document.getElementById(fldnam+'_error_msg').innerHTML="";
					}else if(fldnam=="Password"){
						document.getElementById(fldnam+'_error_msg').innerHTML="";
					}
					else if(fldnam=="VerifyPassword"){
						document.getElementById(fldnam+'_error_msg').innerHTML="";
					}
					if(obj.elements[i].value != '' && frmAttrVal == "true" && fldnam=='security_code'){
						if (window.XMLHttpRequest)
						  {// code for IE7+, Firefox, Chrome, Opera, Safari
						  xmlhttp=new XMLHttpRequest();
						  }
						else
						  {// code for IE6, IE5
						  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
						  }
						xmlhttp.onreadystatechange=function()
						  {
						  if (xmlhttp.readyState==4 && xmlhttp.status==200)
							{ 
								if(xmlhttp.responseText=='fail'){	
									document.getElementById('security_code').className = 'form_item_rejected';
									document.getElementById('security_code_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
									document.getElementById('security_code_error_msg').innerHTML = '';
								}
								if(xmlhttp.responseText=='success'){
									document.getElementById('security_code').className = 'cm_textfield_white_accepted';
									document.getElementById('security_code_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
									document.getElementById('security_code_error_msg').innerHTML = '';
									
								}
							}
						  }
						xmlhttp.open("GET","student_registration_process.php?imageTXT="+obj.elements[i].value+"&action=checkCaptchaImage",true);
						xmlhttp.send();
					}else if(obj.elements[i].value != '' && frmAttrVal == "true" && fldnam=='Email'){
						
						
						
						if (window.XMLHttpRequest)
						  {// code for IE7+, Firefox, Chrome, Opera, Safari
						  xmlhttp=new XMLHttpRequest();
						  }
						else
						  {// code for IE6, IE5
						  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
						  }
						xmlhttp.onreadystatechange=function()
						  {
						  if (xmlhttp.readyState==4 && xmlhttp.status==200)
							{ 
								if(xmlhttp.responseText=='fail'){	
									document.getElementById('Email_error_msg').innerHTML = '';
									document.getElementById('Email').className = 'form_item_rejected';
									document.getElementById('Email_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">Email already registered with us';
									err = 1;
								}
								if(xmlhttp.responseText=='success'){
									//document.getElementById('Email_error_msg').innerHTML = '';
									//document.getElementById('Email_error_msg').innerHTML = 'Email available';
									document.getElementById('Email').className = 'cm_textfield_white_accepted';
									document.getElementById('Email_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
								}
							}
						  }
						xmlhttp.open("GET","check_email_exsistant.php?q="+obj.elements[i].value,true);
						xmlhttp.send();
						
						
						
						
						
						
						/*document.getElementById(fldnam).className = 'form_item_rejected';
						if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
						numb++;*/
						
						
					}else{
						document.getElementById(fldnam).className = 'cm_textfield_white_accepted';
						document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
						comp++;
					}
				}
		}
		
		if(err == 1){
            //document.getElementById('show_error').style.display = 'block';
            //document.getElementById('show_error_list').className = "requiredfield";
           // document.getElementById('show_error_list').innerHTML = spc+errMsg;
            //document.location.href = "institute_registration.php#errmsg";
            return false;
        } else { 
			obj.submit();
		}
	}
	
	function CheckNotEmptyValidation(attrId){
		
		var fieldValue = document.getElementById(attrId).value;
		 if(fieldValue ==''){
			document.getElementById(attrId).className = 'form_item_rejected';

			if (document.getElementById(attrId+'_error')) 
			{
				//alert(attrId);
				document.getElementById(attrId+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
				if(attrId == "password")
				{
					document.getElementById(attrId+'_error_msg').innerHTML = 'Please enter password';
				}
				else if(attrId == "name")
				{
					document.getElementById(attrId+'_error_msg').innerHTML = 'Please enter name';
				}
				else if(attrId == "security_code")
				{
					document.getElementById(attrId+'_error_msg').innerHTML = 'Type the characters you see in the picture';
				}
				
				
				//else if(attrId == "password")
			}
		}else{
			document.getElementById(attrId+'_error_msg').innerHTML = '';
			document.getElementById(attrId).className = 'cm_textfield_white_accepted';
			document.getElementById(attrId+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
		}
	}
	
	function checkEmailExsist(str)
	{
		var result = checkEmailValidation(str);	
		if(result==true){
			
			var strval = document.getElementById(str).value;
			//alert(strval)
			if (strval=="")
			  {
			  document.getElementById(str+"_error").innerHTML="Please enter email address";
			  return;
			  } 
			if (window.XMLHttpRequest)
			  {// code for IE7+, Firefox, Chrome, Opera, Safari
			  xmlhttp=new XMLHttpRequest();
			  }
			else
			  {// code for IE6, IE5
			  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
			  }
			xmlhttp.onreadystatechange=function()
			  {
			  if (xmlhttp.readyState==4 && xmlhttp.status==200)
				{ 
					//alert(xmlhttp.responseText);
					if(xmlhttp.responseText=='fail'){	
						document.getElementById(str+'_error_msg').innerHTML = 'Email already registered with us';
						document.getElementById(str).className = 'form_item_rejected';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						document.getElementById('emailExist').value = 1;
					}
					if(xmlhttp.responseText=='success'){
						document.getElementById(str+'_error_msg').innerHTML = '';
						document.getElementById(str).className = 'cm_textfield_white_accepted';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
						document.getElementById(str+'_error_msg').className = "requiredfield";
						document.getElementById(str+'_error_msg').innerHTML = 'Email available';
						document.getElementById('emailExist').value = 0;
						
					}
				}
			  }
			xmlhttp.open("GET","check_email_exsistant.php?q="+strval,true);
			xmlhttp.send();
		}
	}
	
	function openLogin(){
		document.getElementById('login_box').style.display = 'block';
	}
	
	function validateEmail(val){
	
	if(val != ''){
		var tfld = val;// value of field with whitespace trimmed off
	    var email = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		//alert(email.test(tfld));
		   if (!email.test(tfld)) {
				document.getElementById('emailadd').className = "form_item_rejected";
				document.getElementById('username_error').className = "requiredfield";
				document.getElementById('emailadd_error').innerHTML="<img src='images/common/icon_rejected.gif' align='absmiddle'>";
				document.getElementById('username_error').innerHTML = " Invalid email address";
		   } else {
			   //alert('in else');
			   document.getElementById('username_error').style.display = "none";
			   document.getElementById('emailadd').className = "cm_textfield_white_accepted"
			   document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
		   }
		}
	}

	function validateLogin(chek){

	var val = document.getElementById('emailadd').value;
    var tfld = val;  // value of field with whitespace trimmed off
		//var pass = document.getElementById('fauxPassword').value;
	    var email = /^[^@]+@[^@.]+\.[^@]*\w\w$/
	   	if (email.test(tfld)) {
			
			var frm = document.studentFrmLogin;
			var req1 = new XMLHttpRequest();
		
			req1.onreadystatechange = function ()
			{
				if (req1.readyState == 4) {
					if (req1.status == 200) { 
					alert(req1.responseText);
						if(req1.responseText!="") { 
							if(req1.responseText == 1 ) {
								
								//document.getElementById('pwd_assist').style.display = 'none';
								document.getElementById('emailadd').className = "cm_textfield_white_accepted";
								document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
							}else if(req1.responseText == 0){ 
							
								document.getElementById('pwd_assist').className = "requiredfield"
								document.getElementById('pwd_assist').style.display = 'block';
								document.getElementById('pwd_assist').innerHTML = 'Email is not registered';
								document.getElementById('emailadd').className = "form_item_rejected";
							
								document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
							}else if((req1.responseText != "") && req1.responseText != 0 && chek == '2'){
							
								frm.submit();
							}
						} 
					} /*else {
						alert("Error: while trying to login to applicants login here, please try again");
					}*/
				}
			}
			var pars = "emailadd=" + escape(frm.emailadd.value) +  "&action=logincheck" ;
			req1.open("GET", "student_registration_process.php?" + pars, true);
			req1.send("");
		} else {
			document.getElementById('pwd_assist').className = "requiredfield";
			document.getElementById('pwd_assist').style.display = "block";
			document.getElementById('pwd_assist').innerHTML = "Invalid email address";
		}
	}
	
	function onFocusHandler_p(fld){
		document.getElementById('fauxPassword_error').style.display='none';
		fld.style.display = 'none';
		var fld2 = (document.getElementById) ? document.getElementById('password') : document.all['password'];
		fld2.style.display = 'block';
		fld2.focus();
		return true;
	}
	
	function onBlurHandler_p(fld){
		if(fld.value === ''){
			fld.style.display = 'none';
			var fld2 = (document.getElementById) ? document.getElementById('fauxPassword') : document.all['fauxPassword'];
			fld2.style.display = 'block';
		}
		return true;
	}
	
	// Function for checking correct email id and password
	function validateLoginPassword(){
		var val = document.getElementById('emailadd').value;
		var tfld = val;  // value of field with whitespace trimmed off
		//document.getElementById('pwd_assist').style.display = 'none';
		var passval = document.getElementById('password').value;
		var passtfld = passval;
			var frm = document.instFrmLogin;
			var req1 = new XMLHttpRequest();
			req1.onreadystatechange = function ()
			{
				if (req1.readyState == 4) {
					if (req1.status == 200) {
						if(req1.responseText!="") { ///alert(req1.responseText);
							if(req1.responseText == 0 ) {
								
								document.getElementById('pwd_assist').className = "requiredfield"
								document.getElementById('pwd_assist').style.display = 'block';
								document.getElementById('pwd_assist').innerHTML = 'User name or password wrong.';
								document.getElementById('emailadd').className = "form_item_rejected";
								document.getElementById('passwd_sent').style.display = 'none';
							} else if((req1.responseText != "") && req1.responseText == 1){
								frm.submit();
							}
						} 
					} /*else {
						alert("Error: while trying to login to applicants login here, please try again");
					}*/
				}
			}
			var pars = "emailadd=" +tfld + "&password=" + passtfld + "&action=passwordcheck" ;
			req1.open("GET", "institute_registration_process.php?" + pars, true);
			req1.send("");
		
	}
	
	function checkEmailExsistForForgotPassword(str)
	{
		
		//var result = checkEmailValidation(str);
		
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		var address = document.getElementById(str).value;
		if(reg.test(address) == false) {
			//alert('Please enter a valid email address!');
			document.getElementById(str).className = 'form_item_rejected';
			document.getElementById("email_msg").innerHTML="Please enter a valid email address";
			if (document.getElementById(str+'_error')) document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
			document.form1.email.focus();
			var result = false;
		}else{
			//document.getElementById(ids).className = 'cm_textfield_white_accepted';
			//document.getElementById(ids+'_error').innerHTML = '<img src="images/icon_accepted.gif" align="absmiddle">';
			var result = true;
		}
		if(result==true){
		
			var strval = document.getElementById(str).value;
			
			if (strval=="")
			  {
			  document.getElementById(str+"_error").innerHTML="Please enter email address";
			  return;
			  } 
			if (window.XMLHttpRequest)
			  {// code for IE7+, Firefox, Chrome, Opera, Safari
			  xmlhttp=new XMLHttpRequest();
			  }
			else
			  {// code for IE6, IE5
			  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
			  }
			xmlhttp.onreadystatechange=function()
			  {
			  if (xmlhttp.readyState==4 && xmlhttp.status==200)
				{ //alert(xmlhttp.responseText);
					if(xmlhttp.responseText=='fail'){	
						document.getElementById(str).className = 'cm_textfield_white_accepted';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
					}
					if(xmlhttp.responseText=='success'){
						document.getElementById(str).className = 'form_item_rejected';
						document.getElementById(str+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
						 document.getElementById("email_msg").innerHTML="Email does not exists";
					}
				}
			  }
			xmlhttp.open("GET","check_email_exsistant.php?q="+strval,true);
			xmlhttp.send();
		}
	}
	
	function submitfrmLogin(frmNm){
		var obj = frmNm;
		var frmLength = obj.length;
		var fldnam;
		var frm ;
		var err = 0;
		var errMsg = '';
		var spc = "&nbsp;&nbsp;&nbsp;&nbsp;";
		var numb = 1;
		var comp = 0;
		var totreq = 0;
		var pending = 0;
		var progressbar;
		var total_obtain_marks1=0;
		var total_maxx_marks1=0;
		var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
		//alert(frmLength);
		for(var i=0; i<frmLength-1; i++){
				fldnam = obj.elements[i].id;
				//alert(fldnam);
				frmAttrVal = document.getElementById(fldnam).getAttribute("required");
				frmVal = document.getElementById(fldnam).value;
				if(frmAttrVal == "true"){ totreq++; }
				//alert(obj.elements[i].value);
				if((obj.elements[i].value == '' ) && frmAttrVal == "true"){
					document.getElementById(fldnam).className = 'form_item_rejected';
					if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
					numb++;
					err = 1;
				} else if(obj.elements[i].value != '' && frmAttrVal == "true"){
					if(fldnam=="emailadd" && obj.elements[i].value != ""){
						
						if(obj.elements[i].value=="Email Address"){
							document.getElementById(fldnam).className = 'form_item_rejected';
							if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
							document.getElementById('username_error').innerHTML="Enter email address";
							errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
							numb++;
							err = 1;
						}else{
							if (!reg.test(obj.elements[i].value)){
								//alert('wrong email');	
								document.getElementById(fldnam).className = 'form_item_rejected';
								document.getElementById('username_error').innerHTML=" Invalid email address";
								if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
								errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
								numb++;
								err = 1;
							}else{
								//alert('correct email');	
								document.getElementById(fldnam).className = 'cm_textfield_white_accepted';
								document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
							}
						}
					}else if(fldnam=="fauxPassword" && obj.elements[i].value !=""){
						
						var ttpass = document.getElementById('password').value;
						
						if(ttpass == ""){
							
							document.getElementById(fldnam).className = 'form_item_rejected';
							
							if (document.getElementById(fldnam+'_error')) document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
							document.getElementById('user_password').innerHTML="Enter Password";
							errMsg = errMsg + numb + ". " + document.getElementById(fldnam).getAttribute("errmsg")+ "<br>" + spc ;
							numb++;
							err = 1;
						}
					}else{					
						document.getElementById(fldnam).className = 'cm_textfield_white_accepted';
						document.getElementById(fldnam+'_error').innerHTML = '<img src="images/common/icon_accepted.gif" align="absmiddle">';
						comp++;
					}
					
				}
		}
		
		if(err == 1){
            
            return false;
        } else { 
			obj.submit();
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
		  if ( (key>=48 &&  key<=57) || (key==8) || (key==127) || (key==45) ) {
			  return true;
		  } else {
			  return false;
		  }
	}
	
function commonChecklat    (vfld,   // element to be validated
                         ifld,   // id of element to receive info/error msg
                         reqd, err_img, err_msg)   // true if required
{
  if (!document.getElementById) 
    return true;  // not available on this browser - leave validation to the server
  var elem = document.getElementById(ifld);
   if (emptyString.test(vfld.value)) {
    if (reqd) {
	 document.getElementById(vfld.id).className = 'form_item_rejected';
	 document.getElementById(err_img).innerHTML = '<img src="images/common/icon_rejected.gif">';
      msg (ifld, "requiredfield", err_msg);
      setfocus(vfld);
      return false;
    }
    else {
      msg (ifld, "success_msg", "");   // OK
      return true;
    }
  }
  return proceed;
}


function validateEmptyMod(vfld, ifld, err_img, err_msg, valmsg){
	var stat = commonChecklat (vfld, ifld, true,  err_img, err_msg);
	  if (stat != proceed)
		  return stat;
	if(vfld.id == 'email'){
		var tfld = trim(vfld.value);  // value of field with whitespace trimmed off
	    var email = /^[^@]+@[^@.]+\.[^@]*\w\w$/
	   if (!email.test(tfld)) {
		  document.getElementById(vfld.id).className = 'form_item_rejected';
		  document.getElementById(ifld).className = 'requiredfield';
		  document.getElementById(ifld).innerHTML = 'Invalid email address';
		  document.getElementById(err_img).innerHTML = '<img src="images/common/icon_rejected.gif">';
		} else {
			  msg (ifld, "success_msg", valmsg);
			  document.getElementById(ifld).style.dispaly = 'block';
			  document.getElementById(vfld.id).className = 'cm_textfield_white_accepted';
			  document.getElementById(err_img).innerHTML = '<img src="images/common/icon_accepted.gif">';
			  return true;
		}
	} else if(vfld.id == 'mypassword'){
		var passwdlen = document.getElementById('mypassword').value;
		if(passwdlen.length < 4){
			document.getElementById("mypassword").className = "form_item_rejected";
			document.getElementById("pwd_error_img").innerHTML = '<img src="images/common/icon_rejected.gif">';
			msg ('error_pwd', "requiredfield", "Password must contain atleast 4 characters.");
		} else {
			document.getElementById("mypassword").className = "cm_textfield_white_accepted";
			document.getElementById("pwd_error_img").innerHTML = '<img src="images/common/icon_accepted.gif">';
			msg ('error_pwd', "success_msg", "Password must contain atleast 4 characters");
		}
	} else if(vfld.id == 'vpwd' || vfld.id == 'pwd') {
		var vpsswd = document.getElementById('vpwd').value;
		var passwd = document.getElementById('mypassword').value;
			if (vpsswd != passwd){
				document.getElementById("vpwd").className = "form_item_rejected";
				document.getElementById("vpwd_error_img").innerHTML = '<img src="images/common/icon_rejected.gif">';
				msg ('error_vpwd', "requiredfield", "ERROR: Passwords do not match.");
			} else {
				document.getElementById("mypassword").className = "cm_textfield_white_accepted";
				document.getElementById("pwd_error_img").innerHTML = '<img src="images/common/icon_accepted.gif">';
				document.getElementById("vpwd").className = "cm_textfield_white_accepted";
				document.getElementById("vpwd_error_img").innerHTML = '<img src="images/common/icon_accepted.gif">';
				msg ('error_vpwd', "success_msg", "Please confirm password");
			}

	} else {
	  msg (ifld, "success_msg", valmsg);
	  document.getElementById(ifld).style.dispaly = 'block';
	  document.getElementById(vfld.id).className = 'cm_textfield_white_accepted';
	  document.getElementById(err_img).innerHTML = '<img src="images/common/icon_accepted.gif">';
	  return true;
	}
}

function trim(str){    if(!str || typeof str != 'string')        return null;    return str.replace(/^[\s]+/,'').replace(/[\s]+$/,'').replace(/[\s]{2,}/,' ');}


      if (window.XMLHttpRequest)
		 {// code for IE7+, Firefox, Chrome, Opera, Safari
		   xmlhttp=new XMLHttpRequest();
		 }
		else
		 {// code for IE6, IE5
		   xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	     }
function submit_login_form()
{
	
	var email_id_val = document.getElementById('emailadd').value;
	var password_val = document.getElementById('epassword').value;
	var institute_id=document.getElementById('inst').value;
	var inst1=institute_id;
	var err = 0;
	var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
	  
	  if(reg.test(email_id_val) == false)
	  {
		document.getElementById("emailadd").className = "form_item_rejected";
		document.getElementById('error_email_id').className = "requiredfield";
		document.getElementById('error_email_id').innerHTML = 'Please enter a valid email address.';
		document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
		err = 1;
   	  }
	 else
	 {
		//document.getElementById("emailadd").className = "cm_textfield_white_accepted";
		//document.getElementById('error_email_id').innerHTML = '';
		//document.getElementById('emailadd_error').innerHTML='<img src="images/common/icon_accepted.gif" align="absmiddle">';
	 }
	 	 
	if((password_val == "Password") || (trim(password_val) == '')) {
		document.getElementById("epassword").className = "form_item_rejected";
		document.getElementById('error_password').className = "requiredfield";
		document.getElementById('error_password').innerHTML = 'Please enter your password.';
		document.getElementById('epassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
		err = 1;
    }else{
		//document.getElementById("epassword").className = "cm_textfield_white_accepted";
		//document.getElementById('error_password').innerHTML = '';
		//document.getElementById('epassword_error').innerHTML='<img src="images/common/icon_accepted.gif" align="absmiddle">';
		
	}
	
	if(err)
	{
		return false;
	}
	else
	{
		 if (window.XMLHttpRequest)
			  {// code for IE7+, Firefox, Chrome, Opera, Safari
			  xmlhttp=new XMLHttpRequest();
			  }
			else
			  {// code for IE6, IE5
			  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
			  }
		xmlhttp.onreadystatechange=function()
			  {
				
			  if(xmlhttp.readyState==4 || xmlhttp.status==200)
				{
					
					if(xmlhttp.responseText=='Fail')
					{	
					  document.getElementById('display_msg').innerHTML='Enter valid username and password.';
					  document.getElementById("emailadd").className = "form_item_rejected";
					  document.getElementById('error_email_id').className = "requiredfield";
					  document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					  document.getElementById("epassword").className = "form_item_rejected";
					  document.getElementById('error_password').className = "requiredfield";
					  document.getElementById('epassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					  return false;
					}
					if(xmlhttp.responseText=='Success')
					{
						window.location="xaviers_apply_application.php?inst="+inst1;
					}
					
				}
				
			  }
		  
		  xmlhttp.open("GET","check_userdetail_xaviers_exist.php?username="+email_id_val+"&password="+password_val+"&inst="+institute_id,true);
		  xmlhttp.send();
		  return false;
     
	}
	 
}


function check_userdetail_xaviers_exist(email_id_val,password_val,institute_id){
	
	  
	      xmlhttp.onreadystatechange=function()
			  {
				
			  if(xmlhttp.readyState==4 || xmlhttp.status==200)
				{
					if(xmlhttp.responseText=='Fail')
					{	
					  document.getElementById('display_msg').innerHTML='Enter valid username and password.';
					  document.getElementById("emailadd").className = "form_item_rejected";
					  document.getElementById('error_email_id').className = "requiredfield";
					  document.getElementById('emailadd_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					  document.getElementById("epassword").className = "form_item_rejected";
					  document.getElementById('error_password').className = "requiredfield";
					  document.getElementById('epassword_error').innerHTML = '<img src="images/common/icon_rejected.gif" align="absmiddle">';
					  return false;
					}
					if(xmlhttp.responseText=='Success')
					{
						window.location="xaviers_apply_application.php?inst="+inst1;
					}
					
				}
				
			  }
		  xmlhttp.open("GET","check_userdetail_xaviers_exist.php?username="+email_id_val+"&password="+password_val+"&inst="+institute_id,true);
		  xmlhttp.send();
		  return false;
	
	
	}