using CountingLibrary;
using CountingLibrary.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoApp
{
    public class DemoViewModel : INotifyPropertyChanged
    {
        private IEnumerable<string> fizzBuzzOutput;

        public IEnumerable<string> FizzBuzzOutput
        {
            get 
            { 
                return fizzBuzzOutput; 
            }
            set 
            { 
                fizzBuzzOutput = value; 
                OnPropertyChanged(nameof(FizzBuzzOutput));
            }
        }

        public DemoViewModel()
        {
            FizzBuzz fizzBuzz = new(100, new List<IModulo>()
            {
                new Modulo("Jonathan", 3),
                new Modulo("Markman", 5),
                new Modulo("Jonathan Markman", 3, 5)
            });

            FizzBuzzOutput = new List<string>(fizzBuzz.Execute());
        }

        #region INPC Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
