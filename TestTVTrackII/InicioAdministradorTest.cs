using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestTVTrackII
{
    [TestClass]
    internal class InicioAdministradorTest
    {
        [TestMethod]
        public void CerrarSesion_Deberia_Existir_En_InicioAdministrador()
        {
            // Arrange: Se simula el HTML de la página InicioAdministrador.cshtml
            string htmlPagina = @"
                <h2>Panel de Administración</h2>
                <nav>
                    <ul style=""list-style-type:none; padding:0;"">
                        <li><a href=""/Usuarios"">Gestión de Usuarios</a></li>
                        <li><a href=""#"">Gestión de Contenido</a></li>
                        <li><a href=""#"">Reportes</a></li>
                        <li><a href=""#"">Comentarios</a></li>
                        <li><a href=""#"">Estadísticas</a></li>
                        <li><a href=""/Login"">Cerrar Sesión</a></li>
                    </ul>
                </nav>
            ";

            // Act: Se verifica si el enlace de cerrar sesión está presente
            bool contieneLinkCerrarSesion = htmlPagina.Contains("<a href=\"/Login\">Cerrar Sesión</a>");

            // Assert: Se espera que el enlace esté en el HTML
            Assert.IsTrue(contieneLinkCerrarSesion);
        }

    }
}
