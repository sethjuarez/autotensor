#addin "Newtonsoft.Json"
#addin "Cake.DocFx"
#tool "docfx.console"
#tool "nuget:?package=xunit.runner.console"


//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var release = "0.1.3";
var suffix = "alpha";
var copyright = string.Format("©{0}, Seth Juarez. All rights reserved.", DateTime.Now.Year);
var target = Argument("target", "Default");
var output = Argument("output", "./output");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var baseDir = Directory(output);
var buildDir = baseDir + Directory(configuration);
var testResultsDir = baseDir + Directory("results");
var packageDir = baseDir + Directory("package");
var docsDir = baseDir + Directory("docs");

//////////////////////////////////////////////////////////////////////
// Utility
//////////////////////////////////////////////////////////////////////
public static void UpdateProjectJsonVersion(string version, FilePath projectPath, string node)
{
    var project = Newtonsoft.Json.Linq.JObject.Parse(
        System.IO.File.ReadAllText(projectPath.FullPath, Encoding.UTF8));

    if (node.Contains("+"))
    {
        // for nested entries use a "+"
        var entries = node.Split('+');
        var n = project[entries[0]];
        for (int i = 1; i < entries.Length; i++)
            n = n[entries[i]];
        n.Replace(version);
    }
    else
        project[node].Replace(version);

    System.IO.File.WriteAllText(projectPath.FullPath, project.ToString(), Encoding.UTF8);
}

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

/// CLEAN
Task("Clean")
    .Does(() =>
{
    CleanDirectory(baseDir);
});

Task("Version")
    .IsDependentOn("Clean")
    .Does(() =>
{
    // update csproj build
    var version = release + "-" + suffix;
    Information("Updating AutoTensor project file");
    Information(" ====> " + version + " (" + copyright + ")");
    XmlPoke(File("../src/AutoTensor/AutoTensor.csproj"), "//PropertyGroup/PackageVersion", version);
    XmlPoke(File("../src/AutoTensor/AutoTensor.csproj"), "//PropertyGroup/Copyright", copyright);
});

Task("Restore")
    .IsDependentOn("Version")
    .Does(() =>
{
    DotNetCoreRestore("../src/AutoTensor/AutoTensor.csproj");
    DotNetCoreRestore("../src/AutoTensor.Tests/AutoTensor.Tests.csproj");
});

Task("Test")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreTest("../src/AutoTensor.Tests/AutoTensor.Tests.csproj", new DotNetCoreTestSettings {
        Configuration = configuration,
        Framework = "netcoreapp2.0",
        OutputDirectory = buildDir
    });
});

Task("Package")
    .IsDependentOn("Test")
    .Does(() =>
{
    var settings = new DotNetCorePackSettings
    {
        Configuration = configuration,
        OutputDirectory = packageDir
    };
            
    DotNetCorePack("../src/AutoTensor/AutoTensor.csproj", settings);
});

Task("Docs")
    .IsDependentOn("Package")
    .Does(() => 
{
    // write out version in prep for doc gen
    if(suffix.Length > 0)
        UpdateProjectJsonVersion(release + "-" + suffix, "../docs/version.json", "_appId");
    else
        UpdateProjectJsonVersion(release, "../docs/version.json", "_appId");

    UpdateProjectJsonVersion(DateTime.Now.Year.ToString(), "../docs/version.json", "_year");
    UpdateProjectJsonVersion(DateTime.Now.ToString("f"), "../docs/version.json", "_date");


    DocFxBuild("../docs/docfx.json", new DocFxBuildSettings()
    {
        OutputPath = docsDir
    });
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////
Task("Default")
    .IsDependentOn("Docs");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);
