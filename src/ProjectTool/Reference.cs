namespace ProjectTool
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    class Reference
    {
        public string Identifier { get; private set; }

        public string ReferencePath { get; private set; }

        public string Name { get; private set; }

        private ProjectFile projectFile { get; set; }
        
        public Reference (ProjectFile projectFile, string identifier, string path)
        {
            this.projectFile = projectFile;
            this.Identifier = identifier;
            this.ReferencePath = path;
            this.Name = this.Identifier.Split(',').First();
        }

        public Version GetVersion()
        {
            var absolutePath = this.ReferencePath;
            if (!Path.IsPathRooted(this.ReferencePath))
            {
                absolutePath = Path.Combine(this.projectFile.ProjectRoot, this.ReferencePath);
            }

            AssemblyName updatedAssemblyName = AssemblyName.GetAssemblyName(absolutePath);
            return updatedAssemblyName.Version;
        }
    }
}
