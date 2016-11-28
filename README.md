# CPU-Scheduling-Algorithms
A Simple Simulation to Scheduling Algorithms.
* First Come First Serve (FCFS)
* Shortest Job First (SJF) Preemptive
* Shortest Job First (SJF) Non-Preemptive
* RoundRubin

##Examples:

```C#
            List<FCFSModel> m = new List<FCFSModel>()
            {
                new FCFSModel("P1",0,24),
                new FCFSModel("P2",0,3),
                new FCFSModel("P3",0,3)
            };
            SchedulingAlgorithms.FCFS(m);
```

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
                m1.Add(new SJFModel(pn,  bu, at));
            }

            SchedulingAlgorithms.SJFPreemptive(m1);
            
            
            List<SJFModel> m = new List<SJFModel>()
            {
                new SJFModel("P1", 8, 0),
                new SJFModel("P2", 4, 1),
                new SJFModel("P3", 9, 2),
                new SJFModel("P4", 5, 3)

            };
            SchedulingAlgorithms.SJFPreemptive(m);
```
```C#
            List<SJFModel> m = new List<SJFModel>()
            {
                new SJFModel("P1",7,0),
                new SJFModel("P2",4,2),
                new SJFModel("P3",1,4),
                new SJFModel("P4",4,5),
            };
            SchedulingAlgorithms.SJFNonPreemptive(m);
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
