<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

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
        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.min.css'/> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container text-center my-4">
    <div class="row">
        <div class="col-sm-12 col-md-12">
            <h2 class="text-center mt-4 text-warning fw-bold">CONTACT</h2>
            <div class="rectangle"></div>
        </div>
    </div>
</div>
     <!-- ======= Contact Section ======= -->
    <div id="contact" class="paddsection my-5">
      <div class="container">
        <div class="contact-block1">
          <div class="row">

            <div class="col-lg-6 col-md-6 col-sm-6 col-12">
              <div class="contact-map">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3393.010527849232!2d85.70861337478752!3d21.71315796392173!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3a1ef934d3618cbb%3A0xfb265a20a21269b1!2sVishwa%20Vinayak%20Degree%20College%20(VVDC)!5e1!3m2!1sen!2sin!4v1699636771720!5m2!1sen!2sin" width="400" height="350" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
              </div>
            </div>

            <div class="col-lg-6">
              <div method="post" role="form" class="php-email-form">
                <div class="row gy-3">

                  <div class="col-lg-6">
                    <div class="form-group contact-block1">
                      <%--<input type="text" name="name"  id="name" placeholder="Your Name" required>--%>
                        <asp:TextBox ID="txtcontname" CssClass="form-control" Placeholder="Your Name" runat="server"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-lg-6">
                    <div class="form-group">
                      <%--<input type="email" class="form-control" name="email" id="email" placeholder="Your Email" required>--%>
                        <asp:TextBox ID="txtcontmail" CssClass="form-control" Placeholder="Your Email" TextMode="Email" runat="server"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-lg-12">
                    <div class="form-group">
                      <%--<input type="text" class="form-control" name="subject" id="subject" placeholder="Subject" required>--%>
                        <asp:TextBox ID="txtcontsubject" CssClass="form-control" Placeholder="Subject" runat="server"></asp:TextBox>
                    </div>
                  </div>

                  <div class="col-lg-12">
                    <div class="form-group">
                      <%--<textarea class="form-control" name="message" placeholder="Message" required></textarea>--%>
                        <asp:TextBox ID="txtcontmsg"  CssClass="form-control" runat="server" Placeholder="Message" TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>

                  <%--<div class="col-lg-12">
                    <div class="loading">Loading</div>
                    <div class="error-message"></div>
                    <div class="sent-message">Your message has been sent. Thank you!</div>
                  </div>--%>

                  <div class="mt-2">
                      <asp:Button ID="btnsend" runat="server" CssClass="btn btn-outline-warning btn-send" OnClick="btnsend_Click" Text="Send" />
                    <%--<input type="submit"  value="Send message">--%>
                  </div>

                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div><!-- End Contact Section -->
</asp:Content>

