namespace TestApp
{
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Models.V1;

    public class ForecastODataConfiguration : IModelConfiguration
    {
        public void Apply(
            ODataModelBuilder builder,
            ApiVersion apiVersion,
            string routePrefix)
        {
            switch (apiVersion.MajorVersion)
            {
                default:
                    ConfigureV1(builder);
                    break;
            }
        }

        private static void ConfigureV1(ODataModelBuilder builder)
        {
            var weatherForecastType = builder.EntitySet<WeatherForecast>("WeatherForecasts").EntityType;
            weatherForecastType.HasKey(r => r.Id);
            weatherForecastType.Property(r => r.Id).IsOptional();
        }
    }
}
