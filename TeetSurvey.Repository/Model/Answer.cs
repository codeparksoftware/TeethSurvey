namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            AnwerOptions = new HashSet<AnwerOption>();
        }

        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnwerOption> AnwerOptions { get; set; }
    }
}
