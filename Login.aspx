<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Online Admission</title>
<link rel="stylesheet" href="css/bootstrap.min.css" />
<script type="text/javascript">
    function validate() {
        if (document.getElementById("<%=txtUserid.ClientID%>").value == "") {
                 alert("Please Enter User ID");
                 document.getElementById("<%=txtUserid.ClientID%>").focus();
                 return false;
             }
             if (document.getElementById("<%=txtPasswd.ClientID%>").value == "") {
                 alert("Please Enter Password");
                 document.getElementById("<%=txtPasswd.ClientID%>").focus();
            return false;
        }
        return true;
    } 32
</script>
<style>
    .topMargin {
        margin-top: 10px;
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

    .well {
        margin: 0
    }


    .panel-footer {
        position: fixed;
        bottom: 0;
        width: 100%;
        background-color: #f1f1f1; /* Adjust as needed */
        padding: 10px 0;
        text-align: center;
    }
</style>

<form id="frm1" runat="server">
    <div class="panel-default">
        <div class="panel-heading">
           
            <center>
                <div style="margin-top: 15px">
                    <!--//logo-->
                    <center>
                        <img id="logo" src="images/mu.png" height="100" alt="Logo" />
                        <p style="font-family: 'Times New Roman'; font-size: 15px; text-align: center">
                            <b>
                                <%--<h5>Shri. Vishnu Waman Thakur Charitable Trust's</h5>--%>
                            </b>
                            <h4 style="font-size: 15pt; font-family: 'Times New Roman'">Affiliated to University Of Mumbai</h4>
                            <h4 style="font-size: 15pt; font-family: 'Verdana'; color: gray">Online Admission</h4>
                        </p>
                    </center>
                </div>
            </center>
        </div>
        <div class="panel-body">
             <br />
            <br />
            <br />
            <br />
            <br />
            <center>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-2"></div>
                    <div class="col-lg-4 col-md-4 col-sm-8 col-xs-12">
                        <div class="panel panel-info" style="height:280px">
                            <div class="panel-heading">LOGIN</div>
                            <div class="panel-body">
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <a title="Click here for Registration!" href="Register.aspx" style="text-decoration: none;" class="thickbox" tabindex="4">Click here for Registration!</a>

                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <input id="txtUserid" runat="server" type="text" class="form-control" placeholder="Username" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                            <input id="txtPasswd" runat="server" type="password" class="form-control" placeholder="Password" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row topMargin">
                                    <div class="col-lg-1"></div>
                                    <div class="col-lg-10" style="margin-top:25px">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" class="form-control btn-primary" OnClick="btnLogin_Click" style="background: linear-gradient(135deg, #FF1493, #1E90FF);color: white;"></asp:Button>
                                    </div>
                                </div>
                                <%--<div class="row topMargin"> 
                            <div class="col-lg-1"> </div>
                            <div class="col-lg-10"> 
                                <a href="forgotpassword.aspx" title="Forgot Password" style="text-decoration:none"><span style="font-size: 12pt; font-family: Verdana;">Forgot Password?</span></a>
                            </div>
                        </div>--%>
                                <div runat="server" id="errorMessage" visible="false" class="row topMargin alert alert-danger"></div>

                            </div>

                            <%-- <div id="Div1" runat="server" class="well alert alert-dismissable">Technical HelpLine No: <strong>8408931470</strong><br/>Contact Timing :- 10am to 5pm</div>--%>
                        </div>
                    </div>
                </div>
            </center>
        </div>
        <div class="panel-footer">
            <center>
                <div class="well">
                    Design and Maintained by <a href="http://www.vssdevelopers.com" style="text-decoration: none">Viva Software Solutions.</a>
                </div>
            </center>
        </div>
    </div>
</form>





