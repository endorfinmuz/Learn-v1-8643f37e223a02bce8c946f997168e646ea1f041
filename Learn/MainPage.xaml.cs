using Microsoft.Win32;
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
using Learn.Functions;

namespace Learn
{
    public partial class MainPage : Page
    {
        public string theme = "";

        //данные для получения из реестра или БД

        public string name = "";
        public int completed_stages = 0;
        public int progress = 0;
        public string status = "auth";

        public static RegistryKey currentUserKey = Registry.CurrentUser;

        public void UserInfoVisibleON()
        {
            InitializeComponent();
            addnamelabel.Visibility = Visibility.Hidden;
            personName_TB.Visibility = Visibility.Hidden;
            AddName.Visibility = Visibility.Hidden;

            profilehello.Visibility = Visibility.Visible;
            profileimg.Visibility = Visibility.Visible;
            profilename.Visibility = Visibility.Visible;
            lbthemestext.Visibility = Visibility.Visible;
            lbyourthemes.Visibility = Visibility.Visible;

            status = "loggined";
        }

        public MainPage()
        {
            InitializeComponent();
            progressask.Content = "Прогресс показывает насколько вы далеки от полного прохождения курса. \r\nОчки прогресса вы сможете получить проходя тесты в темах.";

            if (Registry.CurrentUser.OpenSubKey("LearnData") == null)
            {
                return;
            }
            else
            {
                RegistryKey open = currentUserKey.OpenSubKey("LearnData");

                if (open.GetValue("user") == null)
                {
                    open.Close();
                    return;
                }
                else
                {
                    name = open.GetValue("user").ToString();
                    progress = Convert.ToInt32(open.GetValue("stagesago")) * 20;
                    ProgressBar_Main.Value = progress;

                    Main mainfunc = new Main(); // показывает информацию об авторизованном пользователе, убирая ввод нового
                    UserInfoVisibleON();

                    profilename.Content = name;
                    completed_stages = Convert.ToInt32(open.GetValue("stagesago"));
                    lbyourthemes.Content = completed_stages.ToString();

                    open.Close();
                }
            }

            ProgressBar_Main.Value = progress;
        }

        private void GotoTheme(string theme)
        {
            if (theme == "Тема 1. ВВЕДЕНИЕ В WPF И XAML")
            {
                NextFrame.Navigate(new Theme1());
            }
            else if (theme == "Тема 2. КОНТЕЙНЕРЫ КОМПОНОВКИ В WPF" && completed_stages.ToString() == "1")
            {
                NextFrame.Navigate(new Theme2());
            }
            else { MessageBox.Show("Такой темы не существует или у вас нет доступа к ней!", "Интерактивный помощник"); }
        }

        private void Start_Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (profilename.Content.ToString() != "")
                {
                    name = personName_TB.Text;
                    theme = Tb_Themes.Text;
                    if (Tb_Themes.Text != "")
                    {
                        GotoTheme(theme);
                    }
                    else if (status == "loggined")
                    {
                        GotoTheme(theme);
                    }
                    else { MessageBox.Show("Неверно введены данные!", "Интерактивный помощник"); }
                }
                else if (status == "loggined")
                {
                    theme = Tb_Themes.Text;
                    GotoTheme(theme);
                }
                else { MessageBox.Show("Введите данные верно!", "Интерактивный помощник"); }
            }
            catch
            {
                MessageBox.Show("При авторизации произошла ошибка", "Интерактивный помощник");
            }
        }

        private void NextFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void NextFrame_ContentRendered(object sender, EventArgs e)
        {
            NextFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void AddName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                profilename.Content = personName_TB.Text;

                RegistryKey create = currentUserKey.CreateSubKey("LearnData");
                create.SetValue("user", personName_TB.Text);
                create.SetValue("stagesago", completed_stages);
                progress = 0;

                Main mainfunc = new Main(); // показывает информацию об авторизованном пользователе, убирая ввод нового
                UserInfoVisibleON();

                lbyourthemes.Content = completed_stages.ToString();
                create.Close();
                return;
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить запись в реестр!\nПопробуйте ещё раз.", "Интерактивный помощник");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey open = currentUserKey.OpenSubKey("LearnData");
            name = open.GetValue("user").ToString();
            progress = Convert.ToInt32(open.GetValue("stagesago")) * 20;
            ProgressBar_Main.Value = progress;

            Main mainfunc = new Main(); // показывает информацию об авторизованном пользователе, убирая ввод нового
            UserInfoVisibleON();

            profilename.Content = name;
            completed_stages = Convert.ToInt32(open.GetValue("stagesago"));
            lbyourthemes.Content = completed_stages.ToString();

            open.Close();
        }

        private void CheckAdwards_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (status == "loggined")
                {
                    NextFrame.Navigate(new adwards());
                }
                else { MessageBox.Show("Авторизуйтесь!", "Интерактивный помощник"); }
            }
            catch
            {
                MessageBox.Show("При авторизации произошла ошибка", "Интерактивный помощник");
            }
        }
    }
}
