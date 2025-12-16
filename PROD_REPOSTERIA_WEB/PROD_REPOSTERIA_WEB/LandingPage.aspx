<%@ Page Title="Inicio"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="LandingPage.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.LandingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<!-- HERO SECTION -->
<section
    style="
        min-height:70vh;
        width:100%;
        background-image:
            linear-gradient(rgba(0,0,0,0.55), rgba(0,0,0,0.55)),
            url('/Content/images/Cocina de postres y personas.png');
        background-size:cover;
        background-position:center;
        display:flex;
        align-items:center;
        margin-top:0;
        padding-top:0;
    ">

    <div class="container text-center text-white">
        <h1 class="display-4 fw-bold">La Emperatriz 👑</h1>
        <p class="lead mt-3">
            Repostería artesanal donde cada postre se crea
            con pasión, tradición y calidad.
        </p>

        <a href="Catalogo.aspx" class="btn btn-primary btn-lg mt-4">
            Ver Catálogo 🍰
        </a>
    </div>
</section>

<!-- SECCIÓN DE TEXTO (DESCANSO VISUAL) -->
<section class="py-5">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 text-center">
                <h2 class="fw-bold mb-3">Nuestra filosofía</h2>
                <p class="lead text-muted">
                    En <strong>La Emperatriz</strong> creemos que un buen postre
                    no solo se disfruta con el paladar, sino también con el corazón.
                    Cada receta es preparada cuidadosamente para ofrecer una experiencia
                    dulce, elegante y memorable.
                </p>
            </div>
        </div>
    </div>
</section>

<!-- SECCIÓN DE CARDS CON FONDO -->
<section class="py-5" style="background-color:#f8f9fa;">
    <div class="container">

        <div class="row justify-content-center text-center mb-4">
            <div class="col-lg-8">
                <h2 class="fw-bold">¿Por qué elegirnos?</h2>
            </div>
        </div>

        <div class="row justify-content-center g-4">

            <!-- Card 1 -->
            <div class="col-md-4 col-lg-3">
                <div class="card shadow-sm h-100 text-center">
                    <img src="https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=800&q=80"
                         class="card-img-top"
                         style="height:180px; object-fit:cover;"
                         alt="Postres artesanales">

                    <div class="card-body">
                        <h5 class="card-title">Artesanal</h5>
                        <p class="card-text">
                            Elaboración manual con recetas tradicionales
                            y dedicación en cada detalle.
                        </p>
                    </div>
                </div>
            </div>

            <!-- Card 2 -->
            <div class="col-md-4 col-lg-3">
                <div class="card shadow-sm h-100 text-center">
                    <img src="https://images.unsplash.com/photo-1551024601-bec78aea704b?auto=format&fit=crop&w=800&q=80"
                         class="card-img-top"
                         style="height:180px; object-fit:cover;"
                         alt="Calidad">

                    <div class="card-body">
                        <h5 class="card-title">Calidad</h5>
                        <p class="card-text">
                            Ingredientes frescos y seleccionados
                            para garantizar excelencia.
                        </p>
                    </div>
                </div>
            </div>

            <!-- Card 3 -->
            <div class="col-md-4 col-lg-3">
                <div class="card shadow-sm h-100 text-center">
                    <img src="https://images.unsplash.com/photo-1499636136210-6f4ee915583e?auto=format&fit=crop&w=800&q=80"
                         class="card-img-top"
                         style="height:180px; object-fit:cover;"
                         alt="Experiencia dulce">

                    <div class="card-body">
                        <h5 class="card-title">Experiencia</h5>
                        <p class="card-text">
                            Diseñamos cada postre para acompañar
                            momentos especiales.
                        </p>
                    </div>
                </div>
            </div>

        </div>
    </div>
</section>

<!-- SECCIÓN FINAL DE TEXTO -->
<section class="py-5">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 text-center">
                <h3 class="fw-bold mb-3">Un proyecto con propósito</h3>
                <p class="text-muted">
                    Este sistema web representa la integración de diseño,
                    desarrollo y bases de datos para simular un entorno
                    real de gestión y compra de productos de repostería.
                </p>
            </div>
        </div>
    </div>
</section>

</asp:Content>
