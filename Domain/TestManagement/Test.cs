namespace TestTool.Domain.TestManagement
{
    public class Test(int ID, string title, string? description, List<SubTest>? subtests)
    {
        public int Id { get; } = ID;
        public string Title { get; } = title;
        public string? Description { get; } = description;
        public List<SubTest>? SubTests { get; } = subtests;
    }
}
