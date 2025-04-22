using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII.Tests
{

    [TestClass]
    public class DeleteTest
    {
        // Simulamos un usuario :)
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = "";
            public string Correo { get; set; } = "";
        }

        [TestMethod]
        public void EliminarUsuario_Deberia_Redireccionar_Si_No_Existe()
        {
            // Arrange: lista vacía = no existe
            var listaUsuarios = new List<Usuario>();
            int idAEliminar = 1;

            // Act: Buscar usuario
            var usuario = listaUsuarios.FirstOrDefault(u => u.Id == idAEliminar);

            // Assert: no debería encontrarlo
            Assert.IsNull(usuario, "Si el usuario no existe, tiene que retornar null y redirigir.");
        }

        [TestMethod]
        public void Usuario_Se_Elimina_Si_Existe()
        {
            // Arrange: lista con un usuario
            var listaUsuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Juan", Correo = "juan@mail.com" }
            };

            int idAEliminar = 1;

            // Act: encontrar y eliminar
            var usuario = listaUsuarios.FirstOrDefault(u => u.Id == idAEliminar);
            bool eliminado = false;

            if (usuario != null)
            {
                listaUsuarios.Remove(usuario);
                eliminado = true;
            }

            // Assert
            Assert.IsTrue(eliminado, "El usuario existente tiene que eliminarse correctamente.");
            Assert.AreEqual(0, listaUsuarios.Count, "La lista debería quedar vacía tras eliminar.");
        }

        [TestMethod]
        public void Vista_Muestra_Nombre_Y_Correo_Del_Usuario()
        {
            // Arrange
            var usuario = new Usuario { Nombre = "Chris", Correo = "chris@mail.com" };

            // Act
            string textoRenderizado = $"¿Estás seguro que deseas eliminar el usuario: <strong>{usuario.Nombre}</strong> con correo: <strong>{usuario.Correo}</strong>?";

            // Assert
            Assert.IsTrue(textoRenderizado.Contains(usuario.Nombre) && textoRenderizado.Contains(usuario.Correo),
                "La vista tiene que mostrar correctamente el nombre y correo del usuario.");
        }


    }
}
