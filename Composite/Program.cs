var root = new Composite.Directory("root", 0);

var topFile = new Composite.File("TopFile.txt", 100);

var topDir1 = new Composite.Directory("TopDirectory1", 5);
var topDir2 = new Composite.Directory("TopDirectory1", 5);

root.Add(topFile);
root.Add(topDir1);
root.Add(topDir2);

var childFile1 = new Composite.File("ChildFile1.txt", 200);
var childFile2 = new Composite.File("ChildFile2.txt", 300);

topDir2.Add(childFile1);
topDir2.Add(childFile2);

Console.WriteLine($"Top dir 1: {topDir1.GetSize()}");
Console.WriteLine($"Top dir 2: {topDir2.GetSize()}");
Console.WriteLine($"Root: {root.GetSize()}");

Console.ReadKey();