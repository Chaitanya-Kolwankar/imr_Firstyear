<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="FY_upload" %>

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
    </style>

    <style>
        .topMargin {
            margin-top: 20px;
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
              if (document.getElementById("<%=filesign.ClientID%>").value == "") {
                alert("Please Upload Sign");
                document.getElementById("<%=filesign.ClientID%>").focus();
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
    </script>
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <span style="font-family: Verdana; font-size: 18pt; padding: 10px;"><strong>Upload Photo/Sign</strong></span>
                <div class="hidden-lg hidden-md">
                    <a class="btn btn-sm btn-success pull-right" href="FY_Other_Information.aspx"><i class="fa fa-plus"></i>Previous Page</a>
                </div>
            </div>
        </div>
        <div class="panel panel-body">
            <div class="row" style="padding: 14px;">
                <div class="well alert-danger">
                    <span><strong>NOTE:</strong> (format : jpg, gif, png, jpeg, bmp). Maximum file size alloted :&nbsp;500 KB.</span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span style="font-family: Verdana"><strong>Upload Photo</strong></span>
                        </div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="alert-info">
                                    <center> <span style="font-family: Verdana">Upload your recent passport size
                                                    (3.5 x 4.5cm) color photograph <span style="color: #ff3333">*</span> </span>
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
                                    <asp:FileUpload ID="filephoto" TabIndex="1" CssClass="form-control" runat="server"  accept="image/*" ToolTip="Upload Photo"></asp:FileUpload>
                                </div>
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
                <div class="col-xs-12 col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <span style="font-family: Verdana"><strong>Upload Sign</strong></span>
                        </div>
                        <div class="panel panel-body">
                            <div class="row">
                                <div class="alert-info">
                                    <center>  <span style="font-family: Verdana">Upload your sign <span style="color: #ff3333">*</span>
                                    </span>
                                       </center>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-12">
                                    <center>
                                <asp:Image ID="imgsign" runat="server" CssClass="form-control img-responsive" ImageUrl="" Visible="true" ToolTip="Photo"
                                            Height="200px" Width="200px"></asp:Image>
                                    
                                    </center>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:FileUpload ID="filesign" accept="image/*"  TabIndex="3" CssClass="form-control" runat="server" ToolTip="Upload sign"></asp:FileUpload>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="btnsign"  TabIndex="4" runat="server" Text="Upload Sign" OnClick="btnsign_Click" class="form-control btn-default"></asp:Button>
                                </div>
                            </div>
                            <div class="row topMargin">
                                <asp:Label ID="lblErrMsgSign" runat="server" CssClass="form-control" Visible="False" Text="Label" Font-Names="Verdana"></asp:Label>
                            </div>
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
                    <asp:Button ID="btnsubmit" runat="server" Text="SAVE & CONTINUE" class="btn btn-success btn-block btn-lg topMargin" OnClick="btnsubmit_Click" TabIndex="5" Style="margin-top: 20px;background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

