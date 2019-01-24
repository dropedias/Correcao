namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class Usuario
    {
        [Key]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        [Required]
        [StringLength(50)]
        public string Perfil { get; set; }
    }
}
