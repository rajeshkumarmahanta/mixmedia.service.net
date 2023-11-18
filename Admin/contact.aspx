<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="Admin_contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <title>mix media services || Pannel </title>
        <meta content="width=device-width, initial-scale=1.0" name="viewport">
<meta content="" name="keywords">
<meta content="" name="description">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
<link href="../assests/css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
                <header class="sticky-top">
    <div class="collapse bg-dark" id="navbarHeader">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-md-7 col-12 py-4">
                    <asp:LinkButton ID="linkbtnhome" runat="server" CssClass="fw-bold text-light text-decoration-none" OnClick="linkbtnhome_Click">Home</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnheading" runat="server" CssClass="text-light mx-1 px-1 fw-bold text-decoration-none" OnClick="linkbtnheading_Click">Slider</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnabout" runat="server" CssClass="text-light mx-1 px-1 fw-bold text-decoration-none" OnClick="linkbtnabout_Click" >About</asp:LinkButton>
                    <asp:LinkButton ID="linkbtncontmsg" runat="server" CssClass="text-light mx-1 px-1 fw-bold text-decoration-none" OnClick="linkbtncontmsg_Click" >Contact Messages from user</asp:LinkButton>
                    <asp:LinkButton ID="linkbtnteamber" runat="server" CssClass="text-light mx-1 px-1 fw-bold text-decoration-none" OnClick="linkbtnteamber_Click">Add Team Member</asp:LinkButton>
<asp:LinkButton ID="linkbtnlogout" runat="server" CssClass="text-light mx-1 px-1 fw-bold text-decoration-none" OnClick="linkbtnlogout_Click">Logout</asp:LinkButton>
                </div>
                <div class="col-sm-4 offset-md-1 py-4">
                    <h4 class="text-white">Contact</h4>
                    <ul class="list-unstyled">
                        <li>
                            <asp:LinkButton ID="linkbtntwitter" CssClass="text-white" runat="server">Follow on Twitter</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="linkbtninstagram" CssClass="text-white" runat="server">Follow on Instagram</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="linkbtnfacebook" CssClass="text-white" runat="server">Like on Facebook</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="linkbtnemail" CssClass="text-white" runat="server">Email me</asp:LinkButton></li>
                        <%--<li><a href="#" class="text-white">Follow on Twitter</a></li>
                     <li><a href="#" class="text-white">Like on Facebook</a></li>
                       <li><a href="#" class="text-white">Email me</a></li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="navbar navbar-dark bg-dark shadow-sm">
        <div class="container">
            <a href="#" class="navbar-brand d-flex align-items-center">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" aria-hidden="true" class="me-2" viewBox="0 0 24 24">
                    <path d="M23 19a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2h4l2-3h6l2 3h4a2 2 0 0 1 2 2z" />
                    <circle cx="12" cy="13" r="4" />
                </svg>
                <strong>MIX<span class="fw-bold px-1 text-warning">MEDIA SERVICES</span></strong>
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarHeader" aria-controls="navbarHeader" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
        </div>
    </div>
</header>
        <div class="container mt-5">
            <div class="row">
                <div class="col-md-4 col-sm-4 col-12">
                    <div class="heading m-2 p-2">
                        <u>
                            <span class="fw-bold">Admin Pannel || Message From User</span>
                        </u>
                    </div>

                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12 col-12">
                    
             <div class="tbl-overflow">
                    <asp:GridView ID="ContactGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive overflow-auto tbl-bg" DataKeyNames="Id" OnRowDeleting="ContactGrid_RowDeleting" >
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="User&#39;s Name"></asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="User&#39;s Email"></asp:BoundField>
                            <asp:BoundField DataField="Subject" HeaderText="Subject"></asp:BoundField>
                            <asp:BoundField DataField="Message" HeaderText="User&#39;s Message"></asp:BoundField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="dltbtn" CommandName="Delete" runat="server" Text="Delete" CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                 </div>
                </div>
            </div>
        </div>
    </form>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
