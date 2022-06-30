using System;
using System.Collections.Generic;
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
}
