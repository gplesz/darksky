// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace pg.DarkSky.Wpf.tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MainViewModelFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "MainViewModel.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("hu-HU"), "MainViewModel", "\tFejlesztőként szükségem van egy viewmodell-re, ami adakötéssel megjeleníthető a " +
                    "főablakban.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "MainViewModel")))
            {
                global::pg.DarkSky.Wpf.tests.MainViewModelFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void INotifyPropertyChanged(string tesztnev, string tipusnev, string tulajdonsag, string esemeny, string ertek, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("INotifyPropertyChanged", null, exampleTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given(string.Format("egy \'{0}\' viewmodel", tipusnev), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 6
 testRunner.When(string.Format("a \'{0}\' értékét beállítom erre az \'{1}\'-re", tulajdonsag, ertek), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 7
 testRunner.Then(string.Format("a \'{0}\' értéke ez lesz: \'{1}\'", tulajdonsag, ertek), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line 8
 testRunner.And(string.Format("a megfelelő esemény megérkezik: \'{0}\'", esemeny), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "És ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: MainViewModel HasSuccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel HasSuccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel HasSuccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "HasSuccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "HasSuccess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "true")]
        public virtual void INotifyPropertyChanged_MainViewModelHasSuccess()
        {
#line 4
this.INotifyPropertyChanged("MainViewModel HasSuccess", "MainViewModel", "HasSuccess", "HasSuccess", "true", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: MainViewModel IsBusy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel IsBusy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel IsBusy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "IsBusy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "IsBusy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "true")]
        public virtual void INotifyPropertyChanged_MainViewModelIsBusy()
        {
#line 4
this.INotifyPropertyChanged("MainViewModel IsBusy", "MainViewModel", "IsBusy", "IsBusy", "true", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: MainViewModel ForecastApiCalls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel ForecastApiCalls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel ForecastApiCalls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "ForecastApiCalls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "ForecastApiCalls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5")]
        public virtual void INotifyPropertyChanged_MainViewModelForecastApiCalls()
        {
#line 4
this.INotifyPropertyChanged("MainViewModel ForecastApiCalls", "MainViewModel", "ForecastApiCalls", "ForecastApiCalls", "5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: MainViewModel ErrorMessage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel ErrorMessage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel ErrorMessage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "ErrorMessage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "ErrorMessage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "Hiba történt!!!")]
        public virtual void INotifyPropertyChanged_MainViewModelErrorMessage()
        {
#line 4
this.INotifyPropertyChanged("MainViewModel ErrorMessage", "MainViewModel", "ErrorMessage", "ErrorMessage", "Hiba történt!!!", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "12/27/2018 10:00:00 +01:00")]
        public virtual void INotifyPropertyChanged_ForecastViewModelTime()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel Time", "ForecastViewModel", "Time", "Time", "12/27/2018 10:00:00 +01:00", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "summary")]
        public virtual void INotifyPropertyChanged_ForecastViewModelSummary()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel Summary", "ForecastViewModel", "Summary", "Summary", "summary", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "icon")]
        public virtual void INotifyPropertyChanged_ForecastViewModelIcon()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel Icon", "ForecastViewModel", "Icon", "Icon", "icon", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void INotifyPropertyChanged_ForecastViewModelTemperature()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel Temperature", "ForecastViewModel", "Temperature", "Temperature", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void INotifyPropertyChanged_ForecastViewModelApparentTemperature()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel ApparentTemperature", "ForecastViewModel", "ApparentTemperature", "ApparentTemperature", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "AtmosphericPressure,AtmosphericPressureText")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void INotifyPropertyChanged_ForecastViewModelAtmosphericPressure()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel AtmosphericPressure", "ForecastViewModel", "AtmosphericPressure", "AtmosphericPressure,AtmosphericPressureText", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "WindSpeed,WindSpeedText")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void INotifyPropertyChanged_ForecastViewModelWindSpeed()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel WindSpeed", "ForecastViewModel", "WindSpeed", "WindSpeed,WindSpeedText", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "Humidity,HumidityText")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void INotifyPropertyChanged_ForecastViewModelHumidity()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel Humidity", "ForecastViewModel", "Humidity", "Humidity,HumidityText", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("INotifyPropertyChanged: ForecastViewModel UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ForecastViewModel UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "ForecastViewModel UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "ForecastViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:esemény", "UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "15")]
        public virtual void INotifyPropertyChanged_ForecastViewModelUvIndex()
        {
#line 4
this.INotifyPropertyChanged("ForecastViewModel UvIndex", "ForecastViewModel", "UvIndex", "UvIndex", "15", ((string[])(null)));
#line hidden
        }
        
        public virtual void CurrentINotifyPropertyChanged(string tesztnev, string tipusnev, string tulajdonsag, string ertek, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Current INotifyPropertyChanged", null, exampleTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
 testRunner.Given(string.Format("egy \'{0}\' viewmodel", tipusnev), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 31
 testRunner.When(string.Format("a \'{0}\' értékét beállítom a Current tulajdonságon erre az \'{1}\'-re", tulajdonsag, ertek), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 32
 testRunner.Then(string.Format("a \'{0}\' a Current tulajdonságon az értéke ez lesz: \'{1}\'", tulajdonsag, ertek), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line 33
 testRunner.And("nem érkezik esemény", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "És ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "12/27/2018 10:00:00 +01:00")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_Time()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.Time", "MainViewModel", "Time", "12/27/2018 10:00:00 +01:00", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Summary")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "summary")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_Summary()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.Summary", "MainViewModel", "Summary", "summary", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Icon")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "icon")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_Icon()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.Icon", "MainViewModel", "Icon", "icon", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Temperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_Temperature()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.Temperature", "MainViewModel", "Temperature", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "ApparentTemperature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_ApparentTemperature()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.ApparentTemperature", "MainViewModel", "ApparentTemperature", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "AtmosphericPressure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_AtmosphericPressure()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.AtmosphericPressure", "MainViewModel", "AtmosphericPressure", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "WindSpeed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_WindSpeed()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.WindSpeed", "MainViewModel", "WindSpeed", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "Humidity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "5.5")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_Humidity()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.Humidity", "MainViewModel", "Humidity", "5.5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Current INotifyPropertyChanged: MainViewModel Current.UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MainViewModel Current.UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tesztnév", "MainViewModel Current.UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:típusnév", "MainViewModel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tulajdonság", "UvIndex")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:érték", "15")]
        public virtual void CurrentINotifyPropertyChanged_MainViewModelCurrent_UvIndex()
        {
#line 29
this.CurrentINotifyPropertyChanged("MainViewModel Current.UvIndex", "MainViewModel", "UvIndex", "15", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
