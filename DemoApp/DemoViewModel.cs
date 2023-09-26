using CountingLibrary;
using CountingLibrary.Interfaces;
using DemoApp.Commands;
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

        public DelegateCommand MyNameDemo { get; }
        public DelegateCommand CompanyNameDemo { get; }
        public DelegateCommand GameNameDemo { get; set; }

        public DemoViewModel()
        {
            MyNameDemo = new DelegateCommand(MyNameExample);
            CompanyNameDemo = new DelegateCommand(CompanyNameExample);
            GameNameDemo = new DelegateCommand(GameNameExample);

            FizzBuzz fizzBuzz = new(100, new List<IModulo>()
            {
                new Modulo("Jonathan", 3),
                new Modulo("Markman", 5),
                new Modulo("Jonathan Markman", 3, 5)
            });

            FizzBuzzOutput = new List<string>(fizzBuzz.Execute());
        }

        public void MyNameExample()
        {
            FizzBuzz fizzBuzz = new(100, new List<IModulo>()
            {
                new Modulo("Jonathan", 3),
                new Modulo("Markman", 5),
                new Modulo("Jonathan Markman", 3, 5)
            });

            FizzBuzzOutput = new List<string>(fizzBuzz.Execute());
        }

        public void CompanyNameExample()
        {
            FizzBuzz fizzBuzz = new(250, new List<IModulo>()
            {
                new Modulo("Clear Measure", 5, 10, 25)
            });

            FizzBuzzOutput = new List<string>(fizzBuzz.Execute());
        }

        public void GameNameExample()
        {
            FizzBuzz fizzBuzz = new(400, new List<IModulo>()
            {
                new Modulo("Age of Empires", 17),
                new Modulo("Super Mario", 22),
                new Modulo("Street Fighter", 25)
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
