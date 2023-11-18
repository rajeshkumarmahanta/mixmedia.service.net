<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <%--text section--%>
<section class="slider"> 

       
<!-- Carousel -->
<div id="demo" class="carousel slide" data-bs-ride="carousel">

    <!-- Indicators/dots -->
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
        <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
        <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
    </div>

    <!-- The slideshow/carousel -->
    <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="SliderImage/sliderimage1.jpg" alt="Los Angeles" class="d-block" style="width: 100%">
            <div class="carousel-caption">
                <h3 class="fw-bold text-capitalize" id="caption1" runat="server"></h3>
                <p id="captioncontent1" runat="server"></p>
               <%-- <div>
                   
                    <a href="https://instagram.com/the_scripy_2128" target="_blank"><button class="bn632-hover bn24 btn-res1">Follow Me on Instagram</button></a>
                    <a href="https://www.youtube.com/@a_rajesh_kumar_vlogs" target="_blank"><button class="bn631-hover bn28 btn-res2">Subscribe on Youtube</button></a>
                </div>--%>
            </div>
        </div>
        <div class="carousel-item">
            <img src="SliderImage/sliderimage2.jpg" alt="Chicago" class="d-block" style="width: 100%">
            <div class="carousel-caption">
                <h3 class="fw-bold text-capitalize" id="caption2" runat="server"></h3>
                <p id="captioncontent2" runat="server"></p>
                <%--<div>
                    <a href="https://instagram.com/the_scripy_2128" target="_blank"><button class="bn632-hover bn24 btn-res1">Follow Me on Instagram</button></a>
                    <a href="https://www.youtube.com/@a_rajesh_kumar_vlogs" target="_blank"><button class="bn631-hover bn28 btn-res2">Subscribe on Youtube</button></a>
                </div>--%>
            </div>
        </div>
        <div class="carousel-item">
            <img src="SliderImage/sliderimage3.jpg" alt="New York" class="d-block" style="width: 100%">

            <div class="carousel-caption">
                <h3 class="fw-bold text-capitalize" id="caption3" runat="server"></h3>
                <p id="captioncontent3" runat="server"></p>
                <%--<div>
                    <a href="https://instagram.com/the_scripy_2128" target="_blank"><button class="bn632-hover bn24 btn-res1">Follow Me on Instagram</button></a>
                    <a href="https://www.youtube.com/@a_rajesh_kumar_vlogs" target="_blank"><button class="bn631-hover bn28 btn-res2">Subscribe on Youtube</button></a>
                </div>--%>
            </div>
        </div>
    </div>

    <!-- Left and right controls/icons -->
    <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
        <span class="carousel-control-prev-icon"></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
        <span class="carousel-control-next-icon"></span>
    </button>
</div>
     </section>
<%--text section end--%>
    <!-- ======= About Section ======= -->
        <div class="container text-center my-4">
    <div class="row">
        <div class="col-sm-12 col-md-12">
            <h2 class="text-center text-warning fw-bold">About Us</h2>
            <div class="rectangle"></div>
        </div>
    </div>
</div>
  <div class="container">
    <div class="row justify-content-between">

      <div class="col-lg-4 col-md-6">
        <div class="zoom-photo-rjs m-auto">
              <img src="assests/about-pic/profile-image.jpg" class="img-fluid zoom-rajesh-hover about-profile-img" alt="Profile picture">
            <asp:Image ID="Image2" runat="server" />
            </div>
          
            <p class="mt-3 text-center">Rajesh Kumar Mahanta</p>
      </div>

      <div class="col-lg-8 col-md-6">
        <div class="about-descr">
          <p class="p-heading" runat="server" id="aboutheading"></p>
          <p class="separator" runat="server" id="aboutcontent"></p>
             <button type="button" class="btn btn-outline-primary mt-5" data-bs-toggle="modal" data-bs-target="#myModal">
    Read More..
  </button>
</div>

<!-- The Modal -->
<div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title" runat="server" id="aboutheadingmodal"></h4>
        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
      </div>

      <!-- Modal body -->
      <div class="modal-body" runat="server" id="aboutcontentmodal">
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
      </div>

    </div>
  </div>
        </div>

      </div>
    </div>
  </div>

    <!-- End About Section -->
<%--    team member--%>
    <%--    team member--%>
<%--photo section--%>
            <div class="container text-center my-5">
    <div class="row">
        <div class="col-sm-12 col-md-12">
            <h2 class="text-center text-warning fw-bold">Gallery</h2>
            <div class="rectangle"></div>
        </div>
    </div>
</div>

    <div class="container album py-5 bg-light">
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
            <asp:ListView ID="galleryview" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card animate__backInUp shadow-sm">
                            <div class="card-img-zoom">
                                
                            <a href='<%# Eval("Images") %>' id="imglink" runat="server" data-lightbox="mygallery" data-title='<%# Eval("ImageContent")%>' >

                                <img id="Image1" runat="server" src='<%# Eval("Images") %>' class="img-fluid img-zoom card-img-top gallery-img" />
                            </a>
                            </div>
                       
                                <div class="card-body">
                                <p class="card-text">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ImageContent")%>'></asp:Label></p>
                                <div class="d-flex justify-content-between align-items-center">
                                    <div class="btn-group">
                                        <a href='<%# Eval("Images") %>' runat="server" class="btn btn-sm btn-outline-secondary" data-lightbox="mygallery" data-title='<%# Eval("ImageContent")%>' >View</a>
                                        <%--<asp:LinkButton ID="linkbtnview" runat="server" CssClass="btn btn-sm btn-outline-secondary">View</asp:LinkButton>--%>
                                        <%--<a href='<%# Eval("Images") %>' data-lightbox="models" data-title="caption1"><button type="button" class="btn btn-sm btn-outline-secondary">View</button></a>--%>
                                        <a href='<%# Eval("Images") %>' id="downloadbtn" runat="server" class="btn btn-sm btn-outline-secondary" download="download.jpg" >Download</a>
                                       <%-- <button type="button" class="btn btn-sm btn-outline-secondary">Download</button>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                </asp:ListView>
        </div>
    </div>
<%--photosection end--%>
</asp:Content>

