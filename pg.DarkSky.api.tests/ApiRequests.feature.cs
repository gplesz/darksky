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
namespace pg.DarkSky.api.tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ApiRequestsFeature : Xunit.IClassFixture<ApiRequestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ApiRequests.feature"
#line hidden
        
        public ApiRequestsFeature(ApiRequestsFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("hu-HU"), "ApiRequests", "\tFejlesztőként szükségem van egy osztályra, amin keresztül elérem az API felülete" +
                    "t.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.TheoryAttribute(DisplayName="GetDataWithCoordinateAndLanguage")]
        [Xunit.TraitAttribute("FeatureTitle", "ApiRequests")]
        [Xunit.TraitAttribute("Description", "GetDataWithCoordinateAndLanguage")]
        [Xunit.InlineDataAttribute("Bp-hu", "2f4659626fb968a85a5ff22561962711", "47.49801,19.03991", "hu", "true", new string[0])]
        [Xunit.InlineDataAttribute("Bp-hu-wrongapikey", "wrongapikey", "47.49801,19.03991", "hu", "false", new string[0])]
        public virtual void GetDataWithCoordinateAndLanguage(string tesztnev, string apiKulcs, string varos, string nyelv, string ervenyes, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetDataWithCoordinateAndLanguage", null, exampleTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given(string.Format("egy API kapcsolat \'{0}\' paraméterrel", apiKulcs), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Adott ");
#line 6
 testRunner.When(string.Format("lekérdezem az időjárási adatokat \'{0}\' és \'{1}\' adatokkal", varos, nyelv), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Ha ");
#line 7
 testRunner.Then(string.Format("a válasz eredménye ez lesz: \'{0}\' lesz", ervenyes), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Akkor ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ApiRequestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ApiRequestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
