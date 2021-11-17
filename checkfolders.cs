// See https://aka.ms/new-console-template for more information
//Console.WriteLine(Directory.GetCurrentDirectory());


const string basePath = @"c:\dev\abac-policies\rego";
string? inputPath = Environment.GetCommandLineArgs().Skip(1).FirstOrDefault();
string pathToUse = inputPath ?? basePath;
var files = Directory.EnumerateFileSystemEntries(pathToUse, "*.rego", SearchOption.AllDirectories);
//foreach (var f in files.Take(3))
//    Console.WriteLine(f);

var errors = new List<string>();
foreach (var file in files)
{
    IEnumerable<string> lines = File.ReadLines(file);
    string? firstLine = lines.FirstOrDefault(l => l.StartsWith("package"))?.Trim();
    if (string.IsNullOrEmpty(firstLine))
        continue;
    var package = firstLine.Remove(0, "package ".Length);
    var segments = package.Split('.');
    var folders = file
        .Remove(0, pathToUse.Length)
        .Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries)
        .SkipLast(1);
    //Console.WriteLine($"package {package}");
    string foldersAsPackage = string.Join('.', folders);
    //Console.WriteLine($"folders {foldersAsPackage}");

    if (package != foldersAsPackage)
    {
        errors.Add(file);
    }

}
if (errors.Any())
{
    Console.WriteLine("Errors:");
    foreach (var error in errors)
        Console.WriteLine(error);
}
else
    Console.WriteLine("All good");
