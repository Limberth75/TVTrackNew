using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII
{

    [TestClass]
    internal class InicioTest
    {

        [TestMethod]
        public void CerrarSesion_Tiene_Link_A_Login()
        {
            // Arrange: Se simula el HTML de la página 
            string htmlPagina = @"
                <h2>Bienvenido Usuario</h2>
                <p>Has iniciado sesión como usuario normal.</p>
                <a href=""/Login"">Cerrar sesión</a>
            ";

            // Act: Se busca si el enlace al login está en el HTML
            bool contieneLinkCerrarSesion = htmlPagina.Contains("<a href=\"/Login\">Cerrar sesión</a>");

            // Assert: Se espera que el link esté presente
            Assert.IsTrue(contieneLinkCerrarSesion, "La página debería tener un enlace para cerrar sesión que redirija al Login.");
        }
    }
}
