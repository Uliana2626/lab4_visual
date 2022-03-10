using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace lab4_visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string rez = "";
        public ReactiveCommand<string, string> OnClickCommand { get; }
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Result_string = str);
        }
        public string Result_string
        {
            set
            {
                if (rez == "Error")
                {
                    rez = "";
                }
                if (value != "=")
                {
                    this.RaiseAndSetIfChanged(ref rez, rez + value);
                }
                else
                {
                    try
                    {
                        if (rez.IndexOf("+") == 0 || rez.IndexOf("+") == rez.Length - 1 ||
                            rez.IndexOf("-") == 0 || rez.IndexOf("-") == rez.Length - 1 ||
                            rez.IndexOf("*") == 0 || rez.IndexOf("*") == rez.Length - 1 ||
                            rez.IndexOf("/") == 0 || rez.IndexOf("/") == rez.Length - 1)
                        {
                            throw new Models.RomanNumberException("Invalid input");
                        }
                        if (rez.IndexOf("+") != -1)
                        {
                            Models.RomanNumberExtend a = new(rez.Substring(0, rez.IndexOf("+")));
                            Models.RomanNumberExtend b = new(rez.Substring(rez.IndexOf("+")));
                            this.RaiseAndSetIfChanged(ref rez, (a + b).ToString());
                        }
                        if (rez.IndexOf("*") != -1)
                        {
                            Models.RomanNumberExtend a = new(rez.Substring(0, rez.IndexOf("*")));
                            Models.RomanNumberExtend b = new(rez.Substring(rez.IndexOf("*")));
                            this.RaiseAndSetIfChanged(ref rez, (a * b).ToString());
                        }
                        if (rez.IndexOf("-") != -1)
                        {
                            Models.RomanNumberExtend a = new(rez.Substring(0, rez.IndexOf("-")));
                            Models.RomanNumberExtend b = new(rez.Substring(rez.IndexOf("-")));
                            this.RaiseAndSetIfChanged(ref rez, (a - b).ToString());
                        }
                        if (rez.IndexOf("/") != -1)
                        {
                            Models.RomanNumberExtend a = new(rez.Substring(0, rez.IndexOf("/")));
                            Models.RomanNumberExtend b = new(rez.Substring(rez.IndexOf("/")));
                            this.RaiseAndSetIfChanged(ref rez, (a / b).ToString());
                        }
                        rez = "";
                    }
                    catch (Models.RomanNumberException)
                    {
                        this.RaiseAndSetIfChanged(ref rez, "Error occured");
                    }
                }
            }
            get
            {
                return rez;
            }
        }
    }
}
