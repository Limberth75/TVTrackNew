using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TVTrackII.Test
{
    [TestClass]
    public class ContenidoControllerTests
    {
        [TestMethod]
        public void ObtenerContenido_DeberiaRetornar100Elementos()
        {
            // Act
            List<Contenido> lista = ContenidoController.ObtenerContenido();

            // Assert
            Assert.AreEqual(100, lista.Count);
        }

        [TestMethod]
        public void CargarContenido_DeberiaResetearYRegenerarContenido()
        {
            // Arrange
            ContenidoController.CargarContenido();
            var contenidoAntes = ContenidoController.ObtenerContenido();

            // Act
            ContenidoController.CargarContenido();
            var contenidoDespues = ContenidoController.ObtenerContenido();

            // Assert
            Assert.AreEqual(100, contenidoDespues.Count);
            CollectionAssert.AreNotEqual(contenidoAntes, contenidoDespues);
        }

        [TestMethod]
        public void CadaContenido_DeberiaTenerTituloGeneroYCalificacionValidos()
        {
            // Act
            List<Contenido> lista = ContenidoController.ObtenerContenido();

            // Assert
            foreach (var item in lista)
            {
                Assert.IsFalse(string.IsNullOrEmpty(item.Titulo), "El título no debe estar vacío.");
                Assert.IsFalse(string.IsNullOrEmpty(item.Genero), "El género no debe estar vacío.");
                Assert.IsTrue(item.Calificacion >= 0 && item.Calificacion <= 10, "La calificación debe estar entre 0 y 10.");
            }
        }
    }
}
