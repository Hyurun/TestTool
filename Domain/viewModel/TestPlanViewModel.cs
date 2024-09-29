using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTool.Domain.viewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using TestTool.Domain.TestManagement;

    public class TestPlanViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TestFolder> _testFolders;
        public ObservableCollection<TestFolder> TestFolders
        {
            get { return _testFolders; }
            set
            {
                _testFolders = value;
                OnPropertyChanged(nameof(TestFolders));
            }
        }

        private ObservableCollection<Test> _tests;
        public ObservableCollection<Test> Tests
        {
            get { return _tests; }
            set
            {
                _tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }

        private ObservableCollection<SubTest> _subtests;
        public ObservableCollection<SubTest> SubTests
        {
            get { return _subtests; }
            set
            {
                _subtests = value;
                OnPropertyChanged(nameof(SubTests));
            }
        }

        private TestFolder _selectedTestFolder;
        public TestFolder SelectedTestFolder
        {
            get { return _selectedTestFolder; }
            set
            {
                _selectedTestFolder = value;
                OnPropertyChanged(nameof(SelectedTestFolder));

                if (_selectedTestFolder != null)
                {
                    LoadTestList(_selectedTestFolder);
                }
            }
        }

        private Test _selectedTest;
        public Test SelectedTest
        {
            get { return _selectedTest; }
            set
            {
                _selectedTest = value;
                OnPropertyChanged(nameof(SelectedTest));

                if (_selectedTest != null)
                {
                    LoadSubTestList(_selectedTest);
                }
            }
        }

        public TestPlanViewModel()
        {
            //Dummy steps for example
            List<Step> steps_precond = new List<Step>
            {
                new Step("Set TR = 15", State.notRun),
                new Step("Set TF = 14", State.notRun),
                new Step("Check Type is Midea", State.notRun)
            };
            List<Step> check_temp = new List<Step>
            {
                new Step("Check TR = 15", State.notRun),
                new Step("Check TF = 14", State.notRun)
            };
            List<Step> check_defrost = new List<Step>
            {
                new Step("Check defrost is on", State.notRun),
                new Step("Set TF = 14", State.notRun)
            };
            List<Step> check_heating = new List<Step>
            {
                new Step("Check Compressor Demand ON", State.notRun),
                new Step("Check Compressor State ON", State.notRun)
            };

            //Dummy SubTest for example
            SubTest precondition = new SubTest("Precondition", steps_precond);
            SubTest temp = new SubTest("Temp change", check_temp);
            SubTest defrost = new SubTest("Defrost", check_defrost);
            SubTest heating = new SubTest("Heating", check_heating);

            // Dummy test for example
            Test test1 = new Test(1019, "Defrost", "dummy test 1019", [precondition, temp]);
            Test test2 = new Test(1020, "Zoning", "dummy test 1020", [precondition, defrost]);
            Test test3 = new Test(1021, "DHW Mode", "dummy test 1021", [precondition, heating]);
            Test test4 = new Test(1022, "Antileg", "dummy test 1022", [precondition, temp, defrost]);

            List<Test> test_list1 = new List<Test> {test1, test2};
            List<Test> test_list2 = new List<Test> { test3, test4};
            List<Test> test_list3 = new List<Test> { test1, test2, test3, test4 };

            // Initialisation of Observable collection
            TestFolders = new ObservableCollection<TestFolder>
            {   // Dummy folder for example
                new TestFolder(1, "EHC-10", test_list1),
                new TestFolder(2, "EHC-11", test_list2),
                new TestFolder(3, "EHC-12", test_list3)
            };

            Tests = new ObservableCollection<Test>();

            SubTests = new ObservableCollection<SubTest>();
        }


        private void LoadTestList(TestFolder selectedTestFolder)
        {
            Tests.Clear(); // Clean the list of previous test
            SubTests.Clear();
            foreach (Test test in selectedTestFolder.Tests)
            {
                Tests.Add(test);
            }
        }

        private void LoadSubTestList(Test selectedTest)
        {
            SubTests.Clear(); // Clean the list of previous test
            foreach (SubTest subtest in selectedTest.SubTests)
            {
                SubTests.Add(subtest);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
