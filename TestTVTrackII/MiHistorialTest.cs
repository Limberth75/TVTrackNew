using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTVTrackII
{
    [TestClass]
    internal class MiHistorialTest
    {
        // Definimos las clases para simular el historial
        public class Contenido
        {
            public string Titulo { get; set; }
            public string Genero { get; set; }
        }

        public class HistorialItem
        {
            public Contenido Contenido { get; set; }
            public DateTime Fecha { get; set; }
        }

        [TestMethod]
        public void Historial_Se_Muestra_Si_Hay_Contenido()
        {
            // Arrange: Se crea una lista con un historial de ejemplo
            var historial = new List<HistorialItem>
            {
                new HistorialItem
                {
                    Contenido = new Contenido { Titulo = "Película X", Genero = "Acción" },
                    Fecha = DateTime.Now
                }
            };

            // Act: Se revisa si hay contenido para mostrar
            bool hayContenido = historial.Any();

            // Assert: Se espera que haya contenido
            Assert.IsTrue(hayContenido);
        }

        [TestMethod]
        public void Se_Muestra_Mensaje_Cuando_No_Hay_Contenido()
        {
            // Arrange: Se crea una lista vacía (sin historial)
            var historial = new List<HistorialItem>();

            // Act: Se revisa si hay contenido
            bool hayContenido = historial.Any();

            // Assert: Se espera que NO haya contenido
            Assert.IsFalse(hayContenido);
        }


    }
}
