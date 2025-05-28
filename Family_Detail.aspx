<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Family_Detail.aspx.cs" Inherits="FY_Family_Detail" %>

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

        function allowOnlyAlphabetschool(event) {
            let input = event.target;
            let value = input.value;

            value = value.replace(/^\s+/, '');
            value = value.replace(/[^a-zA-Z0-9 ]/g, '');
            value = value.replace(/\s{2,}/g, ' ');
            value = value.replace(/( [a-zA-Z0-9]+)* {5,}/g, '$1    ');
            input.value = value;
        }
    </script>
    
    
    
    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=txtFather_Name.ClientID%>").value == "") {
                alert("Please Enter Father Name");
                document.getElementById("<%=txtFather_Name.ClientID%>").focus();
                return false;
            }
           
            if (document.getElementById("<%=txtfatheroccupation.ClientID%>").value == "--SELECT--") {
                alert("Please Enter Father Occupation");
                document.getElementById("<%=txtfatheroccupation.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtmothername.ClientID%>").value == "") {
                alert("Please Enter Mother Name");
                document.getElementById("<%=txtmothername.ClientID%>").focus();
                return false;
            }
          
            if (document.getElementById("<%=txtmotheroccupation.ClientID%>").value == "--SELECT--") {
                alert("Please Enter Mother Occupation");
                document.getElementById("<%=txtmotheroccupation.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtmothercontactno.ClientID%>").value == "" && (document.getElementById("<%=txtfathercontact.ClientID%>").value == "")) {
                alert("Please Enter Mother/Father Contact No.");
                document.getElementById("<%=txtmothercontactno.ClientID%>").focus();
                return false;
            }
            return true;
        }

    </script><script lang="javascript" type="text/javascript">
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

    </script><script type="text/javascript">

        function Opencaste() {

            window.open("nlogin.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");

            return false;

        }

    </script><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Family Information</strong></span>
                <div class="hidden-lg hidden-md">
                    <a class="btn btn-sm btn-success pull-right" href="FY_Education_Detail.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class=" panel panel-default">
                <div class="panel-heading">
                    <div><span><strong>Father Details</strong></span></div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Father Name<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="father_name" ID="txtFather_Name" class="form-control" placeholder="Father Name *" TabIndex="1" required="true" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Age </span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="age" ID="txtfatherage" class="form-control" onkeypress="CheckNumeric(event);" placeholder="Age " TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Email Id</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="Email_id" ID="txtfatheremail" class="form-control" placeholder="Email Id" TabIndex="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Contact No.<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="Contact_no" ID="txtfathercontact" onkeypress="CheckNumeric(event);" class="form-control" placeholder="Contact No. *" TabIndex="4"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Father Qualification</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="father_quali" ID="txtfatherqualification" class="form-control" placeholder="Father Qualification" TabIndex="5" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Occupation<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:DropDownList ID="txtfatheroccupation" runat="server" CssClass="form-control" TabIndex="6">
                                    <asp:ListItem>Service</asp:ListItem>
                                    <asp:ListItem>Business</asp:ListItem>
                                    <asp:ListItem>Professional</asp:ListItem>
                                    <asp:ListItem>Farmer</asp:ListItem>
                                    <asp:ListItem>Laborer</asp:ListItem>
                                    <asp:ListItem>Retired</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Father Designation</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="Father_design" ID="txtfatherdesignation" class="form-control" placeholder="Father Designation" TabIndex="7" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Father Business/Service Add</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="father_add " ID="txtfatheraddress" class="form-control" placeholder="Father Business/Service Add" TabIndex="8" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=" panel panel-default">
                <div class="panel-heading">
                    <div><span><strong>Mother Details</strong></span></div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                             <span style="font-family: Verdana;">Mother Name<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="mother_name" ID="txtmothername" class="form-control" placeholder="Mother Name *" TabIndex="9" required="true" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                             <span style="font-family: Verdana;">Age</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" onkeypress="CheckNumeric(event);" name="mother_age" ID="txtmotherage" class="form-control" placeholder="Age " TabIndex="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                             <span style="font-family: Verdana;">Email Id</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="mother_id" ID="txtmotheremail_id" class="form-control" placeholder="Email Id" TabIndex="11"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                             <span style="font-family: Verdana;">Contact No<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="Contact_no" ID="txtmothercontactno" onkeypress="CheckNumeric(event);" class="form-control" placeholder="Contact No*" TabIndex="12"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                             <span style="font-family: Verdana;">Mother Qualification</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="father_quali" ID="txtmotherqualification" class="form-control" placeholder="Mother Qualification" TabIndex="13" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                              <span style="font-family: Verdana;">Occupation<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-group">
                                <asp:DropDownList ID="txtmotheroccupation" runat="server" CssClass="form-control" TabIndex="14">
                                    <asp:ListItem>House Wife</asp:ListItem>
                                    <asp:ListItem>Service</asp:ListItem>
                                    <asp:ListItem>Business</asp:ListItem>
                                    <asp:ListItem>Professional</asp:ListItem>
                                    <asp:ListItem>Farmer</asp:ListItem>
                                    <asp:ListItem>Laborer</asp:ListItem>
                                    <asp:ListItem>Retired</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Mother Designation</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="mother_design" ID="txtmotherdesignation" class="form-control" placeholder="Mother Designation" TabIndex="15" oninput="allowOnlyAlphabets(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <span style="font-family: Verdana;">Mother Business/Service Add</span>
                            <br />
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" name="mother_add " ID="txtmotheraddress" class="form-control" placeholder="Mother Business/Service Add" TabIndex="16" oninput="allowOnlyAlphabetschool(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div runat="server" id="errorMessage" visible="false" class="topMargin alert alert-danger"></div>
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <asp:Button ID="btnsave" runat="server" Text="SAVE & CONTINUE" class="btn btn-success btn-block btn-lg topMargin" TabIndex="17" Style="margin-bottom: 15px;background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;" OnClick="btnsave_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

