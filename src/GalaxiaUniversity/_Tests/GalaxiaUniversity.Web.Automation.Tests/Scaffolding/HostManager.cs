namespace GalaxiaUniversity.Web.Automation.Tests.Scaffolding
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using TechTalk.SpecFlow;

    [Binding]
    public class HostManager
    {
        public static Host Host
        {
            get; private set;
        }

        public static Page Page => Host.Page;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var task = Task.Run(() => CreateEmptyDatabase());

            IisExpressHelper.StartIis();
            Host = new Host();

            task.Wait();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Host.WebDriver.Quit();
            IisExpressHelper.StopIis();
        }

        private static void CreateEmptyDatabase()
        {
            Debug.WriteLine("Starting CreateEmptyDatabase()");
        }
    }
}
