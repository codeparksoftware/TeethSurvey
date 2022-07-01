using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{

    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int? OptionId { get; set; }
    }


    public class Cat
    {
        public int CatId { get; set; }
        public string Title { get; set; }
        public List<SurveyQuest> Quests { get; set; }
    }
    public class SurveyQuest
    {

        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public string Description { get; set; }
        public int QuestionType { get; set; }
        public string DependedQuestionDescription { get; set; }
        public List<int> SubQuestIds { get; set; }
        public int? ParentQuestionId { get; set; }
        public List<Opt> Options { get; set; }
        public bool IsMultipleOption { get; set; }
        public int ControlId { get; set; }
        public List<Answer> Answers { get; set; }
        public List<DependedOptions> DependedOptions { get; set; }
        public bool IsSubQuestion => ParentQuestionId.HasValue;
        public bool IsRootQuestion => !ParentQuestionId.HasValue;

    }

    public class DependedOptions
    {
        public int SubQuestId { get; set; }
        public int? ParentQuestId { get; set; }
        public int ParentQuestionOption { get; set; }
    }

    public class SurveyView
    {
        public int SurveyId { get; set; }
        public string Pollster { get; set; }
        public string SurveyName { get; set; }
        public DateTime SurveyDate { get; set; }
        public string Patient { get; set; }
        public bool IsSubmitted { get; set; }
        public Image Icon => IsSubmitted ? Sample.Properties.Resources.apply_16x16 : Sample.Properties.Resources.time2_16x16;

        public List<AnsweredQuestion> Questions { get; set; }
    }
    public class AnsweredQuestion
    {
        public int QuestionId { get; set; }
        public string CategoryTitle { get; set; }
        public string QuestionDesc { get; set; }
        public string AnswerOptionDesc { get; set; }
    }
}
