using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Az INotifyPropertyChanged alap implementáció.
        /// Kap egy értéket, és ellenőrzi, hogy ez a property jelenlegi értékéhez képest változást jelent-e?
        /// Ha igen, akkor módosítja a mezőt, ami a property értékóét tárolja,
        /// és dob egy PropertyChanged eseményt a property nevével
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">az új érték, amire a property értékét változtatni szeretnénk.</param>
        /// <param name="backingField">a property mögötti mező, amit módosítani kell, ha változik a property</param>
        /// <param name="propertyName">a property, amit változtatunk. Ha nem adjuk meg, akkor a hívó eljárás nevét használja</param>
        /// <returns>igaz, ha változott, a property értéke, hamis, ha az új érték ugyanaz, mint a régi</returns>
        protected virtual bool SetProperty<T>(T value, ref T backingField, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) { return false; }

            backingField = value;

            OnPropertyChanged(propertyName);

            return true;
        }

    }
}
