namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Surveys = new HashSet<Survey>();
        }

        public int PatientId { get; set; }

        [Required]
        [StringLength(250)]
        public string PatientName { get; set; }

        [Required]
        [StringLength(250)]
        public string PatientSurname { get; set; }

        [Required]
        [StringLength(11)]
        public string PatientTCKN { get; set; }

        public DateTime EnrollDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
