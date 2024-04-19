using System;
using System.Collections.Generic;
using LazarusServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = LazarusServer.Data.Models.Attribute;

namespace LazarusServer.Data;

public partial class LazarusContext : DbContext
{
    public LazarusContext()
    {
    }

    public LazarusContext(DbContextOptions<LazarusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute> Attributes { get; set; }

    public virtual DbSet<AttributeCategory> AttributeCategories { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExerciseCategory> ExerciseCategories { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramExercise> ProgramExercises { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    public virtual DbSet<WorkoutExerciseAttribute> WorkoutExerciseAttributes { get; set; }

    public virtual DbSet<WorkoutExerciseSet> WorkoutExerciseSets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=Lazarus;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attribut__3214EC07816F0C75");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.AttributeCategory).WithMany(p => p.Attributes)
                .HasForeignKey(d => d.AttributeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttributeCategory_Attributes");

            entity.HasOne(d => d.User).WithMany(p => p.Attributes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Attributes");
        });

        modelBuilder.Entity<AttributeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attribut__3214EC075C1252F0");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC07CBF217B0");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Category_ExerciseCategories");

            entity.HasOne(d => d.User).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_ExerciseCategories");

            entity.HasMany(d => d.Attributes).WithMany(p => p.Exercises)
                .UsingEntity<Dictionary<string, object>>(
                    "ExerciseAttribute",
                    r => r.HasOne<Attribute>().WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Attribute_ExerciseAttributes"),
                    l => l.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Exercise_ExerciseAttributes"),
                    j =>
                    {
                        j.HasKey("ExerciseId", "AttributeId");
                        j.ToTable("ExerciseAttributes");
                    });
        });

        modelBuilder.Entity<ExerciseCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC07A8076C3A");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Programs__3214EC07E6E14BE7");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Programs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Programs");
        });

        modelBuilder.Entity<ProgramExercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProgramE__3214EC07F6A8ECDB");

            entity.HasOne(d => d.Exercise).WithMany(p => p.ProgramExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_ProgramExercises");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramExercises)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Program_ProgramExercises");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078F42296A");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053439A2F5A4").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Workouts__3214EC07C19415F1");

            entity.HasIndex(e => new { e.Day, e.UserId }, "UQ_Workout_Day_User").IsUnique();

            entity.HasOne(d => d.User).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Workouts");
        });

        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkoutE__3214EC0761E44EC5");

            entity.HasOne(d => d.Exercise).WithMany(p => p.WorkoutExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exercise_WorkoutExercises");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutExercises)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workout_WorkoutExercises");
        });

        modelBuilder.Entity<WorkoutExerciseAttribute>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Attribute).WithMany()
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attribute_WorkoutExerciseAttributes");

            entity.HasOne(d => d.WorkoutExercise).WithMany()
                .HasForeignKey(d => d.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutExercise_WorkoutExerciseAttributes");
        });

        modelBuilder.Entity<WorkoutExerciseSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkoutE__3214EC075B4102BD");

            entity.Property(e => e.Time).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.WorkoutExercise).WithMany(p => p.WorkoutExerciseSets)
                .HasForeignKey(d => d.WorkoutExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutExercise_WorkoutExerciseSets");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
