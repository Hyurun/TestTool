using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTool.Domain.TestManagement
{
    public class TestFolder(int ID, string title, List<Test>? tests)
    {
        public int Id { get; } = ID;
        public string Title { get; } = title;
        public List<Test>? Tests { get; } = tests;
    }
}
