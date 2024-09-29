namespace TestTool.Domain.TestManagement
{
    public class SubTest
    {
        public string Title { get; set; }
        public List<Step> Steps { get; set; }
        public SubTest(string title, List<Step> steps)
        {
            Title = title;
            Steps = steps;
        }

        public Step AddStep(string description, State state)
        {
            Step step = new Step(description, state);
            return step;
        }
    }
}
