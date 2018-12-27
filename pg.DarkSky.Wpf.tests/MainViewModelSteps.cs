using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class MainViewModelSteps
    {
        private MainViewModel sut;
        private List<string> events = new List<string>();

        [Given(@"egy viewmodel")]
        public void AmennyibenEgyViewmodel()
        {
            sut = new MainViewModel();
            sut.PropertyChanged += Sut_PropertyChanged;
        }

        private void Sut_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            events.Add(e.PropertyName);
        }

        [When(@"a '(.*)' értékét beállítom erre az '(.*)'-re")]
        public void MajdAErteketBeallitomErreAz_Re(string propertyName, bool value)
        {

            var prop = sut.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);
            prop.SetValue(sut, value);

        }

        [Then(@"a '(.*)' értéke ez lesz: '(.*)'")]
        public void AkkorAErtekeEzLesz(string propertyName, bool value)
        {
            var prop = sut.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);

            var result = prop.GetValue(sut);

            var val = Convert.ChangeType(result, prop.PropertyType);

            Assert.AreEqual(value, val);

        }

        [Then(@"a megfelelő esemény megérkezik: '(.*)'")]
        public void AkkorAMegfeleloEsemenyMegerkezik(string propertyName)
        {
            var expected = new List<string> { propertyName };

            CollectionAssert.AreEqual(expected, events);
        }
    }
}
