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


namespace LSystem
{

    #region SYMBOLE
    /*
    F- krok w przód o długości d
    f- krok w przód o długości d bez rysowania
    +- obrót o określony kąt w prawo
    -- obrót o określony kąt w lewo
    [- wrzucenie bierzącego stanu na stos.
        Zapamiętanie pozycji żółwia, koloru, grubości rysowanej linii itp.
    ]- bieżącym stanem staje się stan pobrany ze szczytu stosu
       Żółw nie rysuje przy tym żadnych linii, choć jego pozycja może się zmienić
    R,G,B,T - kolory pędzla

    Użytkownik podaje symbol startowy, kąt, rozmiar kroku, regułę (z kolorami)
     */
    #endregion


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myCanva.Children.Clear();

            LInformacje informacje = new LInformacje();
            informacje.aksjomat = lAksjomat.Text;

            informacje.z1 = z1.Text;
            informacje.regula1 = lRegula.Text;
            informacje.p1 = Convert.ToDouble(p1.Text);


            if (lRegula2.Text != null && z2.Text != null)
            {
                informacje.z2 = z2.Text;
                informacje.regula2 = lRegula2.Text;
                informacje.p2 = Convert.ToDouble(p2.Text);
            }


            if (lRegula3.Text != null && z3.Text != null)
            {
                informacje.z3 = z3.Text;
                informacje.regula3 = lRegula3.Text;
                informacje.p3 = Convert.ToDouble(p3.Text);
            }

            if (lRegula4.Text != null && z3.Text != null)
            {
                informacje.z4 = z4.Text;
                informacje.regula4 = lRegula4.Text;
                informacje.p4 = Convert.ToDouble(p4.Text);
            }

            if (lRegula5.Text != null && z5.Text != null)
            {
                informacje.z5 = z5.Text;
                informacje.regula5 = lRegula5.Text;
                informacje.p5 = Convert.ToDouble(p5.Text);
            }

            if (lRegula6.Text != null && z6.Text != null)
            {
                informacje.z6 = z6.Text;
                informacje.regula6 = lRegula6.Text;
                informacje.p5 = Convert.ToDouble(p5.Text);
            }

            informacje.kat = Convert.ToDouble(lKat.Text);
            informacje.krok = Convert.ToDouble(lKrok.Text);
            informacje.powtorzenia = Convert.ToInt32(lPowtorki.Text);

            Canvas myCanvax = informacje.LRysowanie();
            
            var childrenList = myCanvax.Children.Cast<UIElement>().ToArray();
            foreach (var c in childrenList)
            {
                myCanvax.Children.Remove(c);
                myCanva.Children.Add(c);
            }

