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
using APX_Steel;
using APX_Concrete;
using APX_PublishTEXtoPDF;
using static APX_InputDataValidation.InputDataValidation;
using ValuesFromSSA;
using APX_SolveManager;


//using APX_SolveManager;

namespace Lyashenko.Anna.Concrete
{
    

    public partial class ConcreteArea : UserControl, ILinkToMainProject, IValuesFromSSA
    {
        
        const string MODULE_Name = "СП63-Внецентренно-растянутый-элемент";
        public ConcreteArea()
        {
            InitializeComponent();
            Нагрузка.Items.Add("Кратковременная");
            Нагрузка.Items.Add("Длительная");
            Нагрузка.SelectedIndex = 0;
            Вид_сечения.Items.Add("Прямоугольное");
            Вид_сечения.Items.Add("Тавровый,полки сверху");
            Вид_сечения.Items.Add("Тавровый,полки снизу");
            Steel.fillComboBoxByRSteelClass(SteelClass1, RSteelClass.A240);
            APX_Concrete.Concrete.fillComboBoxByClass(ConcClass, ConcreteClass.B40);
            Способ_задания_арматуры.Items.Add("С помощью диаметра");
            Способ_задания_арматуры.Items.Add("С помощью площади");
         
            Вид.Items.Add("Проверка прочности сечения элемента");
            Вид.Items.Add("Подбор арматуры из условий прочности");
            Гамма1.Items.Add("1.0");
            Гамма1.Items.Add("0.9");
            Гамма1.Items.Add("0.85");
            //Гамма2.Items.Add("1.0");
            //Гамма2.Items.Add("0.9");
            Гамма3.Items.Add("1.0");
            Гамма3.Items.Add("0.85");
            
           
           
         

            if (SteelClass1.Text == "A240") { Диаметр.ItemsSource = APX_Steel.A240.Diams; Диаметр1.ItemsSource = APX_Steel.A240.Diams; }
            else if (SteelClass1.Text == "A400") { Диаметр.ItemsSource = APX_Steel.A400.Diams; Диаметр1.ItemsSource = APX_Steel.A400.Diams; }
            else if (SteelClass1.Text == "A500") { Диаметр.ItemsSource = APX_Steel.A500.Diams; Диаметр1.ItemsSource = APX_Steel.A500.Diams; }
            else if (SteelClass1.Text == "B500") { Диаметр.ItemsSource = APX_Steel.B500.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp500") { Диаметр.ItemsSource = APX_Steel.Bp500.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp1200") { Диаметр.ItemsSource = APX_Steel.Bp1200.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp1300") { Диаметр.ItemsSource = APX_Steel.Bp1300.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp1400") { Диаметр.ItemsSource = APX_Steel.Bp1400.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp1500") { Диаметр.ItemsSource = APX_Steel.Bp1500.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "Bp1600") { Диаметр.ItemsSource = APX_Steel.Bp1600.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "K1400") { Диаметр.ItemsSource = APX_Steel.K1400.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "K1500") { Диаметр.ItemsSource = APX_Steel.K1500.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "K1600") { Диаметр.ItemsSource = APX_Steel.K1600.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            else if (SteelClass1.Text == "K1700") { Диаметр.ItemsSource = APX_Steel.K1700.Diams; Диаметр1.ItemsSource = APX_Steel.B500.Diams; }
            solveManager solveMan = new solveManager(
        sp_solveManager,
        MODULE_Name,
        new object[] {
            Продольная_сила,
            Момент_в_сечении,
            Ширина_сечения,
            Высота_сечения,
            Защитный_слой_бетона_более_растянутой_арматуры,
            Защитный_слой_бетона_менее_растянутой_арматуры,
            Гамма1,Гамма3,Гамма4,Гамма5,
            Площадь_растянутой_арматуры,
            Площадь_менее_растянутой_арматуры,
            Диаметр,
            Диаметр1,
            //Rb,e_b2,Rs,Rsc,
            Модуль_упругости_арматуры,
            Шифр,Дата,Этаж,Конструкция,Оси,Комментарии,
            Способ_задания_арматуры,
            ConcClass,
            SteelClass1,
            Вид,Нагрузка,Вид_сечения,Ширина_полки,Высота_полки,
                    }
                                                   );

        }

        bool cvet = true;
        Brush LightGray, Silver;

        private void Color(object sender, EventArgs e)
        {
            if (cvet)
            {
                btn_Color.Background = Brushes.LightGray;

                a.Background = Brushes.White;
                b.Background = Brushes.White;
                c.Background = Brushes.White;
                d.Background = Brushes.White;
                m.Background = Brushes.White;
                f.Background = Brushes.White;
                k.Background = Brushes.White;
                i.Background = Brushes.White;
                z.Background = Brushes.White;
                w.Background = Brushes.White;

                v.Background = Brushes.White;
                o.Background = Brushes.White;
                p.Background = Brushes.White;
                q.Background = Brushes.White;
                r.Background = Brushes.White;
                s.Background = Brushes.White;
                t.Background = Brushes.White;
                u.Background = Brushes.White;

            }
            else
            {
                btn_Color.Background = Brushes.White;

                a.Background = Brushes.Gainsboro;
                b.Background = Brushes.Gainsboro;
                c.Background = Brushes.Gainsboro;
                d.Background = Brushes.Gainsboro;
                m.Background = Brushes.Gainsboro;
                f.Background = Brushes.Gainsboro;
                k.Background = Brushes.Gainsboro;
                z.Background = Brushes.Gainsboro;
                w.Background = Brushes.Gainsboro;
                i.Background = Brushes.Silver;

                v.Background = Brushes.Silver;
                o.Background = Brushes.Silver;
                p.Background = Brushes.Silver;
                q.Background = Brushes.Silver;
                r.Background = Brushes.Silver;
                s.Background = Brushes.Silver;
                t.Background = Brushes.Silver;
                u.Background = Brushes.Silver;
            }
            cvet = !cvet;
        }

        double As;
        double As1;
        double n;
        double n1;
        double ds;
        double ds1;
        private void Способ_задания_арматуры_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {

                Kol.Text = "Количество растянутых стержней";
                Kol1.Text = "Количество менее растянутых стержней";
                // n = double.Parse(Площадь_растянутой_арматуры.Text.Replace(".", "."));
                // n1 = double.Parse(Площадь_менее_растянутой_арматуры.Text.Replace(".", "."));
                Diam.Visibility = System.Windows.Visibility.Visible;
                Diam1.Visibility = System.Windows.Visibility.Visible;
                Диаметр.Visibility = System.Windows.Visibility.Visible;
                Диаметр1.Visibility = System.Windows.Visibility.Visible;
                //ds = double.Parse(Диаметр.SelectedValue.ToString());
                // ds1 = double.Parse(Диаметр1.SelectedValue.ToString());
                //As = (Math.PI * ds*ds *n)/ 400d;
                //As1 = (Math.PI * ds1 * ds1*n1) / 400d;

            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                Kol.Text = "As,см²:";
                Kol1.Text = "As',см²:";
                Diam.Visibility = System.Windows.Visibility.Hidden;
                Diam1.Visibility = System.Windows.Visibility.Hidden;
                Диаметр.Visibility = System.Windows.Visibility.Hidden;
                Диаметр1.Visibility = System.Windows.Visibility.Hidden;
                //As = double.Parse(Площадь_растянутой_арматуры.Text.Replace(".", ","));
                //As1 = double.Parse(Площадь_менее_растянутой_арматуры.Text.Replace(".", ","));
            }
           
        }

