namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Survey()
        {
            Answers = new HashSet<Answer>();
        }

        public int SurveyId { get; set; }

        public int PatientId { get; set; }

        public DateTime SurveyDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Pollster { get; set; }

        public int? TotalPoint { get; set; }

        [StringLength(500)]
        public string SurveyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
