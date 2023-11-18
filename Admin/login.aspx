<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Mix Media Services || Admin Pannel</title>
        <meta content="width=device-width, initial-scale=1.0" name="viewport">
<meta content="" name="keywords">
<meta content="" name="description">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" 
    integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
            <style>
    
    .login-box {
        width: 100%;
        border: 1px solid #00000036;
        border-radius: 10px;
        box-shadow: 0px 0px 21px -10px black;
    }

    .user-icon {
        color: #959595;
    }

    .lock-icon {
        color: #959595;
    }
    .circle-user{
        color: #959595;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row">
                <div class="col-sm-4 col-md-4">

                
            <h3 class="text-center fw-bold text-primary mb-3"><u>Login</u></h3>
            <div class="login-box m-auto pt-3">
                <div class="text-center">
                    <img src="../assests/images/profile.png" width="50%" />
                </div>
                <div class="username m-2 p-2">
                    <div class="my-2">
                        <asp:Label ID="lblusername" runat="server" Text="Username :" CssClass="text-start fw-bold px-1 my-2"></asp:Label>
                    </div>
                    <div class="d-flex">
                        <span class="h3 m-1 px-1 user-icon"><i class="fa-solid fa-user"></i></span>
                        <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
                    </div>
                </div>
                <div class="passowrd m-2 p-2">
                    <div class="my-2">
                        <asp:Label ID="lblpassword" runat="server" Text="Password :" CssClass="text-start fw-bold px-1 my-2"></asp:Label>
                    </div>
                    <div class="d-flex">
                        <span class="h3 m-1 px-1 lock-icon"><i class="fa-solid fa-lock"></i></span>
                        <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                    </div>
                </div>
                <div class="m-1 text-center">
                    <div class="m-1">
                        <asp:Button ID="loginbtn" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="loginbtn_Click" />
                    </div>
                </div>
            </div>
          </div>
</div>
        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" 
     integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>


