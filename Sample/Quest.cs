using System.Collections.Generic;

namespace Sample
{
    public sealed class Quest
    {
        public Quest(
            int id,
            string categoryTitle,
            string description,
            int questionType,
            string dependedQuestionDescription,
            List<Quest> quests,
            List<Opt> options,
            bool isMultipleOption,
            int controlId,
            int? parentQuestionId)
        {
            Id = id;
            CategoryTitle = categoryTitle;
            Description = description;
            QuestionType = questionType;
            DependedQuestionDescription = dependedQuestionDescription;
            SubQuests = quests;
            Options = options;
            IsMultipleOption = isMultipleOption;
            ControlId = controlId;
            ParentQuestionId = parentQuestionId;
        }

        public int Id { get; }
        public string CategoryTitle { get; }
        public string Description { get; }
        public int QuestionType { get; }
        public string DependedQuestionDescription { get; }
        public List<Quest> SubQuests { get; }
        public int? ParentQuestionId { get; }
        public List<Opt> Options { get; }
        public bool IsMultipleOption { get; }
        public int ControlId { get; }

    }
}
