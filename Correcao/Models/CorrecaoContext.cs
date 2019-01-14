namespace Correcao.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CorrecaoContext : DbContext
    {
        public CorrecaoContext()
            : base("name=Cesgranrio")
        {
        }

        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<Questao> Questoes { get; set; }
        public virtual DbSet<TipoQuestao> TiposQuestao { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>()
                .Property(e => e.ValorNota)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Questao>()
                .Property(e => e.DescricaoQuestao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoQuestao>()
                .Property(e => e.DescricaoTipoQuestao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoQuestao>()
                .HasMany(e => e.Questao)
                .WithOptional(e => e.TipoQuestao)
                .HasForeignKey(e => e.IdTipoQuestao);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
