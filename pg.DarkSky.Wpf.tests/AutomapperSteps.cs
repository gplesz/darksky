using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Profiles;
using Serilog;
using Serilog.Core;
using System;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class AutomapperSteps
    {
        private Logger logger;
        private IMapper mapper;
        private MapperConfiguration config;
        private ForecastModelDataPoint forecast;

        public AutomapperSteps()
        {
            //a tesztben nincs DI így nekünk kell a loggert konfigurálni
            logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .CreateLogger();


        }

        [Given(@"egy felparaméterezett mapper")]
        public void AmennyibenEgyFelparameterezettMapper()
        {
            logger.Information("Create Mapper config");
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ForecastProfile>();
            });

            //ezt kitehetném a konstruktorba, de mivel itt megvan a konfig és mindig fut, itt is jó helyen van
            mapper = config.CreateMapper();
        }

        [When(@"ellenőrzöm a konfigurációt")]
        public void MajdEllenorzomAKonfiguraciot()
        {
            //ezzel most nincs dolgunk
        }

        [Then(@"a végeredmény azt jelzi, hogy minden rendben")]
        public void AkkorAVegeredmenyAztJelziHogyMindenRendben()
        {
            logger.Information("Assert configuration is valid");
            config.AssertConfigurationIsValid();
        }


        [When(@"egy CurrentDataPoint példányt transzformálok ForecastModelDataPoint típusra")]
        public void MajdEgyCurrentDataPointPeldanytTranszformalokForecastModelDataPointTipusra()
        {
            //todo: itt lehetne a minimumra és még egy köztes értékre tesztet írni
            var current = new CurrentlyDataPoint
            {
                time = 1545087600,
                summary = "Ködös idő reggel.",
                icon = "fog",
                precipIntensity = double.MaxValue,
                precipProbability = double.MaxValue,
                temperature = double.MaxValue,
                apparentTemperature = double.MaxValue,
                dewPoint = double.MaxValue,
                humidity = double.MaxValue,
                pressure = double.MaxValue,
                windSpeed = double.MaxValue,
                windGust = double.MaxValue,
                windBearing = int.MaxValue,
                cloudCover = double.MaxValue,
                uvIndex = int.MaxValue,
                visibility = double.MaxValue,
                ozone = double.MaxValue
            };

            forecast = mapper.Map<ForecastModelDataPoint>(current);

            logger.Information("Mapped from {@Current} to {@Forecast}", current, forecast);

        }

        [When(@"egy DailyDataPoint példányt transzformálok ForecastModelDataPoint típusra")]
        public void MajdEgyDailyDataPointPeldanytTranszformalokForecastModelDataPointTipusra()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a ForecastDataPoint példány jól van kitöltve")]
        public void AkkorAForecastDataPointPeldanyJolVanKitoltve()
        {
            Assert.IsNotNull(forecast);
            Assert.AreEqual(DateTime.Parse(""), forecast.Time);
            Assert.AreEqual("Ködös idő reggel.", forecast.Summary);
            Assert.AreEqual("fog", forecast.Icon);
            Assert.AreEqual(double.MaxValue, forecast.Temperature);
            Assert.AreEqual(double.MaxValue, forecast.ApparentTemperature);
            Assert.AreEqual(double.MaxValue, forecast.AtmosphericPressure);
            Assert.AreEqual(double.MaxValue, forecast.WindSpeed);
            Assert.AreEqual(double.MaxValue, forecast.Humidity);
            Assert.AreEqual(int.MaxValue, forecast.UvIndex);
        }

        [When(@"egy ListOfDailyDataPoint példányt transzformálok ListOfForecastModelDataPoint típusra")]
        public void MajdEgyListOfDailyDataPointPeldanytTranszformalokListOfForecastModelDataPointTipusra()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a ListOfForecastModelDataPoint példány jól van kitöltve")]
        public void AkkorAListOfForecastModelDataPointPeldanyJolVanKitoltve()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"egy ApiResult példányt transzformálok ForecastModel típusra")]
        public void MajdEgyApiResultPeldanytTranszformalokForecastModelTipusra()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a ForecastModel példány jól van kitöltve")]
        public void AkkorAForecastModelPeldanyJolVanKitoltve()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
