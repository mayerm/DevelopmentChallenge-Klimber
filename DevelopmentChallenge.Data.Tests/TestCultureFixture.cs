using System.Globalization;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [SetUpFixture]
    public class TestCultureFixture
    {
        [OneTimeSetUp]
        public void PinCulture()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("es-AR");
        }
    }
}
