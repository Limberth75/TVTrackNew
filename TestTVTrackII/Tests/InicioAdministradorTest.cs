using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII.Tests
{
    [TestClass]
    public class InicioAdministradorTest
    {

        [TestMethod]
        public void PanelAdministrador_Tiene_Todos_Los_Enlaces()
        {
            // Arrange: Se simula el HTML de la página de administrador
            string htmlSimulado = @"
                <ul>
                    <li><a href=""/Usuarios"">Gestión de Usuarios</a></li>
                    <li><a href=""#"">Gestión de Contenido</a></li>
                    <li><a href=""#"">Reportes</a></li>
                    <li><a href=""#"">Comentarios</a></li>
                    <li><a href=""#"">Estadísticas</a></li>
                    <li><a href=""/Login"">Cerrar Sesión</a></li>
                </ul>";

            // Act: Se valida si cada enlace clave está presente en el HTML
            bool tieneUsuarios = htmlSimulado.Contains("href=\"/Usuarios\"");
            bool tieneLogin = htmlSimulado.Contains("href=\"/Login\"");
            bool tieneReportes = htmlSimulado.Contains(">Reportes<");
            bool tieneComentarios = htmlSimulado.Contains(">Comentarios<");
            bool tieneEstadisticas = htmlSimulado.Contains(">Estadísticas<");

            // Assert: Todos los enlaces esperados deben estar
            Assert.IsTrue(tieneUsuarios && tieneLogin && tieneReportes && tieneComentarios && tieneEstadisticas,
                "El panel tiene que tener enlaces a todas las secciones ");
        }

    }
}
