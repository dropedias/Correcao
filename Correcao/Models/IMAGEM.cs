namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMAGEM")]
    public partial class Imagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Imagem()
        //{
        //    Candidatos = new HashSet<Candidato>();
        //}

        [Key]
        [Column("ID_IMAGEM")]
        public int IdImagem { get; set; }
        
        [Column("CONTENT_IMAGEM", TypeName = "image")]
        public byte[] Conteudo { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}
