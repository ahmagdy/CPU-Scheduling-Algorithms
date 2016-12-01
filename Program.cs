using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;


namespace CPUSchedulingAlgorithms
{

    class Program
    {
        static void Main(string[] args)
        {
            List<SJFModel> m1 = new List<SJFModel>();
            string pn;
            int bu, at;
            while (true)
            {

                Console.Write("Enter the name of The Process: ");
                pn = Console.ReadLine();
                if (pn == string.Empty) break;
                Console.Write("Enter the Arrive Time: ");
                at = int.Parse(Console.ReadLine());
                Console.Write("Enter the Burst Time: ");
                bu = int.Parse(Console.ReadLine());
                m1.Add(new SJFModel(pn,  bu, at));
            }

            SchedulingAlgorithms.SJFPreemptive(m1);
            List<HashModel> h = new List<HashModel>
            {
                new HashModel("P1", 12),
                new HashModel("P2", 8),
                new HashModel("P3", 4),
                new HashModel("P4", 10),
                new HashModel("P5", 5)
                //new HashModel("P1", 10),
                //new HashModel("P2", 1),
                //new HashModel("P3", 2),
                //new HashModel("P4", 1),
                //new HashModel("P5", 5)
                //new HashModel("P1", 6),
                //new HashModel("P2", 5),
                //new HashModel("P3", 2),
                //new HashModel("P4", 3),
                //new HashModel("P5", 7)
            };
            SchedulingAlgorithms.RoundRubin(h, 5);
            List<SJFModel> m2 = new List<SJFModel>()
            {
				new SJFModel("P1", 7, 0),
                new SJFModel("P2", 4, 2),
                new SJFModel("P3", 1, 4),
                new SJFModel("P4", 4, 5)

            };
            SchedulingAlgorithms.SJFPreemptive(m2);
            List<SJFModel> m = new List<SJFModel>()
            {
				new SJFModel("P1", 8, 0),
                new SJFModel("P2", 4, 1),
                new SJFModel("P3", 9, 2),
                new SJFModel("P4", 5, 3)

            };
            SchedulingAlgorithms.SJFPreemptive(m);
			
			List<SJFModel> m = new List<SJFModel>()
            {
                new SJFModel("P1",7,0),
                new SJFModel("P2",4,2),
                new SJFModel("P3",1,4),
                new SJFModel("P4",4,5),
            };
            SchedulingAlgorithms.SJFNonPreemptive(m);
			
			List<SJFModel> m = new List<SJFModel>
            {
				new SJFModel("P1",3,0),
                new SJFModel("P2",2,1),
                new SJFModel("P3",1,2)

            };
            SchedulingAlgorithms.RoundRubinAT(m,2);
			
			List<PriorityModel> p = new List<PriorityModel>()
            {
                new PriorityModel("P1",10,3),
                new PriorityModel("P2",1,1),
                new PriorityModel("P3",2,4),
                new PriorityModel("P4",1,5),
                new PriorityModel("P5",5,2)
			};
            SchedulingAlgorithms.Priority(p);

        }
    }

}
