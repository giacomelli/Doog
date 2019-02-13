#tool nuget:?package=MSBuild.SonarQube.Runner.Tool&version=4.3.1
#addin nuget:?package=Cake.Sonar&version=1.1.18

var target = Argument("target", "Default");
var solutionDir = "src";
var sonarLogin = "cf36fef221b4268b5989d3b044f6167cc739b78f";

Task("Build")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = "Release",
    };

    DotNetCoreBuild(solutionDir, settings);
});

Task("Test")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
    {
        ArgumentCustomization = args => {
            return args.Append("/p:CollectCoverage=true")
                       .Append("/p:CoverletOutputFormat=opencover");
        }
    };

    DotNetCoreTest(solutionDir, settings);
});

Task("SonarBegin")
    .Does(() => 
{
     SonarBegin(new SonarBeginSettings {
        Key = "Doog",
        Organization = "giacomelli-github",
        Url = "https://sonarcloud.io",
        Exclusions = "**/Samples/**/*.cs,**/Doog.Tests/*.cs,**/Runner/InputSystem.cs,**/Runner/GraphicSystem.cs,**/Runner/Startup.cs",
        OpenCoverReportsPath = "**/*.opencover.xml",
        Login = sonarLogin   
     });
});

Task("SonarEnd")
  .Does(() => {
     SonarEnd(new SonarEndSettings{
        Login = sonarLogin
     });
  });

Task("Default")
    .IsDependentOn("SonarBegin")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("SonarEnd")
	.Does(()=> { 
});

RunTarget(target);