# CPU-Scheduling-Algorithms
A Simple Simulation to Scheduling Algorithms.
* Shortest Job First (SJF) Preemptive
* RoundRubin

##Examples:

```C#
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
                m1.Add(new SJFModel(pn, at, bu));
            }

            SchedulingAlgorithms.SJFPreemptive(m1);
            
            
            List<SJFModel> m = new List<SJFModel>()
            {
                new SJFModel("P1", 0, 8),
                new SJFModel("P2", 1, 4),
                new SJFModel("P3", 2, 9),
                new SJFModel("P4", 3, 5)

            };
            SchedulingAlgorithms.SJFPreemptive(m);
```

```C#
             List<HashModel> h = new List<HashModel>
            {
                new HashModel("P1", 12),
                new HashModel("P2", 8),
                new HashModel("P3", 4),
                new HashModel("P4", 10),
                new HashModel("P5", 5)
                 };
            SchedulingAlgorithms.RoundRubin(h, 5);
```
