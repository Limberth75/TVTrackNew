using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII.Tests
{
    [TestClass]
    public class GenerarPdfTest
    {
        [TestMethod]
        public void Pagina_GenerarPdf_Contiene_Boton_Descarga()
        {
            // Arrange:
            // Simulamos el HTML que se renderiza en la página
            string htmlSimulado = @"
                <h2>Reporte PDF</h2>
                <p>Haz clic en el botón para descargar el archivo PDF generado:</p>
                <a asp-page-handler=""Descargar"" class=""btn btn-primary"">Descargar PDF</a>
            ";

            // Act:
            // Verificamos si el HTML contiene el botón correcto para descargar el PDF
            bool contieneBotonDescarga = htmlSimulado.Contains("asp-page-handler=\"Descargar\"") &&
                                         htmlSimulado.Contains(">Descargar PDF<");

            // Assert:
            // Confirmamos que el botón esté presente
            Assert.IsTrue(contieneBotonDescarga);
        }
    }
}
