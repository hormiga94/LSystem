using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LSystem
{
    class LInformacje
    {
        public string aksjomat { get; set; }

        // REGUŁY ZAMIAN
        public string regula1 { get; set; }
        public string regula2 { get; set; }
        public string regula3 { get; set; }
        public string regula4 { get; set; }
        public string regula5 { get; set; }
        public string regula6 { get; set; }

        // ZMIENNA DO ZAMIANY
        public string z1 { get; set; }
        public string z2 { get; set; }
        public string z3 { get; set; }
        public string z4 { get; set; }
        public string z5 { get; set; }
        public string z6 { get; set; }

        public double kat { get; set; }
        public double krok { get; set; }
        public int powtorzenia { get; set; }

        // PRAWDOPODOBIEŃSTWA
        public double p1 { get; set; }
        public double p2 { get; set; }
        public double p3 { get; set; }
        public double p4 { get; set; }
        public double p5 { get; set; }
        public double p6 { get; set; }

        private Canvas myCanva= new Canvas();
        public LInformacje()
        {

        }

        public Canvas LRysowanie()
        {
            Point point1 = new Point(300,200);
            Point point2 = new Point();

            List<char> regulatmp = aksjomat.ToList<char>();
            List<char> regulatmpoint2 = new List<char>();

            Random random = new Random();
            double los;

            Brush brush = Brushes.Teal;
            Brush brushtmp = brush;


            for (int j = 0; j < powtorzenia; j++)
                {
                    foreach (var i in regulatmp)
                    {
                    
                    los = random.NextDouble();

                    if (i == z1.ToCharArray().ElementAt(0) && p1 <= los) regulatmpoint2.AddRange(regula1.ToList<char>());


                        if (z2 != "" && p2 <= los)
                            if (i == z2.ToCharArray().ElementAt(0)) regulatmpoint2.AddRange(regula2.ToList<char>());


                    if (z3 != "" && p3 <= los)
                            if (i == z3.ToCharArray().ElementAt(0)) regulatmpoint2.AddRange(regula3.ToList<char>());

                    if (z4 != "" && p4 <= los)
                            if (i == z4.ToCharArray().ElementAt(0)) regulatmpoint2.AddRange(regula4.ToList<char>());

                    if (z5 != "" && p5 <= los)
                            if (i == z5.ToCharArray().ElementAt(0)) regulatmpoint2.AddRange(regula5.ToList<char>());

                    if (z6 != "" && p6 <= los)
                            if (i == z6.ToCharArray().ElementAt(0)) regulatmpoint2.AddRange(regula6.ToList<char>());

                    string st = i.ToString();
                        if (st != z1 && st != z2 && st != z3 && st != z4 && st != z5 && st != z6) regulatmpoint2.Add(i);
                    }
                    regulatmp = new List<char>();
                    regulatmp.AddRange(regulatmpoint2);
                    regulatmpoint2.Clear();
               }

            
            double newX = point1.X;
            double newY = point1.Y;
            double newKat = kat;
            double ox= 0, oy= 0;
            Stack<double> stosX = new Stack<double>();
            Stack<double> stosY = new Stack<double>();
            Stack<double> stosKat = new Stack<double>();
        
  
                foreach (char c in regulatmp) 
                {
                    switch (c)
                    {
                        case 'F':
                            newX += ox;
                            newY += oy;
                            point2 = new Point(newX, newY);
                            myCanva = LLine(point1, point2, brush);
                            point1 = point2;
                            break;

                        case 'f':
                            newX += ox;
                            newY += oy;
                            point2 = new Point(newX, newY);
                            brushtmp = brush;
                            brush = Brushes.Transparent;
                            myCanva = LLine(point1, point2, brush);
                            brush = brushtmp;
                            point1 = point2;
                            break;

                        case '+':
                            newKat += kat;
                            ox = Math.Cos(newKat * Math.PI / 180) * krok;
                            oy = Math.Sin(newKat * Math.PI / 180) * krok;

                            break;

                        case '-':
                            newKat -= kat;
                            ox = Math.Cos(newKat * Math.PI / 180) * krok;
                            oy = Math.Sin(newKat * Math.PI / 180) * krok;
                            break;

                        case '[':
                            stosX.Push(newX);
                            stosY.Push(newY);
                            stosKat.Push(newKat);
                            break;

                        case ']':
                            newX = stosX.Pop();
                            newY = stosY.Pop();
                            newKat = stosKat.Pop();
                            point2 = new Point(newX, newY);
                            brushtmp = brush;
                            brush = Brushes.Transparent;
                            myCanva = LLine(point1, point2, brush);
                            brush = brushtmp;
                            point1 = point2;
                            break;

                        case 'R':
                            brush = Brushes.Red;
                            break;
                        case 'G':
                            brush = Brushes.Green;
                            break;
                        case 'B':
                            brush = Brushes.DodgerBlue;
                            break;
                        case 'T':
                            brush = Brushes.Teal;
                            break;
                        case 'O':
                            brush = Brushes.Orange;
                            break;
                    }
                }
            return myCanva;
        }

        private Canvas LLine(Point point1, Point point2, Brush brush)
        {
            Line myLine = new Line();

            myLine.Stroke = brush;

            myLine.X1 = point1.X;
            myLine.Y1 = point1.Y;

            myLine.X2 = point2.X;
            myLine.Y2 = point2.Y;

            myLine.HorizontalAlignment = HorizontalAlignment.Center;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            
            myCanva.Children.Add(myLine);
            myCanva.VerticalAlignment = VerticalAlignment.Center;
            myCanva.HorizontalAlignment = HorizontalAlignment.Center;

            return myCanva;
        }


    }
}
