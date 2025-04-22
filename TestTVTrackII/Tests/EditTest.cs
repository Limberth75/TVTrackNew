using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII.Tests
{

    [TestClass]

    public class EditTest
    {
        // Simulamos clase para el usuario
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = "";
            public string Correo { get; set; } = "";
            public string Contrasena { get; set; } = "";
            public string Rol { get; set; } = "Usuario";
        }

        [TestMethod]
        public void Correo_Deberia_Terminar_En_Com()
        {
            // Arrange
            string correo = "usuario@mail.com";

            // Act
            bool esValido = correo.Trim().ToLower().EndsWith(".com");

            // Assert
            Assert.IsTrue(esValido, "El correo debe terminar en .com");
        }

        [TestMethod]
        public void Contraseña_Deberia_Ser_Numérica_Y_Maximo_5_Digitos()
        {
            // Arrange
            string contrasena = "12345";

            // Act
            bool esNumerica = contrasena.All(char.IsDigit);
            bool largoValido = contrasena.Length <= 5;
            bool esValida = esNumerica && largoValido;

            // Assert
            Assert.IsTrue(esValida, "La contrasena debe ser numerica y de máximo 5 dígitos.");
        }

        [TestMethod]
        public void No_Permitir_Mas_De_5_Administradores()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Rol = "Administrador" },
                new Usuario { Id = 2, Rol = "Administrador" },
                new Usuario { Id = 3, Rol = "Administrador" },
                new Usuario { Id = 4, Rol = "Administrador" },
                new Usuario { Id = 5, Rol = "Administrador" }
            };

            var usuarioEditado = new Usuario { Id = 6, Rol = "Administrador" };

            // Act
            int totalAdmins = usuarios.Count(u => u.Rol == "Administrador" && u.Id != usuarioEditado.Id);
            bool puedeConvertirse = totalAdmins < 5;

            // Assert
            Assert.IsFalse(puedeConvertirse, "No pueden agregar mas de 5 admins.");
        }

        [TestMethod]
        public void Usuario_Actualizable_Cuando_Todo_Es_Valido()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 10,
                Nombre = "Chris",
                Correo = "chris@hotmail.com",
                Contrasena = "1234",
                Rol = "Usuario"
            };

            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Correo = "admin@hotmail.com", Rol = "Administrador" },
                new Usuario { Id = 2, Correo = "admin2@hotmail.com", Rol = "Administrador" },
            };

            // Act
            bool correoTerminaCom = usuario.Correo.ToLower().EndsWith(".com");
            bool contrasenaValida = usuario.Contrasena.Length <= 5 && usuario.Contrasena.All(char.IsDigit);
            bool correoDuplicado = usuarios.Any(u => u.Correo == usuario.Correo && u.Id != usuario.Id);
            bool puedeEditar = correoTerminaCom && contrasenaValida && !correoDuplicado;

            // Assert
            Assert.IsTrue(puedeEditar, "El usuario tiene que poder actualizarse si cumple con todas las validaciones.");
        }


    }
}
