using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEFCoreNet6.Models
{
    public class Usuario
    {
        // Atributos 
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        // Constructor 
        public Usuario(int id, string nombre, string telefono, string celular, string email) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Celular = celular;
            this.Email = email;
   
        }

    }
}