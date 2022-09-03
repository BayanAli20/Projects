using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_BEE
{
    class ThirdType
    {
        public Component[] feeder;
        public double turret;

        public ThirdType(double turret_time)
        {
            turret = turret_time;
        }

        public double fitness(List<int> r3, Component[] cordinate)
        {
            double fit_f = 0 , fit_c = 0 , fit_all=0;
            int t_beg, t_end;
            double xc, yc, xf, yf;
            int f1 =-1,f2 =-1;

            for (int i = 0; i < r3.Count()-2 ; i++)
			{
                t_beg = cordinate[r3.ElementAt(i)].type;
                t_end = cordinate[r3.ElementAt(i + 1)].type;
                for (int j = 0; j < feeder.Length ; j++)
                {
                    if (feeder[j].type == t_beg)
                        f1 = j;
                    if (feeder[j].type == t_end)
                        f2 = j;
                }
			    
                xf=  feeder[f2].x - feeder[f1].x;
                yf=  feeder[f2].y - feeder[f1].y;
                xf = Math.Pow(xf, 2.0);
                yf = Math.Pow(yf, 2.0);
                fit_f = Math.Sqrt(xf + yf);

                xc=  cordinate[r3.ElementAt(i+1)].x - cordinate[r3.ElementAt(i)].x ;
			    yc=  cordinate[r3.ElementAt(i+1)].y - cordinate[r3.ElementAt(i)].y ;
                xc = Math.Pow(xc, 2.0);
                yc = Math.Pow(yc, 2.0);
                fit_c = Math.Sqrt(xc + yc);

                fit_all+=max_of_fits(turret,fit_f,fit_c);

            }
            return fit_all;
            
        }
    
        public double max_of_fits(double tur,double fit_f,double fit_c)
        {
            double max=0;
            if (fit_f >= fit_c)
                max = fit_f;
            else
                max = fit_c;
            if (tur >= max)
                max = tur;

            return max;
        }
        
    }

        
}

