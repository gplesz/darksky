using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.api.Model;
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
        private ForecastModel apiResult;

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
            //ezzel most nincs dolgunk, mert nincs köztes lépés, csak a jellemző (AutomapperFeature)
            //forgatókönyve (Automapper configuration check) miatt kell egy ilyen hívás váza
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
            var current = CurrentlyDataPointFactory();

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

        [Then(@"a ForecastDataPoint példány jól van kitöltve")]
        public void AkkorAForecastDataPointPeldanyJolVanKitoltve()
        {
            AssertForecastDataPoint(forecast);
        }

        [When(@"egy ListOfDailyDataPoint példányt transzformálok ListOfForecastModelDataPoint típusra")]
        public void MajdEgyListOfDailyDataPointPeldanytTranszformalokListOfForecastModelDataPointTipusra()
        {
            List<DailyDataPoint> dailyList = DailyDataPointListFactory();

            forecastList = mapper.Map<List<ForecastModelDataPoint>>(dailyList);

            logger.Information("Mapped from {@DailyList} to {@ForecastList}", dailyList, forecastList);
        }

        [Then(@"a ListOfForecastModelDataPoint példány jól van kitöltve")]
        public void AkkorAListOfForecastModelDataPointPeldanyJolVanKitoltve()
        {
            AssertListOfForecastDataPointList(forecastList);
        }

        [When(@"egy ApiResult példányt transzformálok ForecastModel típusra")]
        public void MajdEgyApiResultPeldanytTranszformalokForecastModelTipusra()
        {
            var result = new ApiResult<ApiResponse> {
                ForecastApiCalls = 11,
                HasSuccess = true,
                Data = new ApiResponse
                {
                    currently = CurrentlyDataPointFactory(),
                    daily = new DailyDataBlock
                    {
                        data = DailyDataPointListFactory(),
                        summary = "bumm bumm",
                        icon = "bamm bamm"
                    }
                }
            };

            apiResult = mapper.Map<ForecastModel>(result);
        }

        [Then(@"a ForecastModel példány jól van kitöltve")]
        public void AkkorAForecastModelPeldanyJolVanKitoltve()
        {
            Assert.AreEqual(11, apiResult.ForecastApiCalls);
            Assert.IsTrue(apiResult.IsValid);
            AssertForecastDataPoint(apiResult.Current);
            AssertListOfForecastDataPointList(apiResult.Daily);
        }

        private static List<DailyDataPoint> DailyDataPointListFactory()
        {
            //todo: itt lehetne a minimumra és még egy köztes értékre tesztet írni

            //készítünk egy listát amit mappelünk, hogy teszteljük a heti előrejelzés mappingjét
            var dailyList = new List<DailyDataPoint>();

            for (int i = 0; i < 7; i++)
            {
                var daily = DailyDataPointFactory();
                dailyList.Add(daily);
            }

            return dailyList;
        }

        private static CurrentlyDataPoint CurrentlyDataPointFactory()
        {
            //todo: itt lehetne a minimumra és még egy köztes értékre tesztet írni
            return new CurrentlyDataPoint
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
                dewPoint = double.MaxValue,
                humidity = double.MaxValue,
                pressure = double.MaxValue,
                windSpeed = double.MaxValue,
                windGust = double.MaxValue,
                windBearing = int.MaxValue,
                cloudCover = double.MaxValue,
                uvIndex = int.MaxValue,
                visibility = double.MaxValue,
                ozone = double.MaxValue,

                sunriseTime = 1545087600,
                sunsetTime = 1545087600,
                windGustTime = 1545087600,
                uvIndexTime = 1545087600,

                moonPhase = double.MaxValue,
                precipIntensityMax = double.MaxValue,
                precipIntensityMaxTime = 1545087600,
                precipAccumulation = double.MaxValue,
                precipType = "DuDuDu",
                temperatureHigh = double.MaxValue,
                temperatureHighTime = 1545087600,
                temperatureLow = double.MaxValue,
                temperatureLowTime = 1545087600,
                apparentTemperatureHigh = double.MaxValue,
                apparentTemperatureHighTime = 1545087600,
                apparentTemperatureLow = double.MaxValue,
                apparentTemperatureLowTime = 1545087600,
                temperatureMin = double.MaxValue,
                temperatureMinTime = 1545087600,
                temperatureMax = double.MaxValue,
                temperatureMaxTime = 1545087600,
                apparentTemperatureMin = double.MaxValue,
                apparentTemperatureMinTime = 1545087600,
                apparentTemperatureMax = double.MaxValue,
                apparentTemperatureMaxTime = 1545087600,

            };
        }

        private static void AssertForecastDataPoint(ForecastModelDataPoint sut)
        {
            Assert.IsNotNull(sut);
            Assert.AreEqual(new DateTimeOffset(2018, 12, 17, 23, 0, 0, TimeSpan.FromSeconds(0)), sut.Time);
            Assert.AreEqual("Ködös idő reggel.", sut.Summary);
            Assert.AreEqual("fog", sut.Icon);
            Assert.AreEqual(double.MaxValue, sut.Temperature);
            Assert.AreEqual(double.MaxValue, sut.ApparentTemperature);
            Assert.AreEqual(double.MaxValue, sut.AtmosphericPressure);
            Assert.AreEqual(double.MaxValue, sut.WindSpeed);
            Assert.AreEqual(double.MaxValue, sut.Humidity);
            Assert.AreEqual(int.MaxValue, sut.UvIndex);
        }

        private static void AssertListOfForecastDataPointList(List<ForecastModelDataPoint> sut)
        {
            Assert.IsNotNull(sut);
            Assert.AreEqual(7, sut.Count);
            foreach (var fsut in sut)
            {
                AssertForecastDataPoint(fsut);
            }
        }
    }
}
