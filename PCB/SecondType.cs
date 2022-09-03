using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_BEE
{
    class SecondType
    {
        public Component[] feeder;
        private double x_beg;
        private double y_beg;

        public SecondType(double xBegin, double yBegin)
        {
            x_beg = xBegin;
            y_beg = yBegin;
        }

        public double fitness(List<int> r2, Component[] cordinate)
        {
            double fit = 0;
            int t_beg,t_end;
            Component current_feeder=new Component();
            double x, y;
                                        //لحساب المسافة من نقطة البدء الى الفييدر الأول
            t_beg = cordinate[r2.ElementAt(0)].type;
            for (int j = 0; j < feeder.Length; j++)
                if(feeder[j].type==t_beg)
                    current_feeder = feeder[j];
            x = current_feeder.x - x_beg;
            y = current_feeder.y - y_beg;
            x = Math.Pow(x, 2.0);
            y = Math.Pow(y, 2.0);
            fit += Math.Sqrt(x + y);
            
            for (int i = 0; i < cordinate.Length-2; i++)
            {
                t_beg = cordinate[r2.ElementAt(i)].type;
                t_end = cordinate[r2.ElementAt(i + 1)].type;
                                            //المسافة من الفييدر الحالي الى البورد
                x = cordinate[r2.ElementAt(i)].x - current_feeder.x;
                y = cordinate[r2.ElementAt(i)].y - current_feeder.y;
                x = Math.Pow(x, 2.0);
                y = Math.Pow(y, 2.0);
                fit += Math.Sqrt(x + y);

                                            //المسافة من البورد الى الفييدر القادم
                for (int j = 0; j < feeder.Length; j++)
                    if (feeder[j].type == t_end)
                        current_feeder = feeder[j];
                x = current_feeder.x - cordinate[r2.ElementAt(i)].x ;
                y = current_feeder.y - cordinate[r2.ElementAt(i)].y ;
                x = Math.Pow(x, 2.0);
                y = Math.Pow(y, 2.0);
                fit += Math.Sqrt(x + y);

            }                               //الذراع واقف عند الفييدر الخاص بالعنصر الأخير بالمسار
                                            //المسافة من الفييدر لآخر عنصر عالبورد
            t_end = cordinate[r2.ElementAt(r2.Count-1)].type;
            for (int j = 0; j < feeder.Length; j++)
                if (feeder[j].type == t_end)
                    current_feeder = feeder[j];
            x = cordinate[r2.ElementAt(r2.Count-1)].x - current_feeder.x;
            y = cordinate[r2.ElementAt(r2.Count-1)].y - current_feeder.y;
            x = Math.Pow(x, 2.0);
            y = Math.Pow(y, 2.0);
            fit += Math.Sqrt(x + y);
                                            //المسافة من العنصر الأخير على البورد الى نقطة البدء
            x = x_beg - cordinate[r2.ElementAt(r2.Count - 1)].x;
            y = y_beg - cordinate[r2.ElementAt(r2.Count - 1)].y;
            x = Math.Pow(x, 2.0);
            y = Math.Pow(y, 2.0);
            fit += Math.Sqrt(x + y);

            return fit;
        }
    }
}
