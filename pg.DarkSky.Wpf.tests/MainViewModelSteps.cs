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

        [When(@"a '(.*)' értékét beállítom a Current tulajdonságon erre az '(.*)'-re")]
        public void MajdAErteketBeallitomACurrentTulajdonsagonErreAz_Re(string propertyName, string value)
        {

            var currentProp = sut.GetType().GetProperty("Current",
                            BindingFlags.Instance | BindingFlags.Public);
            var current = currentProp.GetValue(sut);

            var prop = current.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);

            var converter = TypeDescriptor.GetConverter(prop.PropertyType);
            var val = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);
            prop.SetValue(current, val);

        }

        [Then(@"a '(.*)' a Current tulajdonságon az értéke ez lesz: '(.*)'")]
        public void AkkorAACurrentTulajdonsagonAzErtekeEzLesz(string propertyName, string value)
        {
            var currentProp = sut.GetType().GetProperty("Current",
                            BindingFlags.Instance | BindingFlags.Public);
            var current = currentProp.GetValue(sut);

            var prop = current.GetType().GetProperty(propertyName,
                            BindingFlags.Instance | BindingFlags.Public);

            var result = prop.GetValue(current);

            var converter = TypeDescriptor.GetConverter(prop.PropertyType);
            var expected = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value);

            Assert.AreEqual(expected, result);
        }

        [Then(@"nem érkezik esemény")]
        public void AkkorNemErkezikEsemeny()
        {
            var expected = new List<string>();

            CollectionAssert.AreEqual(expected, events);
        }

        [Then(@"a megfelelő esemény megérkezik: '(.*)'")]
        public void AkkorAMegfeleloEsemenyMegerkezik(string propertyName)
        {
            var expected = new List<string> { propertyName };

            CollectionAssert.AreEqual(expected, events);
        }

    }
}
