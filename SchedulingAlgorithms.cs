using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSchedulingAlgorithms
{
    public class SJFModel
    {
        public SJFModel(string processName, int BurstTime, int ArriveTime=0)
        {
            this.ProcessName = processName;
            this.ArriveTime = ArriveTime;
            this.BurstTime = BurstTime;
        }

        public string ProcessName { get; set; }
        public int ArriveTime { get; set; }
        public int BurstTime { get; set; }
        public int WT { get; set; } = 0;
        public int LastEnd { get; set; } = 0;
    }

    public class HashModel
    {
        public HashModel(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public int Value { get; set; }
        public int WT { get; set; } = 0;
        public int LastEnd { get; set; } = 0;
    }
    
    public class FCFSModel
    {
        public FCFSModel(string Name,int AT,int BT)
        {
            this.Name = Name;
            this.AT = AT;
            this.BT = BT;
        }

        public string Name { get; set; }
        public int AT { get; set; }
        public int BT { get; set; }
        public int WT { get; set; }
    }
	
	public class PriorityModel
    {
        public PriorityModel(string name, int burstTime,int priority)
        {
            this.Name = name;
            this.BurstTime = burstTime;
            this.Priority = priority;
        }
        public string Name { get; set; }
        public int BurstTime { get; set; }
        public int Priority { get; set; }
        public int WT { get; set; } = 0;

    }

    public class SchedulingAlgorithms
    {
        public static void SJFPreemptive(IList<SJFModel> sjfModels)
        {
            string tempElementName = string.Empty;
            SJFModel tempElement;
            for (int i = 0;; i++)
            {

                tempElement =
                    sjfModels.Where(e => e.ArriveTime <= i && e.BurstTime > 0)
                        .OrderBy(e => e.BurstTime)
                        .FirstOrDefault();
                if (tempElement == null)
                {
                    Console.WriteLine($"|{0}|\t {i}");
                    break;
                }

                tempElement.BurstTime -= 1;
                //if (item.ArriveTime < counter) continue;
                if (tempElementName == tempElement.ProcessName) continue;

                if (i != 0)
                {
                    Console.WriteLine(
                        $"|{sjfModels.FirstOrDefault(x => x.ProcessName == tempElementName).BurstTime}|\t {i}");
                    sjfModels.FirstOrDefault(x => x.ProcessName == tempElementName).LastEnd = i;
                }

                Console.Write($"{i}\t({tempElement.ProcessName})");

                tempElementName = tempElement.ProcessName;

                tempElement.WT = tempElement.LastEnd == 0
                    ? i - tempElement.ArriveTime
                    : i - tempElement.LastEnd;
            }
            int sum = 0;
            sum = sjfModels.Sum(x => x.WT);
            //foreach (var item in sjfModels)
            //{
            //    sum += item.WT;
            //}
            Console.WriteLine($"AWT is = {(double) sum/sjfModels.Count} ");
        }
		
		public static void SJFNonPreemptive(IList<SJFModel> sjfModels)
        {
            SJFModel holder;
            int counter = 0;
            while (true)
            {
                holder = sjfModels.Where(i => i.ArriveTime <= counter && i.BurstTime >0)
                    .OrderBy(x => x.BurstTime).FirstOrDefault();
                if(holder == null) break;
                holder.WT = counter - holder.ArriveTime;
                Console.Write($"{counter}\t {holder.ProcessName} ({holder.BurstTime})\t ");
                counter += holder.BurstTime;
                holder.BurstTime -= holder.BurstTime;
                Console.WriteLine(counter);
            }

            int sum = 0;
            sum = sjfModels.Sum(x => x.WT);
            Console.WriteLine($"AWT is = {(double)sum / sjfModels.Count} ");

        }
		

        public static void RoundRubin(List<HashModel> testHashModels, int quantum)
        {
            int tempbegin = 0;
            string highest = "";
            bool outx = false;
            highest = testHashModels.FirstOrDefault(x => x.Value == testHashModels.Max(p => p.Value)).Name;

            for (;;)
            {
                foreach (var item in testHashModels)
                {
                    if (item.Value < 1)
                        continue;
                    Console.Write(tempbegin + "\t");
                    Console.Write($"{item.Name} ({item.Value})");
                    item.WT = tempbegin - item.LastEnd + item.WT;
                    if (item.Value - quantum < 0)
                    {
                        tempbegin += item.Value;
                        item.Value -= item.Value;
                    }

                    else
                    {
                        item.Value -= quantum;
                        tempbegin += quantum;
                    }

                    Console.Write($"||{item.Value}\t");
                    Console.WriteLine(tempbegin);
                    if (item.Name == highest && item.Value < 1) outx = true;
                    item.LastEnd = tempbegin;
                }
                if (outx) break;

            }
            testHashModels.ForEach(x => Console.WriteLine(x.WT));
            int sum = testHashModels.Sum(x => x.WT);
            Console.WriteLine($"AWT  = {sum/testHashModels.Count}");
        }
		
		 //RoundRubin With Arrive Time
        public static void RoundRubinAT(List<SJFModel> models, int quantum)
        {
			models = models.OrderBy(x => x.ArriveTime).ToList();
            int tempbegin = 0;
            string tempname = "";
            bool outx = false;
            var temList  = models.Where(x => x.ArriveTime <= tempbegin && x.BurstTime > 0).ToList(); 
            for (;;)
            {
                
                foreach (var item in temList)
                {
                    if (item.ProcessName.Equals(tempname) && temList.Count > 1)
                        continue;
                    Console.Write(tempbegin + "\t");
                    Console.Write($"{item.ProcessName} ({item.BurstTime})");
                    item.WT = tempbegin - item.LastEnd - item.ArriveTime + item.WT;
                    item.ArriveTime = 0;
                    if (item.BurstTime - quantum < 0)
                    {
                        tempbegin += item.BurstTime;
                        item.BurstTime -= item.BurstTime;
                    }

                    else
                    {
                        item.BurstTime -= quantum;
                        tempbegin += quantum;
                    }

                    Console.Write($"||{item.BurstTime}\t");
                    Console.WriteLine(tempbegin);
                    
                    item.LastEnd = tempbegin;
                    tempname = item.ProcessName;
                    temList = models.Where(x => x.ArriveTime <= tempbegin && x.BurstTime > 0).OrderBy(x=> x.LastEnd).ToList();
                    if (temList.Count <1) outx = true;
                }
                if (outx) break;

            }
            models.ForEach(x => Console.WriteLine($"{x.ProcessName}:  {x.WT}"));
            int sum = models.Sum(x => x.WT);
            Console.WriteLine($"AWT  = {sum / models.Count}");
        }
		
        
         public static void FCFS(ICollection<FCFSModel> models)
        {
            models = models.OrderBy(p => p.AT).ToList();
            int counter = 0;
            foreach (var item in models)
            {
                item.WT = counter;
                Console.Write($"{counter}\t {item.Name}({item.BT})\t");
                counter += item.BT;
                Console.WriteLine(counter);
            }
            int sum = models.Sum(x => x.WT);
            Console.WriteLine($"AWT  = {sum / models.Count}");
        }
		
		public static void Priority(IList<PriorityModel> models)
        {
            models = models.OrderBy(i => i.Priority).ToList();
            int counter = 0;
            foreach (var item in models)
            {
                Console.Write($"{counter}\t |{item.Name}({item.Priority})|\t");
                item.WT = counter;
                counter += item.BurstTime;
                item.BurstTime -= item.BurstTime;
                Console.WriteLine(counter);
            }
            int sum = models.Sum(x => x.WT);
            Console.WriteLine($"AWT is = {(double) sum/models.Count} ");

        }
        
    }

}
