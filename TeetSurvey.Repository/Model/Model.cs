namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelWeb")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnwerOption> AnwerOptions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DependendOption> DependendOptions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionControl> QuestionControls { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasMany(e => e.AnwerOptions)
                .WithRequired(e => e.Answer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Option>()
                .HasMany(e => e.AnwerOptions)
                .WithRequired(e => e.Option)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Option>()
                .HasMany(e => e.DependendOptions)
                .WithRequired(e => e.Option)
                .HasForeignKey(e => e.DependedOptionId);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientTCKN)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Surveys)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.DependendOptions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Question1)
                .WithOptional(e => e.Question2)
                .HasForeignKey(e => e.DependedQuestionId);

            modelBuilder.Entity<QuestionControl>()
                .Property(e => e.ControlName)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionControl>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.QuestionControl)
                .HasForeignKey(e => e.ControlId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Survey)
                .WillCascadeOnDelete(false);
        }
    }
}
