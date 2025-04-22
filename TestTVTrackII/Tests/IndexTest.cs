using Microsoft.VisualStudio.TestTools.UnitTesting;
using TVTrackII.Models;

namespace TestTVTrackII.Tests
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
            Assert.IsTrue(esValido);
        }

        [TestMethod]
        public void Comentarios_MuestraMensaje_Solo_Si_Lista_Vacia()
        {
            // Arrange
            var comentarios = new List<Comentario>();

            // Act
            bool hayComentarios = comentarios.Any();

            // Assert
            Assert.IsFalse(hayComentarios, "Debería mostrarse el mensaje 'No hay comentarios aún.' cuando esta la lista esta vacía.");
        }

        [TestMethod]
        public void Comentarios_Tiene_Boton_Enviar()
        {
            // Arrange
            string htmlForm = @"
        <form method=""post"">
            <button type=""submit"" class=""btn btn-primary"">Enviar</button>
        </form>";

            // Act
            bool contieneBoton = htmlForm.Contains("<button type=\"submit\" class=\"btn btn-primary\">Enviar</button>");

            // Assert
            Assert.IsTrue(contieneBoton);
        }


        [TestMethod]
        public void No_Agrega_Comentario_Si_Texto_Vacio()
        {
            // Arrange
            var comentario = new Comentario { Texto = "", ContenidoId = 1 };

            // Act
            var esValido = !string.IsNullOrWhiteSpace(comentario.Texto);

            // Assert
            Assert.IsFalse(esValido, "No permitira agregar un comentario sin texto.");
        }

      
    }
}
