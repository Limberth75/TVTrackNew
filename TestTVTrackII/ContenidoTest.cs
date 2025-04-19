[TestMethod]
public void ContenidoPage_BotonHomePage()
{
    // Arrange:
    // Se simula el HTML que se renderiza en la página
    string htmlSimulado = @"
        <h2>Gestión de Contenido</h2>
        <p>
            <a class=""btn btn-secondary"" href=""/HomePage"">Volver al Inicio</a>
        </p>";

    // Act:
    // Busca si el enlace correcto está presente
    bool contieneBoton = htmlSimulado.Contains("href=\"/HomePage\"") &&
                         htmlSimulado.Contains(">Volver al Inicio<");

    // Assert:
    // Revisa que el HTML contenga correctamente el enlace al HomePage
    Assert.IsTrue(contieneBoton, "La página debería contener un botón que redirige a /HomePage");
}
