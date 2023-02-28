using AutoFixture;
using irrigation_system_webapp.Models;

namespace irrigation_system_webapp.Data
{
    public static class Seeder
    {
        public static void Seed(this IrrigationAppContext appContext)
        {
            if (!appContext.Temperatures.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<Temperature>(product => product.Without(p => p.TemperatureId));
                //--- The next two lines add 100 rows to your database
                List<Temperature> products = fixture.CreateMany<Temperature>(100).ToList();
                appContext.AddRange(products);
                appContext.SaveChanges();
            }
        }
    }
}
