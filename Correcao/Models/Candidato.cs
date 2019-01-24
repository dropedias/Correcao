namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CANDIDATO")]
    public partial class Candidato
    {
        public Candidato()
        {
            Questoes = new HashSet<Questao>();
        }

        [Key]
        [Column("ID_CANDIDATO")]
        public int IdCandidato { get; set; }

        [StringLength(50)]
        [Column("NOME_CANDIDATO")]
        public string NomeCandidato { get; set; }

        [Column("ID_IMAGEM")]
        public int? IdImagem { get; set; }

        [Column("VL_NOTA")]
        public decimal? ValorNota { get; set; }

        public virtual Imagem Imagem { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questao> Questoes { get; set; }
    }
}
