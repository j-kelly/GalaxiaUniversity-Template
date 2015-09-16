namespace WebApplication1
{
    using Newtonsoft.Json.Converters;
    using System;
    using System.Web.Http;

    public static class WebApiConfig
    {
        private class DateFormatConverter : DateTimeConverterBase
        {
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                return DateTime.Parse(reader.Value.ToString());
            }

            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString("d"));
            }
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new DateFormatConverter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
