namespace JetBrains.TeamCity.NUnitAddins.IntegrationTests
{
    using System.Collections.Generic;
    using Utilities;
    using NUnit.Framework;

    [TestFixture]
    public class RunNUnitConsoleTest
    {
        private static IEnumerable<string> Versions
        {
            get
            {
                return NUnitVersions.All;
            }
        }

        [Test, TestCaseSource("Versions")]
        public void ShouldRun(string nUnitVersion)
        {
            // Given
            EnvironmentUtils.Prepare(nUnitVersion);

            // When
            var exitCode = TestUtils.RunTests(nUnitVersion);

            // Then
            Assert.AreEqual(0, exitCode);
        }
    }
}
