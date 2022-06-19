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
            int controlId)
        {
            Id = id;
            CategoryTitle = categoryTitle;
            Description = description;
            QuestionType = questionType;
            DependedQuestionDescription = dependedQuestionDescription;
            Quests = quests;
            Options = options;
            IsMultipleOption = isMultipleOption;
            ControlId = controlId;
        }

        public int Id { get; }
        public string CategoryTitle { get; }
        public string Description { get; }
        public int QuestionType { get; }
        public string DependedQuestionDescription { get; }
        public List<Quest> Quests { get; }

        public List<Opt> Options { get; }
        public bool IsMultipleOption { get; }
        public int ControlId { get; }

    }
}
