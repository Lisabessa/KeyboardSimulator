using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyboardApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool UpperCase;
        bool ShiftCase;
        Trainer trainer;
        int ind;
        System.Windows.Threading.DispatcherTimer timer;
        int Chars = 0;
        public MainWindow()
        {
            InitializeComponent();
            StopBtn.IsEnabled = false;
            StartBtn.IsEnabled = true;
            GenText.Text = "";
            UserText.Text = "";
            UpperCase = false;
            ShiftCase = false;
            trainer = new Trainer();
            Difficulty.Value = 3;
            Difficulty.Minimum = 3;
            ind = 0;

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!StartBtn.IsEnabled)
            {
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                {
                    PanelDefault.Visibility = Visibility.Collapsed;
                    PanelCaps.Visibility = Visibility.Collapsed;
                    PanelShift.Visibility = Visibility.Visible;
                    UpperCase = true;
                    ShiftCase = true;

                }
                else if (e.Key == Key.CapsLock)
                {
                    if (UpperCase)
                    {
                        PanelCaps.Visibility = Visibility.Collapsed;
                        PanelShift.Visibility = Visibility.Collapsed;
                        PanelDefault.Visibility = Visibility.Visible;
                        UpperCase = false;
                        ShiftCase = false;
                    }
                    else
                    {
                        PanelDefault.Visibility = Visibility.Collapsed;
                        PanelShift.Visibility = Visibility.Collapsed;
                        PanelCaps.Visibility = Visibility.Visible;
                        UpperCase = true;
                        ShiftCase = false;
                    }

                }
                else if (e.Key == Key.Space)
                {
                    UserText.Text += " ";
                    Count(" ");
                }
                else if (e.Key == Key.LeftAlt || e.Key == Key.RightAlt || e.Key == Key.LWin
                    || e.Key == Key.RWin || e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl
                    || e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Tab)
                {
                    //ничего не происходит
                }
                else if (e.Key == Key.Oem3)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "~";
                        Count("~");
                    }
                    else
                    {
                        UserText.Text += "`";
                        Count("`");
                    }
                }
                else if (e.Key == Key.D1)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "!";
                        Count("!");
                    }
                    else
                    {
                        UserText.Text += "1";
                        Count("1");
                    }

                }
                else if (e.Key == Key.D2)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "@";
                        Count("@");
                    }
                    else
                    {
                        UserText.Text += "2";
                        Count("2");
                    }
                }
                else if (e.Key == Key.D3)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "#";
                        Count("#");
                    }
                    else
                    {
                        UserText.Text += "3";
                        Count("3");
                    }
                }
                else if (e.Key == Key.D4)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "$";
                        Count("$");
                    }
                    else
                    {
                        UserText.Text += "4";
                        Count("4");
                    }
                }
                else if (e.Key == Key.D5)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "%";
                        Count("%");
                    }
                    else
                    {
                        UserText.Text += "5";
                        Count("5");
                    }
                }
                else if (e.Key == Key.D6)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "^";
                        Count("^");
                    }
                    else
                    {
                        UserText.Text += "6";
                        Count("6");
                    }
                }
                else if (e.Key == Key.D7)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "&";
                        Count("&");
                    }
                    else
                    {
                        UserText.Text += "7";
                        Count("7");
                    }
                }
                else if (e.Key == Key.D8)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "*";
                        Count("*");

                    }
                    else
                    {
                        UserText.Text += "8";
                        Count("8");
                    }
                }
                else if (e.Key == Key.D9)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "(";
                        Count("(");
                    }
                    else
                    {
                        UserText.Text += "9";
                        Count("9");
                    }
                }
                else if (e.Key == Key.D0)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += ")";
                        Count(")");
                    }
                    else
                    {
                        UserText.Text += "0";
                        Count("0");
                    }
                }
                else if (e.Key == Key.OemMinus)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "_";
                        Count("_");
                    }
                    else
                    {
                        UserText.Text += "-";
                        Count("-");
                    }
                }
                else if (e.Key == Key.OemPlus)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "+";
                        Count("+");
                    }
                    else
                    {
                        UserText.Text += "=";
                        Count("=");
                    }
                }
                else if (e.Key == Key.OemOpenBrackets)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "{";
                        Count("{");
                    }
                    else
                    {
                        UserText.Text += "[";
                        Count("[");
                    }
                }
                else if (e.Key == Key.Oem6)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "}";
                        Count("}");
                    }
                    else
                    {
                        UserText.Text += "]";
                        Count("]");
                    }
                }
                else if (e.Key == Key.Oem1)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += ":";
                        Count(":");
                    }
                    else
                    {
                        UserText.Text += ";";
                        Count(";");
                    }
                }
                else if (e.Key == Key.OemQuotes)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += '"';
                        Count("\"");
                    }
                    else
                    {
                        UserText.Text += "'";
                        Count("'");
                    }
                }
                else if (e.Key == Key.Oem5)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "|";
                        Count("|");
                    }
                    else
                    {
                        UserText.Text += "\\";
                        Count("\\");
                    }
                }
                else if (e.Key == Key.OemPeriod)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += ">";
                        Count(">");
                    }
                    else
                    {
                        UserText.Text += ".";
                        Count(".");
                    }
                }
                else if (e.Key == Key.OemQuestion)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "?";
                        Count("?");
                    }
                    else
                    {
                        UserText.Text += "/";
                        Count("/");
                    }
                }
                else if (e.Key == Key.OemComma)
                {
                    if (ShiftCase)
                    {
                        UserText.Text += "<";
                        Count("<");
                    }
                    else
                    {
                        UserText.Text += ",";
                        Count(",");
                    }

                }
                else if (!UpperCase)
                {     
                    UserText.Text += e.Key.ToString().ToLower();
                    Count(e.Key.ToString().ToLower());

                }
                else if (UpperCase)
                {   
                    UserText.Text += e.Key.ToString().ToUpper();
                    Count(e.Key.ToString().ToUpper());
                }
            }
             
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (!StartBtn.IsEnabled)
            {
                if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                {
                    PanelShift.Visibility = Visibility.Collapsed;
                    PanelCaps.Visibility = Visibility.Collapsed;
                    PanelDefault.Visibility = Visibility.Visible;
                    UpperCase = false;
                    ShiftCase = false;
                }
            }       
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            ind = 0;
            GenText.Text = "";
            UserText.Text = "";
            StopBtn.IsEnabled = true;
            StartBtn.IsEnabled = false;
            trainer.Errors = 0;
            Fails.Text = trainer.Errors.ToString();
            GenText.Text = trainer.GenTest();

            timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            EndTheGame();
        }
        private void timerTick(object sender, EventArgs e)
        {
            trainer.Speed = Chars * 6;
            CharsMin.Text = trainer.Speed.ToString();
            Chars = 0;
        }

        private void Dificulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {   
            trainer.Level = (int)Difficulty.Value;
            DifficultyInfo.Text = trainer.Level.ToString();
        }

        private void CaseSensitiveInfo_Checked(object sender, RoutedEventArgs e)
        {
            trainer.CaseSensitive = true;
        }

        private void CaseSensitiveInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            trainer.CaseSensitive = false;
        }

        private void Count(string sym)
        {
            Chars++;

            if (!trainer.Comparison(ind, sym))
            {
                trainer.Errors ++;
                Fails.Text = trainer.Errors.ToString();
            }
            
            ind++;
            if(ind == 50)
            {            
                MessageBox.Show(trainer.GameResult());
                EndTheGame();
            }
        }

        private void EndTheGame()
        {
            timer.Stop();
            ind = 0;
            StopBtn.IsEnabled = false;
            StartBtn.IsEnabled = true;
            trainer.Errors = 0;
            Fails.Text = trainer.Errors.ToString();
            GenText.Text = "";
            UserText.Text = "";
            trainer.Speed = 0;
            CharsMin.Text = trainer.Speed.ToString();
            Chars = 0;
        }
    }
}
