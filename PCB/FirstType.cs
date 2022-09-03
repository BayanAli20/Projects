using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_BEE
{
    class FirstType
    {
        private double x_beg;
        private double y_beg;

        public FirstType(double xBegin,double yBegin)
        {
            x_beg = xBegin;
            y_beg = yBegin;
        }

        public double fitness(List<int> r1, Component[] cordinate)
        {   
            double fit = 0;
            double x, y;

            //لحساب المسافة من نقطة البدء لأول عنصر بالبورد
            x = cordinate[r1.ElementAt(0)].x - x_beg;
            y = cordinate[r1.ElementAt(0)].y - y_beg;
            x = Math.Pow(x, 2.0);
            y = Math.Pow(y, 2.0);
            fit += Math.Sqrt(x + y);
            
            for (int i = 0; i < cordinate.Length-1 ; i++)
            {
                x = cordinate[r1.ElementAt(i + 1)].x - cordinate[r1.ElementAt(i)].x;
                y = cordinate[r1.ElementAt(i + 1)].y - cordinate[r1.ElementAt(i)].y;

                x = Math.Pow(x, 2.0);
                y = Math.Pow(y, 2.0);

                fit += Math.Sqrt(x + y);
            }

            //لحساب المسافة من اخر عنصر بالبورد الى  نقطة البدء
            x = x_beg - cordinate[r1.ElementAt(r1.Count() - 1)].x;
            y = y_beg - cordinate[r1.ElementAt(r1.Count() - 1)].y;
            x = Math.Pow(x, 2.0);
            y = Math.Pow(y, 2.0);
            fit += Math.Sqrt(x + y);
            
            return fit;
        }

    }
}

