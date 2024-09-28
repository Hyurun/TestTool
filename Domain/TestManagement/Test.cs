namespace TestTool.Domain.TestManagement
{
    public class Test
    {
        public int Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public List<SubTest> Subtest { get; }

        public Test(int ID, string title, string? description, List<SubTest> subtest)
        {
            Id = ID;
            Title = title;
            Description = description;
            Subtest = subtest;
        }

    }
}
