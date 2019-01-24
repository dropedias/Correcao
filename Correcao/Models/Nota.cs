namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTAS")]
    public partial class Nota
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Nota()
        //{
        //    Questao = new HashSet<Questao>();
        //}

        [Key]
        [Column("ID_NOTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdNota { get; set; }

        [Column("VL_NOTA")]
        public decimal ValorNota { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Questao> Questao { get; set; }
    }
}
