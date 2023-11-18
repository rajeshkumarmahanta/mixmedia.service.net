<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="team.aspx.cs" Inherits="team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
                           <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css"
    integrity="sha512-z3gLpd7yknf1YoNbCzqRKc4qyor8gaKU1qmn+CShxbuBusANI9QpRohGBreCFkKxLhei6S9CQXFEbbKuqLg0DA=="
    crossorigin="anonymous" referrerpolicy="no-referrer" />
<%--favicon--%>
<link rel="icon" type="image/x-icon" href="assests/images/favicon.ico"/>
<link href="assests/css/StyleSheet.css" rel="stylesheet" />
<link href="assests/css/lightbox.min.css" rel="stylesheet" />
<%--animation--%>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- ======= Team Section ======= -->
    <section id="team" class="team my-5 pb-4 section-bg">
      <div class="container" data-aos="fade-up">

        <div class="section-title my-4 py-4">
          <h2 class="fw-bold">Team</h2>
          <p>Check our Team</p>
        </div>

        <div class="row">
            <asp:ListView ID="TeamView" runat="server">
                <ItemTemplate>
                    <div class="col-xl-3 col-lg-4 col-md-6">
                        <div class="member" data-aos="zoom-in" data-aos-delay="100">
                            <img id="img1" runat="server" src='<%# Eval("Images") %>' class="img-fluid team-img" height="600" width="600" alt="">
                            <div class="member-info">
                                <div class="member-info-content">
                                    <h4> <asp:Label ID="Label1" runat="server" Text='<%#Eval("TeamMemberName") %>'></asp:Label></h4>
                                    <span>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Designation") %>'></asp:Label></span>
                                </div>
                                <div class="social">
                                    <a href='<%#Eval("facebooklink")%>' id="sociallink1" runat="server"><i class="fab fa-facebook"></i></a>
                                    <a href='<%#Eval("twitterlink")%>' id="sociallink2" runat="server"><i class="fab fa-twitter"></i></a>
                                    <a href='<%#Eval("instagramlink")%>' id="sociallink3" runat="server"><i class="fab fa-instagram"></i></a>
                                    <a href='<%#Eval("linkedinlink")%>' id="sociallink4" runat="server"><i class="fab fa-linkedin"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
          

        </div>

      </div>
    </section><!-- End Team Section -->
</asp:Content>

