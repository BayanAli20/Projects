using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_BEE
{
    class Route
    {
        public int num_comp;
        public List<int> route;
        static Random r = new Random(3);
        public double fitness;
        public Route(int n_comp)
        { 
            num_comp = n_comp;
        }
        public void generate_route()
        {

            route = new List<int>();
            int x;
            x = r.Next(0, num_comp);
            route.Add(x);
            
            for (int i = 1; i < num_comp; i++)
            {
                x = r.Next(0, num_comp);
                while (route.Contains(x))
                    x = r.Next(0, num_comp);
                route.Add(x);
            }
        }
    }
}
