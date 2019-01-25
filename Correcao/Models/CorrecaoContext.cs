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
        public virtual DbSet<Candidato> Candidatos { get; set; }
        public virtual DbSet<Imagem> Imagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>()
                .Property(e => e.NomeCandidato)
                .IsUnicode(false);

            modelBuilder.Entity<Candidato>()
                .Property(e => e.ValorNota);

            modelBuilder.Entity<Candidato>()
                .Property(e => e.IsLock);

            modelBuilder.Entity<Questao>()
                .HasMany(e => e.Candidatos)
                .WithMany(e => e.Questoes)                
                .Map(m => m.ToTable("CANDIDATO_QUESTAO").MapLeftKey("ID_QUESTAO").MapRightKey("ID_CANDIDATO"));

            //modelBuilder.Entity<Candidato>()
            //    .HasMany(e => e.Questoes)
            //    .WithMany(e => e.Candidatos)
            //    .Map(m => m.ToTable("CANDIDATO_QUESTAO").MapLeftKey("ID_CANDIDATO").MapRightKey("ID_QUESTAO"));

            modelBuilder.Entity<Questao>()
                .Property(e => e.DescricaoQuestao)
                .IsUnicode(false);

            //modelBuilder.Entity<Nota>()
            //    .Property(e => e.ValorNota)
            //    .HasPrecision(18, 0);            

            modelBuilder.Entity<TipoQuestao>()
                .Property(e => e.DescricaoTipoQuestao)
                .IsUnicode(false);                                             

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Perfil)
                .IsUnicode(false);

            //modelBuilder.Entity<TipoQuestao>()
            //    .HasMany(e => e.Questao)
            //    .WithOptional(e => e.TipoQuestao)
            //    .HasForeignKey(e => e.IdTipoQuestao);    

            //modelBuilder.Entity<Candidato>()
            //.HasMany(e => e.Questoes)
            //.WithMany(c => c.Candidatos)            
            //.Map(cs =>
            //{
            //    cs.MapLeftKey("ID_CANDIDATO");
            //    cs.MapRightKey("ID_QUESTAO");
            //    cs.ToTable("CANDIDATO_QUESTAO");
            //});

            //base.OnModelCreating(modelBuilder);
        }
    }
}
