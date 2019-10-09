<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/CSS/styles.css" rel="Stylesheet" type="text/css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="wrapper_box">

                <div class="wrapper_result" >
                     <div class="wrapper_result--prev">
                       <asp:Label ID="storeRes" runat="server" CssClass="text_prev--hide" Text=""></asp:Label>
                       <asp:Label ID="prevRes" runat="server" CssClass="text_prev" Text=""></asp:Label>
                     </div>
                    <div class="wrapper_result--curr">
                       <asp:Label ID="result" runat="server" CssClass="text_result" Text="0"></asp:Label>
                       <asp:Label ID="parentheses" runat="server" CssClass="text_parentheses" Text=""></asp:Label>
                    </div>
    
                </div>
             <div class="wrapper_button">
                 <div class="wrapper_line">
                     <asp:Button ID="btn7" runat="server" Text="7"  OnClick="btn_num"/>
                        <asp:Button ID="btn8" runat="server" Text="8"  OnClick="btn_num"/>
                     <asp:Button ID="btn9" runat="server" Text="9"  OnClick="btn_num"/>
                      <asp:Button ID="btn_div" runat="server" Text=":"  OnClick="btn_oper"/>
                 </div>
                  <div class="wrapper_line">
                     <asp:Button ID="btn4" runat="server" Text="4"  OnClick="btn_num"/>
                        <asp:Button ID="btn5" runat="server" Text="5"  OnClick="btn_num"/>
                     <asp:Button ID="btn6" runat="server" Text="6"  OnClick="btn_num"/>
                      <asp:Button ID="btn_mul" runat="server" Text="x"  OnClick="btn_oper"/>
                 </div>
                          <div class="wrapper_line">
                     <asp:Button ID="btn1" runat="server" Text="1"  OnClick="btn_num"/>
                        <asp:Button ID="btn2" runat="server" Text="2"  OnClick="btn_num"/>
                     <asp:Button ID="btn3" runat="server" Text="3"  OnClick="btn_num"/>
                      <asp:Button ID="btn_sub" runat="server" Text="-"  OnClick="btn_oper"/>
                 </div>
                   <div class="wrapper_line">
                     <asp:Button ID="btn0" runat="server" Text="0"  OnClick="btn_num"/>
                        <asp:Button ID="parentheses1" runat="server" Text="("  OnClick="btnParenthesesOpen"/>
                     <asp:Button ID="parentheses2" runat="server" Text=")"  OnClick="btnParenthesesClose"/>
                      <asp:Button ID="btn_add" runat="server" Text="+"  OnClick="btn_oper"/>
                 </div>
                  <div class="wrapper_line--submit">
                     <asp:Button ID="btnC" runat="server" Text="C"  OnClick="btn_c"/>
                        <asp:Button ID="btnCE" runat="server" Text="CE"  OnClick="btn_ce"/>
                     <asp:Button ID="btnEnter" runat="server" Text="Enter"  OnClick="btn_enter"/>
                 </div>
             </div>
            

           </div>
        </div>
     
    </form>
</body>
</html>
