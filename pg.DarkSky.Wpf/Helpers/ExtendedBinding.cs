using System;
using System.Windows;
using System.Windows.Data;

namespace pg.DarkSky.Wpf.Helpers
{
    /// <summary>
    /// Segít az ikonok megjelenítésében, hogy ne kelljen DependencyProperty-t implementálni
    /// 
    /// Loptam: https://www.codeproject.com/Articles/71348/Binding-on-a-Property-which-is-not-a-DependencyPro
    /// </summary>
    public class ExtendedBinding : FrameworkElement
    {
        #region Source DP
        //We don't know what will be the Source/target type so we keep 'object'.
        public static readonly DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(object), typeof(ExtendedBinding),
          new FrameworkPropertyMetadata()
          {
              BindsTwoWayByDefault = true,
              DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
          });
        public Object Source
        {
            get { return GetValue(ExtendedBinding.SourceProperty); }
            set { SetValue(ExtendedBinding.SourceProperty, value); }
        }
        #endregion

        #region Target DP
        //We don't know what will be the Source/target type so we keep 'object'.
        public static readonly DependencyProperty TargetProperty =
          DependencyProperty.Register("Target", typeof(object), typeof(ExtendedBinding),
          new FrameworkPropertyMetadata()
          {
              BindsTwoWayByDefault = true,
              DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
          });
        public Object Target
        {
            get { return GetValue(ExtendedBinding.TargetProperty); }
            set { SetValue(ExtendedBinding.TargetProperty, value); }
        }
        #endregion

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == ExtendedBinding.SourceProperty.Name)
            {
                //no loop wanted
                if (!object.ReferenceEquals(Source, Target))
                    Target = Source;
            }
            else if (e.Property.Name == ExtendedBinding.TargetProperty.Name)
            {
                //no loop wanted
                if (!object.ReferenceEquals(Source, Target))
                    Source = Target;
            }
        }
    }
}
