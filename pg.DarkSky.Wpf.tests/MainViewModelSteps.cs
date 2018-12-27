using System;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class MainViewModelSteps
    {
        [Given(@"egy viewmodel")]
        public void AmennyibenEgyViewmodel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"a HasSuccess értékét beállítom erre az true-re")]
        public void MajdAHasSuccessErteketBeallitomErreAzTrue_Re()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a HasSuccess értéke ez lesz: true")]
        public void AkkorAHasSuccessErtekeEzLeszTrue()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a megfelelő esemény megérkezik: HasSuccess")]
        public void AkkorAMegfeleloEsemenyMegerkezikHasSuccess()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
