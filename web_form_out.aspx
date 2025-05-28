<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_form_out.aspx.cs" Inherits="web_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Form</title>
    <link href="style_report.css" rel="stylesheet" />
    <script type="text/javascript">
        window.print();
    </script>

    <script>
        function SetPrintSettings() {
            // -- advanced features 
            factory.printing.SetMarginMeasure(2) // measure margins in inches 
            factory.SetPageRange(false, 1, 3) // need pages from 1 to 3 
            factory.printing.printer = "HP DeskJet 870C"
            factory.printing.copies = 1
            factory.printing.collate = true
            factory.printing.paperSize = "A4"
            factory.printing.paperSource = "Manual feed"

            // -- basic features 
            factory.printing.portrait = false
            factory.printing.leftMargin = 1.0
            factory.printing.topMargin = 1.0
            factory.printing.rightMargin = 1.0
            factory.printing.bottomMargin = 1.0
        }
    </script>




    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }

        .auto-style2 {
            width: 900px;
            height: 25px;
        }
    </style>




</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black;" class="Section1">
            <table style="width: 100%">
                <tr>
                    <td>
                        <table align="left" style="height: 50px; border: groove; width: 130px;">
                            <tr>
                                <td>
                                    <span style="font-weight: bold; font-size: 15px; color: #000000">Office</span>
                                    <br />
                                    <br />

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" style="height: 50px; border: groove; width: 130px">
                            <tr>
                                <td>
                                    <span style="font-weight: bold; font-size: 15px; color: #000000">Teacher</span>
                                    <br />
                                    <br />

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="center" style="height: 50px; border: groove; width: 130px">
                            <tr>
                                <td>
                                    <span style="font-weight: bold; font-size: 15px; color: #000000">Roll No</span>
                                    <br />
                                    <br />

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table align="right" style="height: 50px; border: groove; width: 135px;">
                            <tr>
                                <td>
                                    <span style="font-weight: bold; font-size: 15px; color: #000000">Viva Form No</span>
                                    <asp:Label ID="lblvivaform" runat="server"></asp:Label>
                                    <br />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%">
                <tr>
                    <td>
                        <img src="images/logo.gif" style="width: 115px; height: 109px" alt="" />
                    </td>
                    <td style="text-align: center; height: 30px">
                        <span style="font-weight: normal; color: #000000; font-size: 12px;">LATE SHRI VISHNU WAMAN THAKUR CHARITABLE TRUST'S<br />
                        </span>

                        &nbsp;<span style="font-weight: bold; font-size: 18px; word-spacing: 5px; color: #000000">Bhaskar Waman Thakur College of Science,<br />
                            Yashvant Keshav Patil College of Commerce,
         
     
          <br />
                            Vidhya Dayanand Patil College of Arts
      
          <br />
                            (Afflitated to the University of Mumbai)<br />
                        </span>

                        &nbsp;<span style="font-weight: normal; color: #000000; font-size: 12px;">Viva College Road,Virar(West),Pin:401303,Tel No:(0250)2515276 /78</span>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="img1" runat="server" ImageUrl="~/0022.jpg" Height="102px" Width="102px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center; padding-left: 120px; border: groove; height: 5px">
                        <span style="font-weight: bold; font-size: 16px; word-spacing: 2px; color: #000000;">ADMISSION FORM FOR </span>&nbsp;
             <asp:Label ID="grp_name" runat="server" Text="" Style="font-weight: bold; width: auto; font-size: 16px; color: #000000"> </asp:Label>&nbsp;
             <span style="font-weight: bold; font-size: 16px; color: #000000">2016-2017</span>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <%-- <asp:Label ID="lblinhouse" style="font-size:16px" runat="server"></asp:Label>--%>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="name" runat="server" Text="1.Full Name: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td colspan="3" style="border-bottom-style: solid; border-width: thin; font-size: 14px; font-weight: bold; word-spacing: 5px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblfname" runat="server" Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="2.Address: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td colspan="3" style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 5px; font-family: sans-serif">
                        <asp:Label ID="lbladdress" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="3.Mobile No: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 220px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblmobile" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 120px">
                        <asp:Label ID="Label5" runat="server" Text="4.Phone No: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblphone" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="5.Email Id: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 150px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblemail" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="6.Gender: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblgender" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text="7.Category: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style2">
                        <asp:Label ID="lblcategory" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="Label13" runat="server" Text="8.Caste: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;" class="auto-style1">
                        <asp:Label ID="lblcaste" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="9.Blood Group: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 150px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblbloodgrup" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="10.Date Of Birth: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lbldob" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="11.Birth Place: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 150px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblbirthplce" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="12.Marital Status: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblmaritalstatus" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>

            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="13.Physically Challanged: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 165px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblphysicallychallngd" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 120px">
                        <asp:Label ID="Label25" runat="server" Text="14.Religion: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td style="width: 250px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif">
                        <asp:Label ID="lblreligion" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label27" runat="server" Text="15.Special Category: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td colspan="3" style="border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif; width: 230px">
                        <asp:Label ID="lblspecialcategory" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label29" runat="server" Text="16.Are You Applying for Freeship/Scholarship: " Style="font-weight: bold; font-size: 14px; color: #000000"></asp:Label>
                    </td>
                    <td colspan="3" style="width: 410px; border-bottom-style: solid; border-width: thin; font-size: 12px; border-color: #000000; height: 1px; font-family: sans-serif;">&nbsp;&nbsp;
                    <asp:Label ID="lblfreeship" runat="server" Style="font-size: 14px; color: #000000"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 100%" border="1px">
                <tr>
                    <td class="auto-style1">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Exam</span>
                    </td>
                    <td class="auto-style2">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Board/University</span>
                    </td>
                    <td class="auto-style2">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Institute Name</span>

                    </td>
                    <%--<td>
                            <span style="font-weight: bold; font-size: 15px; color: #000000">First Attempt</span>
                        </td>--%>
                    <td class="auto-style1">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Passed In</span>

                    </td>
                    <%--<td>
                            <span style="font-weight: bold; font-size: 15px; color: #000000">Seat No</span>

                        </td>--%>
                    <td class="auto-style1">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Marks Obtnd</span>

                    </td>
                    <td class="auto-style1">
                        <span style="font-weight: bold; font-size: 15px; color: #000000">Out Of</span>

                    </td>

                </tr>



                <tr>
                    <td align="center ">
                        <asp:Label ID="lblexam" runat="server" Style="font-size: x-small"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lblboard" runat="server" Style="font-size: x-small"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lblclg" runat="server" Style="font-size: x-small"></asp:Label>

                    </td>
                    <%--<td>
                            <asp:Label ID="lblsscfirstattmt" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>
                        </td>--%>
                    <td>
                        <asp:Label ID="lblmnth" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                    </td>
                    <%--<td align="center">
                            <asp:Label ID="lblseat" runat="server" Style="font-size:medium; padding-left: 15px"></asp:Label>

                        </td>--%>
                    <td>
                        <asp:Label ID="lblmrksobt" runat="server" Style="font-size: medium; padding-left: 10px"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lblmrkscout" runat="server" Style="font-size: medium; padding-left: 5px"></asp:Label>

                    </td>

                </tr>
            </table>
            <hr></hr>
            <table style="width: 100%" border="1px">
                <tr>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Cource</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">University</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">College Name</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem1</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem2</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem3</span></td>
                    <td align="center"><span style="font-weight: bold; font-size: 15px; color: #000000">Sem4</span></td>
                </tr>
                <tr>
                   <td align="center"><asp:Label ID="lbl_cource" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_univers" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_colg_name" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_sem1" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_sem2" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_sem3" runat="server" Style="font-size: x-small"></asp:Label></td>
                    <td align="center"><asp:Label ID="lbl_sem4" runat="server" Style="font-size: x-small"></asp:Label></td>
                </tr>
            </table>

            <table style="width: 100%">

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


            </table>
            <table style="width: 98%; height: 89px;">

                <tr>
                    <td style="text-align: center">
                        <br />
                        <asp:Label ID="studSign" runat="server" Text="__________________"> </asp:Label><br />
                        Student's Signature    
                    </td>

                    <td rowspan="3" style="width: 250px" align="center">
                        <asp:PlaceHolder ID="plBarCode" runat="server" />

                    </td>
                    <td rowspan="3" align="left" style="width: 100px">
                        <asp:Image ID="qr_code" Width="100px" Height="100px" runat="server" />
                    </td>
                    <td style="text-align: center; height: 1px; padding-right: 5px">
                        <br />
                        <asp:Label ID="parentSign" runat="server" Text="_________________"> </asp:Label><br />
                        <asp:Label ID="Label31" runat="server" Text="Parent's Signature"> </asp:Label>

                    </td>
                </tr>

                <tr>
                    <td></td>

                    <td></td>
                </tr>

            </table>
        </div>
        <div style="border: 1px solid black; padding: 5px" class="break">
            <table style="width: 100%">

                <tr>
                    <td colspan="2">
                        <span align="center" style="font-weight: bold; font-size: 15px; color: #000000; padding-left: 150px">Late Shri. Vishnu Waman Thakur Charitable Trust's</span><br />
                        <span align="center" style="font-weight: bold; font-size: 15px; color: #000000; padding-left: 230px">Viva College Virar(W)</span>

                    </td>
                    <td style="border-style: groove; border-color: inherit; border-width: medium;">
                        <span style="font-weight: bold; font-size: 10px; color: #000000;">Sign. Office Staff</span>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <table>

                <tr>
                    <td>
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Received Application Form from Shri/Smt/Kum:</span>&nbsp;
                  
                    </td>
                    <td style="width: 300px; border-bottom: thin solid #000000; font-size: 14px; font-weight: bold; word-spacing: 5px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;">
                        <asp:Label ID="lblrecieved" runat="server" Font-Size="14px" Style="font-family: sans-serif; font-weight: bold"></asp:Label>
                    </td>

                </tr>
            </table>
            <table style="width: 100%">
                <tr>
                    <td style="width: 150px">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">For Admission Course:</span>

                    </td>
                    <td style="width: 200px; border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;">
                        <asp:Label ID="lbladmissioncourse" runat="server" Style="font-family: sans-serif; font-weight: bold"></asp:Label>
                    </td>
                    &nbsp;
                    <td style="width: 100px">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Academic Year</span>

                    </td>
                    <td style="width: 100px; border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; font-size: 15px; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;">
                        <asp:Label ID="lblacademic" Text="2015-2016" runat="server"></asp:Label>
                    </td>
                    &nbsp
                    <td style="width: 80px">
                        <span style="font-weight: bold; font-size: 12px; color: #000000">Form No:</span>

                    </td>
                    <td style="width: 100px; border-bottom: thin solid #000000; font-size: 12px; font-family: sans-serif; border-left-color: #000000; border-left-width: thin; border-right-color: #000000; border-right-width: thin; border-top-color: #000000; border-top-width: thin;">
                        <asp:Label ID="lblrecivedform" runat="server"> </asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 110px"></td>
                    <td align="center" colspan="1">
                        <asp:PlaceHolder ID="plBarCode1" runat="server" />

                    </td>
                    <td style="padding-bottom: 20px;">
                        <asp:Image ID="qr_code1" CssClass="image" Width="120px" Height="120px" runat="server" />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
