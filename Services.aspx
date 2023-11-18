<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

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
     <section id="services" class="services my-5">
      <div class="container">



        <div class="section-title mb-4 p-2">
          <h2 class="h2 fw-bold tezt-warning">Services</h2>
          <p>
            Here are some of the things that we do:</p>
        </div>

        <div class="row">

            <asp:ListView ID="ServiceListView" runat="server">

                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up">
                        <div class="icon">
                            <%--<i class="fa-solid fa-briefcase"></i>--%>
                            <img src='<%# Eval("ServiceImage") %>' id="serviceimg" runat="server" class="img-fluid services-img" />

                        </div>
                        <h4 class="title" ><a href="#"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("ServicesHeading")%>'></asp:Label></a></h4>
                        <p class="description">
                            <%--web design
                            We take pride in the creative spell and expert knowledge that our web designers and
                            developers are adhered to.--%>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("ServicesContent")%>'></asp:Label>
                        </p>
                    </div>
                </ItemTemplate>

            </asp:ListView>


<%--          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up">
            <div class="icon">
                <img src="assests/services-img/profile-img.jpg" class="img-fluid services-img" />

            </div>
            <h4 class="title"><a href="#">Web Design</a></h4>
            <p class="description">We take pride in the creative spell and expert knowledge that our web designers and
              developers are adhered to. </p>
          </div>
          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up" data-aos-delay="100">
            <div class="icon"><i class="fa-regular fa-rectangle-list"></i></div>
            <h4 class="title"><a href="#">Poster/Banner Design</a></h4>
            <p class="description">If you are thinking about putting up your own website, no matter what brand of trade
              it may be related to, think about us.</p>
          </div>
          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up" data-aos-delay="200">
            <div class="icon"><i class="fa-solid fa-earth-americas"></i></div>
            <h4 class="title"><a href="#">Web Developement</a></h4>
            <p class="description">We can serve you with different business models in a great deal of different fields
              like education, medicine, law, real estate, telecommunication, retail, and civic association among others
            </p>
          </div>
          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up" data-aos-delay="300">
            <div class="icon"><i class="fa-solid fa-desktop"></i> </div>
            <h4 class="title"><a href="#">Software Developement</a></h4>
            <p class="description">We can make the most useful embedded software that you will need to power up your
              presence in the Internet community. We implement projects as they are required. </p>
          </div>
          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up" data-aos-delay="400">
            <div class="icon"><i class="fa-solid fa-camera"></i></div>
            <h4 class="title"><a href="#">Photography & Videography</a></h4>
            <p class="description">My photographs are taken with thought and consideration and carefully edited to
              showcase and impress your potential buyers! The reality is, first impressions last...</p>
          </div>
          <div class="col-lg-4 col-md-6 icon-box" data-aos="fade-up" data-aos-delay="500">
            <div class="icon"><i class="fa-solid fa-palette"></i></div>
            <h4 class="title"><a href="#">Editing</a></h4>
            <p class="description">My photographs are taken with thought and consideration and carefully edited to
              showcase and impress your potential buyers! The reality is, first impressions last...</p>
          </div>--%>
        </div>

      </div>
    </section><!-- End Services Section -->
</asp:Content>

