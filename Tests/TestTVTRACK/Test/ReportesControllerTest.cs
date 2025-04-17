using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TVTrackII.Test
{
    [TestClass]
    public class ReportesControllerTests
    {
        [TestMethod]
        public void GenerarReporteUsuarios_DeberiaContarUsuariosYActivos()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario("Usuario1", "correo1@example.com") { Historial = new List<Contenido> { new Contenido("A", "Acción", 8.5, false) } },
                new Usuario("Usuario2", "correo2@example.com"),
                new Usuario("Usuario3", "correo3@example.com") { Historial = new List<Contenido> { new Contenido("B", "Drama", 7.2, false) } }
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            ReportesController.GenerarReporteUsuarios(usuarios);
            var output = sw.ToString();

            // Assert
            StringAssert.Contains(output, "Total de usuarios registrados: 3");
            StringAssert.Contains(output, "Usuarios activos (que han visto contenido): 2");
        }

        [TestMethod]
        public void GenerarReporteGeneros_DeberiaMostrarCantidadPorGenero()
        {
            // Arrange
            var contenidos = new List<Contenido>
            {
                new Contenido("A", "Acción", 8.0, false),
                new Contenido("B", "Drama", 7.5, false),
                new Contenido("C", "Acción", 9.0, false),
                new Contenido("D", "Comedia", 6.5, false),
                new Contenido("E", "Acción", 7.0, false)
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            ReportesController.GenerarReporteGeneros(contenidos);
            var output = sw.ToString();

            // Assert
            StringAssert.Contains(output, "Acción: 3 títulos");
            StringAssert.Contains(output, "Drama: 1 títulos");
            StringAssert.Contains(output, "Comedia: 1 títulos");
        }
    }
}
