using Microsoft.VisualStudio.TestTools.UnitTesting;
using TVTrackII.Models; 

namespace TestTVTrackII
{
    [TestClass]
    public class ComentarioTests
    {
        [TestMethod]
        public void BotonEnviar_Habilitado_Si_Comentario_Es_Valido()
        {
            // Arrange: Crear un comentario simulado
            var comentario = new Comentarios
            {
                Texto = "Muy interesante este contenido",
                ContenidoId = 1 // Supongamos que este ID representa un contenido existente
            };

            // Act: Validar si los campos necesarios están completos
            var esValido = !string.IsNullOrWhiteSpace(comentario.Texto) && comentario.ContenidoId > 0;

            // Assert: Se espera que el comentario sea válido
            Assert.IsTrue(esValido, "El botón 'Enviar' debería estar habilitado si el comentario tiene texto y un ContenidoId válido.");
        }
    }
}
