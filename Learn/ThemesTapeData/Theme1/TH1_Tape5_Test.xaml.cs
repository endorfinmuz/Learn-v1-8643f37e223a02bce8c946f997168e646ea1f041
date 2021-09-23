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

namespace Learn.ThemesTapeData.Theme1
{
    public partial class TH1_Tape5_Test : Page
    {
        public TH1_Tape5_Test()
        {
            InitializeComponent();
        }

        public int scores = 0;
        public int types = 1;
        public bool status = false;

        public void BT_1Answer_Click(object sender, RoutedEventArgs e)
        {
            switch(types)
            {
                case 0:
                    MessageBox.Show("Запусти тему в меню, чтобы начать заново!", "Уведомление");
                    break;

                case 1:
                    if (ANW1_True.IsChecked == true) // первый вопрос
                    {
                        scores += 1;
                        types += 1;
                        firstquestion.Visibility = Visibility.Collapsed;
                        secondquestion.Visibility = Visibility.Visible;
                    }
                    else if (ANW1_False1.IsChecked == true || ANW1_False2.IsChecked == true || ANW1_False3.IsChecked == true)
                    {
                        types += 1;
                        firstquestion.Visibility = Visibility.Collapsed;
                        secondquestion.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Выберите ответ!", "Ошибка");
                        return;
                    }
                    break;

                case 2:
                    if (ANW2_True.IsChecked == true) // второй вопрос
                    {
                        types += 1;
                        scores += 1;
                        secondquestion.Visibility = Visibility.Collapsed;
                        threequestion.Visibility = Visibility.Visible;
                    }
                    else if (ANW2_False1.IsChecked == true || ANW2_False3.IsChecked == true || ANW2_False2.IsChecked == true)
                    {
                        types += 1;
                        secondquestion.Visibility = Visibility.Collapsed;
                        threequestion.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Выберите ответ!", "Ошибка");
                        return;
                    }
                    break;

                case 3:
                    if (ANW3_True.IsChecked == true) // пятый вопрос
                    {
                        types += 1;
                        scores += 1;
                        threequestion.Visibility = Visibility.Collapsed;
                        fourquestion.Visibility = Visibility.Visible;
                        BT_1Answer.Content = "Узнать результаты";
                    }
                    else if (ANW3_False2.IsChecked == true || ANW3_False1.IsChecked == true || ANW3_False3.IsChecked == true)
                    {
                        types += 1;
                        threequestion.Visibility = Visibility.Collapsed;
                        fourquestion.Visibility = Visibility.Visible;
                        BT_1Answer.Content = "Узнать результаты";
                    }
                    else
                    {
                        MessageBox.Show("Выберите ответ!", "Ошибка");
                        return;
                    }
                    break;

                case 4:
                    fourquestion.Visibility = Visibility.Collapsed;
                    resultquestion.Visibility = Visibility.Visible;

                    if(scores == 1)
                    {
                        AgreeQuestions.Content = "Правильные ответы: 1/3";
                        ResultComment.Content = "Очень плохой результат, изучи тему заново.";
                        BT_1Answer.Content = "Начать заново";
                        types = 0;
                    }
                    else if(scores == 2)
                    {
                        AgreeQuestions.Content = "Правильные ответы: 2/3";
                        ResultComment.Content = "Ты можешь лучше! Изучи тему заново.";
                        BT_1Answer.Content = "Начать заново";
                        types = 0;
                    }
                    else if (scores == 3)
                    {
                        AgreeQuestions.Content = "Правильные ответы: 3/3";
                        ResultComment.Content = "Ты всё выполнил(-а) верно, поздравляю!\nОбнови информацию слева для доступа к курсу.";
                        GoodNotification.Visibility = Visibility.Visible;
                        BT_1Answer.Visibility = Visibility.Hidden;

                        RegistryKey open = Registry.CurrentUser.OpenSubKey("LearnData");
                        int progress = Convert.ToInt32(open.GetValue("stagesago"));
                        if(progress == 0)
                        {
                            progress = 1;
                        }
                        open.Close();

                        RegistryKey create = Registry.CurrentUser.CreateSubKey("LearnData");

                        create.SetValue("stagesago", progress);
                        create.Close();
                        status = true;
                    }
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            firstquestion.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Hidden;
            BT_1Answer.Visibility = Visibility.Visible;
        }
    }
}
