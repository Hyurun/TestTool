namespace TestTool.Domain.TestManagement
{
    public class Step
    {
        public string Description { get; set; }
        public State State { get; set; }

        public Step(string description, State state)
        {
            Description = description;
            State = state;
        }

    }
}
