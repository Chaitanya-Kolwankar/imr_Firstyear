<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forgot_Stud_Id.aspx.cs" Inherits="Forgot_Stud_Id" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .topMargin {
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span style="font-family: Verdana; font-size: 18pt">
                        <center><strong>Student ID</strong></center>
                    </span>
                </div>
                <div class="panel panel-body">
                    <div class="row" style="padding: 14px">
                        <div class="well alert-danger">
                            <%-- <fieldset style="width:auto"><legend style="font-size:10pt">NOTE</legend>--%>
                            <span><strong>NOTE:</strong>1. All Fields Are Required</span><br />
                            <span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp2. Enter Your Details As In Your H.S.C Marksheet.<br />
                                <span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp3. Repeater's & Private Students Are Not Eligible For Inhouse Admission.</span>
                                <%--</fieldset>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <span style="FONT-FAMILY: Verdana">First Name <span style="COLOR: #ff3333">*</span> </span>
                                <br />
                                <asp:TextBox runat="server" type="text" name="first_name" ID="txtFname" class="uppercase form-control" placeholder="First Name" TabIndex="1" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <span style="FONT-FAMILY: Verdana">Last Name <span style="COLOR: #ff3333">*</span> </span>
                                <br />
                                <asp:TextBox runat="server" type="text" name="txtLname" ID="txtLname" class="uppercase form-control" placeholder="Last Name" TabIndex="2" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <span style="FONT-FAMILY: Verdana">Mother Name <span style="COLOR: #ff3333">*</span> </span>
                                <br />
                                <asp:TextBox runat="server" type="text" name="mother_name" ID="txt_moName" class="uppercase form-control" placeholder="Mother Name" TabIndex="3" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <span style="FONT-FAMILY: Verdana">Date of Birth<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-inline">
                                <asp:DropDownList onblur="OnBlur(this);" ID="ddl_day" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="4" runat="server">
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
                                <asp:DropDownList onblur="OnBlur(this);" ID="ddl_month" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="5" runat="server">
                                    <asp:ListItem>Month</asp:ListItem>
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList onblur="OnBlur(this);" ID="ddl_year" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="6" runat="server">
                                    <asp:ListItem>Year</asp:ListItem>
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
                            <span style="FONT-FAMILY: Verdana">Branch<span style="COLOR: #ff3333">*</span></span>
                            <br />
                            <div class="form-inline">
                                <asp:DropDownList onblur="OnBlur(this);" ID="ddl_branch" onfocus="OnFocus(this);" CssClass="form-control" TabIndex="7" runat="server" ToolTip="Branch" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Utkarsh Vidyalaya Junior College Virar</asp:ListItem>
                                    <asp:ListItem>Viva Junior College Of Commerce Nalasopara</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
                    <div class="row topMargin">
                        <div class="col-lg-6" id="div_stud" runat="server" style="FONT-FAMILY: Verdana">
                            Your Student ID is :
                        <asp:Label ID="lbl_stud_id" runat="server" CssClass="form-control"></asp:Label><br />
                        </div>
                    </div>
                    <div class="row">
                        <center> <a href="Basic_Detail.aspx">Click Here To Go Back</a></center>
                    </div>

                    <div id="div_valid" visible="false" runat="server" style="width:auto" class="validation_stud"></div>
                </div>
            </div>
            </span>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

