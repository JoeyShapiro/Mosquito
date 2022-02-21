// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string PATH = Environment.GetCommandLineArgs()[1]; // thats what the "@" is for, it lets you use the escape char
string MY_HOME = Directory.GetCurrentDirectory();
string TARGET_PATH = MY_HOME + @"\harvest";
string HARVEST = MY_HOME + @"\harvested.txt";
long MB = 1048576;
long GB = 1073741824; // i think you keep multipling (something) by 1024
int counter = 0; // amount of files currently gotten
int found = 0; // files found from this machine
int yield = 0; // files that were collected because they matched the criteria
List<string> harvested = new List<string>(); // list of currently gotten

foreach (string line in System.IO.File.ReadLines(HARVEST)) { // all gotten files put into a list
    harvested.Add(line);
    counter++;
}

System.Console.WriteLine($"Currently have {counter} files"); // ...
IEnumerable<string> files = Directory.EnumerateFiles(PATH, "*.exe", SearchOption.AllDirectories);
int total = files.Count();
counter = 0; // reset, for cheapness

System.Console.Write("Progress: ");
foreach (string file in files) { // (recursively) go through each folder for exes
    string fileName = System.IO.Path.GetFileName(file); // current files name
    string destFile = System.IO.Path.Combine(TARGET_PATH, fileName); // where to put it
    long length = new System.IO.FileInfo(file).Length; // the length of the file
    if (length >= MB && length <= GB) { // if the file is within the size limits
        found++;
        if (!harvested.Contains(fileName)) { // if it is not in the currently gotten list
            System.IO.File.Copy(file, destFile, true); // copy the file into folder with overwrite, not like it matters
            File.AppendAllText(HARVEST, fileName + Environment.NewLine); // add the filename to list
            harvested.Add(fileName);
            yield++;
        }
    }

    counter++;
    if ((counter/total)%0.10 == 0) // :P so clever
        System.Console.Write("#"); // progress bar
}

System.Console.WriteLine($"\nFound {found} files and harvested {yield} files"); // show results