using Coypu;

namespace ConductOfCode.Specs
{
    public class BasePage
    {
        protected static BrowserSession Browser;

        protected BasePage()
        {
            Init();
        }

        public void Dispose()
        {
            Browser.Dispose();
            Browser = null;
        }

        private void Init()
        {
            if (Browser != null) return;

            var configuration = new SessionConfiguration
            {
                AppHost = "http://localhost",
                Port = 5000,
                Browser = Coypu.Drivers.Browser.Chrome
            };

            Browser = new BrowserSession(configuration);
        }
    }
}