#load nuget:?package=Cake.Recipe&version=1.1.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./Source",
                            title: "Cake.Gitter",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Gitter",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunGitVersion: true,
                            shouldPublishToMyGetWithApiKey: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                            BuildParameters.RootDirectoryPath + "/Source/Cake.Gitter.Tests/*.cs", BuildParameters.RootDirectoryPath + "/Source/Cake.Gitter/**/*.AssemblyInfo.cs", BuildParameters.RootDirectoryPath + "/Source/Cake.Gitter/LitJson/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* ",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
