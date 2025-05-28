<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebReport.aspx.cs" Inherits="WebReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="css/bootstrap.min.css" rel="stylesheet" />--%>
    <style type="text/css">
        .break {
            page-break-before: always;
        }

        .auto-style9 {
            width: 125px;
            height: 47px;
        }

        .auto-style11 {
            width: 95px;
        }

        .auto-style18 {
            height: 40px;
            width: 158px;
        }

        .auto-style20 {
            height: 5px;
            width: 95px;
        }

        .auto-style21 {
            width: 17%;
            height: 5px;
        }

        .auto-style22 {
            width: 17%;
        }

        .auto-style35 {
            width: 303px;
        }

        .auto-style37 {
            height: 1px;
            width: 614px;
        }

        .auto-style43 {
            width: 168px;
        }

        .auto-style45 {
            width: 258px;
        }

        .auto-style46 {
            width: 258px;
            height: 23px;
        }

        .auto-style47 {
            height: 23px;
            width: 171px;
        }

        .auto-style49 {
            width: 119px;
        }

        .auto-style50 {
            width: 203px;
        }

        .auto-style51 {
            width: 83px;
        }

        .auto-style53 {
            width: 174px;
        }

        .auto-style56 {
            width: 126px;
        }

        .auto-style57 {
            width: 85px;
        }

        .auto-style60 {
            width: 185px;
        }

        .auto-style61 {
            width: 522px;
        }

        .auto-style68 {
            width: 129px;
        }

        .auto-style71 {
            width: 352px;
        }

        .auto-style72 {
            width: 229px;
        }
        /*@media print {
        html, body {
            width: 210mm;
            height: 297mm;        
        }*/


        }
    </style>
    <link href="css/style_report.css" rel="stylesheet" />
    <script type="text/javascript">
        window.print();
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black; padding: 10px">
            <div>
                <table style="width: 100%; border-color: black">
                    <tr>
                        <td>
                            <table style="height: 50px; border: groove">
                                <tr>
                                    <td style="width: 120px; height: 30px">
                                        <span style="font-weight: bold; font-size: 15px; color: #000000">Office Staff</span>&nbsp;<br />
                                        &nbsp;<br />
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td>
                            <table style="height: 50px; border: groove">
                                <tr>
                                    <td style="width: 120px; height: 30px">
                                        <span style="font-weight: bold; font-size: 15px; color: #000000">Verified By</span>&nbsp;<br />
                                        &nbsp;</td>
                                </tr>

                            </table>
                        </td>

                        <td>
                            <table style="height: 50px; border: groove">
                                <tr>
                                    <td style="width: 120px; height: 30px">
                                        <span style="font-weight: bold; font-size: 15px; color: #000000">Form No</span>&nbsp;<br />
                                        &nbsp;
                                <asp:Label ID="lblform" runat="server"></asp:Label>

                                    </td>
                                </tr>

                            </table>
                        </td>

                    </tr>
                </table>
            </div>

            <table style="width: 100%; height: 90px">
                <tr>
                    <td style="text-align: center" class="auto-style9">
                        <%-- <img src="images/logo.gif" />--%>
                        <%--<img src="logo.gif" style="width: 115px; height: 109px" alt="" />--%>
                        <img src="images/mu.png" style="height: 90px" alt="" />
                    </td>

                    <td style="text-align: center; height: 30px">

                        <%--<span style="font-weight: normal; color: #000000; font-size: 12px; margin-top:10px"> VISHNU WAMAN THAKUR CHARITABLE TRUST'S
                        </span>--%>
                        <div style="font-weight: bold; font-size: 15px; word-spacing: 3px; color: #000000; line-height: 14px;">
                            INSTITUTE OF MANAGEMENT AND RESEARCH<br />
                            <span style="font-size: 12px; word-spacing: 2px; color: #000000"><%--Shirgaon, Virar (East)--%> Mumbai</span><br />
                            <span style="font-size: 14px; word-spacing: 2px; color: #000000"><%--(Approved by AICTE & DTE)--%></span><br />
                            (<b style="box-sizing: border-box; font-weight: 600; color: rgb(68, 68, 68); font-family: 'Times New Roman'; font-size: 15px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 28.5714px; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">Affiliated<span class="Apple-converted-space">&nbsp;</span></b>to the University of Mumbai)<br />
                        </div>
                    </td>
                    <td style="text-align: center" class="auto-style9">

                        <%--          <asp:Image ID="Image1" runat="server" />--%>
                        <asp:Image ID="img1" runat="server" ImageUrl="~/0022.jpg" Height="90px" Width="90px" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3" style="text-align: center; padding-left: 120px; border: groove; height: 5px">
                        <span style="font-weight: bold; font-size: 16px; word-spacing: 2px; color: #000000;">ADMISSION FORM FOR </span>&nbsp;
             <asp:Label ID="grp_name" runat="server" Text="" Style="font-weight: bold; width: auto; font-size: 16px; color: #000000"> </asp:Label>&nbsp;
             <span style="font-weight: bold; font-size: 16px; color: #000000">2021-2022</span>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <%--<asp:Label ID="lblinhouse" style="font-size:16px" runat="server"></asp:Label>--%>
                        <%--<asp:Label ID="lbl_dte_Institute" runat="server" Text="" Style="font-weight: bold; width: auto; font-size: 16px; color: #000000"> </asp:Label>--%>

                    </td>
                </tr>
            </table>

            <table style="width: 100%">
                <tr>
                    <td style="height: 5px">
                        <asp:Label ID="name" runat="server" Text="1.Full Name: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>

                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 14px; font-weight: bold; word-spacing: 5px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblName" runat="server"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="address" runat="server" Text="2.Address: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                        <%-- <asp:Image ID="Image1" runat ="server" ImageUrl="~/images/line.png" Height="1px" Width="558px" />--%>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 5px; font-family: sans-serif">
                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="mobNo" runat="server" Text="3.Mobile No: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblmobNo" runat="server"></asp:Label>
                    </td>

                    <td class="auto-style21">
                        <asp:Label ID="phoneNo" runat="server" Text="4.Phone Number: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblphoneNo" runat="server"></asp:Label>
                    </td>


                </tr>

                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="email" runat="server" Text="5.Email Id: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>

                    <td class="auto-style22">
                        <asp:Label ID="gender" runat="server" Text="6.Gender: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                    </td>


                </tr>

                <tr>

                    <td class="auto-style20">
                        <asp:Label ID="Label1" runat="server" Text="7.Category: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblcategory" runat="server"></asp:Label>

                    </td>

                    <td class="auto-style22">
                        <asp:Label ID="sub_caste" runat="server" Text="8.Caste: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblcaste" runat="server"></asp:Label>
                    </td>


                </tr>

                <tr>

                    <td class="auto-style20">
                        <asp:Label ID="blood" runat="server" Text="9.Blood Group: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblBlood" runat="server"></asp:Label>
                    </td>

                    <td class="auto-style22">
                        <asp:Label ID="Dob" runat="server" Text="10.Date Of Birth: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblDob" runat="server"></asp:Label>
                    </td>

                </tr>

                <tr>
                    <td class="auto-style20">
                        <asp:Label ID="Birthplace" runat="server" Text="11.Birth Place: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblBirthPlace" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style22">
                        <asp:Label ID="category" runat="server" Text="12.Marital Status: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblmarital" runat="server"></asp:Label>
                    </td>


                </tr>
            </table>
            <table>

                <tr>
                    <td class="auto-style72">
                        <asp:Label ID="Label2" runat="server" Text="13.Physically Challenged: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style71">
                        <asp:Label ID="lblphy" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style68">
                        <asp:Label ID="Label3" runat="server" Text="14.Religion: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblreligion" runat="server"></asp:Label>
                    </td>

                </tr>

            </table>
            <table>
                <tr>
                    <td class="auto-style43">
                        <asp:Label ID="apply" runat="server" Text="15.Special Category : " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>

                    </td>
                    <td colspan="3" style="border-bottom: thin solid #000000; font-size: 12px; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style37">
                        <asp:Label ID="lbl_specialcategory" runat="server"></asp:Label>
                    </td>


                </tr>


            </table>
            <table style="width: 100%">
                <tr>
                    <td class="auto-style35">
                        <asp:Label ID="lblfreeship" runat="server" Text="16.Are You Applying for Freeship/Scholarship: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>

                    </td>
                    <td colspan="3" style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px">
                        <asp:Label ID="lbl_is_Scholarship" runat="server"></asp:Label>
                        <%--  <asp:Label  ID ="lblApply" runat ="server"  text="___________________________________________________" style="text-decoration: underline"></asp:Label>--%>
                    </td>
                </tr>
            </table>
            <table>

                <tr>
                    <td class="auto-style72">
                        <asp:Label ID="Label7" runat="server" Text="17.Aadhar Card: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style71">
                        <asp:Label ID="lblaadhar" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style68">
                        <asp:Label ID="Label9" runat="server" Text="18.DTE/ARA ID: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblate" runat="server"></asp:Label>
                    </td>

                </tr>

            </table>
            <table>
                <tr>
                    <td style="width: 220px; height: 21px">
                        <asp:Label ID="Label8" runat="server" Text="19.Cast Validity/Receipt No.:" Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label></td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblcerrec" runat="server" Font-Bold="False" Font-Underline="False" Font-Names="Georgia"></asp:Label></td>
                    <td class="auto-style68">
                        <asp:Label ID="Label10" runat="server" Text="20.Cast Validity: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label></td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblcerdt" runat="server" Font-Bold="False" Font-Underline="False" Font-Names="Georgia"></asp:Label></td>

                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 255px; height: 21px">
                        <asp:Label ID="Label11" runat="server" Text="21.Income Certif. No.:" Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label></td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblincrec" runat="server" Font-Bold="False" Font-Underline="False" Font-Names="Georgia"></asp:Label></td>
                    <td style="width: 190px; height: 21px">
                        <asp:Label ID="Label12" runat="server" Text="22. Certificate Date:" Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label></td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; margin-left: 100px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin; width: 250px">
                        <asp:Label ID="lblincdt" runat="server" Font-Bold="False" Font-Underline="False" Font-Names="Georgia"></asp:Label></td>
                </tr>
            </table>
            <div style="width: 100%">
                <table border="1" style="table-layout: auto">
                    <tr>
                        <td>
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Exam</span>
                        </td>
                        <td style="width: 1000px">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Board/University</span>
                        </td>
                        <td style="width: 1000px">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Institute Name</span>

                        </td>
                        <td align="center">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">First Attempt</span>
                        </td>
                        <td align="center">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Passed In</span>

                        </td>
                        <td align="center">
                            <span style="font-weight: bold; font-size: 15px; color: #000000;">Seat No</span>

                        </td>
                        <td align="center">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Marks Obtnd</span>

                        </td>
                        <td align="center">
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Out Of</span>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblexam" runat="server" Text="S.S.C." Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblboard" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblschool" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblfirst" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMonthYear" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblseatNo" runat="server" Style="font-size: medium; padding-left: 15px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblmarksobtain" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblmarksoutoff" runat="server" Style="font-size: medium; padding-left: 5px"></asp:Label>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="lblexam1" runat="server" Text="H.S.C." Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblBoard1" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblcolgname1" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblfirst1" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMonthYear_1" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblseatNo_1" runat="server" Style="font-size: medium; padding-left: 15px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblmarksobtain_1" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblmarksoutoff_1" runat="server" Style="font-size: medium; padding-left: 5px"></asp:Label>

                        </td>

                    </tr>


                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Graduation" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradBoard" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradInstitute" runat="server" Style="font-size: x-small"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradFirst" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGradPassMonth" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradSeat" runat="server" Style="font-size: medium; padding-left: 15px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradMrksObt" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblGradMrksOut" runat="server" Style="font-size: medium; padding-left: 5px"></asp:Label>

                        </td>

                    </tr>
                    <div id="pgDetail" runat="server">
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Post Graduation" Style="font-size: x-small"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGBosrd" runat="server" Style="font-size: x-small"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGInst" runat="server" Style="font-size: x-small"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGFirst" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPGpassMnt" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGSeat" runat="server" Style="font-size: medium; padding-left: 15px"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGMrksObt" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                            </td>
                            <td>
                                <asp:Label ID="lblPGMrksOut" runat="server" Style="font-size: medium; padding-left: 5px"></asp:Label>

                            </td>

                        </tr>
                    </div>

                </table>
                <table style="width: 100%" border="1" runat="server" id="FYTable">
                    <tr>
                        <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Course/University</span></td>
                        <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">College Name</span></td>
                        <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem1 SGPA</span></td>
                        <td align="center" colspan="2"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem2 SGPA</span></td>
                        <%--                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">CE</span></td>--%>
                        <%-- <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">CG</span></td>--%>
                        <%--<td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">SGPI</span></td>--%>
                    </tr>
                    <tr>
                        <td align="center" rowspan="2">
                            <asp:Label ID="lbl_univers" runat="server" Style="font-size: 15px"></asp:Label></td>
                        <td align="center" rowspan="2">
                            <asp:Label ID="lbl_colg_name" runat="server" Style="font-size: 15px"></asp:Label></td>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbl_sem1_Sgpi" runat="server" Style="font-size: 15px"></asp:Label></td>
                        <td align="center">
                            <asp:Label ID="lbl_sem2_sgpi" runat="server" Style="font-size: 15px"></asp:Label></td>
                        <%--                    <td align="center"><asp:Label ID="lbl_sem1_ce" runat="server" Style="font-size:  15px"></asp:Label></td>--%>
                        <%--<td align="center"><asp:Label ID="lbl_sem1_cg" runat="server" Style="font-size:  15px"></asp:Label></td>--%>
                        <%--   <td align="center"><asp:Label ID="lbl_sem1_sgpi" runat="server" Style="font-size:  15px"></asp:Label></td>--%>
                    </tr>

                </table>


            </div>
            <br />
            <div class="col-lg-12  col-md-12 col-sm-12 col-xs-12" style="border-bottom: 1px solid black">
                <asp:Label ID="lbl_exam_type" runat="server" Text=""></asp:Label>
            </div>
            <table style="width: 100%">
                <%-- <tr>
                <td colspan="3" class="auto-style8"></td>
            </tr>--%>
                <tr>
                    <td colspan="3">
                        <span style="font-weight: bold; color: #000000; font-size: 12px;">Declaration by Student: </span>

                        <span style="font-size: 12px; font-family: 'Times New Roman'">I hereby declare that, I have read the rules related to admission as well as the college rules also and the information filled by me in this form is accurate and true to the best of my knowledge. I will be responsible for any discrepancy, arising out of the form signed by me and I undertake that, in absence of any document the final admission will not be granted and/or admission will stand cancelled. 
	Note: Students from Reserved Category class may please note that their freeship/scholarship form is subject to official sanctioning from the government.
	Students writing any negative and offensive remark about any staff member or institution on any social networking website may be booked under cyber crime law, Indian I.T Act 2000.
                        </span>
                        <br />
                    </td>
                </tr>

                <%--<tr>
                <td class="auto-style4" style="text-align :center " >
                     <asp:Label  ID ="Label2" runat ="server" Text ="Student Signature  : " style="font-weight: bold; font-size: large; color: #000000"></asp:Label>
                </td>

                <td class="auto-style4">

                </td>

                <td class="auto-style4"  style="text-align :center ">
                     <asp:Label  ID ="Label4" runat ="server" Text ="Parent Signature  : " style="font-weight: bold; font-size: large; color: #000000"></asp:Label>
                </td>
            </tr>--%>
            </table>


            <table style="width: 98%; height: 89px;">

                <tr>
                    <td class="auto-style60">
                        <br />
                        <div style="float: left">
                            <asp:Label ID="studSign" runat="server" Text="__________________"> </asp:Label><br />
                            Student's Signature   
                        </div>
                    </td>

                    <%--<td rowspan="1" class="auto-style61" style="margin-left:10px"  align="center" >
                        <asp:PlaceHolder ID="plBarCode" runat="server" />

                    </td>--%>
                    <td rowspan="1" style="width: 100%; text-align: center">
                        <%--     &nbsp;<asp:Image ID="qr_code"  Width="100px" Height="100px" runat="server" style="margin-right: 10px" />--%>
                        &nbsp;<asp:PlaceHolder ID="qr_code" runat="server" />
                    </td>
                    <td style="height: 1px; padding-right: 5px">
                        <br />
                        <div style="float: right;">
                            <asp:Label ID="parentSign" runat="server" Text="_________________"> </asp:Label><br />
                            <asp:Label ID="Label6" runat="server" Text="Parent's Signature"> </asp:Label>
                        </div>

                    </td>
                </tr>

                <%--<tr>
                    <td class="auto-style60"  >
                    
                    </td>

                    <td >
                       
                    </td>
                </tr>--%>
            </table>


        </div>

        <div style="border: 1px solid black" class="break">
            <table style="width: 100%">

                <tr>
                    <td colspan="2">
                        <%--<span align="center" style="font-weight: bold; font-size: 15px; color: #000000; padding-left: 150px"> Vishnu Waman Thakur Charitable Trust's</span><br />--%>
                        <span align="center" style="font-weight: bold; font-size: 15px; color: #000000; padding-left: 125px">INSTITUTE OF MANAGEMENT AND RESEARCH</span>

                    </td>
                    <td style="border-style: groove; border-color: inherit; border-width: medium;" class="auto-style18">
                        <span style="font-weight: bold; font-size: 10px; color: #000000;">Sign. Office Staff</span>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <table>

                <tr>
                    <td class="auto-style45">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Received Application Form from Shri/Smt/Kum:</span>&nbsp;
                  
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 14px; font-weight: bold; word-spacing: 5px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style46">
                        <asp:Label ID="lblrecieved" runat="server" Font-Size="14px" Style="font-family: sans-serif; font-weight: bold"></asp:Label>
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td class="auto-style47">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">For Admission Course:</span>

                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style50">
                        <asp:Label ID="lbladmissioncourse" runat="server"></asp:Label>
                    </td>
                    &nbsp;
                    <td class="auto-style49">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Academic Year</span>

                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style56">
                        <asp:Label ID="lblacademic" runat="server" Text="2021-2022" Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td class="auto-style57">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Form No:</span>

                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style51">
                        <asp:Label ID="lblform1" runat="server"> </asp:Label>
                    </td>
                </tr>
            </table>
            <center>
                <table>
                    <tr>
                        <%--<td align="center" colspan="1" class="auto-style53">
                        <asp:PlaceHolder ID="plBarCode1" runat="server" />

                    </td>--%>
                        <td style="padding-bottom: 20px;">&nbsp;<asp:PlaceHolder ID="qr_code1" runat="server" />
                            <%--<asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="120px" runat="server" />--%>
                    
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
