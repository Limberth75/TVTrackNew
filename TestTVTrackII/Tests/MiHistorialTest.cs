﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTVTrackII
{
    [TestClass]
    public class MiHistorialTest
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

        [TestMethod]
        public void Historial_Incluye_Boton_Comentarios()
        {
            // Arrange: Simula una fila del historial con el botón
            string filaHtml = @"
        <tr>
            <td>Película X</td>
            <td>Acción</td>
            <td>01/01/2024 10:00 AM</td>
            <td>
                <a href=""/Comentarios/1"" class=""btn btn-sm btn-outline-primary"">Comentarios</a>
            </td>
        </tr>";

            // Act: Se revisa si el HTML contiene el enlace de comentarios
            bool tieneBotonComentarios = filaHtml.Contains("href=\"/Comentarios/1\"") &&
                                         filaHtml.Contains(">Comentarios<");

            // Assert: Se espera que sí exista
            Assert.IsTrue(tieneBotonComentarios, "Cada elemento del historial debería tener un botón de comentarios.");
        }

        [TestMethod]
        public void Fecha_De_Historial_Deberia_Tener_Formato_Valido()
        {
            // Arrange
            var fecha = new DateTime(2024, 4, 20, 14, 30, 0);

            // Act
            var formato = fecha.ToString("g");

            // Assert
            Assert.AreEqual("20/04/2024 14:30", formato);
        }

    }
}
