namespace ProjectTool
{
    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: project-tool.exe <csproj file name>");
                return;
            }

            var project = new ProjectFile(args[0]);
            foreach (var reference in project.References)
            {
                Console.WriteLine($"{reference.Name},{reference.GetVersion()}");
            }
        }
    }
}
