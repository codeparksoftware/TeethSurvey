namespace Sample
{
    public enum OptionControls
    {
        RadioButton = 1,
        CheckedListBox = 2,
        ComboBox = 3
    }

    public sealed class OptionControl
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
