namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnwerOption")]
    public partial class AnwerOption
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }

        public int OptionId { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual Option Option { get; set; }
    }
}
