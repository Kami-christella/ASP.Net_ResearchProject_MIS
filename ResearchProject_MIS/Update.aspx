<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ResearchProject_MIS.Register" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Student</title>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <style>
        .container {
            margin-top: 50px;
        }
        .form-group label {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <h2 class="text-center"> STUDENT FORM </h2>
        <asp:Label ID="Label2" runat="server" CssClass="text-center d-block"></asp:Label>
        <div class="form-group">
            <label for="studentid">Student ID</label>
            <asp:TextBox ID="idBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="fullname">Full Name</label>
            <asp:TextBox ID="nameBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="year">Year Of Study</label>
            <asp:TextBox ID="yearBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="gpa">GPA</label>
            <asp:TextBox ID="gpaBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <asp:TextBox ID="emailBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div><br /><br />
        <div class="form-group text-center">
            <asp:Button ID="registerBTN" runat="server" Text="UPDATE" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
        </div> 
    </form>
     <form id="form2" runat="server" class="container">

 
     </form>

    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
