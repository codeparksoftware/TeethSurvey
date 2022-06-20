namespace TeetSurvey.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnswerOption")]
    public partial class AnswerOption
    {
        public int Id { get; set; }

        public int AnswerId { get; set; }

        public int OptionId { get; set; }
    }
}
