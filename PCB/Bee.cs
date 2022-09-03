using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_BEE
{
    class Bee
    {
        public int num_of_bees, m, n1, n2, e, m_e, itration = 0, num_comp;
        static Random rand = new Random(2);
        static Random randf = new Random(3);
        public Route[] bee;
        public Component[] board_comp1;
        public FirstType first;
        public SecondType second;
        public ThirdType third;

        public Bee(int type, int num_feeders, int num_components, double xBegin , double yBegin , double turret_time)
        {
            num_comp = num_components;
            board_comp1 = new Component[num_components];
            if (type == 2)
            {
                second = new SecondType(xBegin,yBegin);
                second.feeder = new Component[num_feeders];
            }
            else if (type == 3)
            {
                third = new ThirdType(turret_time);
                third.feeder = new Component[num_feeders];
            }
            else
                first = new FirstType(xBegin,yBegin);

        }

        //لازمني انو نوع الة لحتى عبي فيدراتها او لازم اعمل مصفوفة الفيدرات هون متل الكومبونانت
        public void set_feeder_component(int machine_type, int i, double x, double y, int type)
        {
            if (machine_type == 2)
            {
                second.feeder[i] = new Component();
                second.feeder[i].x = x;
                second.feeder[i].y = y;
                second.feeder[i].type = type;
            }
            if (machine_type == 3)
            {
                third.feeder[i] = new Component();
                third.feeder[i].x = x;
                third.feeder[i].y = y;
                third.feeder[i].type = type;
            }
        }
        public void set_board_component(int i, double x, double y, int type)
        {
            board_comp1[i] = new Component();
            board_comp1[i].x = x;
            board_comp1[i].y = y;
            board_comp1[i].type = type;
        }
        public Route[] generate_routes(int num_of_routes, int type)
        {
            Route[] generated_routes = new Route[num_of_routes];
            for (int i = 0; i < num_of_routes; i++)
            {
                generated_routes[i] = new Route(num_comp);
            }

            generated_routes[0].generate_route();
            if (type == 1)
            {
                //first = new FirstType();
                generated_routes[0].fitness = first.fitness(generated_routes[0].route, board_comp1);
            }
            else if (type == 2)
            {
                //second = new SecondType();
                generated_routes[0].fitness = second.fitness(generated_routes[0].route, board_comp1);
            }
            else 
            {
                generated_routes[0].fitness = third.fitness(generated_routes[0].route, board_comp1);
            
            }
            for (int i = 1; i < generated_routes.Length; i++)
            {
                generated_routes[i].generate_route();
                while (!validate_routes(i, generated_routes))
                    generated_routes[i].generate_route();
                if (type == 1)
                    generated_routes[i].fitness = first.fitness(generated_routes[i].route, board_comp1);
                else if (type == 2)
                    generated_routes[i].fitness = second.fitness(generated_routes[i].route, board_comp1);
                else
                    generated_routes[i].fitness = third.fitness(generated_routes[i].route, board_comp1);
            }
            return generated_routes;
        }

        public Boolean validate_routes(int n, Route[] route_to_validate)
        {
            Boolean x = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < route_to_validate[0].route.Count() ; j++)
                {
                    if (route_to_validate[n].route.ElementAt(j) != route_to_validate[i].route.ElementAt(j))
                    {
                        x = true;
                        break;
                    }
                    x = false;
                }
                if (x == false)//مشان مايكمل ع باقي المسارات 
                    return x;
            }
            return x;
        }

        public Route[] sort(Route[] sorted_route)
        {
            for (int i = 0; i < sorted_route.Length; i++)
                for (int j = i + 1; j < sorted_route.Length; j++)
                    if (sorted_route[i].fitness > sorted_route[j].fitness)
                    {
                        Route temp = sorted_route[i];
                        sorted_route[i] = sorted_route[j];
                        sorted_route[j] = temp;
                    }
            return sorted_route;
        }

        public void find_neighbour(int index_of_bee, int num_bee_ngh, int type_bee_ngh, int opts)
        {
            Route[] ngh_bees = new Route[num_bee_ngh];
            for (int i = 0; i < ngh_bees.Length; i++)
            {
                ngh_bees[i] = new Route(num_comp);
            }
            for (int i = 0; i < num_bee_ngh; i++)
            {

                int j1 = rand.Next(0, bee[0].num_comp);
                int j2 = rand.Next(0, bee[0].num_comp);
                while (j1 == j2)
                    j2 = rand.Next(0, bee[0].num_comp);

                if (opts == 1)
                {
                    int[] i1 = bee[index_of_bee].route.ToArray();
                    int temp = i1[j1];
                    i1[j1] = i1[j2];
                    i1[j2] = temp;
                    ngh_bees[i].route = i1.ToList();
                }
                else if (opts == 2)
                {
                    int j3 = rand.Next(0, bee[0].num_comp);
                    while (j3 == j1 || j3 == j2)
                        j3 = rand.Next(0, bee[0].num_comp);
                    int j4 = rand.Next(0, bee[0].num_comp);
                    while (j4 == j1 || j4 == j2 || j4 == j3)
                        j4 = rand.Next(0, bee[0].num_comp);

                    int[] i1 = bee[index_of_bee].route.ToArray();
                    //تبديل اول نقطتين
                    int temp = i1[j1];
                    i1[j1] = i1[j2];
                    i1[j2] = temp;
                    //تبديل ثاني نقطتين
                    temp = i1[j3];
                    i1[j3] = i1[j4];
                    i1[j4] = temp;
                    ngh_bees[i].route = i1.ToList();

                }
                //fitness for the neighbour route
                if (type_bee_ngh == 1)
                    ngh_bees[i].fitness = first.fitness(ngh_bees[i].route, board_comp1);
                else if (type_bee_ngh == 2)
                    ngh_bees[i].fitness = second.fitness(ngh_bees[i].route, board_comp1);
                else
                    ngh_bees[i].fitness = third.fitness(ngh_bees[i].route, board_comp1);
            }
            sort(ngh_bees);
            if (ngh_bees[0].fitness < bee[index_of_bee].fitness)
                bee[index_of_bee] = ngh_bees[0];
        }

        public Component[] feeder_arrangement(Component[] feeder)
        {
            Component[] new_feeders = feeder;
            int j1 = randf.Next(0, feeder.Count());
            int j2 = randf.Next(0, feeder.Count());
            while (j1 == j2)
                j2 = randf.Next(0, feeder.Count());

            int temp_type = new_feeders[j1].type;
            new_feeders[j1].type = new_feeders[j2].type;
            new_feeders[j2].type = temp_type;

            return new_feeders;
        }

        public void Run_Bee(int num_bees, int itr, int type, Boolean feeder_arrang, Boolean route_neighbour, int num_opts)
        {
            num_of_bees = num_bees;
            bee = new Route[num_bees];
            for (int i = 0; i < num_bees; i++)
            {
                bee[i] = new Route(num_comp);
            }
            bee = generate_routes(num_bees, type);
            bee = sort(bee);
            while (itration < itr)
            {
                if (route_neighbour)
                {
                    //bee = sort(bee);
                    m = rand.Next(2, num_bees);
                    e = rand.Next(1, m);
                    m_e = m - e;
                    n2 = rand.Next(1, num_bees);
                    n1 = rand.Next(1, n2);
                    for (int i = 0; i < e; i++)
                        find_neighbour(i, n2, type, num_opts);
                    for (int i = e; i < m; i++)
                        find_neighbour(i, n1, type, num_opts);
                    Route[] temp_bee = generate_routes(num_bees - m, type);

                    for (int i = m, j = 0; i < num_bees; i++, j++)
                        bee[i] = temp_bee[j];
                }
                if (feeder_arrang)
                {
                    if (type == 2)
                    {
                        second.feeder = feeder_arrangement(second.feeder);
                        for (int i = 0; i < num_bees; i++)
                            bee[i].fitness = second.fitness(bee[i].route, board_comp1);
                    }
                    if(type == 3)
                    {
                        third.feeder = feeder_arrangement(third.feeder);
                        for (int i = 0; i < num_bees; i++)
                            bee[i].fitness = third.fitness(bee[i].route, board_comp1);
                    }
                    
                }
                bee = sort(bee);
                itration++;
            }
        }

        public void Run_Bee_Random(int num_bees, int itr, int type, Boolean feeder_arrang, Boolean route_neighbour, int num_opts, int mm, int ee, int nn2, int nn1)
        {
            num_of_bees = num_bees;
            bee = new Route[num_bees];
            for (int i = 0; i < num_bees; i++)
            {
                bee[i] = new Route(num_comp);
            }
            bee = generate_routes(num_bees, type);
            bee = sort(bee);
            while (itration < itr)
            {
                if (route_neighbour)
                {
                    m = mm;
                    e = ee;
                    m_e = m - e;
                    n2 = nn2;
                    n1 = nn1;
                    for (int i = 0; i < e; i++)
                        find_neighbour(i, n2, type, num_opts);
                    for (int i = e; i < m; i++)
                        find_neighbour(i, n1, type, num_opts);

                    if (num_bees - m != 0)
                    {
                        Route[] temp_bee = generate_routes(num_bees - m, type);
                        for (int i = m, j = 0; i < num_bees; i++, j++)
                            bee[i] = temp_bee[j];
                    }
                }
                if (feeder_arrang)
                {
                    if (type == 2)
                    {
                        second.feeder = feeder_arrangement(second.feeder);
                        for (int i = 0; i < num_bees; i++)
                            bee[i].fitness = second.fitness(bee[i].route, board_comp1);
                    }
                    if (type == 3)
                    {
                        third.feeder = feeder_arrangement(third.feeder);
                        for (int i = 0; i < num_bees; i++)
                            bee[i].fitness = third.fitness(bee[i].route, board_comp1);
                    }
                }
                bee = sort(bee);
                itration++;
            }

        }
    
    
    }

}
