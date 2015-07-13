using System.Xml.Linq;

namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    using System.Diagnostics;
    using System.IO;

    internal class EnvironmentUtils
    {
        public static void Prepare(string nUnitVersion)
        {
            CopyDirectory(PathsUtils.GetLibPathByVersion(nUnitVersion), PathsUtils.GetBinPathByVersion(nUnitVersion));
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