using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pg.DarkSky.Wpf.ViewModels
{
    public class pgCommand : ICommand
    {
        private Action<object> actionExecute;
        private Func<object, bool> actionCanExecute;

        /// <summary>
        /// Átvesszük a tennivalót, amit a későbbi használatra elmentünk
        /// </summary>
        /// <param name="ExecuteAction">Amit végre kell hajtani a parancs művelethez</param>
        /// <param name="CanExecuteAction">Ami megmondja, hogy a parancs éppen végrehajtható-e?</param>
        public pgCommand(Action<object> ExecuteAction, Func<object, bool> CanExecuteAction)
        {
            this.actionExecute = ExecuteAction;
            this.actionCanExecute = CanExecuteAction;
        }

        /// <summary>
        /// Ez a konstruktor arra való, amikor az Execute mindig hívható
        /// </summary>
        /// <param name="ExecuteAction">Amit végre kell hajtani a parancs művelethez</param>
        public pgCommand(Action<object> ExecuteAction)
            : this(ExecuteAction, null)
        { }

        /// <summary>
        /// Ez az esemény akkor kell kiváltódnia, ha megváltozik az Execute függvényünk
        /// hívhatósága. 
        /// </summary>
        public event EventHandler CanExecuteChanged
        { //Ha a CanExecute értéke változhat, akkor ez egy kötelező implementáció
            //itt azt érjük el, hogy aki feliratkozik a CanExecuteChanged eseményünkre (value)
            //azt feliratkoztatjuk erre a központi eseményre
            add { CommandManager.RequerySuggested += value; }
            //itt meg leiratkoztatjuk a központi eseményről, ha leiratkozott
            //a CanExecuteChanged eseményünkről (value)
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //Ez megmondja, hogy az Execute függvény hívható-e?
            return actionCanExecute == null ? true : actionCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            //Amikor kell, meghívjuk a tennivalót
            actionExecute.Invoke(parameter);
        }
    }
}
