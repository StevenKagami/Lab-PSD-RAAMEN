<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RAAMEN.View.Register" %>

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
        input, .input {
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
             <h1 style="text-align: center;">Register</h1>
        </div>
        <div style="display:flex; flex-direction:column; align-items: center; justify-content: center; gap:10px;">

            <div class="username" style="text-align:center;">
                <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox><br />
                <asp:Label ID="UsernameValid" runat="server" Visible="false" class="red" Text="Username's length must be between 5 and 15 characters and contains alphabet and space only!" ></asp:Label>
            </div>

            <div class="email" style="display:flex; flex-direction:column; align-items: center; justify-content: center;">
                <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                <asp:Label ID="EmailValid" runat="server" Visible="false" class="red" Text="Email must ends with '.com'!" ></asp:Label>
            </div>

            <div class="gender .input" style="display:flex; gap:10px;">
                <asp:Label ID="GenderLbl" runat="server"></asp:Label>
                <div>
                    <asp:DropDownList ID="GenderList" runat="server" >
                        <asp:ListItem Text="--Select Gender--"></asp:ListItem>
                        <asp:ListItem Text="Male"></asp:ListItem>
                        <asp:ListItem Text="Female"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Label ID="GenderValid" runat="server" Visible="false" class="red" Text="Gender must be chosen!" ></asp:Label>

            <div class="password">
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>

            <div class="conf-password" style="text-align:center;">
                <asp:TextBox ID="ConfPasswordTextBox" runat="server" TextMode="Password" placeholder="Confirm Password"></asp:TextBox><br />
                <asp:Label ID="PasswordValid" runat="server" Visible="false" class="red" Text="Password and Confirm Password need be the same!" ></asp:Label>
            </div>

            <div style="text-align: center">
        <a>Already have an account? <a href="Login.aspx"><b>Login Here</b></a>
    </div>

            <div class="button">
                <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" Font-Size="Larger" Font-Bold="true" ForeColor="White" BorderStyle="None" BackColor="#6A994E" Width="150"/>
            </div>

            <div class="errorMessage">
                <asp:Label ID="ErrorLabel" runat="server" Visible="false"  BorderStyle="Solid" BorderColor="#BC4749" BackColor="White" ForeColor="#BC4749" style="padding:20px;" Text="User with the same email already exists!"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

