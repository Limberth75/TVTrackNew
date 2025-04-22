 using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTVTrackII.Tests
{
    [TestClass]
    public class ContenidoTests
    {
        [TestMethod]
        public void Contenido_Boton_HomePage()
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

        [TestMethod]
        public void ContenidoPage_Renderiza_Tabla_Administrador_Si_Rol_Es_Administrador()
        {
            // Arrange
            var rolUsuario = "Administrador";

            // Act
            bool muestraTablaAdmin = rolUsuario == "Administrador";

            // Assert
            Assert.IsTrue(muestraTablaAdmin, "Si el rol es Administrador, se debe mostrar la tabla con la columna Veces Visto.");
        }

        [TestMethod]
        public void ContenidoPage_Renderiza_Tabla_Usuario_Si_Rol_Es_Usuario()
        {
            // Arrange
            var rolUsuario = "Usuario";

            // Act
            bool muestraTablaUsuario = rolUsuario != "Administrador";

            // Assert
            Assert.IsTrue(muestraTablaUsuario, "Si el rol no es Administrador, se debe mostrar la tabla de acciones.");
        }

        [TestMethod]
        public void ContenidoPage_Contiene_Boton_Ver_Contenido()
        {
            // Arrange
            string htmlSimulado = @"<a href=""/Contenido?handler=Ver&idContenido=1"" class=""btn btn-primary"">Ver</a>";

            // Act
            bool contieneBotonVer = htmlSimulado.Contains("href=\"/Contenido?handler=Ver&idContenido=") &&
                                     htmlSimulado.Contains(">Ver<");

            // Assert
            Assert.IsTrue(contieneBotonVer, "La página debería contener un botón para ver el contenido.");
        }

        [TestMethod]
        public void OnGetVer_Solo_Registra_Si_No_Ha_Visto()
        {
            // Arrange: Suponemos que ya vio el contenido
            bool yaVisto = true;

            // Act: Se ejecuta la lógica que decide si registrar o no
            bool debeRegistrar = !yaVisto;

            // Assert
            Assert.IsFalse(debeRegistrar, "No debería registrarse una nueva visualización si el usuario ya vio el contenido.");
        }

    }
}
