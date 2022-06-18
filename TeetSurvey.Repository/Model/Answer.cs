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
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        public int? OptionId { get; set; }

        public int SurveyId { get; set; }

        public virtual Option Option { get; set; }

        public virtual Question Question { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
