#tool "nuget:?package=NUnit.Runners&version=2.6.4"
#tool "nuget:?package=ReportGenerator"

var target = Argument("target", "Default");

Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("UnitTesting")
//.IsDependentOn("CodeCoverage");
  .IsDependentOn("GenerateArtifacts");
  
Task("Clean")  
    .Does(() =>
{
	CleanDirectory("./NAGP_4124_Console/bin/Debug");
	CleanDirectory("./NAGP_4124_UnitTesting/bin/Debug");
	CleanDirectory("./NAGP_4124_IntegrationTesting/bin/Debug");
});


Task("Restore")  
    .Does(() =>
{
    NuGetRestore("./DevOps_123.sln");
});

Task("Build")
  .Does(() =>
{
  MSBuild("./DevOps_123.sln");
});

Task("UnitTesting")
    .Does(() =>
{
  MSTest("./NAGP_UnitTesting/bin/Debug/NAGP_4124_UnitTesting.dll");
});

Task("GenerateArtifacts")
	.Does(() =>
{
	CleanDirectory("./output/bin");
	var files = GetFiles("./**/*.dll") + GetFiles("./**/*.exe");
	CopyFiles(files, "./output/bin");
	Zip("./output/bin", "./output/build.zip");
});

RunTarget(target);