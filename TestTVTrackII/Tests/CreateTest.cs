using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTVTrackII.Tests
{
    [TestClass]
    public class CreateTest
    {
        // Clase simulada para usuario
        public class Usuario
        {
            public string Nombre { get; set; } = "";
            public string Correo { get; set; } = "";
            public string Contrasena { get; set; } = "";
            public string Rol { get; set; } = "Usuario";
        }

        [TestMethod]
        public void Correo_Debe_Terminar_En_Com()
        {
            // Arrange
            var usuario = new Usuario { Correo = "ejemplo@gmail.net" };

            // Act
            bool correoValido = usuario.Correo.Trim().ToLower().EndsWith(".com");

            // Assert
            Assert.IsFalse(correoValido, "El correo debería terminar en .com");
        }

        [TestMethod]
        public void Contrasena_Deberia_Ser_Numerica_Y_Maximo_5_Digitos()
        {
            // Arrange
            var usuario = new Usuario { Contrasena = "12345" };

            // Act
            bool esNumericaYValida = usuario.Contrasena.Length <= 5 &&
                                     usuario.Contrasena.All(char.IsDigit);

            // Assert
            Assert.IsTrue(esNumericaYValida, "La contraseña debe ser numérica y de máximo 5 dígitos.");
        }

        [TestMethod]
        public void Contrasena_Invalida_Si_Tiene_Letras()
        {
            // Arrange
            var usuario = new Usuario { Contrasena = "12a34" };

            // Act
            bool esValida = usuario.Contrasena.All(char.IsDigit);

            // Assert
            Assert.IsFalse(esValida, "La contraseña no debe contener letras.");
        }

        [TestMethod]
        public void No_Se_Puede_Registrar_Si_Correo_Ya_Existe()
        {
            // Arrange: Lista simulada de usuarios en la base de datos
            var usuariosExistentes = new List<Usuario>
    {
        new Usuario { Correo = "repetido@mail.com" },
        new Usuario { Correo = "otro@mail.com" }
    };

            var nuevoUsuario = new Usuario { Correo = "repetido@mail.com" };

            // Act: Validación por duplicado
            bool correoExiste = usuariosExistentes
                .Any(u => u.Correo.Trim().ToLower() == nuevoUsuario.Correo.Trim().ToLower());

            // Assert: Se espera que el sistema detecte el duplicado
            Assert.IsTrue(correoExiste, "No debería permitirse registrar un correo que ya existe.");
        }

        [TestMethod]
        public void No_Se_Pueden_Crear_Mas_De_Cinco_Administradores()
        {
            // Arrange: Simulamos una lista con 5 administradores ya existentes
            var usuariosExistentes = new List<Usuario>
    {
        new Usuario { Rol = "Administrador" },
        new Usuario { Rol = "Administrador" },
        new Usuario { Rol = "Administrador" },
        new Usuario { Rol = "Administrador" },
        new Usuario { Rol = "Administrador" }
    };

            var nuevoUsuario = new Usuario { Rol = "Administrador" };

            // Act: Se valida cuantos admins hay
            int totalAdmins = usuariosExistentes.Count(u => u.Rol == "Administrador");
            bool sePermiteNuevoAdmin = totalAdmins < 5;

            // Assert: No se debería permitir un nuevo administrador
            Assert.IsFalse(sePermiteNuevoAdmin, "No se deberían permitir más de 5 administradores.");
        }
    }
}
