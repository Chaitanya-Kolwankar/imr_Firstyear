<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseFundTransfer.aspx.cs" Inherits="ResponseFundTransfer" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <style>
        @page {
            size: A4;
        }
        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 0.156em;
            border: 1px solid black;
            font-family:'Times New Roman';
            font-size:15px;
        }
        .data{
            padding:5px;
        }
    </style>
</head>
<body onkeydown="return (event.keyCode !=116)">
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="border: 1px solid black">
                        <div class="row" style="margin-top: 8px;margin-bottom:8px;">
                            <div class="col-lg-3 col-md-2 col-sm-1 col-xs-2"></div>
                           <%-- <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                <img src="images/vivalogon.png" style="height: 100px;"/>
                            </div>
                            <div class="col-lg-5 col-md-5 col-sm-7 col-xs-7" style="text-align: center">
                                <span>VISHNU WAMAN THAKUR CHARITABLE TRUST'S</span><br />
                                <span><b>VIVA INSTITUTE OF MANAGEMENT AND RESEARCH</b></span><br />
                                <span><b>Shirgaon, Virar (East)</b></span><br />
                                <span>(Affiliated to University of Mumbai)</span><br />
                                <span style="font-size: 11px">Shirgaon, Veer Sawarkar road, Virar(East) Tal-Vasai, Dist-Thane, Maharashtra.</span>
                            </div>--%>
                             <div class="col-lg-6 col-md-5 col-sm-7 col-xs-7">
                               <img src="images/applicant-logo.gif" />
                            </div>
                            <div class="col-lg-3 col-md-2 col-sm-1 col-xs-3"></div>
                        </div>

                        <div class="row" style="border-top: 1px dotted black; margin-top: 2px;margin-bottom:5px; font-size: 10px">
                        </div>
                        <div>
                            <div class="row">
                                <center>
                                    <span style="margin-bottom:3px;font-size:15px;font-family:'Times New Roman', Times, serif;font-weight:bold">PAYMENT RECEIPT</span>
                                </center>
                            </div>
                            <div class="row">
                                <span style="float:right;font-size:15px;font-family:'Times New Roman', Times, serif;padding-right:20px"><b>Date : </b><asp:Label ID="lbl_date1" runat="server" Text=""></asp:Label></span>
                            </div>
                            <table class="table">
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Student ID:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblstudentid" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Received from Shri/Smt./Kum.</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lbl_name_1" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Category:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lbl_category_1" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Course:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblcourse" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Amount Of Rs:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblamountdigits" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Amount In Words:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lbl_amount_1" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>VIVA Transaction ID:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblvivatransction" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Bank Transaction ID:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lbltransaction_id" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Payment Status:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblstatus1" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Receipt No:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lbl_no_1" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Bank Name:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblbank" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col-lg-4 col-md-4 col-sm-4 col-xs-4"">
                                        <span class="data"><b>Mode of Payment:</b></span>
                                    </th>
                                    <td>
                                        <span class="data"><asp:Label ID="lblmode" runat="server" Text=""></asp:Label></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-2 col-xs-1"></div>
                </div>
            </div>
            <asp:Label ID="lblStatus" runat="server" Visible="false" Style="margin-top: 10px" Text="" />
        </div>
    </form>
</body>
</html>


