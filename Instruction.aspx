<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Instruction.aspx.cs" Inherits="Instruction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <style>
        .topMargin {
            margin-top: 15px;
        }
    </style>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <span style="font-family: Verdana; font-size: 18pt"><strong>Documents Instruction</strong></span>
        </div>
        <div class="panel panel-body">
            <div class="row">
               <div class="col-lg-12 col-md-12"> <span style="font-family: Verdana; color: Black">Note: SUBMIT ALL YOUR DOCUMENTS IN COLLEGE FOR FURTHER ADMISSION PROCESS</span></div>
            </div>
            <div class="row topMargin">
                <div class="col-lg-6 col-md-6">
                    <div class="row">
                         <div class="col-lg-6 col-md-6">
                    <asp:CheckBox runat="server" CssClass="form-control" ID="chk_agree" Text="I Agree" />
                    <div style="color: red" runat="server" id="div_remark" visible="false">Please Check I Agree</div>
                        </div>
                        </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <asp:Button ID="btn_next" Text="NEXT" CssClass="form-control btn-default" runat="server" OnClick="btn_next_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
