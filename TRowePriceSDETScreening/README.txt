Test Execution Notes:
1.	To build and execute tests create a workspace folder in local machine and clone the git hub repository 
2.	Open Visual Studio and open the TRowe.sln from the workspace folder created above
3.	Change the value of the key “FilePath” in  App.config file to read the file from workspace folder created above
4.	Build the solution and run the tests from the test runner tool of your choice like ReSharper or Visual Studio Test Explore
5.	Programming language used: C#
6.	Unit Test Frame Work: Visual Studio MSTest on .NET Framework 4.6.1
7.	Solution consists of two tests one each for smallest and longest word in sentence. Both of these tests are passed. Test Result document included within this repository 
8.	Assumption Made: 
•	Case ignored fore string comparison
•	Given sentence is read from a text file located in a project directory
•	Alternatively, the sentence can directly be ready from BusinessBuilder.cs by setting the value of string “FilePath” = the given sentence and commenting out GetFileContent()