<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apply_Course.aspx.cs" Inherits="FY_Apply_Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />

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

        .panel-primary > .panel-heading {
            color: #fff;
            background-color: #211c6c;
            border-color: #337ab7;
        }

        .well {
            margin-bottom: 0;
        }
    </style>

    <style>
        .topMargin {
            margin-top: 20px;
        }
        .panel-footer {
            padding: 0;
        }

        .panel{
            background: rgba(220, 214, 224, 0.9) !important;
        }

    </style>

    <script type="text/javascript">
        function OnBlur(textBox) {
            textBox.className = '';
            text - transform: uppercase;
        }
        function OnFocus(textBox) {
            textBox.className += ' FocusedStyle';
            text - transform: uppercase;
        }


    </script>
    <script type="text/javascript">

</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Apply Courses</strong></span>
                        <div class="hidden-lg hidden-md">
                            <a class="btn btn-sm btn-success pull-right" href="Document_upload.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                        </div>
                    </div>
                </div>
                <%--F.Y.Apply--%>
                <div id="tab" class="panel panel-body" runat="server">
                    <%-- <div class="row" style="padding: 13px;">
                        <div class="well alert-danger">
                            <span>You can Apply for Multiple courses using this form and take the Print.</span><br />
                            <span><strong>Note:</strong>  Select the Previous Faculty carefully you cannot change later.</span>
                        </div>
                    </div>--%>
                    <div class="panel panel-default topMargin">
                        <div class="panel-body">
                            <div class="row">
                                <%-- <div class="col-lg-6 col-md-6">
                                    <span style="FONT-FAMILY: Verdana"><span style="COLOR: #ff3333"></span>Previous Faculty<span style="color: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddpreviousfaculty" ToolTip="Previous Faculty" CssClass="uppercase form-control" onfocus="OnFocus(this);" TabIndex="1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddpreviousfaculty_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                      
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col-lg-6 col-md-6">
                                    <span style="font-family: Verdana">Course<span style="color: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddl_course" onfocus="OnFocus(this);" ToolTip="Course" TabIndex="1" runat="server" AutoPostBack="True" CssClass="uppercase form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<br />
                            <div class="row">
                                <div class="col-lg-6 col-md-6">
                                    <span style="FONT-FAMILY: Verdana">Class<span style="color: #ff3333">*</span> </span>
                                    <br />
                                    <asp:DropDownList onblur="OnBlur(this);" ID="ddgroup" onfocus="OnFocus(this);" ToolTip="Class" CssClass="uppercase form-control" TabIndex="3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddgroup_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-6 col-md-6">
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <%-- <div class="panel panel-default topMargin" id="unv_no_panel" runat="server">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <span style="FONT-FAMILY: Verdana">
                                        <asp:Label ID="lblUniv_enrol_no" runat="server" Text="University Application Number for Course"></asp:Label>
                                        <%--<asp:Label ID="lblApplicationCourse" runat="server"></asp:Label></span>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox onblur="OnBlur(this);" ID="txtuniversity" onfocus="OnFocus(this);" TabIndex="4" ToolTip="Enter your University Enrolled Number" runat="server" AutoPostBack="True" CssClass="uppercase form-control"></asp:TextBox>
                                    <span>If you don't have University Application Number for this Course: &nbsp<a href="http://mum.digitaluniversity.ac/" target="_blank">Click Here</a></span>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div class="row topMargin">
                        <div class="col-lg-12 col-md-12">
                            <div class="panel panel-danger">
                                <div class="panel-heading">I AGREE</div>
                                <div class="panel-body">
                                    Declaration:
                              <br />
                                    <asp:CheckBox ID="chkIAgree" TabIndex="2" runat="server" Text="I AGREE" CssClass="form-control" AutoPostBack="True" ToolTip="I AGREE"></asp:CheckBox>
                                    <%--  I hereby declare that, I have read the rules related to admission and the information filled by me in this form is accurate and true to the best of my knowledge. I will be responsible for any discrepancy, arising out of the form signed by me and I undertake that, in absence of any document the final admission will not be granted and/or admission will stand cancelled.
                              <br />
                                    <br />
                                    Note: Students from Backward class may please note that their freeship/scholarship form is subject to official sanctioning from the government.
                              Students offering/studying in profession courses should continue to study the same till their graduation.They will not be allowed change of stream.<br />
                                    <br />
                                    students writing any negative and offensive remark about any staff member or institution on any social networking website may be booked under cyber crime law, Indian I.T Act 2000.--%>
                                </div>
                            </div>
                        </div>

                    </div>
                    <%--   <div runat="server" visible="false" id="scholardiv">
                        Notice For Freeship Scholarship Format Kindly <a id="lnkResume" href="pdf/NOTICE%20scholarship%2019-20.docx">Click Here</a>
                    </div>--%>
                    <div class="row">
                        <div runat="server" id="div_valid" visible="false" class="row topMargin alert alert-danger"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-4">
                            <asp:Button ID="btnApply" runat="server" Text="Apply" class="btn btn-primary btn-block" TabIndex="3" Style="margin-bottom: 15px" OnClick="btnApply_Click"></asp:Button>
                        </div>
                        <div class="col-lg-4"></div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12">
                            <div class="table-responsive">
                                <asp:GridView ID="dgvData" runat="server" class="table table-hover table-striped" DataKeyNames="group_id,Group_title" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False"
                                    OnSelectedIndexChanged="dgvData_SelectedIndexChanged" OnRowCommand="dgvData_RowCommand" OnRowDeleting="dgvData_RowDeleting">
                                    <RowStyle HorizontalAlign="Center" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Previous Faculty" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFaculty" runat="server" Text='<%# Eval("pre_faculty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Course">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCourse" runat="server" Text='<%# Eval("course_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subcourse" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcourse" runat="server" Text='<%# Eval("subcourse_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroup" runat="server" Text='<%# Eval("Group_title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Groupid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupid" runat="server" Text='<%# Eval("group_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ButtonType="Link" ShowDeleteButton="true" HeaderText="Cancel"></asp:CommandField>
                                        <asp:TemplateField HeaderText="PRINT">
                                            <ItemTemplate>
                                                <asp:Button ID="btnPrint" runat="server" Text="PRINT" CommandName="print" CssClass="btn btn-warning" OnClientClick="aspnetForm.target ='_blank'"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Form Fees">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ff" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fees Amount" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fee_amt" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fees Amount To Paid">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_amt_pay" runat="server" Text='<%# Eval("Amount") %>' onkeypress="CheckNumeric(event);" Enabled="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Admission">
                                            <ItemTemplate>
                                                <asp:Button ID="btn_confirm_add" runat="server" Text="Confirm Admission" CssClass="btn btn-primary" CommandName="Confirm" Visible="false" OnClientClick="aspnetForm.target ='_blank'"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%-- <asp:TemplateField HeaderText="Offline" Visible="false">
                                            <ItemTemplate>
                                                <asp:Button ID="btn_off" Visible="false" runat="server" Text="OFFLINE" CssClass="btn btn-primary" ></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--  <asp:TemplateField HeaderText="Bank Payment Slip">
                                            <ItemTemplate>
                                                <asp:Button ID="btn_reciept" Visible="false" runat="server" CommandName="recipt_data" OnClick="btn_reciept_Click" Text="Bank Payment Slip" CssClass="btn btn-primary" OnClientClick="aspnetForm.target ='_blank'"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Form No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_frm_grp" runat="server" Style="text-transform: uppercase" Text='<%# Eval("formno_grp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Admission status">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ad_stat" runat="server" Text='<%# Eval("ad_status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <EditRowStyle BackColor="#999999"></EditRowStyle>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 col-md-12">
                        <div class="row" style="background-color: wheat" runat="server" id="div_com" visible="false">
                            <div class="col-lg-12 col-md-12">
                                <br />
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:Label ID="group_id" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="subcourse" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="tot_fees" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="fees" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-lg-2">
                                                <asp:Label ID="stat" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <%--   <asp:Label ID="msg" runat="server" Style="color: green; font-size: 20px; font-family: Century"></asp:Label>
                                        <br />
                                        <asp:Label ID="Fee_stat" runat="server" Visible="false" Style="color: red; font-size: 20px; font-family: Century"></asp:Label>
                                        <br />--%>
                                        <div class="row">
                                            <div class="col-lg-4" style="color: green; font-size: 20px; font-family: Century">Amount To Pay:</div>
                                            <div class="col-lg-2">
                                                <asp:TextBox ID="txt_amount_final" MaxLength="8" CssClass="form-control" runat="server" onkeypress="CheckNumeric(event);" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btn_confirm" Width="100%" runat="server" CssClass="btn btn-success" Text="PAY" OnClick="btn_confirm_Click" />
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btn_cancel" Width="100%" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btn_cancel_Click" />
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row" runat="server" id="msgDiv">
                                            <center>
                                                <div id="divMsg" class="col-lg-12" style="margin-top: 5px">
                                                    <strong>
                                                        <asp:Label ID="lbl_msg" runat="server">  </asp:Label>
                                                    </strong>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
        </ContentTemplate>
        <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlpgFaculty" EventName="SelectedIndexChanged" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
