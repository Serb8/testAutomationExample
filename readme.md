# Example QA Solution
- Specflow UI tests
- NUnit UI tests

### Usage:
##### Visual Studio:
0) Download [Visual Studio](https://www.visualstudio.com/downloads/)
1) Install [NUnit3TestAdapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter) and [SpecFlow](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017) plugin in Visual Studio
1.1) *Optional* Install [Resharper](https://www.jetbrains.com/resharper/)
2) Build solution and open **Test Explorer** (Test -> Windows -> Test Exlorer) or Resharper Unit Tests (Resharper -> Unit Tests -> Unit Tests)
3) Select desired tests and run
##### CI:
1) Clone this repository and restore nuget packages
2) Build with ```MsBuild.exe %ProjectName%.QA.sln /p:outDir=%outputPath%```
3) Run tests with NUnit console ```NUnit3Console.exe %test.dll path%```
