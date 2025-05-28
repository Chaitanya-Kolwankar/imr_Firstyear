<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Online Admission</title>


    <link rel="stylesheet" type="text/css" href="DatePicker/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="DatePicker/Style.css" />
    <script src="js/jquery_1.js"></script>
    <link href="css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/jquery.datetimepicker.js"></script>

    <script>
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                jQuery('#datetimepicker1').datetimepicker(
                    {
                        timepicker: false,
                        format: 'd-m-Y'
                    });
            }
        });
    </script>

    <script type='text/javascript'>
        $(document).ready(function () {
            $(document)[0].oncontextmenu = function () { return false; }
        });

        window.onload = () => {
            const myInput = document.getElementById('txt_code');
            myInput.onpaste = e => e.preventDefault();
        }

        function allowDrop(ev) {
            ev.preventDefault();
        }

        function drag(ev) {
            ev.dataTransfer.setData("Text", ev.target.id);
        }

        function drop(ev) {
            var data = ev.dataTransfer.getData("Text");
            ev.target.appendChild(document.getElementById(data));
            ev.preventDefault();
        }
    </script>

    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(9); //Tab
        specialKeys.push(46); //Delete
        specialKeys.push(36); //Home
        specialKeys.push(35); //End
        specialKeys.push(37); //Left
        specialKeys.push(39); //Right
        function IsAlphaNumeric(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("txtPasswd").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>

    <script language="javascript" type="text/javascript">
        function CheckNumeric(e) {

            if (window.event) // IE
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }

    </script>

    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=txtFname.ClientID%>").value == "") {
                alert("Please Enter First Name");
                document.getElementById("<%=txtFname.ClientID%>").focus();
                return false;
            }
          <%--  if (document.getElementById("<%=txtMname.ClientID%>").value == "") {
                alert("Please Enter Middle Name");
                document.getElementById("<%=txtMname.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtMoName.ClientID%>").value == "") {
                alert("Please Enter Mother Name");
                document.getElementById("<%=txtMoName.ClientID%>").focus();
                return false;
            }--%>
            if (document.getElementById("<%=ddday.ClientID%>").value == "Day") {
                alert("Please Enter Birth Day");
                document.getElementById("<%=ddday.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddmonth.ClientID%>").value == "Month") {
                alert("Please Enter Birth Month");
                document.getElementById("<%=ddmonth.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddyear.ClientID%>").value == "Year") {
                alert("Please Enter Birth Year");
                document.getElementById("<%=ddyear.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtEmailID.ClientID%>").value == "") {
                alert("Please Enter E-Mail");
                document.getElementById("<%=txtEmailID.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtMobNo.ClientID%>").value == "") {
                alert("Please Enter Mobile Number");
                document.getElementById("<%=txtMobNo.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtPasswd.ClientID%>").value == "") {
                alert("Please Enter Password");
                document.getElementById("<%=txtPasswd.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtVerifyPass.ClientID%>").value == "") {
                alert("Please Enter Password Again");
                document.getElementById("<%=txtVerifyPass.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt_code.ClientID%>").value == "") {
                alert("Please Enter Security Code");
                document.getElementById("<%=txt_code.ClientID%>").focus();
                return false;
            }
            var phoneno = /^\d{10}$/;
            //if((inputtxt.value.match(phoneno))  
            if (document.getElementById("<%=txtMobNo.ClientID%>").value == "") {

                alert("Please Enter mobile no.");
                document.getElementById("<%=txt_code.ClientID%>").focus();
                return false;
            }
            else {
                var mob_no = document.getElementById("<%=txtMobNo.ClientID%>").value;
                if (mob_no.match(phoneno)) {
                }
                else {
                    alert("Please Enter 10 digit mobile no.");
                    document.getElementById("<%=txt_code.ClientID%>").focus();
                    return false;
                }
            }
            return true;

        }
    </script>
    <style>
        .topMargin {
            margin-top: 15px;
        }

        .well {
            margin: 0;
        }

        body {
            background-image: url('images/90625.jpg');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            background-attachment: fixed;
            margin: 0;
            padding: 0;
        }

        .panel-primary > .panel-heading {
            color: #fff;
            background: linear-gradient(90deg, #4B0082, #0077B6);
            border-color: #337ab7;
        }

        .panel-info > .panel-heading {
            color: #284452;
            background-color: #d9edf7;
            border-color: #bce8f1;
            background: linear-gradient(135deg, #b265ff, #88d6ff);
        }
    </style>


     <script>
         //function allowOnlyAlphabets(event) {
         //    let input = event.target;
         //    input.value = input.value.replace(/[^a-zA-Z]/g, ''); // Remove non-alphabet characters
         //}

         function allowOnlyAlphabets(event) {
             let input = event.target;
             input.value = input.value.replace(/[^a-zA-Z ]/g, ''); // Allow alphabets and spaces
             input.value = input.value.replace(/\s{2,}/g, ' '); // Prevent multiple spaces between words
             input.value = input.value.replace(/( [a-zA-Z]+)* {5,}/g, '$1    '); // Allow up to 4 trailing spaces
         }


         function validateEmail(input) {
             let emailPattern = /^[a-zA-Z0-9._%+-]+@(gmail|yahoo|outlook)\.com$/;
             let errorSpan = document.getElementById("emailError");

             if (!emailPattern.test(input.value)) {
                 input.style.border = "2px solid red";
                 errorSpan.textContent = "Invalid email format! Must be @gmail.com, @yahoo.com, or @outlook.com.";
                 errorSpan.style.color = "red";
             } else {
                 input.style.border = "2px solid green";
                 errorSpan.textContent = ""; // Remove error when correct
             }
         }

     </script>


</head>


<body>
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="panel-default">
            <div class="panel-heading">
                <center>
                    <div style="margin-top: 15px">
                        <!--//logo-->
                        <center>
                            <img id="logo" src="images/mu.png" height="100" alt="Logo" />
                            <p style="font-family: 'Times New Roman'; font-size: 15px; text-align: center">
                                <%--  <b>
                                    <h5>Shri. Vishnu Waman Thakur Charitable Trust's</h5>
                                </b>--%>
                                <h4 style="font-size: 15pt; font-family: 'Times New Roman'">University of Mumbai</h4>
                                <h4 style="font-size: 15pt; font-family: 'Verdana'; color: gray">Online Admission</h4>
                            </p>
                        </center>
                    </div>
                </center>
            </div>
            <div class="panel-body">
                <center>
                    <div class="row">
                        <div class="col-lg-2 col-md-2 col-sm-1 col-xs-1"></div>
                        <div class="col-lg-8 col-md-8 col-sm-10 col-xs-10">

                            <div class="panel panel-danger">
                                <div class="panel-heading">
                                    Registration Can Only Be Done Once. If You Have Already Registered Then
                                <a title="If Already Registered Then Login To Continue!" href="Login.aspx" class="thickbox" style="text-decoration: underline">Click here to Login</a>
                                </div>
                                <div class="panel-body">

                                    <div class="row">

                                        <div class="col-lg-4  col-md-4">
                                            <div class="panel panel-primary">
                                                <div class="panel-heading">
                                                    <span style="font-family: Verdana; font-size: 18pt"><strong>INSTRUCTIONS</strong></span>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Step 1: Register With College IMR</b></div>
                                                        <%--<strong style="font-family: Verdana; font-size: 12pt">Step 1:</strong>&nbsp; <strong>
                                    <span style="font-family: Verdana; font-size: 12pt; color: black">Register With VIVA College</strong></span>&nbsp;<br />--%>
                                                        <span style="font-family: Verdana; font-size: 10pt; color: black; text-align: justify">Note: [On First Time Register with College IMR you will Recevie UserID and Password on the given Email ID and Mobile Number. Only one Email ID allowed for Registration Form.  To Fill Online Registration Form you will requried Scan Photo and Signature to Complete the Online Process.]</span>
                                                    </div>
                                                    <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Step 2: Login</b></div>

                                                        <span style="font-family: Verdana; font-size: 10pt; color: black">Note: [You can Login by using the UserID and Password Recevied on Your Email ID or Mobile Number.]</span>
                                                        <br />
                                                    </div>
                                                    <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Step 3: Form Fill Up</b></div>
                                                        <%--<strong style="font-family: Verdana;">Step 3:</strong>&nbsp; <span style="font-family: Verdana; font-size: 12pt; color: black"><strong>Form Fill Up</strong></span>&nbsp;<br />--%>
                                                        <span style="font-family: Verdana; font-size: 10pt; color: black">Note: [Please fill Mandatory Details and make Your Selections.]</span>
                                                    </div>

                                                    <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Step 4: Print Form</b></div>
                                                        <%--<strong style="font-family: Verdana;">Step 4:</strong>&nbsp; <span style="font-family: Verdana; font-size: 12pt; color: black"><strong>Print Form</strong></span>&nbsp;<br />--%>
                                                        <span style="font-family: Verdana; font-size: 10pt; color: black">Note: [Print the Form for the Courses You have Applied.]</span>
                                                    </div>

                                                    <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Step 5: Form Submission</b></div>
                                                        <%--<strong style="font-family: Verdana;">Step 5:</strong>&nbsp; <span style="font-family: Verdana; font-size: 12pt; color: black"><strong>Form Submission</strong></span>&nbsp;<br />--%>
                                                        <span style="font-family: Verdana; font-size: 10pt; color: black">Note: [Submit the Form to the College IMR with required Documents and University Online Registration Form.]</span>
                                                    </div>
                                                    <%-- <div class="panel panel-info">
                                                        <div class="panel-heading"><b>Technical HelpLine No.</b></div>
                                                        <span style="font-family: Verdana">For Any further assistance Contact on: 8408931470</span>
                                                        <br />
                                                        <span style="font-family: Verdana">Contact Timing: 10 AM To 5 PM</span>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>



                                                <div class="col-lg-8 col-md-8" style="height: 100%">
                                                    <div class="row">
                                                        <%-- <div class="col-lg-6 col-md-6">
                                                     <span style="font-size:large; ">
                                                     Select Admission Year
                                                         </span>
                                                 </div>--%>
                                                        <div class="col-lg-3 col-md-3">
                                                        </div>
                                                        <div class="col-lg-6 col-md-6">
                                                            <span style="font-size: large;">Select Admission Year
                                                            </span>
                                                            <asp:DropDownList ID="ddl_applicant_type" CssClass="form-control" TabIndex="1" runat="server" OnSelectedIndexChanged="ddl_applicant_type_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                                <%--  <asp:ListItem Value="01">First Year</asp:ListItem>--%>
                                                                <asp:ListItem Value="02">First Year</asp:ListItem>
                                                                <asp:ListItem Value="03">Second Year</asp:ListItem>
                                                                <%--   <asp:ListItem Value="04">First Year Post Graduation</asp:ListItem>   
                                            <asp:ListItem Value="05">Second Year Post Graduation</asp:ListItem>           --%>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>


                                                    <br />
                                                    <div class="panel panel-primary" style="height: 100%" id="pnlregi">
                                                        <div class="panel-heading">
                                                            <span style="font-family: Verdana; font-size: 18pt"><strong>REGISTRATION</strong></span>
                                                        </div>
                                                        <div class="panel-body">
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" type="text" name="last_name" id="txtSurname" class="form-control" placeholder="Last Name" tabindex="2" oninput="allowOnlyAlphabets(event)"/>
                                                                        <!--<span class="error" ng-show="myForm.last_name.$error.required"> Required!</span>
   -->
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" type="text" name="first_name" id="txtFname" class="form-control" placeholder="First Name" tabindex="3" required="true" oninput="allowOnlyAlphabets(event)"/>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" type="text" name="Middle_name" id="txtMname" class="form-control" placeholder="Middle Name" tabindex="4" oninput="allowOnlyAlphabets(event)"/>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" type="text" name="mother_name" id="txtMoName" class="form-control" placeholder="Mother Name" tabindex="5" oninput="allowOnlyAlphabets(event)"/>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <%--<span style="font-family: Verdana"><span style="font-size: 12pt;color:gray">
                                             <asp:Label ID="Label1" Text="Select D.O.B."  runat="server"></asp:Label>                                        </span></span>
                                   
                                     <div class='input-group date' id='date_activity'>
                                    <asp:TextBox type='text' id="datetimepicker1" CssClass="form-control" runat="server"  />
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>    --%>
                                                                <span style="font-family: Verdana"><span style="font-size: 12pt; color: gray">Select D.O.B.
                                                                </span></span>
                                                                <div class="form-inline">
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddday" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="6" runat="server">
                                                                            <asp:ListItem>Day</asp:ListItem>
                                                                            <asp:ListItem>01</asp:ListItem>
                                                                            <asp:ListItem>02</asp:ListItem>
                                                                            <asp:ListItem>03</asp:ListItem>
                                                                            <asp:ListItem>04</asp:ListItem>
                                                                            <asp:ListItem>05</asp:ListItem>
                                                                            <asp:ListItem>06</asp:ListItem>
                                                                            <asp:ListItem>07</asp:ListItem>
                                                                            <asp:ListItem>08</asp:ListItem>
                                                                            <asp:ListItem>09</asp:ListItem>
                                                                            <asp:ListItem>10</asp:ListItem>
                                                                            <asp:ListItem>11</asp:ListItem>
                                                                            <asp:ListItem>12</asp:ListItem>
                                                                            <asp:ListItem>13</asp:ListItem>
                                                                            <asp:ListItem>14</asp:ListItem>
                                                                            <asp:ListItem>15</asp:ListItem>
                                                                            <asp:ListItem>16</asp:ListItem>
                                                                            <asp:ListItem>17</asp:ListItem>
                                                                            <asp:ListItem>18</asp:ListItem>
                                                                            <asp:ListItem>19</asp:ListItem>
                                                                            <asp:ListItem>20</asp:ListItem>
                                                                            <asp:ListItem>21</asp:ListItem>
                                                                            <asp:ListItem>22</asp:ListItem>
                                                                            <asp:ListItem>23</asp:ListItem>
                                                                            <asp:ListItem>24</asp:ListItem>
                                                                            <asp:ListItem>25</asp:ListItem>
                                                                            <asp:ListItem>26</asp:ListItem>
                                                                            <asp:ListItem>27</asp:ListItem>
                                                                            <asp:ListItem>28</asp:ListItem>
                                                                            <asp:ListItem>29</asp:ListItem>
                                                                            <asp:ListItem>30</asp:ListItem>
                                                                            <asp:ListItem>31</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddmonth" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="7" runat="server">
                                                                            <asp:ListItem>Month</asp:ListItem>
                                                                            <asp:ListItem Value="01">Jan</asp:ListItem>
                                                                            <asp:ListItem Value="02">Feb</asp:ListItem>
                                                                            <asp:ListItem Value="03">Mar</asp:ListItem>
                                                                            <asp:ListItem Value="04">Apr</asp:ListItem>
                                                                            <asp:ListItem Value="05">May</asp:ListItem>
                                                                            <asp:ListItem Value="06">Jun</asp:ListItem>
                                                                            <asp:ListItem Value="07">Jul</asp:ListItem>
                                                                            <asp:ListItem Value="08">Aug</asp:ListItem>
                                                                            <asp:ListItem Value="09">Sep</asp:ListItem>
                                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddyear" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="8" runat="server">
                                                                            <asp:ListItem>Year</asp:ListItem>
                                                                            <asp:ListItem>2005</asp:ListItem>
                                                                            <asp:ListItem>2004</asp:ListItem>
                                                                            <asp:ListItem>2003</asp:ListItem>
                                                                            <asp:ListItem>2002</asp:ListItem>
                                                                            <asp:ListItem>2001</asp:ListItem>
                                                                            <asp:ListItem>2000</asp:ListItem>
                                                                            <asp:ListItem>1999</asp:ListItem>
                                                                            <asp:ListItem>1998</asp:ListItem>
                                                                            <asp:ListItem>1997</asp:ListItem>
                                                                            <asp:ListItem>1996</asp:ListItem>
                                                                            <asp:ListItem>1995</asp:ListItem>
                                                                            <asp:ListItem>1994</asp:ListItem>
                                                                            <asp:ListItem>1993</asp:ListItem>
                                                                            <asp:ListItem>1992</asp:ListItem>
                                                                            <asp:ListItem>1991</asp:ListItem>
                                                                            <asp:ListItem>1990</asp:ListItem>
                                                                            <asp:ListItem>1989</asp:ListItem>
                                                                            <asp:ListItem>1988</asp:ListItem>
                                                                            <asp:ListItem>1987</asp:ListItem>
                                                                            <asp:ListItem>1986</asp:ListItem>
                                                                            <asp:ListItem>1985</asp:ListItem>
                                                                            <asp:ListItem>1984</asp:ListItem>
                                                                            <asp:ListItem>1983</asp:ListItem>
                                                                            <asp:ListItem>1982</asp:ListItem>
                                                                            <asp:ListItem>1981</asp:ListItem>
                                                                            <asp:ListItem>1980</asp:ListItem>
                                                                            <asp:ListItem>1979</asp:ListItem>
                                                                            <asp:ListItem>1978</asp:ListItem>
                                                                            <asp:ListItem>1977</asp:ListItem>
                                                                            <asp:ListItem>1976</asp:ListItem>
                                                                            <asp:ListItem>1975</asp:ListItem>
                                                                            <asp:ListItem>1974</asp:ListItem>
                                                                            <asp:ListItem>1973</asp:ListItem>
                                                                            <asp:ListItem>1972</asp:ListItem>
                                                                            <asp:ListItem>1971</asp:ListItem>
                                                                            <asp:ListItem>1970</asp:ListItem>
                                                                            <asp:ListItem>1969</asp:ListItem>
                                                                            <asp:ListItem>1968</asp:ListItem>
                                                                            <asp:ListItem>1967</asp:ListItem>
                                                                            <asp:ListItem>1966</asp:ListItem>
                                                                            <asp:ListItem>1965</asp:ListItem>
                                                                            <asp:ListItem>1964</asp:ListItem>
                                                                            <asp:ListItem>1963</asp:ListItem>
                                                                            <asp:ListItem>1962</asp:ListItem>
                                                                            <asp:ListItem>1961</asp:ListItem>
                                                                            <asp:ListItem>1960</asp:ListItem>
                                                                            <asp:ListItem>1959</asp:ListItem>
                                                                            <asp:ListItem>1958</asp:ListItem>
                                                                            <asp:ListItem>1957</asp:ListItem>
                                                                            <asp:ListItem>1956</asp:ListItem>
                                                                            <asp:ListItem>1955</asp:ListItem>
                                                                            <asp:ListItem>1954</asp:ListItem>
                                                                            <asp:ListItem>1953</asp:ListItem>
                                                                            <asp:ListItem>1952</asp:ListItem>
                                                                            <asp:ListItem>1951</asp:ListItem>
                                                                            <asp:ListItem>1950</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </div>


                                                                </div>
                                                            </div>


                                                            <%--</div>--%>
                                                            <div class="row" style="margin-top: 30px"></div>
                                                            <div class="row">
                                                                <div class="col-lg-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" id="txtEmailID" class="form-control" placeholder="Email Address" tabindex="12" required="true" oninput="validateEmail(input)"/>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <input runat="server" id="txtMobNo" onkeypress="CheckNumeric(event);" class="form-control" placeholder="Mobile No" tabindex="13" required="true" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <asp:TextBox runat="server" type="password" ID="txtPasswd" CssClass="form-control" placeholder="Password" TabIndex="14" required="true" AutoPostBack="false" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-6 col-sm-6">
                                                                    <div class="form-group">
                                                                        <asp:TextBox runat="server" type="password" ID="txtVerifyPass" CssClass="form-control" placeholder="Confirm Password" TabIndex="15" required="true" AutoPostBack="false" />

                                                                    </div>
                                                                </div>
                                                            </div>




                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <asp:Label ID="lbl_captcha" runat="server" ondragstart="drag(event)" Height="80px" ForeColor="#009933" Font-Italic="False" Font-Names="MS PMincho" Style="font-size: 48px"></asp:Label>

                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <input runat="server" type="text" id="txt_code" ondrop="drop(event)" ondragover="allowDrop(event)" class="form-control topMargin" tabindex="29" placeholder="Enter Security Code" name="randomfield" value="" />
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-xs-12 col-md-12">
                                                                    <div runat="server" id="errorMessage" visible="false" class="row topMargin alert alert-danger"></div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-xs-12 col-md-12">
                                                                    <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" class="btn btn-success btn-block btn-lg topMargin" TabIndex="30" OnClick="btnsubmit_Click" Style="margin-bottom: 15px; background: linear-gradient(135deg, #FF1493, #1E90FF); color: white;"></asp:Button>
                                                                </div>
                                                                <!--   <div class="col-xs-12 col-md-6"><a href="#" class="btn btn-success btn-block btn-lg">Login</a></div>-->
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddl_applicant_type" EventName="SelectedIndexChanged" />
                                                <%--<asp:PostBackTrigger  ControlID="datetimepicker1" />--%>
                                                <%--<asp:AsyncPostBackTrigger ControlID="datetimepicker1" EventName="OnClick"/>--%>
                                                <%--   <asp:AsyncPostBackTrigger ControlID="rdbSy" EventName="CheckedChanged" />
                                       <asp:AsyncPostBackTrigger ControlID="rdbTy" EventName="CheckedChanged" />
                                       <asp:AsyncPostBackTrigger ControlID="rdbFyPG" EventName="CheckedChanged" />--%>
                                            </Triggers>
                                        </asp:UpdatePanel>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>

            </center>
        </div>
        <div class="panel-footer">
            <center>
                <div class="well">
                    
                </div>
            </center>
        </div>
        </div>
          
    </form>




</body>

</html>