        private void Вид_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Вид.SelectedItem == "Подбор арматуры из условий прочности")
            {
                Kol.Visibility = System.Windows.Visibility.Hidden;
                Kol1.Visibility = System.Windows.Visibility.Hidden;
                Diam.Visibility = System.Windows.Visibility.Hidden;
                Diam1.Visibility = System.Windows.Visibility.Hidden;
                Площадь_растянутой_арматуры.Visibility = System.Windows.Visibility.Hidden;
                Площадь_менее_растянутой_арматуры.Visibility = System.Windows.Visibility.Hidden;
                Диаметр.Visibility = System.Windows.Visibility.Hidden;
                Диаметр1.Visibility = System.Windows.Visibility.Hidden;
                Способ_задания_арматуры.Visibility = System.Windows.Visibility.Hidden;
                Сжатая_зона.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Вид.SelectedItem == "Проверка прочности сечения элемента")
            {
                Kol.Visibility = System.Windows.Visibility.Visible;
                Kol1.Visibility = System.Windows.Visibility.Visible;
                Diam.Visibility = System.Windows.Visibility.Visible;
                Diam1.Visibility = System.Windows.Visibility.Visible;
                Площадь_растянутой_арматуры.Visibility = System.Windows.Visibility.Visible;
                Площадь_менее_растянутой_арматуры.Visibility = System.Windows.Visibility.Visible;
                Диаметр.Visibility = System.Windows.Visibility.Visible;
                Диаметр1.Visibility = System.Windows.Visibility.Visible;
                Сжатая_зона.Visibility = System.Windows.Visibility.Visible;
                Способ_задания_арматуры.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Нагрузка_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Нагрузка.SelectedItem == "Кратковременная")
            {
                
            }
            else if (Нагрузка.SelectedItem == "Длительная")
            {
            }


        }

        private void Вид_сечения_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Вид_сечения.SelectedItem == "Прямоугольное")
            {
                Ширина_полки.Visibility = System.Windows.Visibility.Hidden;
                Высота_полки.Visibility = System.Windows.Visibility.Hidden;
                Shirina.Visibility = System.Windows.Visibility.Hidden;
                Visota.Visibility = System.Windows.Visibility.Hidden;
                kart.Visibility = System.Windows.Visibility.Hidden;
                kart1.Visibility = System.Windows.Visibility.Hidden;
                kart3.Visibility = System.Windows.Visibility.Visible;

            }
            else if (Вид_сечения.SelectedItem == "Тавровый,полки сверху")
            {
                Ширина_полки.Visibility = System.Windows.Visibility.Visible;
                Высота_полки.Visibility = System.Windows.Visibility.Visible;
                Shirina.Visibility = System.Windows.Visibility.Visible;
                Visota.Visibility = System.Windows.Visibility.Visible;
                kart.Visibility = System.Windows.Visibility.Visible;
                kart1.Visibility = System.Windows.Visibility.Hidden;
                kart3.Visibility = System.Windows.Visibility.Hidden;

            }
            else if(Вид_сечения.SelectedItem == "Тавровый,полки снизу")
            {
                Ширина_полки.Visibility = System.Windows.Visibility.Visible;
                Высота_полки.Visibility = System.Windows.Visibility.Visible;
                Shirina.Visibility = System.Windows.Visibility.Visible;
                Visota.Visibility = System.Windows.Visibility.Visible;
                kart.Visibility = System.Windows.Visibility.Hidden;
                kart1.Visibility = System.Windows.Visibility.Visible;
                kart3.Visibility = System.Windows.Visibility.Hidden;
            }


        }

        public string GetCalculateName()
        {
            return "Расчет внецентренно растянутых элементов";
        }

        public object GetClass()
        {
            return this;
        }

        public void GetValues(Dictionary<string, double> Values)
        {
            throw new NotImplementedException();
        }

        

        private void textBoxTextChaned(object sender, TextChangedEventArgs e) //Проверка все ли ячейки введены верно
        {
            DoubleOnly(e);
            Момент_в_сечении.Background = Brushes.White;//ставим фон textBox1 белым
            if (!double.TryParse(Момент_в_сечении.Text, out double temp)//если НЕ удалось перевести свойство .Text в тип double (здесь double temp - вре'меннная локальная переменная, нужна, чтобы проверить второе условие)
                || !(temp >= 0))//или если НЕ (temp > 0) //второе условие
            {
                Момент_в_сечении.Background = Brushes.Coral;//ставим фон textBox1 красным
                return;//прерываем дальнеушую обработку (если ее в этом методе нет, как сейчас, то можно не писать)
            }

            Продольная_сила.Background = Brushes.White;//ставим фон textBox1 белым
            if (!double.TryParse(Продольная_сила.Text, out double temp1)//если НЕ удалось перевести свойство .Text в тип double (здесь double temp - вре'меннная локальная переменная, нужна, чтобы проверить второе условие)
                || !(temp1 >= 0))//или если НЕ (temp > 0) //второе условие
            {
                Продольная_сила.Background = Brushes.Coral;//ставим фон textBox1 красным
                return;//прерываем дальнеушую обработку (если ее в этом методе нет, как сейчас, то можно не писать)
            }
        }


        private void Otchet2_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            //MessageBox.Show(PDF.Content.ToString() + "не отмечен");
            
                PDF.Visibility = System.Windows.Visibility.Hidden;
                Otchet1.Visibility = System.Windows.Visibility.Hidden;
            

        }

        private void Otchet2_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            
                PDF.Visibility = System.Windows.Visibility.Visible;
                Otchet1.Visibility = System.Windows.Visibility.Visible;

            PDF.IsChecked = true;

        }



        private void PDF_Checked(object sender, RoutedEventArgs e)
        {
            Otchet1.IsChecked = false;
        }

        private void Otchet1_Checked(object sender, RoutedEventArgs e)
        {
            PDF.IsChecked = false;
        }



        private void Сжатая_зона_Checked(object sender, RoutedEventArgs e)////БЕЗ УЧЕТА СЖАТОЙ ЗОНЫ(ДОПУЩЕНИЕ)
        {
            
            CheckBox chBox = (CheckBox)sender;
            
        }
        private void Сжатая_зона_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chBox = (CheckBox)sender;
            
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            //Гамма1.Text = Гамма1.Text.Replace(".", ".");
            //Площадь_растянутой_арматуры.Text = Площадь_растянутой_арматуры.Text.Replace(".", ".");
            //Площадь_менее_растянутой_арматуры.Text = Площадь_менее_растянутой_арматуры.Text.Replace(".", ".");
            //System.Globalization.CultureInfo.CurrentCulture = System.Globalization.GetCultureInfo("en-US");
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            Результаты.Document.Blocks.Clear();
            double γb1=1;
            //double γb2=1;
            double γb3=1;
            //double γb4=1;
            //double γb5=1;
            if (Гамма1.Text == "1.0") { γb1=1; }
            else if (Гамма1.Text == "0.9") { γb1 = 0.9; }
            else if (Гамма1.Text == "0.85") { γb1 = 0.85; }

            //if (Гамма2.Text == "1.0") { γb2 = 1; }
            //else if (Гамма2.Text == "0.9") { γb2 = 0.9; }

            if (Гамма3.Text == "1.0") { γb3 = 1; }
            else if (Гамма3.Text == "0.85") { γb3 = 0.85; }
            
            double γb4 = double.Parse(Гамма4.Text);
            double γb5 = double.Parse(Гамма5.Text);
            string shifr = Шифр.Text;
            string data = Дата.Text;
            string etach = Этаж.Text;
            string constr = Конструкция.Text;
            string osi = Оси.Text;
            string comment = Комментарии.Text;
            
            double M = double.Parse(Момент_в_сечении.Text);
            double N = double.Parse(Продольная_сила.Text);
            if (M > 0)
            { }
            else
            {
                MessageBox.Show("Значение M и N должно быть > 0");
            }
            if (N > 0)
            { }
            else
            {
                MessageBox.Show("Значение M и N должно быть > 0");
            }
            Момент_в_сечении.Background = Brushes.White;//ставим фон textBox1 белым
            if (!double.TryParse(Момент_в_сечении.Text, out double temp)//если НЕ удалось перевести свойство .Text в тип double (здесь double temp - вре'меннная локальная переменная, нужна, чтобы проверить второе условие)
                || !(temp >= 0))//или если НЕ (temp > 0) //второе условие
            {
                Момент_в_сечении.Background = Brushes.Coral;//ставим фон textBox1 красным
                return;//прерываем дальнеушую обработку (если ее в этом методе нет, как сейчас, то можно не писать)
            }

            Продольная_сила.Background = Brushes.White;//ставим фон textBox1 белым
            if (!double.TryParse(Момент_в_сечении.Text, out double temp1)//если НЕ удалось перевести свойство .Text в тип double (здесь double temp - вре'меннная локальная переменная, нужна, чтобы проверить второе условие)
                || !(temp1 >= 0))//или если НЕ (temp > 0) //второе условие
            {
                Продольная_сила.Background = Brushes.Coral;//ставим фон textBox1 красным
                return;//прерываем дальнеушую обработку (если ее в этом методе нет, как сейчас, то можно не писать)
            }

            double b = double.Parse(Ширина_сечения.Text);
            double h = double.Parse(Высота_сечения.Text);
            double a1 = double.Parse(Защитный_слой_бетона_менее_растянутой_арматуры.Text);
            double a = double.Parse(Защитный_слой_бетона_более_растянутой_арматуры.Text);
            double bf=1;
            double hf = 1;
            //Ввод в текстбоксы
            double Rb = 1000 * APX_Concrete.Concrete.getStressByClass(ConcClass.SelectedIndex, ConcreteStressType.Rb);
            double e_b2 = APX_Concrete.Concrete.getEpsilon_b2_ShortLoads(ConcClass.SelectedValue); //Присваиваем значения из библиотеки
            double Rs = 1000 * Steel.getStressByClass(SteelClass1.SelectedIndex, RSteelStressType.Rs);
            double Rsc = 1000 * Steel.getStressByClass(SteelClass1.SelectedIndex, RSteelStressType.Rsc);
            double Es = double.Parse(Модуль_упругости_арматуры.Text);

            if (Нагрузка.SelectedItem == "Кратковременная")
            {
                if (SteelClass1.Text == "A500") { Rsc = 400000; }
                if (SteelClass1.Text == "A600") { Rsc = 400000; }
                if (SteelClass1.Text == "A800") { Rsc = 400000; }
                if (SteelClass1.Text == "A1000") { Rs = 400000; }
                if (SteelClass1.Text == "B500") { Rsc= 380000; }
                if (SteelClass1.Text == "Bp500") { Rsc = 360000; }
                if (SteelClass1.Text == "Bp1200") { Rsc = 400000; }
                if (SteelClass1.Text == "Bp1300") { Rsc = 400000; }
                if (SteelClass1.Text == "Bp1400") { Rsc = 400000; }
                if (SteelClass1.Text == "Bp1500") { Rsc = 400000; }
                if (SteelClass1.Text == "Bp1600") { Rsc = 400000; }
                if (SteelClass1.Text == "K1400") { Rsc = 400000; }
                if (SteelClass1.Text == "K1500") { Rsc = 400000; }
                if (SteelClass1.Text == "K1600") { Rsc = 400000; }
                if (SteelClass1.Text == "K1700") { Rsc = 400000; }
            }
            else if (Нагрузка.SelectedItem == "Длительная")
            {
                Rsc = 1000 * Steel.getStressByClass(SteelClass1.SelectedIndex, RSteelStressType.Rsc);
            }

            if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {


                n = double.Parse(Площадь_растянутой_арматуры.Text);
                n1 = double.Parse(Площадь_менее_растянутой_арматуры.Text);

                ds = double.Parse(Диаметр.SelectedValue.ToString());
                ds1 = double.Parse(Диаметр1.SelectedValue.ToString());
                As = (Math.PI * ds * ds * n) / 400d;
                As1 = (Math.PI * ds1 * ds1 * n1) / 400d;

            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                //ds = double.Parse(Диаметр.SelectedValue.ToString());
                //ds1 = double.Parse(Диаметр1.SelectedValue.ToString());
                As = double.Parse(Площадь_растянутой_арматуры.Text);
                As1 = double.Parse(Площадь_менее_растянутой_арматуры.Text);
            }
            double e0 = (M * 100 / N);
            double h0 = h - a;
            double e1=1;
            double yc=1;
            if (Вид_сечения.SelectedItem == "Прямоугольное")
            {
                e1 = e0+(h/2) - a1 ;
                
            }
            else if (Вид_сечения.SelectedItem == "Тавровый,полки сверху")
            {
                // расстояние от центра тяжести до центра сечения
               
                
                bf = double.Parse(Ширина_полки.Text);
                hf= double.Parse(Высота_полки.Text);
                yc = (bf * hf * ((h / 2) - (hf / 2)) + b * (h - hf) * ((h / 2) - (h - hf) / 2)) / (bf * hf + b * (h - hf));
            }
            else if (Вид_сечения.SelectedItem == "Тавровый,полки снизу")
            {
                
                bf = double.Parse(Ширина_полки.Text);
                hf = double.Parse(Высота_полки.Text);
                yc = (bf * hf * ((h / 2) - (hf / 2)) + b * (h - hf) * ((h / 2) - (h - hf) / 2)) / (bf * hf + b * (h - hf));
            }

            
            
            
            double esl = Rs/ (Es*1000);
            double ξR = 0.8 / (1 + (esl / e_b2));
            if (ConcClass.SelectedValue == "B70" || ConcClass.SelectedValue == "B80" || ConcClass.SelectedValue == "B90" || ConcClass.SelectedValue == "B100")
            {
              ξR = 0.7 / (1 + (esl / e_b2));
            }
            else
            {
                ξR = 0.8 / (1 + (esl / e_b2));
            }
            //double k = h / b;

            string An,arm,arm1,arm2,arm5,tavr,tavr1, resultat, name,raschet, lya, sila, sila1,sila2,sila3, mom1, vipol1, nevipol1, vipol2, nevipol2, vipol4, nevipol4, vipol3, nevipol3, rezultvipol, rezultnevipol, alfa2;
            lya = "D:\\ANNA"; //Вводим начальный текст одинаковый для всех ifelse
            name = "Otchet";
            string PROEKT = (shifr == "") ? ("") : (@"Проект: " + shifr);
            string DATA = (data == "") ? ("") : (@" Дата: " + data);
            string ETACH = (etach == "") ? ("") : (@" Этаж: " + etach);
            string CONSTR = (constr == "") ? ("") : (@" Конструкция: " + constr);
            string OSI = (osi == "") ? ("") : (@" Оси: " + osi);
            string COMMENT = (comment == "") ? ("") : ("\n Комментарий: " + comment + "\n$\\ $\n");

            Rb = Rb * γb1 * γb3 * γb4 * γb5;
            //if (comment != "") 
            //                vvedenie = ("Проект: " + shifr + "; Дата: " + data + "; Этаж № " + etach + "; Конструкция " + constr + "; Оси: " + osi +"; \n"+ "\n Комментарий: " + comment + "\n"+ "\n$\\,$\n");
            //}
            //            else
            //            {
            //                vvedenie =("Проект: " + shifr + "; Дата: " + data + "; Этаж № " + etach + "; Конструкция " + constr + "; Оси: " + osi + "\n" + "\n$\\,$\n");
            //            }
            double sv = (bf - b) / 20;

            tavr1 = "\n\\text{ }\n" +
                    "\n\\textbf{Расчет железобетонных внецентренно растянутых элементов (СП 63.13330.2012).}\n" + "\n$\\ $\n" +
                $"\n\\begin{{center}}\\begin{{tikzpicture}}\\draw[red,thick](0,0)--({(bf / 10).ToString("0.#")},0)--({(bf / 10).ToString("0.#")},{((hf) / 10).ToString("0.#")})--({((bf - (bf - b) / 2) / 10).ToString("0.#")},{((hf) / 10).ToString("0.#")})--({((bf - (bf - b) / 2) / 10).ToString("0.#")},{(h / 10).ToString("0.#")})--({(((bf - b) / 2) / 10).ToString("0.#")},{(h / 10).ToString("0.#")})--({(((bf - b) / 2) / 10).ToString("0.#")},{((hf) / 10).ToString("0.#")})--(0,{((hf) / 10).ToString("0.#")})--cycle;";
           

            if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {
                double step_nizh = (bf - a * 2) / (n - 1);
                for (int i = 0; i < n; i++)
                {
                    tavr1 = tavr1 + "\\put(" + ( a + i * step_nizh) + "," + a + "){\\circle*{1}};";
                }
                double step_verh = (b - a1 * 2) / (n1 - 1);
                if (As1 != 0)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        tavr1 = tavr1 + "\\put(" + (sv * 10+a1 + i * step_verh) + "," + (h - a1) + "){\\circle*{1}};";
                    }
                    tavr1 = tavr1 + $"\\node[rotate=90] at ({((bf / 10) + 0.6).ToString("0.#")},{(h / 10 - (a1 / 20)).ToString("0.#") }) {{${(a1).ToString("0.#") }$}};" +
                    $"\\draw({((bf / 10) - sv + 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({((bf / 10) + 1).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                   $"\\draw({((bf / 10) - sv + 0.1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({((bf / 10) + 1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});" +
                   $"\\draw({((bf / 10) + 0.9).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({((bf / 10) + 0.9).ToString("0.#")},{(((h - a1) / 10) - 0.1).ToString("0.#")});";
                }
            }
            else
            {
                tavr1 = tavr1 + $"\\draw[blue](0.1,{(a / 10).ToString("0.#")})--({((bf / 10) - 0.1).ToString("0.#")},{(a / 10).ToString("0.#")});";

                if (As1 != 0)
                {
                    tavr1 = tavr1 + $"\\node[rotate=90] at ({((bf / 10) + 0.6).ToString("0.#")},{(h / 10 - (a1 / 20)).ToString("0.#") }) {{${(a1).ToString("0.#") }$}};" +
                    $"\\draw({((bf / 10) - sv + 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({((bf / 10) + 1).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                   $"\\draw({((bf / 10) - sv + 0.1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({((bf / 10) + 1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});" +
                   $"\\draw({((bf / 10) + 0.9).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({((bf / 10) + 0.9).ToString("0.#")},{(((h - a1) / 10) - 0.1).ToString("0.#")});"+
                $"\\draw[blue]({((((bf - b) / 2) + 1) / 10).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({((bf / 10) - sv - 0.1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});";
                }
               
            }
            tavr1 = tavr1+$"\\node[rotate=90] at ({((bf / 10) + 0.6).ToString("0.#")},{(a / 20).ToString("0.#") }) {{${(a).ToString("0.#") }$}};" +
                    $"\\draw({((bf / 10) + 0.1).ToString("0.#")},0)--({((bf / 10) + 1).ToString("0.#")},0);" +
                   $"\\draw({((bf / 10) + 0.1).ToString("0.#")},{(a / 10).ToString("0.#")})--({((bf / 10) + 1).ToString("0.#")},{(a / 10).ToString("0.#")});" +
                   $"\\draw({((bf / 10) + 0.9).ToString("0.#")},{(-0.1).ToString("0.#")})--({((bf / 10) + 0.9).ToString("0.#")},{((a / 10) + 0.1).ToString("0.#")});"+
            //добавим стрелочки осей и моменты
            $"\\draw[ ->]({(bf / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({(bf / 20).ToString("0.#") },{((h / 20) + 0.6).ToString("0.#") });" +
             $"\\draw[ ->]({(bf / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 20) + 0.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
             
            $"\\node at (({((bf / 20) - 0.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{c}};" +
            $"\\node at ({((bf / 20) + 0.8).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{y}};" +
            $"\\node at ({((bf / 20)).ToString("0.#") },{((h / 20) + 0.8).ToString("0.#") }) {{z}};" +

            //моменты
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.1).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.1).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\node at ({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) - 0.4).ToString("0.#") }) {{My(+)}};"+

            //Размеры h
                $"\\draw({(sv - 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({(-1.3).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                $"\\draw(-0.1,0)--({(- 1.3).ToString("0.#")},0);" +
                $"\\draw({(-1.2).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({(- 1.2).ToString("0.#")},-0.1);" +

                $"\\draw({(- 0.7).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({(- 0.7).ToString("0.#")},-0.1);" +
                $"\\draw({- 0.1},{(hf / 10).ToString("0.#")})--({(- 0.8).ToString("0.#")},{(hf / 10).ToString("0.#")});" +

                $"\\node[rotate=90] at ({(- 1.4).ToString("0.#")},{(h / 20).ToString("0.#") }) {{${(h).ToString("0.#") }$}};" +
                 $"\\node[rotate=90] at ({(-0.9).ToString("0.#")},{(hf / 20).ToString("0.#") }) {{${(hf).ToString("0.#") }$}};" +
                 $"\\node[rotate=90] at ({(-0.9).ToString("0.#")},{((hf / 10) + (h - hf) / 20).ToString("0.#") }) {{${(h - hf).ToString("0.#") }$}};" +

                 //Нижние размеры 
                 $"\\draw(0,- 0.1)--(0,-1.5);" +
                 $"\\draw({((bf / 10)).ToString("0.#")},- 0.1)--({((bf / 10)).ToString("0.#")},-1.5);" +
                 $"\\draw({(sv).ToString("0.#")},-0.1)--({(sv).ToString("0.#")},-0.9);" +
                 $"\\draw({(sv+(b/10)).ToString("0.#")},-0.1)--({(sv+(b / 10)).ToString("0.#")},-0.9);" +
                 $"\\draw(-0.1,-0.8)--({((bf / 10)+0.1).ToString("0.#")},-0.8);" +
                 $"\\draw(-0.1,-1.4)--({((bf / 10) + 0.1).ToString("0.#")},-1.4);" +

                 $"\\node at (({(bf / 20).ToString("0.#") },-0.6) {{${b.ToString("0.#") }$}};" +
                 $"\\node at (({(sv / 2).ToString("0.#") },-0.6) {{${(sv * 10).ToString("0.#") }$}};" +
                 $"\\node at (({((bf / 10)-(sv / 2) ).ToString("0.#") },-0.6) {{${(sv * 10).ToString("0.#") }$}};" +
                 $"\\node at (({(bf / 20).ToString("0.#") },-1.2) {{${bf.ToString("0.#") }$}};" +

            $"\\end{{tikzpicture}}\\end{{center}}\n" +
            "\n\\textbf{Исходные данные}\n"+
             $"\n$ \\text{{Сечение: Тавровое. Ширина }} b={b} см; \\text{{Высота }} h={h} см; \\text{{Ширина полки }} b'_f ={bf} см; \\text{{Высота полки }} h'_f ={hf} см; $\n" +
                "\n Арматура: " + (SteelClass1.SelectedValue) ;

            if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                tavr1 = tavr1 + $"$;  A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={((As + As1) * 100 / (b * h0)).ToString("0.##")} \\% $" +
             $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}};\\textbf{{}} $";
            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {

                tavr1 = tavr1 + $"$; A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={(((As + As1) * 100) / (b * h0)).ToString("0.##")} \\% $" +
                    $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}} $" +
                $"$; d_s={ds / 10} \\text{{ см}}$" +
                 $"$; d_s'={ds1 / 10} \\text{{ см}}$" +
                 $"$; n={n}; n'={n1} ; $\n";
            }
            tavr1 = tavr1 +
            $"$ R_s={Rs / 1000} \\text{{ МПа}}$" +
            $"$; R_{{sc}}={Rsc / 1000}\\text{{ МПа}}$" +
            $"$;  E_s={Es}\\text{{ МПа; }}$\n" +
            $"$ \\varepsilon_{{s,el}}={esl.ToString("0.###")}; $\n" +


            "\n Бетон: " + (ConcClass.SelectedValue) +
            $"$; R_b={(Rb / (γb1 * γb3 * γb4 * γb5 * 1000)).ToString("0.#")} \\text{{ МПа}}; $\n" +
            $"$ R_b\\cdot\\gamma_b={((Rb) / 1000).ToString("0.##")}\\text{{ МПа}}; $\n" +
           $"$ \\gamma_{{b1}}={γb1.ToString("0.##")}; $\n" +

            $"$ \\gamma_{{b3}}={γb3.ToString("0.##")}; $\n" +
            $"$ \\gamma_{{b4}}={γb4.ToString("0.##")}; $\n" +
            $"$ \\gamma_{{b5}}={γb5.ToString("0.##")}; $\n" +

             $"$ \\varepsilon_{{b}}={e_b2.ToString("0.###")}; $\n" +
            "\n Усилия: " + $"$ M ={M}\\text{{ кНм}}$" + $"$; N={N}\\text{{ кН}}; $\n" + "\n$\\ $\n";



            tavr = "\n\\text{ }\n" +
                    "\n\\textbf{Расчет железобетонных внецентренно растянутых элементов (СП 63.13330.2012).}\n" + "\n$\\ $\n" +
                $"\n\\begin{{center}}\\begin{{tikzpicture}}\\draw[red,thick](0,0)--({(b / 10).ToString("0.#")},0)--({(b / 10).ToString("0.#")},{((h - hf) / 10).ToString("0.#")})--({((bf - (bf - b) / 2) / 10).ToString("0.#")},{((h - hf) / 10).ToString("0.#")})--({((b + (bf - b) / 2) / 10).ToString("0.#")},{(h / 10).ToString("0.#")})--({((-(bf - b) / 2) / 10).ToString("0.#")},{(h / 10).ToString("0.#")})--({(-((bf - b) / 2) / 10).ToString("0.#")},{((h - hf) / 10).ToString("0.#")})--(0,{((h - hf) / 10).ToString("0.#")})--cycle;";
            
            if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {
                double step_nizh = (b - a * 2) / (n - 1);
                for (int i = 0; i < n; i++)
                {
                    tavr = tavr + "\\put(" + (a + i * step_nizh) + "," + a + "){\\circle*{1}};";
                }
                double step_verh = (bf - a1 * 2) / (n1 - 1);
                if (As1 != 0)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        tavr = tavr + "\\put(" + (-sv*10+a1 + i * step_verh) + "," + (h - a1) + "){\\circle*{1}};";
                    }
                    tavr=tavr+ $"\\node[rotate=90] at ({((b / 10) + sv + 0.6).ToString("0.#")},{(h / 10 - (a1 / 20)).ToString("0.#") }) {{${(a1).ToString("0.#") }$}};" +
                    $"\\draw({((b / 10) + sv + 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({((b / 10) + sv + 1).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                   $"\\draw({((b / 10) + sv + 0.1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({((b / 10) + sv + 1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});" +
                   $"\\draw({((b / 10) + sv + 0.9).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({((b / 10) + sv + 0.9).ToString("0.#")},{(((h - a1) / 10) - 0.1).ToString("0.#")});";
                }
            }
            else
            {
                tavr = tavr + $"\\draw[blue](0.1,{(a / 10).ToString("0.#")})--({((b / 10) - 0.1).ToString("0.#")},{(a / 10).ToString("0.#")});";
                if (As1!=0)
                { tavr=tavr+$"\\node[rotate=90] at ({((b / 10) + sv + 0.6).ToString("0.#")},{(h / 10 - (a1 / 20)).ToString("0.#") }) {{${(a1).ToString("0.#") }$}};" +
                        $"\\draw({((b / 10) + sv + 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({((b / 10) + sv + 1).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                   $"\\draw({((b / 10) + sv + 0.1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({((b / 10) + sv + 1).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});" +
                   $"\\draw({((b / 10) + sv + 0.9).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({((b / 10) + sv + 0.9).ToString("0.#")},{(((h - a1) / 10) - 0.1).ToString("0.#")});"+
                    $"\\draw[blue]({((-((bf - b) / 2) + 1) / 10).ToString("0.#")},{((h - a1) / 10).ToString("0.#")})--({(((b + (bf - b) / 2) - 1) / 10).ToString("0.#")},{((h - a1) / 10).ToString("0.#")});";
                }
            }
            //Размеры h
            tavr = tavr + $"\\draw({(-sv - 0.1).ToString("0.#")},{((h) / 10).ToString("0.#")})--({(-sv - 1.5).ToString("0.#")},{((h) / 10).ToString("0.#")});" +
                $"\\draw(-0.1,0)--({(-sv - 1.5).ToString("0.#")},0);" +
                $"\\draw({(-sv - 1.4).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({(-sv - 1.4).ToString("0.#")},-0.1);" +

                $"\\draw({(-sv - 0.7).ToString("0.#")},{((h / 10) + 0.1).ToString("0.#")})--({(-sv - 0.7).ToString("0.#")},-0.1);" +
                $"\\draw({-sv - 0.1},{((h / 10) - (hf / 10)).ToString("0.#")})--({(-sv - 0.9).ToString("0.#")},{((h / 10) - (hf / 10)).ToString("0.#")});"+

            //добавим стрелочки осей и моменты
            $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({(b / 20).ToString("0.#") },{((h / 20) + 0.6).ToString("0.#") });" +
             $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 20) + 0.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\node at (({((b / 20) - 0.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{c}};" +
            $"\\node at ({((b / 20) + 0.8).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{y}};" +
            $"\\node at ({((b / 20)).ToString("0.#") },{((h / 20) + 0.8).ToString("0.#") }) {{z}};" +

            //моменты
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf/ 10) + 1.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.1).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.1).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((bf / 10) + 1.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\node at ({((bf / 10) + 1.2).ToString("0.#") },{((h / 20) - 0.4).ToString("0.#") }) {{My(+)}};";
            
            tavr=tavr+$"\\draw({(b / 10)+ 0.1},{((a/10)).ToString("0.#")})--({((b / 10) + sv + 1).ToString("0.#")},{((a/10)).ToString("0.#")});" +
                $"\\draw({((b / 10) + sv + 0.9).ToString("0.#")},-0.1)--({((b / 10) + sv + 0.9).ToString("0.#")},{((a/10)+0.1).ToString("0.#")});" +
               
                 $"\\draw({((b / 10) + 0.1).ToString("0.#")},0)--({((b / 10) + sv + 1).ToString("0.#")},0);" +

                 $"\\draw({(-sv).ToString("0.#")},{(((h-hf) / 10) - 0.1).ToString("0.#")})--({(-sv).ToString("0.#")},-0.8);" +
                 $"\\draw({(sv+(b/10)).ToString("0.#")},{(((h - hf ) / 10) - 0.1).ToString("0.#")})--({(sv+b/10).ToString("0.#")},-0.8);" +
                 $"\\draw({(-sv-0.1).ToString("0.#")},-0.7)--({(sv+(b/10)+0.1).ToString("0.#")},-0.7);" +

                 //Нижние размеры 
                 $"\\draw(0,- 0.1)--(0,-0.8);" +
                 $"\\draw({((b / 10) ).ToString("0.#")},- 0.1)--({((b / 10)).ToString("0.#")},-0.8);" +
                 $"\\draw({(-sv).ToString("0.#")},{(((h - hf ) / 10) - 0.1).ToString("0.#")})--({(-sv).ToString("0.#")},-1.6);" +
                 $"\\draw({(sv + b / 10).ToString("0.#")},{(((h - hf) / 10) - 0.1).ToString("0.#")})--({(sv + b / 10).ToString("0.#")},-1.6);" +
                 $"\\draw({(-sv - 0.1).ToString("0.#")},-1.5)--({(sv + (b / 10) + 0.1).ToString("0.#")},-1.5);" +
                 
                 
                 $"\\node[rotate=90] at ({(-sv - 1.7).ToString("0.#")},{(h / 20).ToString("0.#") }) {{${(h).ToString("0.#") }$}};" +
                 $"\\node[rotate=90] at ({(-sv - 0.9).ToString("0.#")},{((h/10)-(hf / 20)).ToString("0.#") }) {{${(hf).ToString("0.#") }$}};" +
                 $"\\node[rotate=90] at ({(-sv - 0.9).ToString("0.#")},{((h-hf)/ 20).ToString("0.#") }) {{${(h-hf).ToString("0.#") }$}};" +
                 
                 $"\\node[rotate=90] at ({((b / 10)+sv + 0.6).ToString("0.#")},{(a / 20).ToString("0.#") }) {{${(a).ToString("0.#") }$}};" +

                 $"\\node at (({(b / 20).ToString("0.#") },-0.5) {{${b.ToString("0.#") }$}};" +
                 $"\\node at (({(-sv/2).ToString("0.#") },-0.5) {{${(sv*10).ToString("0.#") }$}};" +
                 $"\\node at (({((sv/2)+(b/10)).ToString("0.#") },-0.5) {{${(sv * 10).ToString("0.#") }$}};" +
                 $"\\node at (({(b / 20).ToString("0.#") },-1.3) {{${bf.ToString("0.#") }$}};" +

            $"\\end{{tikzpicture}}\\end{{center}}\n" +
            "\n\\textbf{Исходные данные}\n" +
                 $"\n$ \\text{{Сечение: Тавровое. Ширина }} b={b} см; \\text{{Высота }} h={h} см; \\text{{Ширина полки }} b'_f ={bf} см; \\text{{Высота полки }} h'_f ={hf} см; $\n" +
                "\n Арматура: " + (SteelClass1.SelectedValue);

            if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                tavr = tavr + $"$ ; A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={((As + As1) * 100 / (b * h0)).ToString("0.##")} \\% $" +
             $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}};\\textbf{{}} $";
            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {

                tavr = tavr + $"$; A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={(((As + As1) * 100) / (b * h0)).ToString("0.##")} \\% $" +
                    $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}} $" +
                $"$; d_s={ds / 10} \\text{{ см}}$" +
                 $"$; d_s'={ds1 / 10} \\text{{ см}}$" +
                 $"$; n={n}; n'={n1} ; $\n";
            }
            tavr = tavr +
            $"$ R_s={Rs / 1000} \\text{{ МПа}}$" +
            $"$; R_{{sc}}={Rsc / 1000}\\text{{ МПа}}$" +
            $"$;  E_s={Es}\\text{{ МПа; }}$\n" +
            $"$ \\varepsilon_{{s,el}}={esl.ToString("0.###")}; $\n" +


            "\n Бетон: " + (ConcClass.SelectedValue) +
            $"$; R_b={(Rb / (γb1 * γb3 * γb4 * γb5 * 1000)).ToString("0.#")} \\text{{ МПа}}; $\n" +
            $"$ R_b\\cdot\\gamma_b={((Rb) / 1000).ToString("0.##")}\\text{{ МПа}}; $\n" +
           $"$ \\gamma_{{b1}}={γb1.ToString("0.##")}; $\n" +
            
            $"$ \\gamma_{{b3}}={γb3.ToString("0.##")}; $\n" +
            $"$ \\gamma_{{b4}}={γb4.ToString("0.##")}; $\n" +
            $"$ \\gamma_{{b5}}={γb5.ToString("0.##")}; $\n" +
            
             $"$ \\varepsilon_{{b}}={e_b2.ToString("0.###")}; $\n" +
            "\n Усилия: " + $"$ M ={M}\\text{{ кНм}}$" + $"$; N={N}\\text{{ кН}}; $\n" + "\n$\\ $\n";

            arm = //Для подбора араматуры (можно было не делать отдельно)
                    "\n\\text{ }\n" +
            "\n\\textbf{Расчет железобетонных внецентренно растянутых элементов (СП 63.13330.2012).}\n" + "\n$\\ $\n" +
            //"\nСечение прямоугольное. Эксцентриситет в одной плоскости.Арматура расположена у противоположных граней сечения. $\n" +

            $"\n\\begin{{center}}\\begin{{tikzpicture}}\\draw[red,thick](0,0)--({(b / 10).ToString("0.#") },0)--({(b / 10).ToString("0.#") },{(h / 10).ToString("0.#") })--(0,{(h / 10).ToString("0.#") })--cycle;" +
            $"\\draw[blue](0.1,{(a / 10).ToString("0.#") })--({((b / 10) - 0.1).ToString("0.#") },{(a / 10).ToString("0.#") });" +
            //$"\\draw[blue](0.5,{(a / 10).ToString("0.#") }) circle(0.08);" +

            $"\\draw(-0.5,-0.1)--(-0.5,{((h / 10) + 0.1).ToString("0.#") });" +
            $"\\draw(-0.1,0)--(-0.6,0);" +
            $"\\draw(-0.1,{(h / 10).ToString("0.#") })--(-0.6,{(h / 10).ToString("0.#") });" +
            $"\\draw({((b / 10) + 0.1).ToString("0.#") },0)--({((b / 10) + 0.6).ToString("0.#") },0);" +

            $"\\draw({((b / 10) + 0.1).ToString("0.#") },{(a / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{(a / 10).ToString("0.#") });" +

            $"\\draw({((b / 10) + 0.5).ToString("0.#") },-0.1)--({((b / 10) + 0.5).ToString("0.#") },{((a / 10) + 0.1).ToString("0.#") });" +
            $"\\draw(-0.1,-0.5)--({((b / 10) + 0.1).ToString("0.#") },-0.5);" +
            $"\\draw(0,-0.1)--(0,-0.6);" +
            $"\\draw({(b / 10).ToString("0.#") },-0.1)--({(b / 10).ToString("0.#") },-0.6);" +
            $"\\node[rotate=90] at (-0.7,{(h / 20).ToString("0.#") }) {{${(h).ToString("0.#") }$}};"+

            //добавим стрелочки осей и моменты
            $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({(b / 20).ToString("0.#") },{((h / 20) + 0.6).ToString("0.#") });" +
             $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 20) + 0.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\node at (({((b / 20) - 0.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{c}};" +
            $"\\node at ({((b / 20) + 0.8).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{y}};" +
            $"\\node at ({((b / 20)).ToString("0.#") },{((h / 20) + 0.8).ToString("0.#") }) {{z}};" +

            //моменты
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.1).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.1).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.2).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });" +
            $"\\node at ({((b / 10) + 2.2).ToString("0.#") },{((h / 20) - 0.4).ToString("0.#") }) {{My(+)}};"+
            
            $"\\draw({((b / 10) + 0.5).ToString("0.#") },{((h / 10) + 0.1).ToString("0.#") })--({((b / 10) + 0.5).ToString("0.#") },{(((h - a1) / 10) - 0.1).ToString("0.#") });" +
                $"\\draw({((b / 10) + 0.1).ToString("0.#") },{(h / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{(h / 10).ToString("0.#") });" +
                $"\\draw({((b / 10) + 0.1).ToString("0.#") },{((h - a1) / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{((h - a1) / 10).ToString("0.#") });" +
                $"\\node[rotate=90] at ({((b / 10) + 0.3).ToString("0.#") },{((h / 10) - (a1 / 20)).ToString("0.#") }) {{${a1.ToString("0.#") }$}};" +
                $"\\draw[blue](0.1,{((h - a1) / 10).ToString("0.#") })--({((b / 10) - 0.1).ToString("0.#") },{((h - a1) / 10).ToString("0.#") });"+
             $"\\node[rotate=90] at ({((b / 10) + 0.3).ToString("0.#") },{(a / 20).ToString("0.#") }) {{${a.ToString("0.#") }$}};" +
            $"\\node at (({(b / 20).ToString("0.#") },-0.3) {{${b.ToString("0.#") }$}};" +
           $"\\end{{tikzpicture}}\\end{{center}}\n" +

               "\n\\textbf{Исходные данные}\n" +
                "\n Сечение: Прямоугольное. Ширина b=" + b + " см; " + "Высота h=" + h + " см \n" +
                "\n Арматура: " + (SteelClass1.SelectedValue) +

                $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}}; $" +"\\textbf{ }"+
            
                $"$; R_s={Rs / 1000} \\text{{ МПа}} $" +
                $"$; R_{{sc}}={Rsc / 1000}\\text{{ МПа}} $" +
                $"$; E_s={Es}\\text{{ МПа; }} $\n" +
                $"$ \\varepsilon_{{s,el}}={esl.ToString("0.###")}; $\n" +

                "\n Бетон: " + (ConcClass.SelectedValue) +
                 $"$; R_b={(Rb / (γb1 * γb3 * γb4 * γb5 * 1000)).ToString("0.#")} \\text{{ МПа}}; $\n" +
                $"$ R_b\\cdot\\gamma_b={((Rb) / 1000).ToString("0.#")}\\text{{ МПа}}; $\n" +
                $"$ \\gamma_{{b1}}={γb1.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b3}}={γb3.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b4}}={γb4.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b5}}={γb5.ToString("0.##")}; $\n" +
                 
                $"$ \\varepsilon_{{b}}={e_b2.ToString("0.###")}; $\n" +
                   "\n Усилия: " + $"$M ={M}\\text{{ кНм}} $" + $"$; N={N}\\text{{ кН}}; $\n" + "\n$\\ $\n" ;

            An =
            "\n\\text{ }\n" +
            "\n\\textbf{Расчет железобетонных внецентренно растянутых элементов (СП 63.13330.2012).}\n" + "\n$\\ $\n" +
            //"\nСечение прямоугольное. Эксцентриситет в одной плоскости.Арматура расположена у противоположных граней сечения. $\n" +

            $"\n\\begin{{center}}\\begin{{tikzpicture}}\\draw[red,thick](0,0)--({(b / 10).ToString("0.#") },0)--({(b / 10).ToString("0.#") },{(h / 10).ToString("0.#") })--(0,{(h / 10).ToString("0.#") })--cycle;";
          
            if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра" )
            {
                double step_nizh = (b - a * 2) / (n - 1);
                for (int i = 0; i < n; i++)
                {
                    An = An + "\\put(" + (a + i * step_nizh) + "," + a + "){\\circle*{1}};";
                }
                double step_verh = (b - a1 * 2) / (n1 - 1);
                if (As1!=0)
                { 
                  for (int i = 0; i < n1; i++)
                  {
                    An = An + "\\put(" + (a1 + i * step_verh) + "," + (h - a1) + "){\\circle*{1}};";
                  }
                  An=An+ $"\\draw({((b / 10) + 0.5).ToString("0.#") },{((h / 10) + 0.1).ToString("0.#") })--({((b / 10) + 0.5).ToString("0.#") },{(((h - a1) / 10) - 0.1).ToString("0.#") });" +
                        $"\\draw({((b / 10) + 0.1).ToString("0.#") },{(h / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{(h / 10).ToString("0.#") });" +
                       $"\\draw({((b / 10) + 0.1).ToString("0.#") },{((h - a1) / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{((h - a1) / 10).ToString("0.#") });" +
                        $"\\node[rotate=90] at ({((b / 10) + 0.3).ToString("0.#") },{((h / 10) - (a1 / 20)).ToString("0.#") }) {{${a1.ToString("0.#") }$}};";

                }
            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                
                    An = An + $"\\draw[blue](0.1,{(a / 10).ToString("0.#") })--({((b / 10) - 0.1).ToString("0.#") },{(a / 10).ToString("0.#") });";

                if (As1 != 0)
                {
                    An = An + $"\\draw[blue](0.1,{((h - a1) / 10).ToString("0.#") })--({((b / 10) - 0.1).ToString("0.#") },{((h - a1) / 10).ToString("0.#") });"+
                         $"\\draw({((b / 10) + 0.5).ToString("0.#") },{((h / 10) + 0.1).ToString("0.#") })--({((b / 10) + 0.5).ToString("0.#") },{(((h - a1) / 10) - 0.1).ToString("0.#") });" +
                        $"\\draw({((b / 10) + 0.1).ToString("0.#") },{(h / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{(h / 10).ToString("0.#") });" +
                       $"\\draw({((b / 10) + 0.1).ToString("0.#") },{((h - a1) / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{((h - a1) / 10).ToString("0.#") });" +
                        $"\\node[rotate=90] at ({((b / 10) + 0.3).ToString("0.#") },{((h / 10) - (a1 / 20)).ToString("0.#") }) {{${a1.ToString("0.#") }$}};";

                }

            }

            An=An+$"\\draw(-0.5,-0.1)--(-0.5,{((h / 10) + 0.1).ToString("0.#") });" +
            $"\\draw(-0.1,0)--(-0.6,0);" +
            $"\\draw(-0.1,{(h / 10).ToString("0.#") })--(-0.6,{(h / 10).ToString("0.#") });" +
            $"\\draw({((b / 10) + 0.1).ToString("0.#") },0)--({((b / 10) + 0.6).ToString("0.#") },0);" +

            $"\\draw({((b / 10) + 0.1).ToString("0.#") },{(a / 10).ToString("0.#") })--({((b / 10) + 0.6).ToString("0.#") },{(a / 10).ToString("0.#") });" +

            $"\\draw({((b / 10) + 0.5).ToString("0.#") },-0.1)--({((b / 10) + 0.5).ToString("0.#") },{((a / 10) + 0.1).ToString("0.#") });" +
            $"\\draw(-0.1,-0.5)--({((b / 10) + 0.1).ToString("0.#") },-0.5);" +
            $"\\draw(0,-0.1)--(0,-0.6);" +
            $"\\draw({(b / 10).ToString("0.#") },-0.1)--({(b / 10).ToString("0.#") },-0.6);" +
            $"\\node[rotate=90] at (-0.7,{(h / 20).ToString("0.#") }) {{${(h).ToString("0.#") }$}};" +

            //добавим стрелочки осей и моменты
            $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({(b / 20).ToString("0.#") },{((h / 20) + 0.6).ToString("0.#") });" +
             $"\\draw[ ->]({(b / 20).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 20) + 0.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\node at (({((b / 20) - 0.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{c}};" +
            $"\\node at ({((b / 20) + 0.8).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") }) {{y}};" +
            $"\\node at ({((b / 20)).ToString("0.#") },{((h / 20) + 0.8).ToString("0.#") }) {{z}};" +

            //моменты
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.6).ToString("0.#") },{(h / 20).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.1).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.1).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });"+
            $"\\draw({((b / 10) + 2.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.2).ToString("0.#") },{((h / 20) + 0.1).ToString("0.#") });" +
            $"\\draw({((b / 10) + 2.1).ToString("0.#") },{(h / 20).ToString("0.#") })--({((b / 10) + 2.2).ToString("0.#") },{((h / 20) - 0.1).ToString("0.#") });"+
            $"\\node at ({((b / 10) + 2.2).ToString("0.#") },{((h / 20)-0.4).ToString("0.#") }) {{My(+)}};" ;

            
             An=An+$"\\node[rotate=90] at ({((b / 10) + 0.3).ToString("0.#") },{(a / 20).ToString("0.#") }) {{${a.ToString("0.#") }$}};" +
             $"\\node at (({(b / 20).ToString("0.#") },-0.3) {{${b.ToString("0.#") }$}};" +
            $"\\end{{tikzpicture}}\\end{{center}}\n" +

            "\n\\textbf{Исходные данные}\n" +
            "\n Сечение: Прямоугольное. Ширина b=" + b + " см; " + "Высота h=" + h + " см;\n" +
            "\n Арматура: " + (SteelClass1.SelectedValue); 
            
            
            if (Способ_задания_арматуры.SelectedItem == "С помощью площади")
            {
                An = An + $"$;  A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={((As + As1) * 100 / (b * h0)).ToString("0.##")} \\% $" +
             $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}};\\textbf{{}} $\n";
            }
            else if (Способ_задания_арматуры.SelectedItem == "С помощью диаметра")
            {

                An =An+ $"$; A_s={As.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A'_s={As1.ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; A_{{s.total}}={(As1 + As).ToString("0.##")} \\text{{ см}}^2 $" +
            $"$; \\mu_{{s}}={(((As + As1)*100) / (b * h0)).ToString("0.##")} \\% $" +
                    $"$; a ={a} \\text{{ см}}; a'={a1} \\text{{ см}} $" +
                $"$; d_s={ds / 10} \\text{{ см}}$" +
                 $"$; d_s'={ds1 / 10} \\text{{ см}}$"+
                 $"$; n={n}; n'={n1} ; $\n";
            }
                An=An +
                $"$ R_s={Rs / 1000} \\text{{ МПа}}$" +
                $"$; R_{{sc}}={Rsc / 1000}\\text{{ МПа}}$" +
                $"$;  E_s={Es}\\text{{ МПа ; }}$\n" +
                $"$ \\varepsilon_{{s,el}}={esl.ToString("0.###")}; $\n" +


                "\n Бетон: " + (ConcClass.SelectedValue) +
                $"$; R_b={(Rb / (γb1 * γb3 * γb4 * γb5 * 1000)).ToString("0.#")} \\text{{ МПа}}; $\n" +
                $"$ R_b\\cdot\\gamma_b={((Rb) / 1000).ToString("0.#")}\\text{{ МПа}}; $\n" +
               $"$ \\gamma_{{b1}}={γb1.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b3}}={γb3.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b4}}={γb4.ToString("0.##")}; $\n" +
                $"$ \\gamma_{{b5}}={γb5.ToString("0.##")}; $\n" +
                
                 $"$ \\varepsilon_{{b}}={e_b2.ToString("0.###")}; $\n" +
                "\n Усилия: " + $"$ M ={M}\\text{{ кНм}}$" + $"$; N={N}\\text{{ кН}}; $\n" + "\n$\\ $\n";


                raschet=
                ("\n\\textbf{Расчет}\n" +
                $"\n$$h_0=h-a={h}-{a}={h-a}\\text{{ см}};$$\n" +
                $"\n$$e_0=\\frac{{M}}{{N}}=\\frac{{{M}\\cdot 100}}{{{N}}}={e0.ToString("0.#")}\\text{{ см}};$$\n" +
                $"\n$$e'=e_o+(\\frac{{h}}{{2}}-a')={e0.ToString("0.#")}+(\\frac{{{h}}}{{{2}}}-{a1})={e1.ToString("0.#")}\\text{{ см}};$$\n" + "\n$\\ $\n");

            

                if (Вид.SelectedItem == "Подбор арматуры из условий прочности" & (e1 < (h0 - a1)) & Вид_сечения.SelectedItem == "Прямоугольное")
                {
                double E = (h/2) - a - e0;
                double As_pod = (N * e1 * 10000) / (Rs * (h0 - a1));
                double As_pod1 = (N * E * 10000) / (Rs * (h0 - a1));
                double μ = ((As_pod+As_pod1) * 100) / (b * h0);
                sila2 =
                    ($"\n$$e = (\\frac{{h}}{{2}}-a)-e_o=(\\frac{{{h}}}{{{2}}}-{a})-{e0.ToString("0.#")}={E.ToString("0.#")}\\text{{ см}};$$\n" +
                    $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                    "Продольная сила приложена между равнодействующими усилий в арматуре.\n");
                
                arm1 =
                   ($"\n\\text{{Определим необходимую площадь сечения растянутой арматуры:}}\n" +
                   $"\n$$A_s=\\frac{{N\\cdot e'}}{{R_s\\cdot(h_0-a')}}=\\frac{{{N}\\cdot{e1.ToString("0.#")}}}{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot({h0}-{a1})}}={As_pod.ToString("0.##")} \\text{{см}}^2;$$\n" +
                   $"\n$$A'_s=\\frac{{N\\cdot e}}{{R_s\\cdot(h_0-a')}}=\\frac{{{N}\\cdot{E.ToString("0.#")}}}{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot({h0}-{a1})}}={As_pod1.ToString("0.##")} \\text{{см}}^2;$$\n"
                   );
                resultat =
                    ("\n\\textbf{{Результаты расчета}}\n" +
                    $"\n\\text{{Площадь растянутой арматуры: }}" + $"$A_s={As_pod.ToString("0.##")} \\text{{см}}^2;$\n" +
                    $"\n\\text{{Площадь менее растянутой арматуры: }}" + $"$A_s={As_pod1.ToString("0.##")} \\text{{см}}^2;$\n" +
                     $"\n\\text{{Процент армирования: }}"+$"$\\mu_{{s}}={(μ).ToString("0.##")} \\textbf{{ }} \\%; $\n" + "\n$\\ $\n"
                    );
                if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                {

                    Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Площадь менее растянутой арматуры A's= " + As_pod1.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                }
                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                {
                    Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Площадь менее растянутой арматуры A's= " + As_pod1.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT+DATA+ETACH+CONSTR+OSI+"\n\\textbf{ }\n"+COMMENT + arm + resultat + "\n\\textbf{ }\n" + raschet + sila2 + arm1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                }
                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                {
                    Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText(" " + Environment.NewLine);
                    Результаты.AppendText("Площадь менее растянутой арматуры A's= " + As_pod1.ToString("0.##") + "см²;" + Environment.NewLine);
                    Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm+ resultat, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                }
                }

            if (Вид.SelectedItem == "Подбор арматуры из условий прочности" & (e1 > (h0 - a1)) & Вид_сечения.SelectedItem == "Прямоугольное")
            {
                double As1;
                double E = e0 - (h / 2) + a;
                
                double α = (N * E ) / ((Rb / 10000) * b * h0 * h0); //без учета сжатой по умолчанию
                //double α = (N * e1 - (Rsc / 10000) * As1 * (h0 - a1)) / ((Rb / 10000) * γb1 * γb2 * γb3 * γb4 * γb5 * b * h0 * h0);
                double ξ = 1 - Math.Sqrt(1 - 2 * α);
                double αR = ξR * (1 - 0.5 * ξR);
                double As_pod = ((ξ * b * h0  * (Rb/10000))+N )/ (Rs/10000);
                double As_pod3 = N * e1 * 10000 / (Rs * (h0 - a1));
              
                sila3 =
                    ($"\n$$e = e_o-(\\frac{{h}}{{2}}-a)={e0.ToString("0.#")}-(\\frac{{{h}}}{{{2}}}-{a})={E.ToString("0.#")}\\text{{ см}};$$\n" +
                    $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                    "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.");
                if (α < αR & α>0)
                {
                    double μ = ((As_pod) * 100) / (b * h0);
                    resultat =
                    ("\n\\textbf{{Результаты расчета}}\n" +
                    $"\n\\text{{Площадь растянутой арматуры: }}" + $"$A_s={As_pod.ToString("0.##")} \\text{{ см}}^2;$\n" +
                    $"\n\\text{{Процент армирования: }}" + $"$\\mu_{{s}}={(μ).ToString("0.##")}  \\textbf{{ }}\\%; $\n"  + "\n$\\ $\n");
                    arm5 = //без учета сжатой
                   ("Определим необходимую площадь сечения растянутой арматуры" +
               $"\n$$ \\alpha_m= \\frac{{N\\cdot e}}{{R_b\\cdot b\\cdot (h_o)^{{2}}}}=\\frac{{{N}\\cdot {E.ToString("0.#")}}}{{{Rb / 1000}\\cdot 10^{{-1}} \\cdot {b} \\cdot {h0}^{{2}}}}={α.ToString("0.##")};$$\n" +
               $"\n$$ \\alpha_R=\\xi_R \\cdot (1-0.5\\xi_R)={ξR.ToString("0.##")} \\cdot (1-0.5\\cdot {ξR.ToString("0.##")})= {αR.ToString("0.##")};$$\n" +
               $"\n$$ \\xi_R=\\frac{{0.8}}{{1+\\frac{{\\varepsilon_{{s,el}} }}{{\\varepsilon_{{b2}} }} }}=\\frac{{0.8}}{{1+\\frac{{{esl}}}{{{e_b2}}}}}={ξR.ToString("0.##")};$$\n" +
               $"\n$$ \\varepsilon_{{s,el}}= \\frac{{R_s}}{{E_s}}=\\frac{{{Rs}}}{{{Es}}}={esl.ToString("0.###")};$$\n" +
                    $"\n$$ \\xi=1-\\sqrt{{1-2\\cdot \\alpha_m}}=1-\\sqrt{{1-2 \\cdot{α.ToString("0.##")}}}={ξ.ToString("0.##")};$$\n" +
                    $"\n$$\\alpha_m \\leq \\alpha_R={αR.ToString("0.##")} \\Rightarrow $$\n" +
                    $"\n$$ A_s=\\frac{{\\xi \\cdot b \\cdot h_0 \\cdot R_b +N }}{{R_s}}=\\frac{{{ξ.ToString("0.##")} \\cdot {b} \\cdot {h0} \\cdot {Rb / 1000} \\cdot 10^{{-1}}+{N}}}{{{Rs / 1000} \\cdot 10^{{-1}}}}={As_pod.ToString("0.##")}\\text{{ см}}^2.$$\n");
                    if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                    {

                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                    }
                    else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat + "\n\\textbf{ }\n" + raschet + sila3 + arm5 , System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                    }
                    else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + "см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                    }
                }
                if (α < 0)
                {
                    double μ = (As_pod3 * 100) / (b * h0);
                    resultat =
                   ("\n\\textbf{{Результаты расчета}}\n" +
                   $"\n\\text{{Площадь растянутой арматуры: }}" + $"$A_s={As_pod3.ToString("0.##")} \\text{{ см}}^2;$\n" +
                   $"\n\\text{{Процент армирования: }}" + $"$\\mu_{{s}}={((As_pod3* 100) / (b * h0)).ToString("0.##")}  \\textbf{{ }} \\%; $\n" + "\n$\\ $\n");
                    alfa2 = //альфа меньше 0
                    ($"\n\\text{{Определим необходимую площадь сечения растянутой арматуры:}}\n" +
               $"\n$$ \\alpha_m= \\frac{{N\\cdot e}}{{R_b\\cdot b\\cdot (h_o)^{{2}}}}=\\frac{{{N}\\cdot {E.ToString("0.#")}}}{{{Rb / 1000}\\cdot 10^{{-1}} \\cdot {b} \\cdot {h0}^{{2}}}}={α.ToString("0.##")};$$\n" +
               $"\n$$ \\alpha_R=\\xi_R \\cdot (1-0.5\\xi_R)={ξR.ToString("0.##")} \\cdot (1-0.5\\cdot {ξR.ToString("0.##")})= {αR.ToString("0.##")};$$\n" +
               $"\n$$ \\xi_R=\\frac{{0.8}}{{1+\\frac{{\\varepsilon_{{s,el}} }}{{\\varepsilon_{{b2}} }} }}=\\frac{{0.8}}{{1+\\frac{{{esl}}}{{{e_b2}}}}}={ξR.ToString("0.##")};$$\n" +
                 $"\n$$ \\varepsilon_{{s,el}}= \\frac{{R_s}}{{E_s}}=\\frac{{{Rs}}}{{{Es}}}={esl.ToString("0.###")};$$\n" +
                    $"\n$$ \\xi=1-\\sqrt{{1-2\\cdot \\alpha_m}}=1-\\sqrt{{1-2 \\cdot{α.ToString("0.##")}}}={ξ.ToString("0.##")};$$\n" +
                    $"\n$$\\alpha_m <0 \\Rightarrow A_s=\\frac{{N\\cdot e'}}{{R_s \\cdot (h_0-a')}}=\\frac{{{N}\\cdot{e1}}}{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot({h0}-{a1})}}={As_pod3.ToString("0.##")} \\text{{ см}}^2.$$\n");
                    if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                    {

                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod3.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                    }
                    else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod3.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat + "\n\\textbf{ }\n" + raschet + sila3 +  alfa2, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                    }
                    else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod3.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);

                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                    }
                }
                if (α> αR)
                {
                    As1 = (N * E - (αR * (Rb / 10000)  * b * h0 * h0)) / ((Rsc / 10000) * (h0 - a1));
                    α = (N * E - (Rsc / 10000) * As1 * (h0 - a1)) / ((Rb / 10000)  * b * h0 * h0);
                    ξ = 1 - Math.Sqrt(1 - 2 * α);
                    As_pod = (((ξ * b * h0  * (Rb/10000))+N )/ (Rs/10000)) + (As1 * Rsc / Rs);
                    double μ= ((As_pod + As1) * 100)/(b * h0);
                    resultat =
                    ("\n\\textbf{{Результаты расчета}}\n" +
                    $"\n\\text{{Площадь растянутой арматуры: }}" + $"$ A_s={As_pod.ToString("0.##")} \\text{{ см}}^2;$\n" +
                    $"\n\\text{{Площадь сжатой арматуры: }}" + $"$ A'_s={As1.ToString("0.##")} \\text{{ см}}^2;$\n" +
                    $"\n\\text{{Процент армирования: }}" + $"$\\mu_{{s}}={μ.ToString("0.##")}  \\textbf{{ }} \\%; $\n" + "\n$\\ $\n");
                    arm2 =//с учетом сжатой
                    ($"\n\\text{{Определим необходимую площадь сечения растянутой арматуры:}}\n" +
                    $"\n$$ \\alpha_m= \\frac{{N\\cdot e}}{{R_b\\cdot b\\cdot (h_o)^{{2}}}}=\\frac{{{N}\\cdot {E.ToString("0.#")}}}{{{Rb / 1000}\\cdot 10^{{-1}} \\cdot {b} \\cdot {h0}^{{2}}}}={((N * E) / ((Rb / 10000) * b * h0 * h0)).ToString("0.##")};$$\n" +
                    $"\n$$ \\alpha_m > \\alpha_R={αR.ToString("0.##")} \\Rightarrow $$\n" +
                $"\n$$ \\alpha_m= \\frac{{N\\cdot e-R_{{cs}} \\cdot A'_s \\cdot(h_0-a')}}{{R_b\\cdot b\\cdot (h_o)^{{2}}}}=\\frac{{{N}\\cdot {E}-{Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} \\cdot ({h0}-{a1})}}{{{Rb / 1000}\\cdot 10^{{-1}} \\cdot {b} \\cdot {h0}^{{2}}}}={α.ToString("0.##")};$$\n" +
                
                $"\n$$ \\alpha_R=\\xi_R \\cdot (1-0.5\\xi_R)={ξR.ToString("0.##")} \\cdot (1-0.5\\cdot {ξR.ToString("0.##")})= {αR.ToString("0.##")};$$\n" +
                $"\n$$ \\xi_R=\\frac{{0.8}}{{1+\\frac{{\\varepsilon_{{s,el}} }}{{\\varepsilon_{{b2}} }} }}=\\frac{{0.8}}{{1+\\frac{{{esl}}}{{{e_b2}}}}}={ξR.ToString("0.##")};$$\n" +
                $"\n$$ \\varepsilon_{{s,el}}= \\frac{{R_s}}{{E_s}}=\\frac{{{Rs/1000}}}{{{Es}}}={esl.ToString("0.###")};$$\n" +
                  $"\n$$ \\xi=1-\\sqrt{{1-2\\cdot \\alpha_m}}=1-\\sqrt{{1-2 \\cdot{α.ToString("0.##")}}}={ξ.ToString("0.##")};$$\n" +
                   $"\n$$\\alpha_m \\leq \\alpha_R={αR.ToString("0.##")} \\Rightarrow $$\n" +
                   $"\n$$ A_s=\\frac{{\\xi \\cdot b \\cdot h_0 \\cdot R_b +N }}{{R_s}}+\\frac{{A'_s \\cdot R_{{sc}}}}{{R_s}}=\\frac{{{ξ.ToString("0.##")} \\cdot {b} \\cdot {h0} \\cdot {Rb / 1000} \\cdot 10^{{-1}}+{N}}}{{{Rs / 1000} \\cdot 10^{{-1}} }}+\\frac{{{As1.ToString("0.##")} \\cdot {Rsc / 1000}}}{{{Rs / 1000}}}={As_pod.ToString("0.##")}\\text{{ см}}^2.$$\n");

                    if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Площадь сжатой арматуры A's= " + As1.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                    }
                    else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Площадь сжатой арматуры A's= " + As1.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat + "\n\\textbf{ }\n" + raschet + sila3 + arm2 , System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                    }
                    else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                    {
                        Результаты.AppendText("Площадь растянутой арматуры As= " + As_pod.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText(" " + Environment.NewLine);
                        Результаты.AppendText("Площадь сжатой арматуры A's= " + As1.ToString("0.##") + " см²;" + Environment.NewLine);
                        Результаты.AppendText("Процент армирования μ= " + μ.ToString("0.##") + " %" + Environment.NewLine);
                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n"+ COMMENT + arm + resultat, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                    }
                }
               
                
            }

            if (Вид_сечения.SelectedItem == "Тавровый,полки снизу") 
            {
                double Mult;
                double Mult1;
                double vivod;
                double x;

                e1 = e0 + (h / 2) + yc - a1;
                sila = "\n\\textbf{Расчет}\n" +
               $"\n$$h_0=h-a={h}-{a}={h - a}\\text{{ см}};$$\n" +
               $"\n$$e_0=\\frac{{M}}{{N}}=\\frac{{{M}\\cdot 100}}{{{N}}}={e0.ToString("0.#")}\\text{{ см}};$$\n" +
               $"\n$$y_c= \\frac{{b'_f \\cdot h'_f \\cdot (\\frac{{h-h'_f}}{{2}})+(h-h'_f)\\cdot b \\cdot (\\frac{{h}}{{2}}-\\frac{{h-h'_f}}{{2}})}}{{b'_f \\cdot h'_f +(h-h'_f)\\cdot b }}=$$\n" +
                 $"\n$$=\\frac{{{bf}\\cdot {hf} \\cdot (\\frac{{{h}-{hf}}}{{2}})+({h}-{hf})\\cdot {b} \\cdot (\\frac{{{h}}}{{2}}-\\frac{{{h}-{hf}}}{{2}})}}{{{bf} \\cdot {hf} +({h}-{hf})\\cdot {b} }}={yc.ToString("0.#")}\\text{{ см}};$$\n" +

               $"\n$$e'=e_0+(\\frac{{h}}{{2}}+ y_c)-a'={e0.ToString("0.#")}+(\\frac{{{h}}}{{2}}+ {yc.ToString("0.#")})-{a1}={(e1).ToString("0.#")}\\text{{ см}};$$\n";
                double E = 1;
                if (e0 > ((h / 2) + yc - a))
                {
                    E = e0 - ((h / 2) - yc) + a;
                    sila = sila + $"\n$$e=e_0-(\\frac{{h}}{{2}}-y_c)+a={e0.ToString("0.#")}-(\\frac{{{h}}}{{2}}-{yc.ToString("0.#")})+{a}={(E).ToString("0.#")}\\text{{ см}};$$\n";
                }
                else
                {
                    E = (h / 2) - yc - a - e0;
                    sila = sila + $"\n$$e= (\\frac{{h}}{{2}}-y_c)-e_0-a=(\\frac{{{h}}}{{2}}-{yc.ToString("0.#")})-{e0.ToString("0.#")}-{a}={(E).ToString("0.#")}\\text{{ см}};$$\n";
                }

                if (As == As1 & Вид.SelectedItem == "Проверка прочности сечения элемента")
                {
                    Mult1 = (Rs * As * (h0 - a1)) / 1000000;

                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));
                    vivod = zapas1;

                    if (e0 < ((h / 2) + yc - a))
                    {
                        sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                           "\n Продольная сила приложена между равнодействующими усилий в арматуре.\n";
                    }
                    else
                    {
                        sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                             "\n Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.\n";
                    }

                    vipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    nevipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
               "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";

                    rezultvipol =
                            ("\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                    if (e0 < ((h / 2) + yc - a))
                    {

                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                        else if (Mult1 < (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                    double x2;
                    x2 = (Rs * As / 10000 - N) / (Rb * b / 10000);
                    if (e0 > ((h / 2) + yc - a))
                    {

                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }

                        else if (Mult1 < (N * e1) / 100 & Сжатая_зона.IsChecked == true & x2 > 0 & x2 < 2 * a1)
                        {
                            x = (Rs * As / 10000 - N) / (Rb * b / 10000);
                            Mult = Rb * b * x * (h0 - x / 2) / 1000000;
                            double prots = Math.Abs(Mult * 100 / (N * E));

                            nevipol1 = nevipol1 +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}};$$\n" +
                              $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b'\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n";

                            rezultvipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");

                            if ((N * E / 100) > Mult)
                            {
                                nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                             "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";

                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else
                            {

                                nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }


                        }
                        else if (Mult1 < (N * e1) / 100 & (Сжатая_зона.IsChecked == false || Сжатая_зона.IsChecked == true & x2 < 0 || Сжатая_зона.IsChecked == true & x2 > 2 * a1))
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                }
              else if (As!= As1 & Вид.SelectedItem == "Проверка прочности сечения элемента")
              { 
                if (e0 > ((h / 2) + yc - a))
                {

                    sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                          "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.\n";
                    if ((Rs * As / 10000) <= ((Rb * b * (h - hf)) / 10000 + Rsc * As1 / 10000 + N)) //Сжатая зона в стенке
                    {
                        x = (Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb * b / 10000);
                        double x1 = (Rs * As / 10000 - N) / (Rb * b / 10000);
                        Mult = Rb * b * x * (h0 - x / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                        vivod = Math.Abs(Mult * 100 / (N * E));
                        sila1 = sila + $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b' \\cdot (h-h_f) + R_{{sc}} \\cdot A'_s +N={((Rb * b * (h - hf)) / 10000 + Rsc * As1 / 10000 + N).ToString("0.##")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в стенке.}} $$\n" +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b'}}=$$\n" +
                           $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} -{N}}}{{{Rb / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}};$$\n";
                            
                            if (Сжатая_зона.IsChecked == true & x1 > 0 & x1 < (2 * a1)) ///////Допущение из сп
                            {
                                sila = sila + /*$"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000+N).ToString("0.##")} \\text{{ кН}};$$\n" +*/
                                $"\n$$\\text{{Сжатая зона находится в стенке.}} $$\n";
                                Mult = (Rb * b * x1 * (h0 - 0.5 * x)) / 1000000;
                                double prots = Math.Abs(Mult * 100 / (N * E));

                                vipol4 = // x>0 и <предельной
                                (
                                $"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x1).ToString("0.##")}\\text{{ см}};$$\n" +

                                $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                                $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                                $"\n$$M_{{ult}}=R_b\\cdot b'\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x1).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x1).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                                "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");
                                nevipol4 =
                                ($"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{(As).ToString("0.##")} -{N}}}{{{(Rb / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={(x1).ToString("0.##")}\\text{{см}}>0;$$\n" +
                                $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                                $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                                $"\n$$M_{{ult}}=R_b\\cdot b'\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x1).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x1).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                                 "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");

                                rezultvipol =
                                 ("\n\\textbf{{Результаты расчета}}\n" +
                                 "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                                 "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                                rezultnevipol =
                                    ($"\n\\textbf{{Результаты расчета}}\n" +
                                    "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                                "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");


                                if (Mult >= (N * E) / 100)
                                {
                                    if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса прочности γ =" + prots.ToString("0.##") + Environment.NewLine);
                                    }
                                    else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса γ =" + prots.ToString("0.##") + Environment.NewLine);
                                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                    }
                                    else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса прочности γ =" + prots.ToString("0.##") + Environment.NewLine);
                                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                    }

                                }
                                else
                                {
                                    if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    }
                                    else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                    }
                                    else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                    {
                                        Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                        Результаты.AppendText(" " + Environment.NewLine);
                                        Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                        PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                    }
                                }

                            }
                            else if (x > ξR * h0)
                            {
                            x = ξR * h0;
                            Mult = Rb * b * x * (h0 - x / 2) / 1000000  + Rsc * As1 * (h0 - a1) / 1000000;
                            vivod = Math.Abs(Mult * 100 / (N * E));
                            sila1 = sila1 +
                            $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.##")}\\cdot{h0}={(ξR * h0).ToString("0.##")}\\text{{см}};$$\n" +
                               $"\n$$ \\text{{Принимается: }} x=\\xi_R\\cdot h_0={(h0 * ξR).ToString("0.##")}\\text{{см}};$$\n";
                            rezultnevipol =
                        ($"\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                        "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                                $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                                 $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila1 + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila1 + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }

                            }
                        else if (x <= 0)
                        {
                            Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                            vivod = Math.Abs(Mult1 * 100 / (N * e1));
                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 =
                            "\nТак так высота сжатой зоны x<0, проверку выполняем по условию (8.21):\n" +
                                $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e'={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = "\nТак так высота сжатой зоны x<0, проверку выполняем по условию (8.21):\n" +
                                 $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";

                            if (Mult1 >= (N * e1) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila1 + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila1 + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }
                        else
                        {
                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                                $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                                 $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila1 + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila1 + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }
                    }
                    else if ((Rs * As / 10000) > ((Rb * b * (h - hf)) / 10000 + Rsc * As1 / 10000 + N)) //Сжатая зона в полке
                    {
                        x = (Rs * As / 10000 - Rsc * As1 / 10000 - N + (Rb * (bf - b) * (h - hf)) / 10000) / (Rb * bf / 10000);
                        Mult =(Rb*bf*x*(h0-(x/2))+Rsc*As1*(h0-a1)-Rb*(bf-b)*(h-hf)*(h0-((h-hf)/2)))/1000000;
                        vivod = Math.Abs(Mult * 100 / (N * E));

                        sila = sila + $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\nleq R_b \\cdot b \\cdot (h-h_f) + R_{{sc}} \\cdot A'_s +N={((Rb * b * (h - hf)) / 10000 + Rsc * As1 / 10000 + N).ToString("0.##")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n" +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N+R_b \\cdot (b_f-b')\\cdot (h-h_f)}}{{R_b\\cdot b_f}}=$$\n" +
                           $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} -{N}+{Rb / 1000}\\cdot 10^{{-1}}\\cdot ({bf}-{b})\\cdot ({h}-{hf})}}{{{Rb / 1000}\\cdot 10^{{-1}}\\cdot {bf}}}={(x).ToString("0.##")}\\text{{ см}};$$\n";
                        if (x > ξR * h0)
                        {
                            x = ξR * h0;

                                if (x <= (h - hf))
                                {
                                    Mult = (Rb * b * x * (h0 - (x / 2)) + Rsc * As1 * (h0 - a1)) / 1000000;
                                    vivod = Math.Abs(Mult * 100 / (N * E));
                                    vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                                    nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b' \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                          $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                           "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                                }
                                else
                                {
                                    Mult = (Rb * bf * x * (h0 - (x / 2)) + Rsc * As1 * (h0 - a1) - Rb * (bf - b) *(h-hf) * (h0 - ((h-hf) / 2))) / 1000000;
                                    vivod = Math.Abs(Mult * 100 / (N * E));
                                    vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b_f \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')-R_b \\cdot (b_f-b)\\cdot (h-h_f) \\cdot(h_0-\\frac{{(h-h_f)}}{{2}})=$$\n" +
                             $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}} +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}+$$\n" +
                             $"\n$$-{Rb / 1000}\\cdot 10^{{3}} \\cdot ({bf}-{b})\\cdot 10^{{-2}} \\cdot ({h}-{hf})\\cdot 10^{{-2}} \\cdot({h0}-\\frac{{({h}-{hf})}}{{2}})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                                    nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b_f \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')-R_b \\cdot (b_f-b)\\cdot (h-h_f) \\cdot(h_0-\\frac{{(h-h_f)}}{{2}})=$$\n" +
                             $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}} +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}+$$\n" +
                             $"\n$$-{Rb / 1000}\\cdot 10^{{3}} \\cdot ({bf}-{b})\\cdot 10^{{-2}} \\cdot ({h}-{hf})\\cdot 10^{{-2}} \\cdot({h0}-\\frac{{({h}-{hf})}}{{2}})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                          $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                           "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                                }
                            sila = sila +
                            $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.##")}\\cdot{h0}={(ξR * h0).ToString("0.##")}\\text{{см}};$$\n" +
                               $"\n$$ \\text{{Принимается: }} x=\\xi_R\\cdot h_0={(h0 * ξR).ToString("0.##")}\\text{{см}};$$\n";

                            rezultnevipol =
                        ($"\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                        "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                            
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }

                        }
                        else
                        { 
                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                            vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b_f \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')-R_b \\cdot (b_f-b)\\cdot (h-h_f) \\cdot(h_0-(\\frac{{h-h_f}}{{2}}))=$$\n" +
                                $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}} +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}+$$\n" +
                                 $"\n$$-{Rb / 1000}\\cdot 10^{{3}} \\cdot ({bf}-{b})\\cdot 10^{{-2}} \\cdot ({h}-{hf}))\\cdot 10^{{-2}} \\cdot({h0}-(\\frac{{({h}-{hf})}}{{2}}))\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b_f \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')-R_b \\cdot (b_f-b)\\cdot (h-h_f) \\cdot(h_0-(\\frac{{h-h_f}}{{2}}))=$$\n" +
                                $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}} +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}+$$\n" +
                                 $"\n$$-{Rb / 1000}\\cdot 10^{{3}} \\cdot ({bf}-{b})\\cdot 10^{{-2}} \\cdot ({h}-{hf}))\\cdot 10^{{-2}} \\cdot({h0}-(\\frac{{({h}-{hf})}}{{2}}))\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }

                    }
                }
                else if (e0< ((h/2)+yc - a))
                {
                    sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                        "Продольная сила приложена между равнодействующими усилий в арматуре.\n";
                    Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                    Mult = (Rs * As1 * (h0 - a1)) / 1000000;
                    double zapas = Math.Abs(Mult * 100 / (N * E));
                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));
                    if (zapas1 < zapas)
                    {
                        vivod = zapas1;

                    }
                    else
                    {
                        vivod = zapas;

                    }

                    vipol1 =
                    ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n" +
                    $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n");

                    nevipol1 =
                        ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                        $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n");
                    rezultvipol =
                           ("\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                           "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    if ((N * E / 100) > Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }
                    else if ((N * E / 100) <= Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }
                    nevipol1 = nevipol1 + $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n";
                    if ((N * e1 / 100) > Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }
                    else if ((N * e1 / 100) <= Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }

                    if (Mult >= (N * E) / 100 & Mult1 >= (N * e1) / 100) //Если моменты меньше предельных VIPOL1 
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }
                    else //Если моменты больше предельных NEVIPOL1
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr1 + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }
                }
              }
            }
            else if (Вид_сечения.SelectedItem == "Тавровый,полки сверху")
            {


                double Mult;
                double Mult1;
                double vivod;
                double x;
                e1 = e0 + (h / 2) - yc - a1;
                sila = "\n\\textbf{Расчет}\n" +
                $"\n$$h_0=h-a={h}-{a}={h - a}\\text{{ см}};$$\n" +
                $"\n$$e_0=\\frac{{M}}{{N}}=\\frac{{{M}\\cdot 100}}{{{N}}}={e0.ToString("0.#")}\\text{{ см}};$$\n" +
                $"\n$$y_c= \\frac{{b'_f \\cdot h'_f \\cdot (\\frac{{h-h'_f}}{{2}})+(h-h'_f)\\cdot b \\cdot (\\frac{{h}}{{2}}-\\frac{{h-h'_f}}{{2}})}}{{b'_f \\cdot h'_f +(h-h'_f)\\cdot b }}=$$\n" +
                 $"\n$$=\\frac{{{bf}\\cdot {hf} \\cdot (\\frac{{{h}-{hf}}}{{2}})+({h}-{hf})\\cdot {b} \\cdot (\\frac{{{h}}}{{2}}-\\frac{{{h}-{hf}}}{{2}})}}{{{bf} \\cdot {hf} +({h}-{hf})\\cdot {b} }}={yc.ToString("0.#")}\\text{{ см}};$$\n" +
                $"\n$$e'=e_0+(\\frac{{h}}{{2}}-y_c)-a'={e0.ToString("0.#")}+(\\frac{{{h}}}{{2}}-{yc.ToString("0.#")})-{a1}={(e1).ToString("0.#")}\\text{{ см}};$$\n";
                double E = 1;
                if (e0 > ((h/2)+yc - a))
                {
                    E = e0 - ((h / 2) + yc) + a;
                    sila = sila + $"\n$$e=e_0-(\\frac{{h}}{{2}}+y_c)+a={e0.ToString("0.#")}-(\\frac{{{h}}}{{2}}+{yc.ToString("0.#")})+{a}={(E).ToString("0.#")}\\text{{ см}};$$\n";
                }
                else
                {
                    E = (h / 2) + yc - a - e0;
                    sila = sila + $"\n$$e= (\\frac{{h}}{{2}}+y_c)-e_0-a=(\\frac{{{h}}}{{2}}+{yc.ToString("0.#")})-{e0.ToString("0.#")}-{a}={(E).ToString("0.#")}\\text{{ см}};$$\n";
                }

                if (As == As1 & Вид.SelectedItem == "Проверка прочности сечения элемента")
                {
                    Mult1 = (Rs * As * (h0 - a1)) / 1000000;

                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));
                    vivod = zapas1;

                    if (e0 < ((h/2)+yc - a))
                    {
                        sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                           "Продольная сила приложена между равнодействующими усилий в арматуре.\n";
                    }
                    else
                    {
                        sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h / 2) + yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                             "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.\n";
                    }

                    vipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    nevipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
               "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";

                    rezultvipol =
                            ("\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                    if (e0 < ((h/2) +yc - a))
                    {

                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT +tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                        else if (Mult1 < (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                    double x2;
                    x2 = (Rs * As / 10000 - N) / (Rb * bf / 10000);
                    if (e0 > ((h/2) +yc- a))
                    {

                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }

                        else if (Mult1 < (N * e1) / 100 & Сжатая_зона.IsChecked == true & x2 > 0 & x2 < 2 * a1)
                        {
                            x = (Rs * As / 10000 - N) / (Rb * bf / 10000);
                            Mult = Rb * bf * x * (h0 - x / 2) / 1000000;
                            double prots = Math.Abs(Mult * 100 / (N * E));

                            nevipol1 = nevipol1 +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'_f}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {bf}}}={(x).ToString("0.##")}\\text{{ см}};$$\n" +
                              $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b'_f\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{bf}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n";

                            rezultvipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");

                            if ((N * E / 100) > Mult)
                            {
                                nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                             "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";

                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n"  + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else
                            {

                                nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }


                        }
                        else if (Mult1 < (N * e1) / 100 & (Сжатая_зона.IsChecked == false || Сжатая_зона.IsChecked == true & x2 < 0 || Сжатая_зона.IsChecked == true & x2 > 2 * a1))
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n"  + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                }
                else if (As!=As1 &  Вид.SelectedItem == "Проверка прочности сечения элемента")
                { 

                  if (e0 > ((h/2)+yc - a))
                  {

                    sila = sila + $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}+y_c-a' =\\frac{{{h}}}{{2}}+{yc.ToString("0.#")}-{a}= {((h/2)+yc - a).ToString("0.#")} \\text{{ см}};$$\n" +
                          "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.\n";
                    //double x1 = (Rs * As / 10000 - N) / (Rb * bf / 10000);
                    //if (Сжатая_зона.IsChecked == true & x1 > 0 & x1 < (2 * a1) & (Rs * As / 10000) <= (Rb * bf * hf / 10000 + N))
                    //{


                    //}
                    if ((Rs * As / 10000) <= (Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N)) //Сжатая зона в полке
                    {
                        x = (Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb * bf / 10000);
                        double x1 = (Rs * As / 10000 - N) / (Rb * bf / 10000);
                        Mult = Rb * bf * x * (h0 - x / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                        vivod = Math.Abs(Mult * 100 / (N * E));

                        if (Сжатая_зона.IsChecked == true & x1 > 0 & x1 < (2 * a1)) ///////Допущение из сп
                        {
                            sila = sila + /*$"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000+N).ToString("0.##")} \\text{{ кН}};$$\n" +*/
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n";
                            Mult = (Rb * bf * x1 * (h0 - 0.5 * x)) / 1000000;
                            double prots = Math.Abs(Mult * 100 / (N * E));

                            vipol4 = // x>0 и <предельной
                            (
                            $"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'_f}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {bf}}}={(x1).ToString("0.##")}\\text{{ см}};$$\n" +

                            $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b'_f\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{bf}\\cdot 10^{{-2}}\\cdot{(x1).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x1).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");
                            nevipol4 =
                            ($"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b'_f}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{(As).ToString("0.##")} -{N}}}{{{(Rb / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {bf}}}={(x1).ToString("0.##")}\\text{{см}}>0;$$\n" +
                            $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b'_f\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{bf}\\cdot 10^{{-2}}\\cdot{(x1).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x1).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                             "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");

                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                                ($"\n\\textbf{{Результаты расчета}}\n" +
                                "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");


                            if (Mult >= (N * E) / 100)
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ =" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса γ =" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ =" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }

                            }
                            else
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }

                        }
                        else if (x <= 0)
                        {
                            Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                            vivod = Math.Abs(Mult1 * 100 / (N * e1));
                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 = $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N).ToString("0.#")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n" +
                            $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b'_f}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}};$$\n" +
                            "\nТак так высота сжатой зоны x<0, проверку выполняем по условию (8.21):\n" +
                                $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e'={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N).ToString("0.#")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n" +
                            $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b'_f}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}};$$\n" +
                            "\nТак так высота сжатой зоны x<0, проверку выполняем по условию (8.21):\n" +
                                 $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";

                            if (Mult1 >= (N * e1) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }
                        else if (x > ξR * h0)
                        {
                            x = ξR * h0;
                            Mult = Rb * b * x * (h0 - x / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                            vivod = Math.Abs(Mult * 100 / (N * E));
                            sila = sila + $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s +N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N).ToString("0.##")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n" +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b'_f}}=$$\n" +
                           $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")}-{N}}}{{{Rb / 1000}\\cdot 10^{{-1}}\\cdot {bf}}}={((Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb * bf / 10000)).ToString("0.##")}\\text{{ см}};$$\n" +
                            $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.##")}\\text{{см}};$$\n" +
                               $"\n$$ \\text{{Принимается: }} x=\\xi_R\\cdot h_0={(h0 * ξR).ToString("0.##")}\\text{{см}};$$\n"
                                ;
                            rezultnevipol =
                        ($"\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                        "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                                $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                                 $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }
                        else
                        {
                            sila = sila + $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\leq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N).ToString("0.##")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в полке.}} $$\n" +
                                  $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b'_f}}=$$\n" +
                             $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")}-{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {bf}}}={(x).ToString("0.##")}\\text{{ см}};$$\n";

                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                             $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                                $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                                 $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                  $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            if (Mult >= (N * E) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }
                    }
                    else if ((Rs * As / 10000) > (Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N))//Сжатая зона в стенке
                    {
                        x = (Rs * As / 10000 - Rsc * As1 / 10000 - Rb * (bf - b) * hf / 10000 - N) / (Rb * b / 10000);

                        sila = sila + $"\n$$ R_s \\cdot A_s={(Rs * As / 10000).ToString("0.#")} \\text{{ кН}}\\nleq R_b \\cdot b'_f \\cdot h'_f + R_{{sc}} \\cdot A'_s+N={(Rb * bf * hf / 10000 + Rsc * As1 / 10000 + N).ToString("0.##")} \\text{{ кН}};$$\n" +
                            $"\n$$\\text{{Сжатая зона находится в стенке.}} $$\n";

                        Mult = Rb * b * x * (h0 - x / 2) / 1000000 + Rb * (bf - b) * hf * (h0 - hf / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                        vivod = Math.Abs(Mult * 100 / (N * E));

                         nevipol2 = "";
                         vipol2 = "";
                            if (x > ξR * h0)
                            {
                            x = ξR * h0;
                            
                            sila = sila +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-R_b \\cdot (b'_f-b) \\cdot h'_f-N}}{{R_b\\cdot b}}=$$\n" +
                           $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")}-{Rb / 1000}\\cdot 10^{{-1}} \\cdot ({bf}-{b}) -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={((Rs * As / 10000 - Rsc * As1 / 10000 - Rb * (bf - b) * hf / 10000 - N) / (Rb * b / 10000)).ToString("0.##")}\\text{{ см}};$$\n" +
                            $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.##")}\\cdot{h0}={(ξR * h0).ToString("0.##")}\\text{{см}};$$\n" +
                               $"\n$$ \\text{{Принимается: }} x=\\xi_R\\cdot h_0={(h0 * ξR).ToString("0.##")}\\text{{см}};$$\n";
                                if (x <= hf)
                                {
                                    Mult = Rb * b * x * (h0 - x / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                                    vivod = Math.Abs(Mult * 100 / (N * E));
                                    vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')={Rb / 1000}\\cdot 10^{{3}} \\cdot {bf}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+$$\n" +
                            $"\n$$ +{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n";
                                    nevipol2 = vipol2;

                                }
                                else
                                {
                                    Mult = Rb * b * x * (h0 - x / 2) / 1000000 + Rb * (bf - b) * hf * (h0 - hf / 2) / 1000000 + Rsc * As1 * (h0 - a1) / 1000000;
                                    vivod = Math.Abs(Mult * 100 / (N * E));
                                    vipol2 = $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_b \\cdot (b'_f-b)\\cdot h'_f \\cdot (h_0-\\frac{{h'_f}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')= $$\n" +
                            $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+ $$\n" +
                            $"\n$$+{Rb / 1000}\\cdot 10^{{3}}  \\cdot({bf}-{b})\\cdot 10^{{-2}}\\cdot {hf.ToString("0.#")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{hf}}}{{2}})\\cdot 10^{{-2}}+{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n";
                                    nevipol2 = vipol2;

                                }

                            }
                        else
                        {
                            sila = sila + $"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-R_b \\cdot (b'_f-b) \\cdot h'_f-N}}{{R_b\\cdot b}}=$$\n" +
                          $"\n$$=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")}-{Rb / 1000}\\cdot 10^{{-1}} \\cdot ({bf}-{b}) -{N}}}{{{(Rb) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}};$$\n"+
                          $"\n$$ M_{{ult}}=R_b \\cdot b \\cdot x \\cdot(h_0-\\frac{{x}}{{2}})+R_b \\cdot (b'_f-b)\\cdot h'_f \\cdot (h_0-\\frac{{h'_f}}{{2}})+R_{{sc}} \\cdot As'\\cdot(h_0-a')= $$\n" +
                            $"\n$$={Rb / 1000}\\cdot 10^{{3}} \\cdot {b}\\cdot 10^{{-2}} \\cdot {(x).ToString("0.##")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{(x).ToString("0.##")}}}{{{2}}})\\cdot 10^{{-2}}+ $$\n" +
                            $"\n$$+{Rb / 1000}\\cdot 10^{{3}}  \\cdot({bf}-{b})\\cdot 10^{{-2}}\\cdot {hf.ToString("0.#")}\\cdot 10^{{-2}} \\cdot({h0} -\\frac{{{hf}}}{{2}})\\cdot 10^{{-2}}+{Rsc / 1000} \\cdot 10^{{3}} \\cdot {As1.ToString("0.#")}\\cdot 10^{{-4}}\\cdot({h0} - {a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n";

                            }

                            rezultnevipol =
                        ($"\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                        "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                        rezultvipol =
                         ("\n\\textbf{{Результаты расчета}}\n" +
                         "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                         "\n Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                        vipol2 = vipol2+ $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                             "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                        nevipol2 = nevipol2+$"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                           $"\n$$N e={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                            "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                        if (Mult >= (N * E) / 100) // момент меньше предельного
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                        else // моменты больше предельных
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }

                    }


                  }
                  else if (e1 < (h0 - a1))
                  {

                    sila = sila + $"\n$$e'={e1.ToString("0.#")}\\text{{см}} < h_0-a' ={h0}-{a1}= {h0 - a1} \\text{{ см}};$$\n" +
                        "Продольная сила приложена между равнодействующими усилий в арматуре.\n";
                    Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                    Mult = (Rs * As1 * (h0 - a1)) / 1000000;
                    double zapas = Math.Abs(Mult * 100 / (N * E));
                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));


                    if (zapas1 < zapas)
                    {
                        vivod = zapas1;

                    }
                    else
                    {
                        vivod = zapas;

                    }

                    vipol1 =
                    ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n" +
                    $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n");

                    nevipol1 =
                        ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                        $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n");
                    rezultvipol =
                           ("\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                           "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    if ((N * E / 100) > Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }
                    else if ((N * E / 100) <= Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }
                    nevipol1 = nevipol1 + $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n";
                    if ((N * e1 / 100) > Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }
                    else if ((N * e1 / 100) <= Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }

                    if (Mult >= (N * E) / 100 & Mult1 >= (N * e1) / 100) //Если моменты меньше предельных VIPOL1 
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol + "\n\\textbf{ }\n" + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }
                    else //Если моменты больше предельных NEVIPOL1
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol + "\n\\textbf{ }\n" + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + tavr + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }
                  }
                }

            }
            else if (Вид_сечения.SelectedItem == "Прямоугольное")
            {
                double E;
                if (e1 < (h0 - a1))
                { E = h / 2 - a - e0; }
                else
                { E = e0 - (h / 2) + a; }
                if (As == As1 & Вид.SelectedItem == "Проверка прочности сечения элемента")
                {
                    double Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                    
                    double vivod = Math.Abs(Mult1 * 100 / (N * E));
                    
                    sila =
                       ($"\n$$e = (\\frac{{h}}{{2}}-a)-e_o=(\\frac{{{h}}}{{{2}}}-{a})-{e0.ToString("0.#")}={E.ToString("0.#")}\\text{{ см}};$$\n" +
                       $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                       "Продольная сила приложена между равнодействующими усилий в арматуре.");
                    vipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                     $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + vivod.ToString("0.##") + " ;\n";
                    nevipol1 = "\n Так как As=As', проверку выполняем по условию (8.21):\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
               "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + vivod.ToString("0.##") + " ;\n";
                   

                    rezultvipol =
                            ("\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                    if (e1 < (h0 - a1))
                    {

                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                        else if (Mult1 < (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                    double x2;
                    x2 = ((Rs * As / 10000 - N) / (Rb * b / 100)) * 100;
                    if (e1 > (h0 - a1))
                    {
                        sila =
                        ($"\n$$e = e_o-(\\frac{{h}}{{2}}-a)={e0.ToString("0.#")}-(\\frac{{{h}}}{{{2}}}-{a})={E.ToString("0.#")}\\text{{ см}};$$\n" +
                        $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                        "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.");
                        if (Mult1 >= (N * e1) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                        
                        else if (Mult1 < (N * e1) / 100 & Сжатая_зона.IsChecked == true & x2>0 & x2<2*a1 )
                        {
                            double x = ((Rs * As / 10000 - N) / (Rb * b / 100)) * 100;
                            double Mult = (Rb * b * x * (h0 - 0.5 * x)) / 1000000;

                            double prots = Math.Abs(Mult * 100 / (N * E));
                            nevipol4 = nevipol1 +
                                $"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{(As).ToString("0.##")} -{N}}}{{{(Rb / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{см}}>0;$$\n" +
                    $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                    $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                    $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                    $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n";
                            rezultvipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                           ($"\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                       "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");

                            if ((N * E / 100) > Mult)
                            {
                                nevipol4 = nevipol4 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                     "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else
                            {

                                nevipol4 = nevipol4 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n";
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }


                        }
                        else if (Mult1 < (N * e1) / 100 & (Сжатая_зона.IsChecked == false || Сжатая_зона.IsChecked == true & x2<0 || Сжатая_зона.IsChecked == true & x2>2*a1 || Сжатая_зона.IsChecked == true & x2 < 0 & x2 > 2 * a1))
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }
                    }
                }



                if (e1 < (h0 - a1) & Вид.SelectedItem == "Проверка прочности сечения элемента" & As != As1) //Если сила находится между усилиями!!!
                {

                    double Mult1 = (Rs * As * (h0 - a1)) / 1000000; //M'
                    double Mult = (Rs * As1 * (h0 - a1)) / 1000000; //M
                    //double E = h0 - a - e1;
                    double zapas = Math.Abs(Mult * 100 / (N * E));
                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));
                    //double defitsit = Math.Abs(Mult * 100 / (N * E));
                    //double defitsit1 = Math.Abs(Mult1 * 100 / (N * e1));
                    double As_pod = (N * e1 * 10000) / (Rs * (h0 - a1));
                    double As_pod1 = (N * E * 10000) / (Rs * (h0 - a1));
                    double vivod;

                    if (zapas1 < zapas)
                    {
                        vivod = zapas1;

                    }
                    else
                    {
                        vivod = zapas;

                    }

                   

                    sila =
                        ($"\n$$e = (\\frac{{h}}{{2}}-a)-e_o=(\\frac{{{h}}}{{{2}}}-{a})-{e0.ToString("0.#")}={E.ToString("0.#")}\\text{{ см}};$$\n" +
                        $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} < \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                        "Продольная сила приложена между равнодействующими усилий в арматуре.");


                    vipol1 =
                        ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                         $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                        "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n" +
                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                         $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                          "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n");

                    nevipol1 =
                        ($"\n$$M_{{ult}}= R_s A'_s (h_0-a') = {Rs / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")}\\text{{ кНм}};$$\n" +
                        $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n");
                    rezultvipol =
                           ("\n\\textbf{{Результаты расчета}}\n" +
                           "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                           "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    rezultnevipol =
                        ("\n\\textbf{{Результаты расчета}}\n" +
                        "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                    if ((N * E / 100) > Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }
                    else if ((N * E / 100) <= Mult)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                      "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas.ToString("0.##") + " ;\n";
                    }

                    nevipol1 = nevipol1 + $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n";

                    if ((N * e1 / 100) > Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                   "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }
                    else if ((N * e1 / 100) <= Mult1)
                    {
                        nevipol1 = nevipol1 + $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")}\\text{{ кНм}};$$\n" +
                    "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u= $" + zapas1.ToString("0.##") + " ;\n";
                    }

                    if (Mult >= (N * E) / 100 & Mult1 >= (N * e1) / 100) //Если моменты меньше предельных VIPOL1 
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false) //Условие выдачи отчета в ПДФ
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ= " + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila + vipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true); //Условие прочности выполняется
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }
                    else //Если моменты больше предельных NEVIPOL1
                    {
                        if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ =" + vivod.ToString("0.##") + Environment.NewLine);

                        }
                        else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ =" + vivod.ToString("0.##") + Environment.NewLine);

                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila + nevipol1, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                        else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                        {
                            Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                            Результаты.AppendText(" " + Environment.NewLine);
                            Результаты.AppendText("Коэффициент запаса прочности γ =" + vivod.ToString("0.##") + Environment.NewLine);
                            PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                        }
                    }

                }


                else if (e1 > (h0 - a1) & Вид.SelectedItem == "Проверка прочности сечения элемента" & As != As1) //Если сила не находится между усилиями
                {
                    //double x = ((Rs * As/10000 - Rsc * As1/10000 - N) / (Rb * γb1 * γb2 * γb3 * γb4 * γb5 * b/100))*100;
                    double x = ((Rs * As / 10000 - N) / (Rb  * b / 100)) * 100;
                    //double E = e0 - (h/2) + a;

                    double Mult1 = (Rs * As * (h0 - a1)) / 1000000;
                    double Mult = (Rs * As1 * (h0 - a1)) / 1000000;
                    double zapas = Math.Abs(Mult * 100 / (N * E));
                    double zapas1 = Math.Abs(Mult1 * 100 / (N * e1));
                    double defitsit = Math.Abs(Mult * 100 / (N * E));
                    double defitsit1 = Math.Abs((Mult1 * 100) / (N * e1));
                    double α = (N * e1 - (Rsc / 10000) * As1 * (h0 - a1)) / ((Rb / 10000)  * b * h0 * h0);
                    double ξ = 1 - Math.Sqrt(1 - 2 * α);
                    double αR = ξR * (1 - 0.5 * ξR);
                    double As_pod = (ξ * b * h0  * Rb / Rs) + (As1 * Rsc / Rs);
                    double As_pod3 = N * e1 * 10000 / (Rs * (h0 - a1));
                    double vivod;


                    sila1 =
                        ($"\n$$e = e_o-(\\frac{{h}}{{2}}-a)={e0.ToString("0.#")}-(\\frac{{{h}}}{{{2}}}-{a})={E.ToString("0.#")}\\text{{ см}};$$\n" +
                        $"\n$$e_0={e0.ToString("0.#")}\\text{{см}} > \\frac{{h}}{{2}}- a =\\frac{{{h}}}{{{2}}}- {a}= {(h / 2) - a} \\text{{ см}};$$\n" +
                        "Продольная сила приложена за пределами расстояния между равнодействующими усилий в арматуре.");

                    if (Сжатая_зона.IsChecked == true & x > 0 & x < (2 * a1)) ///////Допущение из сп
                    {


                        Mult = (Rb  * b * x * (h0 - 0.5 * x)) / 1000000;
                        double prots = Math.Abs(Mult * 100 / (N * E));
                        //double prots1 = Math.Abs(Mult1 * 100 / (N * e1));

                        vipol4 = // x>0 и <предельной
                        ($"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{As.ToString("0.##")}-{N}}}{{{((Rb ) / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={x.ToString("0.##")}\\text{{см}}>0;$$\n" +
                        $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                        $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                        $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb  / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                        "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");
                        nevipol4 =
                        ($"\n$$x=\\frac{{R_s\\cdot A_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{(As).ToString("0.##")} -{N}}}{{{(Rb/ 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{см}}>0;$$\n" +
                        $"\n$$x< {2} \\cdot a'=2 \\cdot{a1}={(2 * a1).ToString("0.#")}\\text{{см}};$$\n" +
                        $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                        $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                         "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");

                        rezultvipol =
                         ("\n\\textbf{{Результаты расчета}}\n" +
                         "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                         "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                        rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                        "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");


                        if (Mult >= (N * E) / 100)
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila1 + vipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }

                        }
                        else
                        {
                            if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                            }
                            else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila1 + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                            else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                            {
                                Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                Результаты.AppendText(" " + Environment.NewLine);
                                Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                            }
                        }

                    }
                    else if (Сжатая_зона.IsChecked == false || (Сжатая_зона.IsChecked == true & x < 0 & As != As1 || Сжатая_зона.IsChecked == true & x >= (2 * a1) & As != As1))
                    {

                        x = ((Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb  * b / 100)) * 100;

                        //Результаты.AppendText("Высота сжатой зоны x=" + x.ToString("0.#") + "см" + Environment.NewLine);


                        if (zapas1 < zapas)
                        {
                            vivod = zapas1;

                        }
                        else
                        {
                            vivod = zapas;

                        }

                        
                        rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                        rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");

                        if (x < ξR * h0 & x <= 0) //Если высота сжатой зоны меньше предельной и меньше нуля,составляем ур-я равновесий относительно 2х растянутых арматур
                        {
                            Mult1= (Rs * As * (h0 - a1)) / 1000000;
                            vivod = Math.Abs(Mult1 * 100 / (N * e1));
                            mom1 = //Считаем Х<0 
                           ($"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}} \\cdot {As.ToString("0.##")}- {Rsc / 1000}\\cdot 10^{{-1}} \\cdot {As1.ToString("0.##")} -{N}}}{{{(Rb ) / 1000}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{ см}}\\ngeq {{0}};$$\n" +
                           "Так так высота сжатой зоны меньше нуля, проверку выполняем по условию (8.21)");
                            rezultnevipol =
                            ($"\n\\textbf{{Результаты расчета}}\n" +
                            "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                            "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + "\n$\\ $\n");
                            vipol2 =

                        $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                        $"\n$$N e'={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                              "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";
                            nevipol2 =
                                 $"\n$$M_{{ult}}'= R_s A_s (h_0-a') ={Rs / 1000}\\cdot 10^{{3}}\\cdot{(As).ToString("0.##")} \\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 $"\n$$N e' ={N}\\cdot\\frac{{{e1.ToString("0.#")}}}{{100}} ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                             $"\n$$N e' ={(N * e1 / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}'={Mult1.ToString("0.#")} \\text{{ кНм}};$$\n" +
                                 "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + vivod.ToString("0.##") + " ;\n";



                            if (Mult1 >= (N * e1) / 100) // момент меньше предельного
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila1 + mom1 + vipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=  " + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else // моменты больше предельных
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila1 + mom1 + nevipol2, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + vivod.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }



                        else if (x > (ξR * h0) & x > 0) //Если высота сжатой зоны больше предельной и больше нуля/ Условие VIPOL3 
                        {
                            x = ξR * h0; //Присваиваем высоте сжатой зоны предельное значение
                            Mult = (Rb  * b * x * (h0 - 0.5 * x) + Rsc * As1 * (h0 - a1)) / 1000000;
                            double prots = Math.Abs((Mult * 100) / (N * E));


                            vipol3 = //x>0 и >предельной
                           ($"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{As.ToString("0.##")}-{Rsc / 1000}\\cdot 10^{{-1}}\\cdot {As1.ToString("0.##")} -{N}}}{{{((Rb ) / 1000).ToString("0.#")}\\cdot 10{{-1}}\\cdot {b}}}={((Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb * b / 10000)).ToString("0.##")}\\text{{см}}>0;$$\n" +
                           $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.##")}\\cdot{h0}={(x).ToString("0.##")}\\text{{см}};$$\n" +
                           $"\n$$ \\text{{Принимается: }} x=\\xi_R\\cdot h_0={(x).ToString("0.##")}\\text{{см}};$$\n" +
                           $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)+R_{{sc}}\\cdot A'_s\\cdot(h_0-a')={ (Rb  / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}+ $$\n" +
                            $"\n$${Rsc / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")} \\text{{ кНм}};$$\n" +
                           $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                           $"\n$$N e ={(N * E / 100).ToString("0.#")}\\text{{ кНм}}\\leq M_{{ult}}= {Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                        "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + " ;\n");


                            nevipol3 =
                                    ($"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{As.ToString("0.##")}-{Rsc / 1000}\\cdot 10^{{-1}}\\cdot {As1.ToString("0.##")} -{N}}}{{{((Rb ) / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={((Rs * As / 10000 - Rsc * As1 / 10000 - N) / (Rb * b / 10000)).ToString("0.##")}\\text{{см}}>0;$$\n" +
                                    $"\n$$x>\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(x).ToString("0.##")}\\text{{см}};$$\n" +
                                    $"\n$$\\text{{Принимается: }} x=\\xi_R\\cdot h_0={(x).ToString("0.##")}\\text{{см}};$$\n" +
                                    $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)+R_{{sc}}\\cdot A'_s\\cdot(h_0-a')={ (Rb/ 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}+ $$\n" +
                                    $"\n$${Rsc / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                                    $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                                    $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                                 "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + " ;\n");


                            //     $"\n\\text{{Определим необходимую площадь сечения растянутой арматуры:}}\n" +
                            //      $"\n$$ \\alpha_m= \\frac{{N\\cdot e-R_{{cs}} \\cdot A'_s \\cdot(h_0-a')}}{{Rb\\cdot b\\cdot (h_o)^{{2}}}}={α.ToString("0.##")};$$\n" +
                            //$"\n$$ \\xi_R=\\frac{{0.8}}{{1+\\frac{{\\varepsilon_{{s,el}}}}{{\\varepsilon_{{b2}} }} }}={ξR.ToString("0.##")};$$\n" +
                            // $"\n$$ \\alpha_R=\\xi_R \\cdot (1-0.5\\xi_R)= {αR.ToString("0.##")};$$\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                                ($"\n\\textbf{{Результаты расчета}}\n" +
                                "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                              "\n\\text{{Коэффициент запаса прочности }}" + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\ $\n");


                            if (Mult >= (N * E) / 100) //Вычислям по новой формуле для момента относительно единственной растянутой арматуры
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila1 + vipol3, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ= " + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                            else
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila1 + nevipol3, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }

                            }
                        }



                        else if (x < ξR * h0 & x > 0) //Если высота сжатой зоны меньше предельной но больше нуля VIPOL4  
                        {
                            Mult = (Rb * b * x * (h0 - 0.5 * x) + Rsc * As1 * (h0 - a1)) / 1000000;
                            double prots = Math.Abs(Mult * 100 / (N * E));

                            vipol4 = // x>0 и <предельной
                            ($"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{As.ToString("0.##")}-{Rsc / 1000}\\cdot 10^{{-1}}\\cdot {As1.ToString("0.##")} -{N}}}{{{((Rb ) / 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={x.ToString("0.##")}\\text{{см}}>0;$$\n" +
                            //$"\n$$x <\\xi_R\\cdot h = { (h * ξR).ToString("0.#") }\\text{{ см}}> 0,$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)+R_{{sc}}\\cdot A'_s\\cdot(h_0-a')={(Rb / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}+$$\n" +
                             $"\n$${Rsc / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\leq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            "\n Прочность сечения обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");
                            nevipol4 =
                            ($"\n$$x=\\frac{{R_s\\cdot A_s-Rsc\\cdot A'_s-N}}{{R_b\\cdot b}}=\\frac{{{Rs / 1000}\\cdot 10^{{-1}}\\cdot{(As).ToString("0.##")}-{Rsc / 1000}\\cdot 10^{{-1}}\\cdot {(As1).ToString("0.##")} -{N}}}{{{(Rb/ 1000).ToString("0.#")}\\cdot 10^{{-1}}\\cdot {b}}}={(x).ToString("0.##")}\\text{{см}}>0;$$\n" +
                            $"\n$$x<\\xi_R\\cdot h_0={ξR.ToString("0.#")}\\cdot{h0}={(ξR * h0).ToString("0.#")}\\text{{см}};$$\n" +
                            $"\n$$M_{{ult}}=R_b\\cdot b\\cdot x\\cdot(h_0-0,5\\cdot x)+R_{{sc}}\\cdot A'_s\\cdot(h_0-a')={(Rb  / 1000).ToString("0.#")}\\cdot 10^{{3}}\\cdot{b}\\cdot 10^{{-2}}\\cdot{(x).ToString("0.##")}\\cdot 10^{{-2}}\\cdot({h0}-0.5\\cdot{(x).ToString("0.##")})\\cdot 10^{{-2}}+$$\n" +
                             $"\n$${Rsc / 1000}\\cdot 10^{{3}}\\cdot{(As1).ToString("0.##")}\\cdot 10^{{-4}}\\cdot({h0}-{a1})\\cdot 10^{{-2}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                            $"\n$$N e ={N}\\cdot\\frac{{{E.ToString("0.#")}}}{{100}} ={(N * E / 100).ToString("0.#")} \\text{{ кНм}};$$\n" +
                            $"\n$$N e ={(N * E / 100).ToString("0.#")} \\text{{ кНм}}\\nleq M_{{ult}}={ Mult.ToString("0.#")} \\text{{ кНм}} ;$$\n" +
                             "\n Прочность сечения не обеспечена. Коэффициент запаса прочности " + $"$ \\gamma_u \\text{{= }} $" + prots.ToString("0.##") + "\n$\\;$\n");


                            //$"\n\\text{{Определим необходимую площадь сечения растянутой арматуры:}}\n" +
                            //  $"\n$$ \\alpha_m= \\frac{{N\\cdot e-R_{{cs}} \\cdot A'_s \\cdot(h_0-a')}}{{Rb\\cdot b\\cdot (h_o)^{{2}}}}={α.ToString("0.##")};$$\n" +
                            // $"\n$$ \\xi_R=\\frac{{0.8}}{{1+\\frac{{\\varepsilon_{{s,el}}}}{{\\varepsilon_{{b2}} }} }}={ξR.ToString("0.##")};$$\n" +
                            // $"\n$$ \\alpha_R=\\xi_R \\cdot (1-0.5\\xi_R)= {αR.ToString("0.##")};$$\n");
                            rezultvipol =
                             ("\n\\textbf{{Результаты расчета}}\n" +
                             "\n\\text{{Прочность сечения: }}" + "\\textbf{{ обеспечена}}\n" +
                             "\n Коэффициент запаса прочности " + $"$ \\gamma_u= $" + prots.ToString("0.##") + "\n$\\ $\n");
                            rezultnevipol =
                                ($"\n\\textbf{{Результаты расчета}}\n" +
                                "\n\\text{{Прочность сечения: }}" + "\\textbf{{ не обеспечена}}\n" +
                                "\n Коэффициент запаса прочности " + $"$ \\gamma_u= $" + prots.ToString("0.##") + "\n$\\ $\n");



                            if (Mult >= (N * E) / 100)
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol + "\n\\textbf{ }\n" + raschet + sila1 + vipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultvipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }

                            }
                            else
                            {
                                if (PDF.IsChecked == false & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                }
                                else if (PDF.IsChecked == true & Otchet1.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol + "\n\\textbf{ }\n" + raschet + sila1 + nevipol4, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                                else if (Otchet1.IsChecked == true & PDF.IsChecked == false)
                                {
                                    Результаты.AppendText("Прочность сечения: не обеспечена" + Environment.NewLine);
                                    Результаты.AppendText(" " + Environment.NewLine);
                                    Результаты.AppendText("Коэффициент запаса прочности γ=" + prots.ToString("0.##") + Environment.NewLine);
                                    PublishTEXtoPDF.publishToPdfTEX(name + ".tex", lya, PROEKT + DATA + ETACH + CONSTR + OSI + "\n\\textbf{ }\n" + COMMENT + An + rezultnevipol, System.Diagnostics.ProcessWindowStyle.Maximized, true);
                                }
                            }
                        }

                    }
                }
            }
        }

        
    }
}
