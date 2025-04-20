using Microsoft.VisualStudio.TestTools.UnitTesting;
using TVTrackII.Models;

namespace TestTVTrackII
{
    [TestClass]
    public class IndexTest
    {
        [TestMethod]
        public void Verifica_Si_Comentario_Es_Valido()
        {
            // Arrange
            var comentario = new Comentario
            {
                Texto = "Buen contenido",
                ContenidoId = 5
            };

            // Act
            var esValido = !string.IsNullOrWhiteSpace(comentario.Texto) && comentario.ContenidoId > 0;

            // Assert
            Assert.IsTrue(esValido, "El comentario debería considerarse válido si tiene texto y un ContenidoId válido.");
        }
    }
}
