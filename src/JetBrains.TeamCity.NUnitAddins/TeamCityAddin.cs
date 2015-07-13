namespace JetBrains.TeamCity.NUnitAddins
{
    using NUnit.Core.Extensibility;

    [NUnitAddin]
    public class TeamCityAddin : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            // Debugger.Launch();
            // var nunitVersion = typeof(IExtensionHost).Assembly.GetName().Version;
            var eventListeners = host.GetExtensionPoint("EventListeners");
            eventListeners.Install(new TeamCityEventListener());
            return true;
        }
    }
}