            if (dany == true)
            {
                BitmapImage btm = new BitmapImage(new Uri("dany.jpg", UriKind.Relative));
                Image img = new Image();
                img.Source = btm;
                img.Stretch = Stretch.Fill;
                img.Width = 230;
                img.Height = 200;
                img.Margin = new Thickness(350, 0, 0, 0);
                myCanva.Children.Add(img);
                dany = false;
            }
        }

        private void ButtonW_Click(object sender, RoutedEventArgs e)
        {
            myCanva.Children.Clear();
            CleanForm();
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var element = sender as UIElement;
            var position = e.GetPosition(element);
            var transform = element.RenderTransform as MatrixTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1);

            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
        }

        private void PrzykladzikW(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedInt = comboPrzyklady.SelectedIndex;

            switch (selectedInt)
            {
                
                case 0: // KRZYWA HILBERTA
                    CleanForm();
                    comboNumerki.SelectedIndex = 1;
                    lAksjomat.Text = "X";

                    z1.Text = "X";
                    lRegula.Text = "-YF+XFX+FY-";

                    z2.Text = "Y";
                    lRegula2.Text = "+XF-YFY-FX+";

                    lPowtorki.Text = "5";
                    
                    lKat.Text = "90";
                    lKrok.Text = "7";
                    
                    break;
                
                case 1: // TRÓJKĄT SIERPIŃSKIEGO
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F+F+F";
                    lPowtorki.Text = "4";
                    lRegula.Text = "F+F-F-F+F";
                    lKat.Text = "120";
                    lKrok.Text = "10";
                    z1.Text = "F";
                    break;

                case 2: // PŁATEK ŚNIEGU KOCH'A
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F++F++F";
                    lPowtorki.Text = "3";
                    lRegula.Text = "F-F++F-F";
                    lKat.Text = "60";
                    lKrok.Text = "5";
                    z1.Text = "F";
                    break;

                case 3: // KRZYWA PEANO
                    CleanForm();
                    comboNumerki.SelectedIndex = 1;
                    lAksjomat.Text = "X";

                    z1.Text = "X";
                    lRegula.Text = "XFYFX+F+YFXFY-F-XFYFX";

                    z2.Text = "Y";
                    lRegula2.Text = "YFXFY-F-XFYFX+F+YFXFY";

                    lPowtorki.Text = "3";

                    lKat.Text = "90";
                    lKrok.Text = "7";
                    break;

                case 4: // SMOK HEIGHWAY'A
                    CleanForm();
                    comboNumerki.SelectedIndex = 1;
                    lAksjomat.Text = "FX";

                    z1.Text = "X";
                    lRegula.Text = "X+YF+";

                    z2.Text = "Y";
                    lRegula2.Text = "-FX-Y";

                    lPowtorki.Text = "10";

                    lKat.Text = "90";
                    lKrok.Text = "7";
                    break;

                case 5: // SMOK LEVY'EGO
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F";
                    lPowtorki.Text = "11";
                    lRegula.Text = "+F--F+";
                    lKat.Text = "45";
                    lKrok.Text = "5";
                    z1.Text = "F";

                    dany = true; // easter egg
                    break;

                case 6: // PENTADENDRYT
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F";
                    lPowtorki.Text = "4";
                    lRegula.Text = "RF+RF-OF--GF+RF+RF";
                    lKat.Text = "72";
                    lKrok.Text = "5";
                    z1.Text = "F";
                    break;

                case 7: // GAŁĄŹ 1
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F";
                    lPowtorki.Text = "4";
                    lRegula.Text = "F[+F]F[-F]F";
                    lKat.Text = "25,7";
                    lKrok.Text = "4";
                    z1.Text = "F";
                    break;

                case 8: // GAŁĄŹ 2
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "----F";
                    lPowtorki.Text = "3";
                    lRegula.Text = "FF+[+F-F-F]-[-F+F+F]";
                    lKat.Text = "22,5";
                    lKrok.Text = "7";
                    z1.Text = "F";
                    break;

                case 9: // Penrose Tiling
                    CleanForm();
                    comboNumerki.SelectedIndex = 4;
                    lAksjomat.Text = "[X]++[X]++[X]++[X]++[X]";

                    z1.Text = "W";
                    lRegula.Text = "YF++ZF----XF[-YF----WF]++";

                    z2.Text = "X";
                    lRegula2.Text = "+YF--ZF[---WF--XF]+";

                    z3.Text = "Y";
                    lRegula3.Text = "-WF++XF[+++YF++ZF]-";

                    z4.Text = "Z";
                    lRegula4.Text = "--YF++++WF[+ZF++++XF]--XF";

                    z5.Text = "F";
                    lRegula5.Text = " ";

                    lPowtorki.Text = "3";

                    lKat.Text = "36";
                    lKrok.Text = "10";
                    break;

                case 10: // KWADRAT SIERPIŃSKIEGO
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F+XF+F+XF";
                    z1.Text = "X";
                    lRegula.Text = "XF-F+F-XF+F+XF-F+F-X";
                    lPowtorki.Text = "4";
                    lKat.Text = "90";
                    lKrok.Text = "5";
                    break;

                case 11: // KOŁA
                    CleanForm();
                    comboNumerki.SelectedIndex = 0;
                    lAksjomat.Text = "F+F+F+F";
                    lPowtorki.Text = "3";
                    lRegula.Text = "FF+F+F+F+F+F-F";
                    lKat.Text = "90";
                    lKrok.Text = "5";
                    z1.Text = "F";
                    break;

                case 12: // KRZYWA GOSPERA
                    CleanForm();
                    comboNumerki.SelectedIndex = 1;
                    lAksjomat.Text = "XF";

                    z1.Text = "X";
                    lRegula.Text = "X+YF++YF-FX--FXFX-YF+";

                    z2.Text = "Y";
                    lRegula2.Text = "-FX+YFYF++YF+FX--FX-Y";

                    lPowtorki.Text = "4";

                    lKat.Text = "60";
                    lKrok.Text = "5";
                    break;

                case 13: // KOLOROWY KRZAK
                    CleanForm();
                    comboNumerki.SelectedIndex = 1;
                    lAksjomat.Text = "X";

                    z1.Text = "X";
                    lRegula.Text = "RF[G[X]+X]+GF[G+FX]-X";

                    z2.Text = "F";
                    lRegula2.Text = "FF";

                    lPowtorki.Text = "4";

                    lKat.Text = "-25";
                    lKrok.Text = "5";
                    break;
            }

        }

        private void CleanForm()
        {
            foreach (UIElement element in myGrid.Children)
            {
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }  
            }

            p1.Text = "0";
            p2.Text = "0";
            p3.Text = "0";
            p4.Text = "0";
            p5.Text = "0";
            p6.Text = "0";
        }

        private bool dany = false;
    }
}
