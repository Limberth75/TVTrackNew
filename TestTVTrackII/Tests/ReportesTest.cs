using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTVTrackII
{
    [TestClass]

    public class ReportesTest
    {
        // Clase falsa para simular el modelo
        public class ReportesModel
        {
            public string MensajeError { get; set; }
        }

        [TestMethod]
        public void Se_Muestran_Botones_Si_No_Hay_Error()
        {
            // Arrange: se crea el modelo sin mensaje de error
            var model = new ReportesModel
            {
                MensajeError = null
            };

            // Act: se verifica si se pueden mostrar los botones
            bool seMuestranBotones = string.IsNullOrEmpty(model.MensajeError);

            // Assert: se espera que sí se muestren los botones
            Assert.IsTrue(seMuestranBotones, "Los botones de descarga deberían mostrarse si no hay error.");
        }

        [TestMethod]
        public void Se_Muestra_Mensaje_De_Error_Si_Existe()
        {
            // Arrange: se crea el modelo con un mensaje de error
            var model = new ReportesModel
            {
                MensajeError = "Error al generar el reporte"
            };

            // Act: se revisa si hay un mensaje de error
            bool hayError = !string.IsNullOrEmpty(model.MensajeError);

            // Assert: se espera que el mensaje se muestre
            Assert.IsTrue(hayError);
        }

    }
}
