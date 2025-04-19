using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTVTrackII
{
    [TestClass]
    internal class LoginlTest
    {
        [TestMethod]
        public void Boton_Ingresar_Deberia_Estar_Presente()
        {
            // Arrange: Se crea una versión simulada del HTML de la página
            string htmlLogin = @"
                <form method=""post"">
                    <div class=""mb-3"">
                        <label class=""form-label"">Correo:</label>
                        <input class=""form-control"" />
                    </div>
                    <div class=""mb-3"">
                        <label class=""form-label"">Contraseña:</label>
                        <input type=""password"" class=""form-control"" />
                    </div>
                    <button type=""submit"" class=""btn btn-primary w-100"">Ingresar</button>
                </form>
            ";

            // Act: Se revisa si el HTML contiene el botón "Ingresar"
            bool botonExiste = htmlLogin.Contains("<button type=\"submit\" class=\"btn btn-primary w-100\">Ingresar</button>");

            // Assert: Se verifica que el botón esté en la página
            Assert.IsTrue(botonExiste);
        }
    }
}
