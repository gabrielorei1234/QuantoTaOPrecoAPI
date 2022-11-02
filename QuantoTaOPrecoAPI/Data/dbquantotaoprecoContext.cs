using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuantoTaOPrecoAPI.Models;

namespace QuantoTaOPrecoAPI.Data
{
    public partial class dbquantotaoprecoContext : DbContext
    {
        public dbquantotaoprecoContext()
        {
        }

        public dbquantotaoprecoContext(DbContextOptions<dbquantotaoprecoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Empresamatriz> Empresamatrizs { get; set; } = null!;
        public virtual DbSet<Empresasproduto> Empresasprodutos { get; set; } = null!;
        public virtual DbSet<Historicoproduto> Historicoprodutos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Unidadesdemedidum> Unidadesdemedida { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;database=dbquantotaopreco;user=root;password=root", ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresas");

                entity.HasIndex(e => e.IdEmpresaMatriz, "idEmpresaMatriz");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.IdEmpresaMatriz).HasColumnName("idEmpresaMatriz");

                entity.Property(e => e.Nome).HasMaxLength(45);

                entity.HasOne(d => d.IdEmpresaMatrizNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdEmpresaMatriz)
                    .HasConstraintName("empresas_ibfk_1");
            });

            modelBuilder.Entity<Empresamatriz>(entity =>
            {
                entity.ToTable("empresamatriz");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Nome).HasMaxLength(45);
            });

            modelBuilder.Entity<Empresasproduto>(entity =>
            {
                entity.ToTable("empresasprodutos");

                entity.HasIndex(e => e.IdEmpresas, "idEmpresas");

                entity.HasIndex(e => e.IdProdutos, "idProdutos");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdEmpresas).HasColumnName("idEmpresas");

                entity.Property(e => e.IdProdutos).HasColumnName("idProdutos");

                entity.Property(e => e.Preco).HasPrecision(6, 2);

                entity.HasOne(d => d.IdEmpresasNavigation)
                    .WithMany(p => p.Empresasprodutos)
                    .HasForeignKey(d => d.IdEmpresas)
                    .HasConstraintName("empresasprodutos_ibfk_2");

                entity.HasOne(d => d.IdProdutosNavigation)
                    .WithMany(p => p.Empresasprodutos)
                    .HasForeignKey(d => d.IdProdutos)
                    .HasConstraintName("empresasprodutos_ibfk_1");
            });

            modelBuilder.Entity<Historicoproduto>(entity =>
            {
                entity.ToTable("historicoproduto");

                entity.HasIndex(e => e.IdEmpresasProdutos, "idEmpresasProdutos");

                entity.HasIndex(e => e.IdUsuario, "idUsuario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DataRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdEmpresasProdutos).HasColumnName("idEmpresasProdutos");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEmpresasProdutosNavigation)
                    .WithMany(p => p.Historicoprodutos)
                    .HasForeignKey(d => d.IdEmpresasProdutos)
                    .HasConstraintName("historicoproduto_ibfk_2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historicoprodutos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("historicoproduto_ibfk_1");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produtos");

                entity.HasIndex(e => e.IdUnidadesDeMedida, "idUnidadesDeMedida");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdUnidadesDeMedida).HasColumnName("idUnidadesDeMedida");

                entity.Property(e => e.Nome).HasMaxLength(45);

                entity.HasOne(d => d.IdUnidadesDeMedidaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUnidadesDeMedida)
                    .HasConstraintName("produtos_ibfk_1");
            });

            modelBuilder.Entity<Unidadesdemedidum>(entity =>
            {
                entity.ToTable("unidadesdemedida");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Descricao).HasMaxLength(45);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Senha).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
