<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Education_Detail.aspx.cs" Inherits="FY_Education_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
        .topMargin {
            margin-top: 15px;
        }
        .panel-footer {
            padding: 0;
        }
    </style>


     <style>
        .stepwizard-step p {
            margin-top: 10px;
        }

        .stepwizard-row {
            display: table-row;
        }

        .stepwizard {
            display: table;
            width: 100%;
            position: relative;
        }

        .stepwizard-step button[disabled] {
            opacity: 1 !important;
            filter: alpha(opacity=100) !important;
        }

        .stepwizard-row:before {
            top: 14px;
            bottom: 0;
            position: absolute;
            content: " ";
            width: 100%;
            height: 1px;
            background-color: #ccc;
            z-order: 0;
        }

        .stepwizard-step {
            display: table-cell;
            text-align: center;
            position: relative;
        }

        .btn-circle {
            width: 30px;
            height: 30px;
            text-align: center;
            padding: 6px 0;
            font-size: 12px;
            line-height: 1.428571429;
            border-radius: 15px;
        }

        .panel-primary>.panel-heading {
    color: #fff;
    background-color: #211c6c;
    border-color: #337ab7;
}

        .well{
                 margin-bottom:0;
             }
    </style>

    <script>
        function allowOnlyAlphabets(event) {
            let input = event.target;
            input.value = input.value.replace(/[^a-zA-Z]/g, ''); // Remove non-alphabet characters
        }

        function allowNumAlpha(event) {
            let input = event.target;
            input.value = input.value.replace(/[^a-zA-Z0-9]/g, ''); // Allow only alphabets and numbers
        }

        function allowOnlyAlphabetschool(event) {
            let input = event.target;
            input.value = input.value.replace(/[^a-zA-Z ]/g, ''); // Allow alphabets and spaces
            input.value = input.value.replace(/\s{2,}/g, ' '); // Prevent multiple spaces between words
            input.value = input.value.replace(/( [a-zA-Z]+)* {5,}/g, '$1    '); // Allow up to 4 trailing spaces
        }


    </script>

    <%--    <script type="text/javascript">

        function validate() {
            if (document.getElementById("<%=ddl10StateBoard.ClientID%>").value == "--Select--") {
                div_valid.innerText = "Please Enter S.S.C. State";
                document.getElementById("<%=ddl10StateBoard.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl10board.ClientID%>").value == "--Select--") {
                div_valid.innerText = "Please Enter S.S.C. Board";
                document.getElementById("<%=ddl10board.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt10institutename.ClientID%>").value == "") {
                alert("Please Enter S.S.C. Institute Name");
                document.getElementById("<%=txt10institutename.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt10instituteplace.ClientID%>").value == "") {
                alert("Please Enter  S.S.C. Institute Place");
                document.getElementById("<%=txt10instituteplace.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl10passyear.ClientID%>").value == "Year") {
                alert("Please Enter S.S.C. Passing Year");
                document.getElementById("<%=ddl10passyear.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=ddl10passmonth.ClientID%>").value == "MONTH") {
                alert("Please Enter S.S.C. Passing Month");
                document.getElementById("<%=ddl10passmonth.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt10marksobtained.ClientID%>").value == "") {
                alert("Please Enter S.S.C. Total Marks Obtained");
                document.getElementById("<%=txt10marksobtained.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt10totalmarks.ClientID%>").value == "") {
                alert("Please Enter S.S.C. Out of Marks");
                document.getElementById("<%=txt10totalmarks.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt10seatno.ClientID%>").value == "") {
                alert("Please Enter S.S.C. Seat No.");
                document.getElementById("<%=txt10seatno.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl12StateBoard.ClientID%>").value == "--Select--") {
                alert("Please Enter H.S.C State");
                document.getElementById("<%=ddl12StateBoard.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddl12board.ClientID%>").value == "--Select--") {
                alert("Please Enter H.S.C Board");
                document.getElementById("<%=ddl12board.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt12institutename.ClientID%>").value == "") {
                alert("Please Enter H.S.C Institute Name");
                document.getElementById("<%=txt12institutename.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt12instituteplace.ClientID%>").value == "") {
                alert("Please Enter H.S.C Institute Place");
                document.getElementById("<%=txt12instituteplace.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=dd12passyear.ClientID%>").value == "--Select--") {
                alert("Please Enter H.S.C Passing Year");
                document.getElementById("<%=dd12passyear.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=dd12passmonth.ClientID%>").value == "--Select--") {
                alert("Please Enter H.S.C Passing Month");
                document.getElementById("<%=dd12passmonth.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt12marksobtained.ClientID%>").value == "") {
                alert("Please Enter H.S.C Total Marks Obtained");
                document.getElementById("<%=txt12marksobtained.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt12totalmarks.ClientID%>").value == "") {
                alert("Please Enter H.S.C Out of Marks");
                document.getElementById("<%=txt12totalmarks.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txt12seatno.ClientID%>").value == "") {
                alert("Please Enter H.S.C Seat No.");
                document.getElementById("<%=txt12seatno.ClientID%>").focus();
                return false;
            }
            return true;
        }
    </script>--%>

    <script type="text/javascript">

        function Opencaste() {
            window.open("nlogin.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");
            return false;
        }

    </script>
    <script lang="javascript" type="text/javascript">
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Educational Details</strong></span>
                        <div class="hidden-lg hidden-md">
                            <a class="btn btn-sm btn-success pull-right" href="FY_Personal_Detail.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row" style="padding: 14px;">
                        <div class="well alert-info">
                            <span><strong>NOTE :</strong> It is mandatory to fill all details of educational qualification (as applicable) till last completed semester / year. If the system of marking of your school / college is on grading pattern, convert grade into marks as applicable and fill in the respective columns. In absence of complete information, form will be rejected.</span>
                        </div>
                    </div>
                    <%-- S.S.C. Tab1--%>
                    <div id="tabssc" class="row" runat="server">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    S.S.C
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">State <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:DropDownList ID="ddl10StateBoard" TabIndex="1" runat="server" ToolTip="State" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl10StateBoard_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Maharashtra </asp:ListItem>
                                                <asp:ListItem>Andaman and Nicobar</asp:ListItem>
                                                <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                                <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                                <asp:ListItem>Assam</asp:ListItem>
                                                <asp:ListItem>Bihar</asp:ListItem>
                                                <asp:ListItem>Chandigarh</asp:ListItem>
                                                <asp:ListItem>Chhattisgarh</asp:ListItem>
                                                <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
                                                <asp:ListItem>Daman and Diu</asp:ListItem>
                                                <asp:ListItem>Delhi</asp:ListItem>
                                                <asp:ListItem>Goa</asp:ListItem>
                                                <asp:ListItem>Gujarat</asp:ListItem>
                                                <asp:ListItem>Haryana</asp:ListItem>
                                                <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                                <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                                <asp:ListItem>Jharkhand</asp:ListItem>
                                                <asp:ListItem>Karnataka</asp:ListItem>
                                                <asp:ListItem>Kerala</asp:ListItem>
                                                <asp:ListItem>Lakshadweep</asp:ListItem>
                                                <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                                <asp:ListItem>Manipur</asp:ListItem>
                                                <asp:ListItem>Meghalaya</asp:ListItem>
                                                <asp:ListItem>Mizoram</asp:ListItem>
                                                <asp:ListItem>Nagaland</asp:ListItem>
                                                <asp:ListItem>Orissa</asp:ListItem>
                                                <asp:ListItem>Pondicherry</asp:ListItem>
                                                <asp:ListItem>Punjab</asp:ListItem>
                                                <asp:ListItem>Rajasthan</asp:ListItem>
                                                <asp:ListItem>Sikkim</asp:ListItem>
                                                <asp:ListItem>Tamil Nadu</asp:ListItem>
                                                <asp:ListItem>Tripura</asp:ListItem>
                                                <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                                <asp:ListItem>Uttarakhand</asp:ListItem>
                                                <asp:ListItem>West Bengal</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Board <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:DropDownList ID="ddl10board" TabIndex="2" CssClass="form-control" runat="server" ToolTip="Select Board">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute Name</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt10institutename" ID="txt10institutename" class="form-control" placeholder="Institute Name" TabIndex="3" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute place</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt10instituteplace" ID="txt10instituteplace" class="form-control" placeholder="Institute place" TabIndex="4" oninput="allowOnlyAlphabets(events)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <div class="form-inline">
                                                <span style="FONT-FAMILY: Verdana">First Attempt<span style="COLOR: #ff3333">*</span>
                                                    <asp:RadioButton onblur="OnBlur(this);" ID="rbt10YesAttempt" onfocus="OnFocus(this);" Checked="true" CssClass="form-control" TabIndex="5" runat="server" Text="Yes" GroupName="Sattempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                                    <asp:RadioButton onblur="OnBlur(this);" ID="rbt10NoAttempt" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="6" runat="server" Text="No" GroupName="Sattempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Year <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddl10passyear" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="7" runat="server" ToolTip="Year">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Month <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddl10passmonth" CssClass=" form-control" onfocus="OnFocus(this);" TabIndex="8" runat="server" ToolTip="Month">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sept</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Total Marks Obtained <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt10marksobtained" ID="txt10marksobtained" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Total Marks Obtained" MaxLength="4" TabIndex="9"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Out of Marks <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt10totalmarks" ID="txt10totalmarks" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Out of Marks " MaxLength="4" TabIndex="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Grade Obtained</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt_grade" ID="txt10_grade" class="uppercase form-control" placeholder="Grade Obtained" TabIndex="11"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Seat No <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt10seatno" ID="txt10seatno" class="uppercase form-control" placeholder="Seat No" TabIndex="12" oninput="allowNumAlpha(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding: 10pt;background: rgba(220, 214, 224, 0.9);">
                                    <div class="col-lg-6"></div>
                                    <div class="col-lg-6 col-xs-12 col-md-12">
                                        <asp:Button ID="btn_ssc_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" TabIndex="13" data-toggle="panel" data-target="#tab" OnClick="btn_ssc_next_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                        <%--<asp:Button ID="btn10" runat="server" Text="Next" class="btn btn-success btn-block topMargin" TabIndex="13" data-toggle="panel" data-target="#tab" OnClick="btnSSC_Click"></asp:Button>--%>
                                    </div>
                                </div>
                                <div class="row" style="background: rgba(220, 214, 224, 0.9);">
                                    <div class="col-lg-12 col-sm-12">
                                        <div runat="server" id="err" visible="false" class="row topMargin alert alert-danger"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- H.S.C. Tab2--%>
                    <div id="tabhsc" class="row" runat="server">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    H.S.C / Diploma
                                </div>
                                <div class="panel-body">
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <asp:CheckBox ID="chk12Diploma" TabIndex="20" runat="server" CssClass="form-control" ToolTip="Is Diploma" Text="Is Diploma" AutoPostBack="True"></asp:CheckBox>
                                        </div>

                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">State <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:DropDownList ID="ddl12StateBoard" TabIndex="14" CssClass="form-control" runat="server" ToolTip="State" AutoPostBack="True" OnSelectedIndexChanged="ddl12StateBoard_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>MAHARASHTRA</asp:ListItem>
                                                <asp:ListItem>ANDHRA PRADESH</asp:ListItem>
                                                <asp:ListItem>ARUNACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>ASSAM</asp:ListItem>
                                                <asp:ListItem>BIHAR</asp:ListItem>
                                                <asp:ListItem>CHHATTISGARH</asp:ListItem>
                                                <asp:ListItem>GOA</asp:ListItem>
                                                <asp:ListItem>GUJARAT</asp:ListItem>
                                                <asp:ListItem>HARYANA</asp:ListItem>
                                                <asp:ListItem>HIMACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>JAMMU AND KASHMIR</asp:ListItem>
                                                <asp:ListItem>JHARKHAND</asp:ListItem>
                                                <asp:ListItem>KARNATAKA</asp:ListItem>
                                                <asp:ListItem>KERALA</asp:ListItem>
                                                <asp:ListItem>MADHYA PRADESH</asp:ListItem>
                                                <asp:ListItem>MANIPUR</asp:ListItem>
                                                <asp:ListItem>MEGHALAYA</asp:ListItem>
                                                <asp:ListItem>MIZORAM</asp:ListItem>
                                                <asp:ListItem>NAGALAND</asp:ListItem>
                                                <asp:ListItem>ORISSA</asp:ListItem>
                                                <asp:ListItem>PUNJAB</asp:ListItem>
                                                <asp:ListItem>RAJASTHAN</asp:ListItem>
                                                <asp:ListItem>SIKKIM</asp:ListItem>
                                                <asp:ListItem>TAMIL NADU</asp:ListItem>
                                                <asp:ListItem>TRIPURA</asp:ListItem>
                                                <asp:ListItem>UTTAR PRADESH</asp:ListItem>
                                                <asp:ListItem>UTTARAKHAND</asp:ListItem>
                                                <asp:ListItem>WEST BENGAL</asp:ListItem>
                                                <asp:ListItem>ANDAMAN AND NICOBAR ISLANDS</asp:ListItem>
                                                <asp:ListItem>CHANDIGARH</asp:ListItem>
                                                <asp:ListItem>DADRA AND NAGAR HAVELI</asp:ListItem>
                                                <asp:ListItem>DAMAN AND DIU</asp:ListItem>
                                                <asp:ListItem>LAKSHADWEEP</asp:ListItem>
                                                <asp:ListItem>NATIONAL CAPITAL TERRITORY OF DELHI</asp:ListItem>
                                                <asp:ListItem>PUDUCHERRY</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Board <span style="COLOR: #ff3333">*</span>&nbsp </span>
                                            <br />
                                            <asp:DropDownList ID="ddl12board" CssClass="form-control" TabIndex="15" runat="server" ToolTip="Select Board">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute Name/College Name<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt12institutename" ID="txt12institutename" class="uppercse form-control" placeholder="Institute Name/College Name" TabIndex="16" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute place<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt12instituteplace" ID="txt12instituteplace" class="upprcase form-control" placeholder="Institute place" TabIndex="17" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <div class="form-inline">
                                                <span style="FONT-FAMILY: Verdana">First Attempt<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                                <asp:RadioButton onblur="OnBlur(this);" ID="rbt12HYes" onfocus="OnFocus(this);" Checked="true" CssClass="form-control" TabIndex="18" runat="server" Text="Yes" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                                <asp:RadioButton onblur="OnBlur(this);" ID="rbt12Hno" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="19" runat="server" Text="No" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Year <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="dd12passyear" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="21" runat="server" Font-Size="10pt" Font-Names="Arial Narrow" Width="106px" ToolTip="Year">
                                                <asp:ListItem>Year</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Month <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="dd12passmonth" onfocus="OnFocus(this);" CssClass="uppercase form-control" TabIndex="22" runat="server" Font-Size="10pt" Font-Names="Verdana" Width="106px" ToolTip="Month">
                                                <asp:ListItem>Month</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sept</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Total Marks Obtained<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt12marksobtained" ID="txt12marksobtained" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Total Marks Obtained" onblur="OnBlur(this);" onfocus="OnFocus(this);" MaxLength="4" TabIndex="23"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Out of Marks<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" onfocus="OnFocus(this);" TabIndex="24" name="txt12totalmarks" ID="txt12totalmarks" class="uppercase form-control" onkeypress="CheckNumeric(event);" MaxLength="4" placeholder="Out of Marks "></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Grade Obtained</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt12grade" ID="txt12grade" class="uppercase form-control" placeholder="Grade Obtained" TabIndex="25"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Seat No<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt12seatno" ID="txt12seatno" class="uppercase form-control" placeholder="Seat No" TabIndex="26" oninput="allowNumAlpha(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding: 10pt;background: rgba(220, 214, 224, 0.9);">
                                    <div class="col-lg-6">
                                        <asp:Button ID="btn_hsc_back" runat="server" Text="Back" class="btn btn-success btn-block topMargin" OnClick="btn_hsc_back_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                        <%--<asp:Button ID="btn12Back" runat="server" Text="Back" OnClick="btn12Back_Click" class="btn btn-success btn-block topMargin" TabIndex="27"></asp:Button>--%>
                                    </div>
                                    <div class="col-lg-6 col-xs-12 col-md-12" style="background: rgba(220, 214, 224, 0.9);">
                                        <asp:Button ID="btn_hsc_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" OnClick="btn_hsc_next_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                        <%--<asp:Button ID="btn12next" runat="server" Text="Next" OnClick="btn12next_Click" class="btn btn-success btn-block topMargin" data-target="#tab" TabIndex="28"></asp:Button>--%>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12 col-sm-12">
                                        <div runat="server" id="err12" visible="false" class="row topMargin alert alert-danger"></div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <%--Graduation--%>
                    <div id="tab_grad" class="row" runat="server">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    GRADUATION
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Graduation Course<span style="COLOR: #ff3333">*</span> </span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" type="text" ID="txtGraduationCourse" class="form-control" placeholder="Graduation Course" TabIndex="56"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">State <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:DropDownList ID="ddlTYstate" TabIndex="56" CssClass="form-control" runat="server" ToolTip="State" AutoPostBack="True" OnSelectedIndexChanged="ddlTYstate_SelectedIndexChanged">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem>MAHARASHTRA</asp:ListItem>
                                                <asp:ListItem>ANDHRA PRADESH</asp:ListItem>
                                                <asp:ListItem>ARUNACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>ASSAM</asp:ListItem>
                                                <asp:ListItem>BIHAR</asp:ListItem>
                                                <asp:ListItem>CHHATTISGARH</asp:ListItem>
                                                <asp:ListItem>GOA</asp:ListItem>
                                                <asp:ListItem>GUJARAT</asp:ListItem>
                                                <asp:ListItem>HARYANA</asp:ListItem>
                                                <asp:ListItem>HIMACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>JAMMU AND KASHMIR</asp:ListItem>
                                                <asp:ListItem>JHARKHAND</asp:ListItem>
                                                <asp:ListItem>KARNATAKA</asp:ListItem>
                                                <asp:ListItem>KERALA</asp:ListItem>
                                                <asp:ListItem>MADHYA PRADESH</asp:ListItem>
                                                <asp:ListItem>MANIPUR</asp:ListItem>
                                                <asp:ListItem>MEGHALAYA</asp:ListItem>
                                                <asp:ListItem>MIZORAM</asp:ListItem>
                                                <asp:ListItem>NAGALAND</asp:ListItem>
                                                <asp:ListItem>ORISSA</asp:ListItem>
                                                <asp:ListItem>PUNJAB</asp:ListItem>
                                                <asp:ListItem>RAJASTHAN</asp:ListItem>
                                                <asp:ListItem>SIKKIM</asp:ListItem>
                                                <asp:ListItem>TAMIL NADU</asp:ListItem>
                                                <asp:ListItem>TRIPURA</asp:ListItem>
                                                <asp:ListItem>UTTAR PRADESH</asp:ListItem>
                                                <asp:ListItem>UTTARAKHAND</asp:ListItem>
                                                <asp:ListItem>WEST BENGAL</asp:ListItem>
                                                <asp:ListItem>ANDAMAN AND NICOBAR ISLANDS</asp:ListItem>
                                                <asp:ListItem>CHANDIGARH</asp:ListItem>
                                                <asp:ListItem>DADRA AND NAGAR HAVELI</asp:ListItem>
                                                <asp:ListItem>DAMAN AND DIU</asp:ListItem>
                                                <asp:ListItem>LAKSHADWEEP</asp:ListItem>
                                                <asp:ListItem>NATIONAL CAPITAL TERRITORY OF DELHI</asp:ListItem>
                                                <asp:ListItem>PUDUCHERRY</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">University <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_graduation_university" ID="txt_graduation_university" class="form-control" placeholder="University Name" TabIndex="58"></asp:TextBox>
                                            <%--<asp:DropDownList ID="ddlTYboard" CssClass="form-control" TabIndex="57" runat="server" ToolTip="Select Board" >
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute Name/College Name<span style="COLOR: #ff3333">*</span> </span>
                                            <asp:TextBox runat="server" type="text" name="txtTYinstitutename" ID="txtTYinstitutename" class="form-control" placeholder="Institute Name/College Name" TabIndex="58" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute place<span style="COLOR: #ff3333">*</span> </span>
                                            <asp:TextBox runat="server" type="text" name="txtTYinstituteplace" ID="txtTYinstituteplace" class="form-control" placeholder="Institute place" TabIndex="59" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-12">
                                            <div class="form-inline">
                                                <span style="FONT-FAMILY: Verdana">First Attempt<span style="COLOR: #ff3333">*</span>
                                                    <asp:RadioButton ID="rbtTYyes" CssClass="form-control" TabIndex="60" runat="server" Checked="true" Text="Yes" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                                    <asp:RadioButton ID="rbtTYno" CssClass="form-control" TabIndex="61" runat="server" Text="No" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Year <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddlTYpassyear" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="62" runat="server" Font-Size="10pt" Font-Names="Arial Narrow" Width="106px" ToolTip="Year">
                                                <asp:ListItem>Year</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Month <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddlTYmonth" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="63" runat="server" Font-Size="10pt" Font-Names="Verdana" Width="106px" ToolTip="Month">
                                                <asp:ListItem>Month</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sept</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Total Marks Obtained <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtTYmarksobtained" ID="txtTYmarksobtained" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Total Marks Obtained" onblur="OnBlur(this);" onfocus="OnFocus(this);" TabIndex="64"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Out of Marks <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" onfocus="OnFocus(this);" TabIndex="65" name="txtTYtotalmarks" ID="txtTYtotalmarks" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Out of Marks "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Grade Obtained<span style="COLOR: #ff3333"></span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txtTYgrade" ID="txtTYgrade" class="uppercase form-control" placeholder="Grade Obtained" TabIndex="66"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Seat No<span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txtTYseatno" ID="txtTYseatno" class="uppercase form-control" placeholder="Seat No" TabIndex="67" oninput="allowNumAlpha(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-12">
                                            <asp:CheckBox ID="chkPG" runat="server" Text="Fill Post Graduation Details" CssClass="form-control" />
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>


                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="Label1" runat="server" Text="Entrance Exam Details"></asp:Label>
                                </div>
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Exam Type<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:DropDownList ID="ddl_examcet_type" runat="server" CssClass="form-control">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>DTE-CET</asp:ListItem>
                                                <asp:ListItem>CAT</asp:ListItem>
                                                <asp:ListItem>MAT</asp:ListItem>
                                                <asp:ListItem>XAT</asp:ListItem>
                                                <asp:ListItem>GMAT</asp:ListItem>
                                                <asp:ListItem>CMAT</asp:ListItem>
                                                <asp:ListItem>ATMA</asp:ListItem>
                                                <asp:ListItem>AMMI CET</asp:ListItem>
                                                <asp:ListItem>OTHERS</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--                                            <asp:TextBox runat="server" type="text" name="txtFYinstitutename" ID="TextBox1" class="form-control" Text="VIVA Institute of Management and Research" placeholder="Institute Name"  ></asp:TextBox>--%>
                                        </div>
                                       <%-- <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Marks Obtained<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_cet_mks_obt" ID="txt_cet_mks_obt" class="form-control" onkeypress="CheckNumeric(event);" placeholder="Marks Obtained"></asp:TextBox>
                                        </div>--%>
                                           <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Percentile<span style="COLOR: #ff3333">*</span>&nbsp</span>

                                            <asp:TextBox runat="server" type="text" name="txt_percentile" ID="txt_percentile" class="form-control" onkeypress="CheckNumeric(event);" placeholder="Entrance Exam Percentage"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                      <%--  <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Marks Out of<span style="COLOR: #ff3333">*</span>&nbsp</span>

                                            <asp:TextBox runat="server" type="text" name="txt_percentile" ID="txt_cet_mks_outof" class="form-control" onkeypress="CheckNumeric(event);" placeholder="Marks Out of"></asp:TextBox>
                                        </div>--%>
                                      
                                    </div>
                                   <%-- <div class="row">
                                         <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana"> Entrance Exam Password<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_entrancepasswd" ID="txt_entrancepasswd" class="form-control"    placeholder="ENTRANCE EXAM Password"></asp:TextBox>
                                        </div>
                                         <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">ENTRANCE EXAM ROLL NO<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_entrance_rollno" ID="txt_entrance_rollno" class="form-control"  placeholder="ENTRANCE EXAM ROLL NO"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                    <div class="row" style="padding: 10pt;background: rgba(220, 214, 224, 0.9);">
                                        <div class="col-lg-6">
                                            <asp:Button ID="btn_graduation_back" runat="server" Text="Back" class="btn btn-success btn-block topMargin" OnClick="btn_graduation_back_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                            <%--<asp:Button ID="btnTyBack" runat="server" Text="Back" OnClick="btnTyBack_Click" class="btn btn-success btn-block topMargin"></asp:Button>--%>
                                        </div>
                                        <div class="col-lg-6 col-xs-12 col-md-12">
                                            <asp:Button ID="btn_graduation_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" OnClick="btn_graduation_next_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                            <%--<asp:Button ID="btnTySave" runat="server" Text="Next" OnClick="btnTySave_Click" class="btn btn-success btn-block topMargin"></asp:Button>--%>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>

                    <%--Post Graduation--%>
                    <div id="tabpg" class="row" runat="server">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    POST GRADUATION
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Post-Graduation Course<span style="COLOR: #ff3333">*</span> </span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox runat="server" type="text" ID="txt_postGraduate_course" class="form-control" placeholder="Post-Graduation Course" TabIndex="56"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">State <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <%--  --%>
                                            <asp:DropDownList ID="ddl_pg_state" TabIndex="56" CssClass="form-control" runat="server" ToolTip="State" AutoPostBack="True" OnSelectedIndexChanged="ddl_pg_state_SelectedIndexChanged">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem>MAHARASHTRA</asp:ListItem>
                                                <asp:ListItem>ANDHRA PRADESH</asp:ListItem>
                                                <asp:ListItem>ARUNACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>ASSAM</asp:ListItem>
                                                <asp:ListItem>BIHAR</asp:ListItem>
                                                <asp:ListItem>CHHATTISGARH</asp:ListItem>
                                                <asp:ListItem>GOA</asp:ListItem>
                                                <asp:ListItem>GUJARAT</asp:ListItem>
                                                <asp:ListItem>HARYANA</asp:ListItem>
                                                <asp:ListItem>HIMACHAL PRADESH</asp:ListItem>
                                                <asp:ListItem>JAMMU AND KASHMIR</asp:ListItem>
                                                <asp:ListItem>JHARKHAND</asp:ListItem>
                                                <asp:ListItem>KARNATAKA</asp:ListItem>
                                                <asp:ListItem>KERALA</asp:ListItem>
                                                <asp:ListItem>MADHYA PRADESH</asp:ListItem>
                                                <asp:ListItem>MANIPUR</asp:ListItem>
                                                <asp:ListItem>MEGHALAYA</asp:ListItem>
                                                <asp:ListItem>MIZORAM</asp:ListItem>
                                                <asp:ListItem>NAGALAND</asp:ListItem>
                                                <asp:ListItem>ORISSA</asp:ListItem>
                                                <asp:ListItem>PUNJAB</asp:ListItem>
                                                <asp:ListItem>RAJASTHAN</asp:ListItem>
                                                <asp:ListItem>SIKKIM</asp:ListItem>
                                                <asp:ListItem>TAMIL NADU</asp:ListItem>
                                                <asp:ListItem>TRIPURA</asp:ListItem>
                                                <asp:ListItem>UTTAR PRADESH</asp:ListItem>
                                                <asp:ListItem>UTTARAKHAND</asp:ListItem>
                                                <asp:ListItem>WEST BENGAL</asp:ListItem>
                                                <asp:ListItem>ANDAMAN AND NICOBAR ISLANDS</asp:ListItem>
                                                <asp:ListItem>CHANDIGARH</asp:ListItem>
                                                <asp:ListItem>DADRA AND NAGAR HAVELI</asp:ListItem>
                                                <asp:ListItem>DAMAN AND DIU</asp:ListItem>
                                                <asp:ListItem>LAKSHADWEEP</asp:ListItem>
                                                <asp:ListItem>NATIONAL CAPITAL TERRITORY OF DELHI</asp:ListItem>
                                                <asp:ListItem>PUDUCHERRY</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--  --%>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">University <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_pg_university" ID="txt_pg_university" class="form-control" placeholder="University Name" TabIndex="58"></asp:TextBox>

                                            <%--<asp:DropDownList ID="ddl_pg_board" CssClass="form-control" TabIndex="57" runat="server" ToolTip="Select Board" >
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute Name/College Name<span style="COLOR: #ff3333">*</span> </span>
                                            <asp:TextBox runat="server" type="text" name="txt_pg_institute_name" ID="txt_pg_institute_name" class="form-control" placeholder="Institute Name/College Name" TabIndex="58" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute place<span style="COLOR: #ff3333">*</span> </span>
                                            <asp:TextBox runat="server" type="text" name="txt_pg_institute_place" ID="txt_pg_institute_place" class="form-control" placeholder="Institute place" TabIndex="59" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-12">
                                            <div class="form-inline">
                                                <span style="FONT-FAMILY: Verdana">First Attempt<span style="COLOR: #ff3333">*</span>
                                                    <asp:RadioButton ID="rbtPgYes" CssClass="form-control" TabIndex="60" runat="server" Checked="true" Text="Yes" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                                    <asp:RadioButton ID="rbtPgNo" CssClass="form-control" TabIndex="61" runat="server" Text="No" AutoPostBack="True" GroupName="attempt" ToolTip="FirstAttempt"></asp:RadioButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Year <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddl_pg_passing_year" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="62" runat="server" Font-Size="10pt" Font-Names="Arial Narrow" Width="106px" ToolTip="Year">
                                                <asp:ListItem>Year</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Passing Month <span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:DropDownList onblur="OnBlur(this);" ID="ddl_pg_passing_month" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="63" runat="server" Font-Size="10pt" Font-Names="Verdana" Width="106px" ToolTip="Month">
                                                <asp:ListItem>Month</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sept</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Total Marks Obtained <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txt_pg_tot_mks_obt" ID="txt_pg_tot_mks_obt" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Total Marks Obtained" onblur="OnBlur(this);" onfocus="OnFocus(this);" TabIndex="64"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Out of Marks <span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" onfocus="OnFocus(this);" TabIndex="65" name="txt_pg_outof_mks" ID="txt_pg_outof_mks" class="uppercase form-control" onkeypress="CheckNumeric(event);" placeholder="Out of Marks "></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Grade Obtained<span style="COLOR: #ff3333"></span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt_pg_grade" ID="txt_pg_grade" class="uppercase form-control" placeholder="Grade Obtained" TabIndex="66"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Seat No<span style="COLOR: #ff3333">*</span> </span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" onblur="OnBlur(this);" name="txt_pg_seat" ID="txt_pg_seat" class="uppercase form-control" placeholder="Seat No" TabIndex="67" oninput="allowNumAlpha(event)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row" style="padding: 10pt;background: rgba(220, 214, 224, 0.9);">
                                        <div class="col-lg-6">
                                            <asp:Button ID="btn_post_graduation_back" runat="server" Text="Back" class="btn btn-success btn-block topMargin" OnClick="btn_post_graduation_back_Click" />
                                            <%--<asp:Button ID="btn_pg_back" runat="server" Text="Back"  class="btn btn-success btn-block topMargin" OnClick="btn_pg_back_Click"></asp:Button>--%>
                                        </div>
                                        <div class="col-lg-6 col-xs-12 col-md-12">
                                            <asp:Button ID="btn_post_graduation_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" OnClick="btn_post_graduation_next_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                            <%--<asp:Button ID="btn_pg_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" OnClick="btn_pg_next_Click"></asp:Button>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- F.Y. Tab3--%>
                    <div id="tabfy" class="row" runat="server">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="lbl_Subcousre12" runat="server" Text="First Year MMS Details"></asp:Label>
                                </div>
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute Name<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtFYinstitutename" ID="txtFYinstitutename" class="form-control" Text="Institute of Management and Research" placeholder="Institute Name" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Institute place<span style="COLOR: #ff3333">*</span>&nbsp</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtFYinstituteplace" Text="Virar" ID="txtFYinstituteplace" class="form-control" placeholder="Institute place" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Enter University Name<span style="COLOR: #ff3333">*</span>&nbsp</span>

                                            <asp:TextBox runat="server" type="text" name="txt_fy_univer" ID="txt_fy_univer" Text="Mumbai University" class="form-control" placeholder="University Name"></asp:TextBox>
                                        </div>
                                    </div>

                                    <%--sem1--%>
                                    <div class="row topMargin" style="margin-right: 5px; margin-left: 5px">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">
                                                SEMISTER 1
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <span style="FONT-FAMILY: Verdana">Sem1 SGPA<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <asp:TextBox ID="txtSem1Sgpi" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>

                                                    </div>
                                                    <%--  <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">SEM 1 Credit Earn<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem1_cre" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="37" runat="server" CssClass="form-control"  MaxLength="4"></asp:TextBox>
                                        </div>
                                      <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">CG<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem1_cg" onfocus="OnFocus(this);" onkeypress="CheckNumeric(event);" TabIndex="37" runat="server" CssClass="form-control"  MaxLength="4"></asp:TextBox>
                                        </div>--%>
                                                </div>
                                                <div class="row topMargin">
                                                    <div class="col-lg-6">
                                                        <span style="FONT-FAMILY: Verdana">Marks Obtain<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <br />
                                                        <asp:TextBox onblur="OnBlur(this);" ID="txt_sem1_mkobtain" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="37" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <span style="FONT-FAMILY: Verdana">Total Marks<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <br />
                                                        <asp:TextBox onblur="OnBlur(this);" onkeypress="CheckNumeric(event);" ID="txt_sem1_ttmks" onfocus="OnFocus(this);" TabIndex="38" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>

                                    </div>

                                    <%--sem2--%>
                                    <div class="row topMargin" style="margin-right: 5px; margin-left: 5px">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">
                                                SEMISTER 2
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <span style="FONT-FAMILY: Verdana">Sem2 SGPA<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <asp:TextBox ID="txtSem2Sgpi" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>

                                                    </div>

                                                    <%-- <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">SEM 2 Credit Earn<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_cre" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="38" runat="server"  CssClass="form-control" MaxLength="4"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">CG<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_cg" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="37" runat="server" CssClass="form-control"  MaxLength="4"></asp:TextBox>
                                        </div>--%>
                                                </div>
                                                <%--<div class="row topMargin">

                                                
                                                
                                    <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">CE<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_ce" onfocus="OnFocus(this);" TabIndex="38" runat="server"  CssClass="form-control" MaxLength="4"></asp:TextBox>
                                        </div><div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">SGPI<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                            <br />
                                            <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_sgpi" onfocus="OnFocus(this);" TabIndex="38" runat="server"  CssClass="form-control" MaxLength="4"></asp:TextBox>
                                        </div>
                                                    </div>--%>

                                                <div class="row topMargin">


                                                    <div class="col-lg-6">
                                                        <span style="FONT-FAMILY: Verdana">Marks Obtain<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <br />
                                                        <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_mkobtain" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="37" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <span style="FONT-FAMILY: Verdana">Total Marks<span style="COLOR: #ff3333">*</span>&nbsp;</span>
                                                        <br />
                                                        <asp:TextBox onblur="OnBlur(this);" ID="txt_sem2_ttmks" onkeypress="CheckNumeric(event);" onfocus="OnFocus(this);" TabIndex="38" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row" style="padding: 10pt;background: rgba(220, 214, 224, 0.9);">
                                    <div class="col-lg-6">
                                        <asp:Button ID="btn_fy_back" runat="server" Text="Back" class="btn btn-success btn-block topMargin" OnClick="btn_fy_back_Click" />
                                        <%--<asp:Button ID="btnFYback" runat="server" Text="Back" OnClick="btnFYback_Click" class="btn btn-success btn-block topMargin" TabIndex="39"></asp:Button>--%>
                                    </div>
                                    <div class="col-lg-6 col-xs-12 col-md-12">
                                        <asp:Button ID="btn_fy_next" runat="server" Text="Next" class="btn btn-success btn-block topMargin" OnClick="btn_fy_next_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"/>
                                        <%--<asp:Button ID="btnFYnext" runat="server" Text="Next" OnClick="btnFYnext_Click" class="btn btn-success btn-block topMargin" TabIndex="40"></asp:Button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                    <%-- CET DETAILS--%>
                </div>
                <div class="row" style="background: rgba(220, 214, 224, 0.9);">
                    <div runat="server" id="errorMessage" visible="false" class="row topMargin alert alert-danger"></div>
                </div>

            </div>
            </div>
            </span></span>
            </span>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
