namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIPO_QUESTAO")]
    public partial class TipoQuestao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoQuestao()
        {
            Questao = new HashSet<Questao>();
        }

        [Key]
        [Column("ID_TIPO_QUESTAO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTipoQuestao { get; set; }

        [StringLength(50)]
        [Column("DS_TIPO_QUESTAO")]
        public string DescricaoTipoQuestao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questao> Questao { get; set; }
    }
}
