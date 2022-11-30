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

        public int Id { get; set; }

        public int PatientId { get; set; }

        public int PollsterId { get; set; }

        public DateTime SurveyDate { get; set; }

        public int SurveyListId { get; set; }

        public bool IsSubmitted { get; set; }
        public bool IsCompleted { get; set; }
        public int SessionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Pollster Pollster { get; set; }

        public virtual SurveyList SurveyList { get; set; }
    }
}
