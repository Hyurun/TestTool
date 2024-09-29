```mermaid
classDiagram
	class TestFolder{
		-List~Test~ test
		-string testFolderName
		+createTestFolder()
		+deleteTestFolder()
		+addTest()
		+removeTest()
	}
	TestFolder *-- Test

	class Test{
		-int ID
		-string title
		-string comment
		-string imagePath
		-List~string~ requirementLinks
		-List~SubTest~ subTests
		-Report report
		+create()
		+edit()
		+run()
		+delete()
		+testImport()
		+testExport()
		+testParse()
	}
	Test *-- SubTest
	Test *-- Report

	class SubTest {
		-string title
		-Steps steps
		+create()
		+edit()
		+delete()
	}
	SubTest *-- Step

	class Report {
		+createReport()
		+fetchReport()
		+exportReport()
	}

	class Step {
		-string description
		-State state
		+createStep()
		+editStep()
		+runStep()
		+deleteStep()
	}
	Step *-- State

	class State {
		<<Enumeration>>
		+notRun
		+blocked
		+passed
		+failed
		+undetermined
	}

	class User {
		-string username
		-string password
		-string firstName
		-string lastName
		-AccessLevel accessLevel
		+createUser()
		+deleteUser()
		+updatePassword()
		+setAccessLevel()
	}
	User *-- AccessLevel

	class AccessLevel{
		<<Enumeration>>
		+notAccess
		+read
		+readWriteTest
		+readWriteFolder
	}