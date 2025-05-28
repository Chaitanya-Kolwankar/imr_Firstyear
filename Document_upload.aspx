    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Document_upload.aspx.cs" Inherits="Document_upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <style>
        .topMargin {
            margin-top: 20px;
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


    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=filephoto.ClientID%>").value == "") {
                alert("Please Upload Photo");
                document.getElementById("<%=filephoto.ClientID%>").focus();
                return false;
            }
            return true;
        }

    </script>
    <script>
        <%-- function previewImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = document.getElementById('<%= imgphoto.ClientID %>');
                    img.src = e.target.result;
                }
                reader.readAsDataURL(input.files[0]);
            }
        }--%>
            function previewImage(input) {
        // Check if it is a special form upload
        var isSpecialForm = document.getElementById('<%= hdn_isSpecialForm.ClientID %>').value;
        
        if (isSpecialForm === "true") {
            // Do nothing because C# already handled the image
            console.log("Special form detected: skipping previewImage");
            return;
        }

        if (input.files && input.files[0]) {
            var file = input.files[0];

            if (file.type.startsWith('image/')) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = document.getElementById('<%= imgphoto.ClientID %>');
            img.src = e.target.result;
                }
            reader.readAsDataURL(file);
            } else {
                console.log("Selected file is not an image. No preview shown.");
            }
        }
    }
    </script>



    <script type="text/javascript">

        function Opencaste() {

            window.open("nlogin.aspx", "List", "scrollbars=no,resizable=no,width=400,height=280");

            return false;

        }
    </script>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Upload Documents</strong></span>
                <div class="hidden-lg hidden-md">
                    <a class="btn btn-sm btn-success pull-right" href="FY_Other_Information.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                </div>
            </div>
        </div>
        <div class="panel panel-body">
            <div class="row" id="div_image" style="padding: 14px;" runat="server">
                <div class="well alert-danger">
                    <span><strong>NOTE:</strong> (format : jpg, gif, png, jpeg, bmp). Maximum file size alloted :&nbsp;50 KB.</span>
                </div>
            </div>
            <div class="row" id="div_pdf" style="padding: 14px;" runat="server">
                <div class="well alert-danger">
                    <span><strong>NOTE:</strong> (format : pdf). Maximum file size alloted :&nbsp;100 KB.</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3" style="margin-bottom: 18px;">
                    <strong>SELECT DOCUMENT :</strong>
                </div>
                <div class="col-lg-6" style="margin-bottom: 10px;">
                    <asp:DropDownList runat="server" ID="ddl_doc" OnSelectedIndexChanged="ddl_doc_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true">
                        <asp:ListItem>--SELECT--</asp:ListItem>
                        <asp:ListItem>STUDENT_PHOTO</asp:ListItem>
                        <asp:ListItem>STUDENT_SIGNATURE</asp:ListItem>
                        <asp:ListItem>STUDENT_ACKNOWLEDGMENT_FC_CENTER</asp:ListItem>
                        <asp:ListItem>STUDENT_CET_OR_JEE_SCORECARD</asp:ListItem>
                        <asp:ListItem>STUDENT_SEAT_ALLOTMENT_DTE</asp:ListItem>
                        <asp:ListItem>STUDENT_SEAT_ACCEPTANCE(ARC)</asp:ListItem>
                        <asp:ListItem>STUDENT_SSC_MARKSHEET</asp:ListItem>
                        <asp:ListItem>STUDENT_SSC_PASSING_CERTIFICATE</asp:ListItem>
                        <asp:ListItem>STUDENT_HSC_MARKSHEET</asp:ListItem>
                        <asp:ListItem>STUDENT_LEAVING_CERTIFICATE</asp:ListItem>
                        <asp:ListItem>STUDENT_BIRTH_CERTIFICATE</asp:ListItem>
                        <asp:ListItem>STUDENT_AADHARCARD</asp:ListItem>
                        <asp:ListItem>STUDENT_MUMBAI_UNIVERSITY_FORM</asp:ListItem>
                        <asp:ListItem>STUDENT_GAP_CERTIFICATE</asp:ListItem>
                        <asp:ListItem>STUDENT_MIGRATION_CERTIFICATE</asp:ListItem>

                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span style="font-family: Verdana"><strong>Upload Documents</strong></span>
                        </div>
                        <div class="panel panel-body">
                            <div class="row">

                                <div class="alert-info">

                                    <center> <span style="font-family: Verdana"><asp:Label runat="server" ID="lbldocname"></asp:Label><span runat="server" id="lblimp" >*</span>  </span>
                                      </center>
                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <center>
                                <asp:Image ID="imgphoto" runat="server" CssClass="form-control img-responsive"  ImageUrl="" Visible="true" ToolTip="Photo"
                                            Height="200px" Width="200px"></asp:Image>
                                                                        </center>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:FileUpload ID="filephoto" TabIndex="1" CssClass="form-control" runat="server" accept="image/*" ToolTip="Upload Photo" onchange="previewImage(this)"></asp:FileUpload>
                                </div>
                                <asp:HiddenField ID="hdn_isSpecialForm" runat="server" Value="false" />

                                <div class="col-lg-6">
                                    <asp:Button ID="btnuploadphoto" TabIndex="2" runat="server" OnClick="btnuploadphoto_Click" Text="Upload Photo" class="form-control btn-default"></asp:Button>
                                </div>
                            </div>

                            <div class="row">
                                <asp:Label ID="lblErrMsgPhoto" runat="server" CssClass="form-control" Visible="False" Text="Label" Font-Names="Verdana"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4"></div>
                <div class="col-lg-4 col-xs-12 col-md-12">
                    <asp:Button ID="btnsubmit" runat="server" Text="SAVE & CONTINUE" class="btn btn-success btn-block btn-lg topMargin" OnClick="btnsubmit_Click" TabIndex="5" Style="margin-top: 20px;background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

