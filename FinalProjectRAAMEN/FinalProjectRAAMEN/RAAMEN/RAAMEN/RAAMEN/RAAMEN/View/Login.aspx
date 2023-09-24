<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAAMEN.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html * {
            color: #000;
            font-family: Arial !important;
        }
        html, body {
            height: 100%;
        }

        html {
            display: table;
            margin: auto;
        }

        body {
            display: table-cell;
            vertical-align: middle;
        }
        input {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border-radius: 4px;
        }
        input[type=text]:focus {
            border: 3px solid;
        }
        .button:hover {
            color:#386641;
            cursor: pointer;
        }
        .button {
            color: white;
        }
        .red{
            color: #BC4749;
        }
        .beige{
            color: #F2E8CF;
        }
        .green{
            color: #386641;
        }
        .center {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 50%;
        }
       

    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div>
            <img class="center" style="width:120px" src="../Asset/Logo.png" alt="Logo RAAMEN"/>
            <br />
             <h1 style="text-align: center;">Login</h1>
        </div>
            <br />
        <div style="display:flex; flex-direction:column; align-items: center; justify-content: center; gap:20px;">
            <div class="username">
                <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox><br/>
                <asp:Label ID="UsernameEmpty" class="red" runat="server" Visible="false" Text="Username must be filled!" ></asp:Label>
            </div>
            <div class="password">
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox><br/>
                <asp:Label ID="PasswordEmpty" class="red" runat="server" Visible="false" Text="Password must be filled!" ></asp:Label>
            </div>
            <div style="text-align: center">
                <a>Do not have an account? <a href="Register.aspx"><b>Register Here</b></a>
            </div>
            <div class="remember-me" style="display:flex">
                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember Me"/>
            </div>
            <br />
            <div class="button">
                <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" Font-Size="Larger" Font-Bold="true" ForeColor="White" BorderStyle="None" BackColor="#6A994E" Width="100"/>
            </div>
            <div class="errorMsg">
                <asp:Label ID="NoUser" runat="server" Visible="false" BorderStyle="Solid" BorderColor="#BC4749" BackColor="White" ForeColor="#BC4749" style="padding:20px;" Text="User does not exist" ></asp:Label>
            </div>
        </div>
      
    </form>
    
</body>
</html>
