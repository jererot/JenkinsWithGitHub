namespace CristoRey.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BDColegio : DbContext
    {
        public BDColegio()
            : base("name=BDColegio")
        {
        }

        public virtual DbSet<ALUMNO> ALUMNO { get; set; }
        public virtual DbSet<AREA> AREA { get; set; }
        public virtual DbSet<ASIGNACION_CURSO_DOCENTE> ASIGNACION_CURSO_DOCENTE { get; set; }
        public virtual DbSet<AULA> AULA { get; set; }
        public virtual DbSet<CURSO> CURSO { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<DISTRITO> DISTRITO { get; set; }
        public virtual DbSet<DOCENTE> DOCENTE { get; set; }
        public virtual DbSet<DOCENTE_FULLTIME> DOCENTE_FULLTIME { get; set; }
        public virtual DbSet<DOCENTE_PARTTIME> DOCENTE_PARTTIME { get; set; }
        public virtual DbSet<EVALUACION> EVALUACION { get; set; }
        public virtual DbSet<GRADO> GRADO { get; set; }
        public virtual DbSet<MATRICULA> MATRICULA { get; set; }
        public virtual DbSet<PABELLON> PABELLON { get; set; }
        public virtual DbSet<PADRE_FAMILIA> PADRE_FAMILIA { get; set; }
        public virtual DbSet<PERIODO> PERIODO { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIA { get; set; }


        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.nom_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.app_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.apm_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.dni_alum)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.sex_alum)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.cor_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.tel_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .Property(e => e.dir_alum)
                .IsUnicode(false);

            modelBuilder.Entity<ALUMNO>()
                .HasMany(e => e.MATRICULA)
                .WithRequired(e => e.ALUMNO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AREA>()
                .Property(e => e.des_are)
                .IsUnicode(false);

            modelBuilder.Entity<AREA>()
                .HasMany(e => e.CURSO)
                .WithRequired(e => e.AREA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AULA>()
                .Property(e => e.des_ubi)
                .IsUnicode(false);

            modelBuilder.Entity<AULA>()
                .HasMany(e => e.GRADO)
                .WithRequired(e => e.AULA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CURSO>()
                .Property(e => e.nom_cur)
                .IsUnicode(false);

            modelBuilder.Entity<CURSO>()
                .HasMany(e => e.ASIGNACION_CURSO_DOCENTE)
                .WithRequired(e => e.CURSO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CURSO>()
                .HasMany(e => e.EVALUACION)
                .WithRequired(e => e.CURSO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.nom_dep)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .HasMany(e => e.PROVINCIA)
                .WithRequired(e => e.DEPARTAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISTRITO>()
                .Property(e => e.nom_dis)
                .IsUnicode(false);

            modelBuilder.Entity<DISTRITO>()
                .HasMany(e => e.ALUMNO)
                .WithRequired(e => e.DISTRITO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISTRITO>()
                .HasMany(e => e.DOCENTE)
                .WithRequired(e => e.DISTRITO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DISTRITO>()
                .HasMany(e => e.PADRE_FAMILIA)
                .WithRequired(e => e.DISTRITO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.nom_doc)
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.app_doc)
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.apm_doc)
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.dni_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.sex_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.cor_doc)
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.tel_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.dir_doc)
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .Property(e => e.tip_doc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCENTE>()
                .HasMany(e => e.ASIGNACION_CURSO_DOCENTE)
                .WithRequired(e => e.DOCENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCENTE>()
                .HasOptional(e => e.DOCENTE_FULLTIME)
                .WithRequired(e => e.DOCENTE);

            modelBuilder.Entity<DOCENTE>()
                .HasOptional(e => e.DOCENTE_PARTTIME)
                .WithRequired(e => e.DOCENTE);

            modelBuilder.Entity<EVALUACION>()
                .Property(e => e.n1p_eva)
                .HasPrecision(4, 2);

            modelBuilder.Entity<EVALUACION>()
                .Property(e => e.n2p_eva)
                .HasPrecision(4, 2);

            modelBuilder.Entity<EVALUACION>()
                .Property(e => e.n1e_eva)
                .HasPrecision(4, 2);

            modelBuilder.Entity<EVALUACION>()
                .Property(e => e.n2e_eva)
                .HasPrecision(4, 2);

            modelBuilder.Entity<EVALUACION>()
                .Property(e => e.pro_eva)
                .HasPrecision(4, 2);

            modelBuilder.Entity<GRADO>()
                .Property(e => e.des_gra)
                .IsUnicode(false);

            modelBuilder.Entity<GRADO>()
                .Property(e => e.niv_gra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GRADO>()
                .Property(e => e.sec_gra)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GRADO>()
                .HasMany(e => e.CURSO)
                .WithRequired(e => e.GRADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GRADO>()
                .HasMany(e => e.MATRICULA)
                .WithRequired(e => e.GRADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MATRICULA>()
                .Property(e => e.pro_mat)
                .HasPrecision(4, 2);

            modelBuilder.Entity<MATRICULA>()
                .HasMany(e => e.EVALUACION)
                .WithRequired(e => e.MATRICULA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PABELLON>()
                .HasMany(e => e.AULA)
                .WithRequired(e => e.PABELLON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.nom_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.app_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.apm_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.dni_paf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.sex_paf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.cor_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.tel_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.dir_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.apo_paf)
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .Property(e => e.tel_apo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PADRE_FAMILIA>()
                .HasMany(e => e.ALUMNO)
                .WithRequired(e => e.PADRE_FAMILIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERIODO>()
                .Property(e => e.des_per)
                .IsUnicode(false);

            modelBuilder.Entity<PERIODO>()
                .HasMany(e => e.EVALUACION)
                .WithRequired(e => e.PERIODO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVINCIA>()
                .Property(e => e.nom_pro)
                .IsUnicode(false);

            modelBuilder.Entity<PROVINCIA>()
                .HasMany(e => e.DISTRITO)
                .WithRequired(e => e.PROVINCIA)
                .WillCascadeOnDelete(false);
        }
    }
}
