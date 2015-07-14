namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests.Utilities
{
    using System.Diagnostics;
    using System.IO;

    internal class TestUtils
    {
        public static int RunTests(string nUnitVersion)
        {
            var bin = PathsUtils.GetBinPathByVersion(nUnitVersion);
            var proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = Path.Combine(bin, "nunit-console.exe");
            proc.StartInfo.Arguments = string.Format("{0}\\Tests\\JetBrains.TeamCity.NUnitAddins.Mocks.dll", bin);
            proc.Start();
            proc.WaitForExit();
            string cmd = proc.StartInfo.FileName + " " + proc.StartInfo.Arguments;
            return proc.ExitCode;
        }
    }
}