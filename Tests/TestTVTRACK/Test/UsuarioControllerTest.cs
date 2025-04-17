using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TVTrackII.Test
{


    [TestClass]
    public class UsuarioControllerTest
    {
        private const string ArchivoBackup = "usuarios_backup.json";
        private const string ArchivoOriginal = "usuarios.json";

        [TestInitialize]
        public void Setup()
        {
            // Respalda el archivo original si existe
            if (File.Exists(ArchivoOriginal))
                File.Copy(ArchivoOriginal, ArchivoBackup, true);

            // Inicializa un archivo vacío para evitar efectos colaterales
            File.WriteAllText(ArchivoOriginal, "[]");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Elimina archivo de prueba
            if (File.Exists(ArchivoOriginal))
                File.Delete(ArchivoOriginal);

            // Restaura archivo original si había uno
            if (File.Exists(ArchivoBackup))
                File.Copy(ArchivoBackup, ArchivoOriginal, true);
        }

        [TestMethod]
        public void AgregarUsuario_DeberiaAgregarUsuarioYGuardar()
        {
            // Arrange
            bool eventoDisparado = false;
            UsuarioController.UsuarioAgregado += () => eventoDisparado = true;

            string nombre = "Chris Test";
            string email = "chris@example.com";
            string contraseña = "secure123";
            string rol = "Usuario";

            // Act
            UsuarioController.AgregarUsuario(nombre, email, contraseña, rol);
            var usuarios = UsuarioController.ObtenerUsuarios();
            var usuario = UsuarioController.ObtenerUsuarioPorNombre(nombre);

            // Assert
            Assert.IsTrue(eventoDisparado);
            Assert.IsNotNull(usuario);
            Assert.AreEqual(nombre, usuario.Nombre);
            Assert.AreEqual(email, usuario.Email);
            Assert.AreEqual(rol, usuario.Rol);
            Assert.IsTrue(File.Exists(ArchivoOriginal));
        }

        [TestMethod]
        public void AgregarContenidoAHistorial_DeberiaAgregarContenidoAlUsuario()
        {
            // Arrange
            string nombre = "Historial Tester";
            UsuarioController.AgregarUsuario(nombre, "historial@test.com", "1234", "Usuario");
            var usuario = UsuarioController.ObtenerUsuarioPorNombre(nombre);

            var contenido = new Contenido("Serie Cool", "Drama", 8.5, false);

            // Act
            UsuarioController.AgregarContenidoAHistorial(usuario, contenido);

            // Assert
            Assert.IsNotNull(usuario);
            Assert.AreEqual(1, usuario.Historial.Count);
            Assert.AreEqual("Serie Cool", usuario.Historial[0].Titulo);
        }

        [TestMethod]
        public void GenerarUsuariosAleatorios_DeberiaCrearLaCantidadCorrecta()
        {
            // Arrange
            int cantidad = 5;

            // Act
            UsuarioController.GenerarUsuariosAleatorios(cantidad);
            var usuarios = UsuarioController.ObtenerUsuarios();

            // Assert
            Assert.IsTrue(usuarios.Count >= cantidad);
        }
    }
}

}
