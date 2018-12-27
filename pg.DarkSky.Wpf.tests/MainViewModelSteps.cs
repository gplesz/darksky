using Microsoft.VisualStudio.TestTools.UnitTesting;
using pg.DarkSky.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using TechTalk.SpecFlow;

namespace pg.DarkSky.Wpf.tests
{
    [Binding]
    public class MainViewModelSteps
    {
        private object sut;
        private List<string> events = new List<string>();

        [Given(@"egy '(.*)' viewmodel")]
        public void AmennyibenEgyViewmodel(string typeName)
        {
            var t = Type.GetType($"pg.DarkSky.Wpf.ViewModels.{typeName}, pg.DarkSky.Wpf", true);
            sut = Activator.CreateInstance(t);
            ((ViewModelBase)sut).PropertyChanged += Sut_PropertyChanged;
        }

        private void Sut_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            events.Add(e.PropertyName);
        }

        [When(@"a '(.*)' értékét beállítom erre az '(.*)'-re")]
        public void MajdAErteketBeallitomErreAz_Re(string propertyName, string value)
        {

            var example = DateTimeOffset.Now.ToString(CultureInfo.InvariantCulture);

            var prop = sut.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);

            var converter = TypeDescriptor.GetConverter(prop.PropertyType);
            var val = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);

            prop.SetValue(sut, val);

        }

        [Then(@"a '(.*)' értéke ez lesz: '(.*)'")]
        public void AkkorAErtekeEzLesz(string propertyName, string value)
        {
            var prop = sut.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);

            var result = prop.GetValue(sut);

            var converter = TypeDescriptor.GetConverter(prop.PropertyType);
            var expected = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);

            Assert.AreEqual(expected, result);

        }

        [Then(@"a megfelelő esemény megérkezik: '(.*)'")]
        public void AkkorAMegfeleloEsemenyMegerkezik(string propertyName)
        {
            var expected = new List<string> { propertyName };

            CollectionAssert.AreEqual(expected, events);
        }
    }
}
