namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DependendOption")]
    public partial class DependendOption
    {
        public int Id { get; set; }

        public int DependedOptionId { get; set; }

        public int QuestionId { get; set; }

        public virtual Option Option { get; set; }

        public virtual Question Question { get; set; }
    }
}
