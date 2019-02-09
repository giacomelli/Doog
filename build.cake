var target = Argument("target", "Default");
var solutionDir = "src";

Task("Build")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = "Release"
    };

    DotNetCoreBuild(solutionDir, settings);
});

Task("Test")
    .Does(() =>
{
    DotNetCoreTest(solutionDir);
});

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
	.Does(()=> { 
});

RunTarget(target);