<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Basic_Detail.aspx.cs" Inherits="Basic_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--    <link rel="stylesheet" href="css/bootstrap.min.css" />
     <link rel="stylesheet" type="text/css" href="DatePicker/bootstrap.css"/>--%>
   <link rel="stylesheet" type="text/css" href="DatePicker/Style.css"/>
      <link href="css/jquery.datetimepicker.css" rel="stylesheet" />
   <%-- <link href="css/jquery.datetimepicker.css" rel="stylesheet" />--%>
    <style>
        .topMargin {
            margin-top: 20px;
        }
        .well{
                 margin-bottom:0;
             }

        .panel-footer {
            padding: 0;
        }
    </style>



       <%--   <script>
           $(document).ready(function () {
               Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

               function EndRequestHandler(sender, args) {
                   jQuery('#ContentPlaceHolder1_txtdate').datetimepicker(
                       {
                           timepicker: false,
                           format: 'Y-m-d'
                       });
               }
           });
     </script>--%>
    <%--<script src="js/jquery-1.3.1.min.js"></script>--%>
    <script src="js/jquery.datetimepicker.js"></script>

 

           <script>
               $(document).ready(function () {
                   jQuery('#ContentPlaceHolder1_txtdate_activity').datetimepicker(
                       {
                           timepicker: false,
                           format: 'Y-m-d'
                       });

               });
    </script>

    <script type="text/javascript">

        function validate() {

           

            if (document.getElementById("<%=txtfirstname.ClientID%>").value == "") {
                alert("Please Enter First Name");
                document.getElementById("<%=txtfirstname.ClientID%>").focus();
                return false;
            }
          <%--  if (document.getElementById("<%=txtmiddlename.ClientID%>").value == "") {
                alert("Please Enter Middle Name");
                document.getElementById("<%=txtmiddlename.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtmothername.ClientID%>").value == "") {
                alert("Please Enter Mother Name");
                document.getElementById("<%=txtmothername.ClientID%>").focus();
                return false;
            }--%>
            if (document.getElementById("<%=txtprevious.ClientID%>").value == "") {
                alert("Please Enter Previous Student Id");
                document.getElementById("<%=txtprevious.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddbranch.ClientID%>").value == "--Select--") {
                
                alert("Please Select The Branch");
                document.getElementById("<%=ddbranch.ClientID%>").focus();
                return false;
            }
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
        
          
            if (document.getElementById("rbtoutsider").checked == false) {
                alert("Select Inhouse ,outside Or private");
                return false;
            }
            return true;
        }
    </script>




    <script type="text/javascript">

        // Script Source: CodeLifter.com
        // Copyright 2003
        // Do not remove this notice.

        // SETUPS:
        // ===============================

        // Set the horizontal and vertical position for the popup

        PositionX = 100;
        PositionY = 100;

        // Set these value approximately 20 pixels greater than the
        // size of the largest image to be used (needed for Netscape)

        defaultWidth = 600;
        defaultHeight = 360;

        // Set autoclose true to have the window close automatically
        // Set autoclose false to allow multiple popup windows

        var AutoClose = true;

        // Do not edit below this line...
        // ================================
        if (parseInt(navigator.appVersion.charAt(0)) >= 4) {
            var isNN = (navigator.appName == "Netscape") ? 1 : 0;
            var isIE = (navigator.appName.indexOf("Microsoft") != -1) ? 1 : 0;
        }
        var optNN = 'scrollbars=no,width=' + defaultWidth + ',height=' + defaultHeight + ',left=' + PositionX + ',top=' + PositionY;
        var optIE = 'scrollbars=no,width=150,height=100,left=' + PositionX + ',top=' + PositionY;
        function popImage(imageURL, imageTitle) {
            if (isNN) { imgWin = window.open('about:blank', '', optNN); }
            if (isIE) { imgWin = window.open('about:blank', '', optIE); }
            with (imgWin.document) {
                writeln('<html><head><style>body{margin:0px;}</style>'); writeln('<sc' + 'ript>');
                writeln('var isNN,isIE;'); writeln('if (parseInt(navigator.appVersion.charAt(0))>=4){');
                writeln('isNN=(navigator.appName=="Netscape")?1:0;'); writeln('isIE=(navigator.appName.indexOf("Microsoft")!=-1)?1:0;}');
                writeln('function reSizeToImage(){'); writeln('if (isIE){'); writeln('window.resizeTo(300,300);');
                writeln('width=300-(document.body.clientWidth-document.images[0].width);');
                writeln('height=300-(document.body.clientHeight-document.images[0].height);');
                writeln('window.resizeTo(width,height);}'); writeln('if (isNN){');
                writeln('window.innerWidth=document.images["George"].width;'); writeln('window.innerHeight=document.images["George"].height;}}');
                writeln('function doTitle(){document.title="' + imageTitle + '";}'); writeln('</sc' + 'ript>');
                if (!AutoClose) writeln('</head><body bgcolor=000000 scroll="no" onload="reSizeToImage();doTitle();self.focus()">')
                else writeln('</head><body bgcolor=000000 scroll="no" onload="reSizeToImage();doTitle();self.focus()" onblur="self.close()">');
                writeln('<img name="George" src=' + imageURL + ' style="display:block"></body></html>');
                close();
            }
        }

    </script>

    <script>
        function allowOnlyAlphabets(event) {
            let input = event.target;
            input.value = input.value.replace(/[^a-zA-Z]/g, ''); // Remove non-alphabet characters
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span style="font-family: Verdana; font-size: 18pt"><strong>Basic Details</strong></span>
                </div>
                <div class=" panel-body">
                    <div class="row" style="padding: 14px">
                        <div class="well alert-danger">
                            <span><strong>NOTE:</strong>1. Please Enter Same Name As In Your H.S.C. Marksheet.</span><br />
                           <%-- <span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp 2. Inhouse means the student should be passed in March 2015 at Regular first attempt and they<br />
                                <span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp should be from Utkarsh Vidyalaya Virar or Viva Jr college Nalasopara branch.</span>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-info" id="divrdb" runat="server">
                                <div class="panel-heading">
                                    <span style="font-weight: 800">Category</span> <span style="COLOR: #ff3333; font-weight: 800">*</span>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <asp:RadioButton onblur="OnBlur(this);" CssClass="form-control" ID="rbthouse" onfocus="OnFocus(this);" TabIndex="1" runat="server" Text="Inhouse" ToolTip="Inhouse" GroupName="house" AutoPostBack="True" OnCheckedChanged="rbthouse_CheckedChanged1"></asp:RadioButton>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:RadioButton onblur="OnBlur(this);" CssClass="form-control" ID="rbtoutsider" onfocus="OnFocus(this);" TabIndex="2" runat="server" Text="Outsider" ToolTip="Outsider" GroupName="house" AutoPostBack="True" OnCheckedChanged="rbtoutsider_CheckedChanged"></asp:RadioButton>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:RadioButton onblur="OnBlur(this);" CssClass="form-control" ID="rbt17number" onfocus="OnFocus(this);" TabIndex="3" runat="server" Text="Private 17" ToolTip="Private_17_NO" GroupName="house" AutoPostBack="True" OnCheckedChanged="rbt17number_CheckedChanged"></asp:RadioButton>
                                        </div>
                                    </div>
                                    <div class="row topMargin"></div>
                                    <div runat="server" id="divinhouse" class="row">
                                        <div class="col-lg-6">
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddbranch" onfocus="OnFocus(this);" CssClass="form-control uppercase topMargin" TabIndex="4" runat="server" ToolTip="Branch" Visible="False">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Utkarsh Vidyalaya Junior College Virar</asp:ListItem>
                                                <asp:ListItem>Viva Junior College Of Commerce Nalasopara</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:Label ID="lblPrevious" runat="server" Visible="False" Text="Previous Student ID"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Visible="False" Text="*" ForeColor="#ff3333"></asp:Label>
                                            <strong>
                                                <a href="javascript:popImage('images/student_ID.png','Student ID')">
                                                    <img id="Img2" onclick="window.open(javascript:popImage('images/student_ID.png','Student ID'), 'nLogin.aspx', 'width=400,height=400');" src="images/question.png" runat="server" visible="false" /></a>
                                            </strong>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txtprevious" onfocus="OnFocus(this);" TabIndex="5" runat="server" Visible="False" ToolTip="Previous Student ID/Roll No" CssClass="form-control" OnTextChanged="txtprevious_TextChanged" AutoPostBack="true"></asp:TextBox>

                                            <span id="span_stud_id" runat="server" visible="false">Don't Know Your Student ID Then <a href="Forgot_Stud_Id.aspx">Click Here</a></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Last Name <span style="COLOR: #ff3333">*</span> </span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" name="last_name" ID="txtsurname" class="uppercase form-control" placeholder="Last Name" TabIndex="6" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">First Name <span style="COLOR: #ff3333">*</span> </span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" name="first_name" ID="txtfirstname" class="uppercase form-control" placeholder="First Name" TabIndex="7" required="true" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Middle Name </span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" name="Middle_name" ID="txtmiddlename" class="uppercase form-control" placeholder="Middle Name" TabIndex="8" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Mother Name</span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" name="mother_name" ID="txtmothername" class="uppercase form-control" placeholder="Mother Name" TabIndex="9" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                     <div class="form-inline">
                                        <span style="font-weight: initial; margin-right: 10px">D.O.B.<span style="COLOR: #ff3333">*</span></span>
                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddday" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="10" runat="server">
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
                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddmonth" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="11" runat="server">
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
                                        <asp:DropDownList onblur="OnBlur(this);" ID="ddyear" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="12" runat="server">
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
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Email Address</span>
                                        <br />
                                        <asp:TextBox runat="server" ID="txtemailid" CssClass="form-control" placeholder="Email Address" TabIndex="13" required="true" Enabled="false" oninput="validateEmail(input)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Contact No.</span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" ID="txtcontact" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" CssClass="form-control" placeholder="Contact No." TabIndex="14" required="true"  Enabled="false" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <span style="FONT-FAMILY: Verdana">Other Contact No.</span>
                                        <br />
                                        <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" ID="txtothercontact" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" class="form-control" placeholder="Other Contact No." TabIndex="15"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                  <%--  <div class="row">
                        <p>Date: <input type="text" id="datepicker"></p>
                    </div>--%>
                    <div class="row">
                        <div runat="server" id="errorMessage" visible="false" class="alert alert-danger"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4 col-xs-12 col-md-12">
                            <asp:Button ID="btnsubmit" runat="server" Text="SAVE & CONTINUE" class="btn btn-success btn-block btn-lg topMargin" TabIndex="16" OnClick="btnsubmit_Click" Style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            </span>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

