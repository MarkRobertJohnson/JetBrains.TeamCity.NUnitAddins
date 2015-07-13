using System.Xml.Linq;

namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    using System.Diagnostics;
    using System.IO;

    internal class EnvironmentUtils
    {
        public static void Prepare(string nUnitVersion)
        {
            CopyDirectory(PathsUtils.NUnitConsolePath, PathsUtils.NUnitConsoleBinPath);
            var doc = new XDocument();
            var addinsElement = new XElement("Addins");
            addinsElement.Add(new XElement("Directory", "addins"));
            addinsElement.Add(new XElement("Directory", Path.Combine(PathsUtils.GetBinPathByVersion(nUnitVersion), "JetBrains.TeamCity.NUnitAddins.dll")));
            doc.Add(addinsElement);
            var addinsConfig = Path.Combine(PathsUtils.NUnitConsoleBinPath, "nunit.engine.addins");
            using (var writer = new StreamWriter(addinsConfig))
            {
                doc.Save(writer);
                writer.Flush();
            }
        }

        private static int CopyDirectory(string source, string desination)
        {
            var proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = @"xcopy.exe";
            proc.StartInfo.Arguments = string.Format(@"{0} {1} /E /I /H /Q /R /K /Y /J /C", source, desination);
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode;
        }
    }
}