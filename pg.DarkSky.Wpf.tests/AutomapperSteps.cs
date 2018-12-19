using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.api.Model.FromDarkSky;
using pg.DarkSky.Wpf.Models;
using pg.DarkSky.Wpf.Profiles;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
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
        private List<ForecastModelDataPoint> forecastList;

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
            //todo: itt lehetne a minimumra és még egy köztes értékre tesztet írni
            var daily = DailyDataPointFactory();

            forecast = mapper.Map<ForecastModelDataPoint>(daily);

            logger.Information("Mapped from {@Daily} to {@Forecast}", daily, forecast);
        }

        private static DailyDataPoint DailyDataPointFactory()
        {
            return new DailyDataPoint
            {
                time = 1545087600,
                summary = "Ködös idő reggel.",
                icon = "fog",
                precipIntensity = double.MaxValue,
                precipProbability = double.MaxValue,
                //temperature = double.MaxValue,
                //apparentTemperature = double.MaxValue,
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
        }

        [Then(@"a ForecastDataPoint példány jól van kitöltve")]
        public void AkkorAForecastDataPointPeldanyJolVanKitoltve()
        {
            var sut = forecast;

            Assert.IsNotNull(sut);
            Assert.AreEqual(DateTime.Parse(""), sut.Time);
            Assert.AreEqual("Ködös idő reggel.", sut.Summary);
            Assert.AreEqual("fog", sut.Icon);
            Assert.AreEqual(double.MaxValue, sut.Temperature);
            Assert.AreEqual(double.MaxValue, sut.ApparentTemperature);
            Assert.AreEqual(double.MaxValue, sut.AtmosphericPressure);
            Assert.AreEqual(double.MaxValue, sut.WindSpeed);
            Assert.AreEqual(double.MaxValue, sut.Humidity);
            Assert.AreEqual(int.MaxValue, sut.UvIndex);
        }

        [When(@"egy ListOfDailyDataPoint példányt transzformálok ListOfForecastModelDataPoint típusra")]
        public void MajdEgyListOfDailyDataPointPeldanytTranszformalokListOfForecastModelDataPointTipusra()
        {
            //todo: itt lehetne a minimumra és még egy köztes értékre tesztet írni

            //készítünk egy listát amit mappelünk, hogy teszteljük a heti előrejelzés mappingjét
            var dailyList = new List<DailyDataPoint>();

            for (int i = 0; i < 7; i++)
            {
                var daily = DailyDataPointFactory();
                dailyList.Add(daily);
            }

            forecastList = mapper.Map<List<ForecastModelDataPoint>>(dailyList);

            logger.Information("Mapped from {@DailyList} to {@ForecastList}", dailyList, forecastList);
        }

        [Then(@"a ListOfForecastModelDataPoint példány jól van kitöltve")]
        public void AkkorAListOfForecastModelDataPointPeldanyJolVanKitoltve()
        {
            var sut = forecastList;

            Assert.IsNotNull(sut);
            Assert.AreEqual(8, sut.Count);
            foreach (var fsut in sut)
            {
                Assert.IsNotNull(fsut);
                Assert.AreEqual(DateTime.Parse(""), fsut.Time);
                Assert.AreEqual("Ködös idő reggel.", fsut.Summary);
                Assert.AreEqual("fog", fsut.Icon);
                Assert.AreEqual(double.MaxValue, fsut.Temperature);
                Assert.AreEqual(double.MaxValue, fsut.ApparentTemperature);
                Assert.AreEqual(double.MaxValue, fsut.AtmosphericPressure);
                Assert.AreEqual(double.MaxValue, fsut.WindSpeed);
                Assert.AreEqual(double.MaxValue, fsut.Humidity);
                Assert.AreEqual(int.MaxValue, fsut.UvIndex);
            }
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
