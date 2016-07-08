namespace ProjectTool
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    internal class ProjectFile
    {
        private static XNamespace NS_MSBUILD_2003 = "http://schemas.microsoft.com/developer/msbuild/2003";

        private XDocument xdoc;

        public string Filename { get; private set; }

        public string ProjectRoot
        {
            get
            {
                return Path.GetDirectoryName(this.Filename);
            }
        }

        public ProjectFile(string filename)
        {
            this.Filename = filename;
            this.xdoc = XDocument.Load(this.Filename);
        }

        public IEnumerable<Reference> References
        {
            get
            {
                return from reference in xdoc.Descendants(NS_MSBUILD_2003 + "Reference")
                       from hintPath in reference.Elements(NS_MSBUILD_2003 + "HintPath")
                       select new Reference(this, reference.Attribute("Include").Value, hintPath.Value);
            }
        }
    }
}
