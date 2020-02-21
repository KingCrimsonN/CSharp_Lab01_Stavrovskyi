using System;
using System.Threading.Tasks;
using System.Windows;
using Sharp_lab01_stavrovskyi.Tools;

namespace Sharp_lab01_stavrovskyi.ViewModels
{
    internal class LoginViewModel:BaseViewModel
    {
        #region Fields
        private DateTime _date;
        private DateTime _savedDate;
        private int _age;
        private string _cZodiac;
        private string _wZodiac;
        private string _ageString;
        private string _cZodiacString;
        private string _wZodiacString;

        private RelayCommand<object> _calculateCommand;

        #endregion

        #region Properties

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value.Date;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string AgeString
        {
            get { return _ageString; }
            set
            {
                _ageString = value;
                OnPropertyChanged();
            }
        }

        public string CZodiac
        {
            get { return _cZodiac; }
            set
            {
                _cZodiac = value;
                OnPropertyChanged();
            }
        }

        public string CZodiacString
        {
            get { return _cZodiacString; }
            set
            {
                _cZodiacString = value;
                OnPropertyChanged();
            }

        }

        public string WZodiac
        {
            get { return _wZodiac; }
            set
            {
                _wZodiac = value;
                OnPropertyChanged();
            }
        }

        public string WZodiacString
        {
            get { return _wZodiacString; }
            set
            {
                _wZodiacString = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Commands



        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(calculate, o => CanExecuteCommand()));
            }
        }

        

        private async void calculate(object o)
        {
            if (!DateIsValid())
            {
                MessageBox.Show("Invalid date, please try again");
                return;
            }

            if (!_savedDate.Equals(_date))
            {
                Age = CalculateAge();
                await Task.Run((() =>
                {
                    CZodiac = CalculateCZodiac();
                    WZodiac = CalculateWZodiac();
                }));
                AgeString = "Age: " + Age;
                await Task.Run((() =>
                {
                    WZodiacString = "Western Zodiac: " + WZodiac;
                    CZodiacString = "Chinese Zodiac: " + CZodiac;
                }));
                _savedDate = _date;
                if (_date.Month == DateTime.Now.Month && _date.Day == DateTime.Now.Day)
                    MessageBox.Show("Happy Birthday!");
                else MessageBox.Show("Your age and astrological symbols have been calculated, have a look!");
            }
        }

        public bool CanExecuteCommand()
        {
            return _date!=null;
        }

        private bool DateIsValid()
        {
            int diff = CalculateAge();
            if (diff<0 || diff>135)
                return false;
            return true;
        }

        private int CalculateAge()
        {
            if (DateTime.Now.Month < _date.Month || (DateTime.Now.Month == _date.Month && DateTime.Now.Day < _date.Day))
                return DateTime.Now.Year - _date.Year - 1;
            return DateTime.Now.Year - _date.Year;
        }

        private string CalculateCZodiac()
        {
            switch (_date.Year % 12)
            {
                case 3:
                    return "Pig";

                case 4:
                    return "Rat";

                case 5:
                    return "Ox";

                case 6:
                    return "Tiger";

                case 7:
                    return "Rabbit";

                case 8:
                    return "Dragon";

                case 9:
                    return "Snake";

                case 10:
                    return "Horse";

                case 11:
                    return "Sheep";

                case 0:
                    return "Monkey";

                case 1:
                    return "Rooster";

                default:
                    return "Dog";

            }
        }

        private string CalculateWZodiac()
        {
            if ((_date.Month >= 3 && _date.Day >= 21) || (_date.Month <= 4 && _date.Day <= 20))
                return "Aries";
            if ((_date.Month >= 4 && _date.Day >= 21) || (_date.Month <= 5 && _date.Day <= 20))
                return "Taurus";
            if ((_date.Month >= 5 && _date.Day >= 21) || (_date.Month <= 6 && _date.Day <= 20))
                return "Gemini";
            if ((_date.Month >= 6 && _date.Day >= 21) || (_date.Month <= 7 && _date.Day <= 21))
                return "Cancer";
            if ((_date.Month >= 7 && _date.Day >= 22) || (_date.Month <= 8 && _date.Day <= 21))
                return "Leo";
            if ((_date.Month >= 8 && _date.Day >= 22) || (_date.Month <= 9 && _date.Day <= 21))
                return "Virgo";
            if ((_date.Month >= 9 && _date.Day >= 22) || (_date.Month <= 10 && _date.Day <= 21))
                return "Libra";
            if ((_date.Month >= 10 && _date.Day >= 22) || (_date.Month <= 11 && _date.Day <= 21))
                return "Scorpio";
            if ((_date.Month >= 11 && _date.Day >= 22) || (_date.Month <= 12 && _date.Day <= 21))
                return "Sagittarius";
            if ((_date.Month >= 12 && _date.Day >= 22) || (_date.Month <= 1 && _date.Day <= 20))
                return "Capricorn";
            if ((_date.Month >= 1 && _date.Day >= 21) || (_date.Month <= 2 && _date.Day <= 19))
                return "Aquarius";
            return "Pisces";
        }

        #endregion
    }
}
