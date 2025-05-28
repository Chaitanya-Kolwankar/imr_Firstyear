<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Personal_Detail.aspx.cs" Inherits="FY_Personal_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
        .topMargin {
            margin-top: 15px;
        }
        .panel-footer {
            padding: 0;
        }
        .well{
            margin-bottom:0;
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
    </style>

    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=txtplaceofbirth.ClientID%>").value == "") {
                alert("Please Enter Birth Place");
                document.getElementById("<%=txtplaceofbirth.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtadddress1.ClientID%>").value == "") {
                alert("Please Enter address in line 1");
                document.getElementById("<%=txtadddress1.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtadddress2.ClientID%>").value == "") {
                alert("Please Enter address in line 2");
                document.getElementById("<%=txtadddress2.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtadddress3.ClientID%>").value == "") {
                alert("Please Enter address in line 3");
                document.getElementById("<%=txtadddress3.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtpincode.ClientID%>").value == "") {
                alert("Please Enter PinCode");
                document.getElementById("<%=txtpincode.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtCity.ClientID%>").value == "") {
                alert("Please Enter city");
                document.getElementById("<%=txtCity.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddlState.ClientID%>").value == "--SELECT--") {
                alert("Please Enter state");
                document.getElementById("<%=ddlState.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=ddReligion.ClientID%>").value == "--SELECT--") {
                alert("Please Select Religion");
                document.getElementById("<%=ddReligion.ClientID%>").focus();
                return false;
            }

            return true;
        }

    </script>
    <script type="text/javascript">

        function Opencaste() {

            window.open("nlogin.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");

            return false;

        }
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
    <style type="text/css">
        .td_class {
            width: auto;
        }

        .auto-style1 {
            width: 308px;
        }

        .auto-style2 {
            width: 311px;
        }

        .auto-style3 {
            width: 457px;
        }

        .auto-style4 {
            width: 314px;
        }
    </style>

    <script>

        function allowOnlyAlphabets(event) {
            let input = event.target;
            input.value = input.value.replace(/[^a-zA-Z]/g, ''); // Remove non-alphabet characters
        }

    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Personal Details</strong></span>
                        <div class="hidden-lg hidden-md">
                            <a class="btn btn-sm btn-success pull-right" href="Basic_Detail.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                        </div>
                    </div>
                </div>
                <div class="panel panel-body">
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6 form-inline">
                                    Gender<span style="COLOR: #ff3333"> *</span>
                                    <asp:RadioButton onblur="OnBlur(this);" ID="rbtmale" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="1" runat="server" Text="Male" GroupName="gender" ToolTip="GENDER"></asp:RadioButton>
                                    <asp:RadioButton onblur="OnBlur(this);" ID="rbtfemale" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="2" runat="server" Text="Female" GroupName="gender" ToolTip="GENDER"></asp:RadioButton>

                                </div>
                                <div class="col-lg-6 form-inline">
                                    Blood Group
                            <asp:DropDownList onblur="OnBlur(this);" ID="ddbloodgroup" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="3" runat="server" ToolTip="Select Blood Group If Known">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>A +ve</asp:ListItem>
                                <asp:ListItem>A -ve</asp:ListItem>
                                <asp:ListItem>B +ve</asp:ListItem>
                                <asp:ListItem>B -ve</asp:ListItem>
                                <asp:ListItem>AB +ve</asp:ListItem>
                                <asp:ListItem>AB -ve</asp:ListItem>
                                <asp:ListItem>O +ve</asp:ListItem>
                                <asp:ListItem>O -ve</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row topMargin">
                                <div class="col-lg-6">
                                    <span style="FONT-FAMILY: Verdana">Place of Birth <span style="COLOR: #ff3333">*</span> </span>
                                    <br />
                                    <asp:TextBox runat="server" type="text" name="last_name" ID="txtplaceofbirth" class="form-control" placeholder="Place of Birth *" TabIndex="4" required="true" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                </div>

                                <div class="col-lg-6">
                                    <span style="FONT-FAMILY: Verdana">Domiciled In</span>
                                    <br />
                                    <asp:TextBox runat="server" type="text" name="txtdomicile" ID="txtdomicile" class="form-control" placeholder="Domiciled In" TabIndex="5" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row topMargin">
                        <div class="col-xs-12 col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <span style="FONT-FAMILY: Verdana">Address <span style="COLOR: #ff3333">*</span></span>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Flat no./bldg</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtadddress1" ID="txtadddress1" class="form-control" placeholder="Flat no./bldg" TabIndex="6" required="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Area</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtadddress2" ID="txtadddress2" class="form-control" placeholder="Area" TabIndex="7" required="true"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Street</span>
                                            <asp:TextBox runat="server" type="text" name="txtadddress3" ID="txtadddress3" class="form-control" placeholder="Street" TabIndex="8" required="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">Pincode</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtpincode" ID="txtpincode" class="form-control" placeholder="Pincode" TabIndex="9" required="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row topMargin">
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">State</span>
                                            <br />
                                            <div class="form-group">
                                                <asp:DropDownList onblur="OnBlur(this);" ID="ddlState" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="10" runat="server" ToolTip="STATE">
                                                    <asp:ListItem>--SELECT--</asp:ListItem>
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
                                                    <asp:ListItem>MAHARASHTRA</asp:ListItem>
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
                                        </div>
                                        <div class="col-lg-6">
                                            <span style="FONT-FAMILY: Verdana">City</span>
                                            <br />
                                            <asp:TextBox runat="server" type="text" name="txtCity" ID="txtCity" class="form-control" placeholder="City" TabIndex="11" required="true" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
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
                                    <span style="FONT-FAMILY: Verdana">Martial Status <span style="COLOR: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddmarried" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="12" runat="server" ToolTip="Martial Status">
                                        <asp:ListItem>UNMARRIED</asp:ListItem>
                                        <asp:ListItem>MARRIED</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-6">
                                    <span style="FONT-SIZE: 10pt; FONT-FAMILY: Verdana">Religion<span style="COLOR: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddReligion" CssClass="form-control" onfocus="OnFocus(this);" TabIndex="13" runat="server" ToolTip="Religion">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>HINDU</asp:ListItem>
                                        <asp:ListItem>MUSLIM</asp:ListItem>
                                        <asp:ListItem>CHRISTIAN</asp:ListItem>
                                        <asp:ListItem>SIKH</asp:ListItem>
                                        <asp:ListItem>JAIN</asp:ListItem>
                                        <asp:ListItem>PARSI</asp:ListItem>
                                        <asp:ListItem>BUDDHIST</asp:ListItem>
                                        <asp:ListItem>INDIGENOUS FAITH</asp:ListItem>
                                        <asp:ListItem>ZORASTRIANISM</asp:ListItem>
                                        <asp:ListItem>JUDAISM</asp:ListItem>
                                        <asp:ListItem>OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div runat="server" id="errorMessage" visible="false" class="alert alert-danger"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4 col-xs-12 col-md-12">
                            <asp:Button ID="btnsubmit" runat="server" Text="SAVE & CONTINUE" class="btn btn-success btn-block btn-lg topMargin" TabIndex="16" Style="margin-top: 20px; height: 51px;background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;" OnClick="btnsubmit_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

