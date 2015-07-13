using System.Diagnostics;
using System.Text;

namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    internal class TestUtils
    {
        public static int RunTests(string nUnitVersion)
        {
            var proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = PathsUtils.NUnitConsoleExeFileName;
            proc.StartInfo.Arguments = string.Format("--work={0} {0}\\JetBrains.TeamCity.NUnitAddins.Mocks.dll", PathsUtils.GetBinPathByVersion(nUnitVersion));
            proc.Start();
            proc.WaitForExit();
            string cmd = proc.StartInfo.FileName + " " + proc.StartInfo.Arguments;
            return proc.ExitCode;
        }
    }
}