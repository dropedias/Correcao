namespace Correcao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTAO")]
    public partial class Questao
    {
        [Key]
        [Column("ID_QUESTAO")]
        public int IdQuestao { get; set; }

        [Required]
        [StringLength(200)]
        [Column("DS_QUESTAO")]
        public string DescricaoQuestao { get; set; }

        [Column("ID_TIPO_QUESTAO")]
        public int? IdTipoQuestao { get; set; }

        [Column("ID_NOTA")]
        public int? IdNota { get; set; }

        //[Column("ID_NOTA")]
        public Nota Nota { get; set; }

        //[Column("ID_TIPO_QUESTAO")]
        public TipoQuestao TipoQuestao { get; set; }
    }
}
