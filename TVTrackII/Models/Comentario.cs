using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVTrackII.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int ContenidoId { get; set; }

        [Required]
        [StringLength(300)]
        public string Texto { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relaciones
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("ContenidoId")]
        public Contenido? Contenido { get; set; }

        // Propiedad auxiliar para mostrar el nombre del usuario
        [NotMapped]
        public string UsuarioNombre => Usuario?.Nombre ?? "Desconocido";
    }
}
