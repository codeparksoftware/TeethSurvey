namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
            DependendOptions = new HashSet<DependendOption>();
            Options = new HashSet<Option>();
            Question1 = new HashSet<Question>();
        }

        public int QuestionId { get; set; }

        public int CategoryId { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int TypeId { get; set; }

        public int? DependedQuestionId { get; set; }

        public bool IsMultipleOption { get; set; }

        public int ControlId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DependendOption> DependendOptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Option> Options { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Question1 { get; set; }

        public virtual Question Question2 { get; set; }

        public virtual QuestionControl QuestionControl { get; set; }
    }
}
