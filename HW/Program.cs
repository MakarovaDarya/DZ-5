using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class Program
    {
        public class Villager
        {
            public string name;
            public short numberOfpasport;
            public string problem;
            public int scandalousness;
            public bool isSmart;

            public Villager(string name, short numberOfpasport, string problem, int scandalousness, bool isSmart)
            {
                this.name = name;
                this.numberOfpasport = numberOfpasport;
                this.problem = problem;
                this.scandalousness = scandalousness;
                this.isSmart = isSmart;
            }

        }
        public class Check
        {
            public bool UserInutWithCheckInteger(out int userNumber)
            {
                Console.WriteLine("Введите число:");
                while (!int.TryParse(Console.ReadLine(), out userNumber))
                {
                    Console.WriteLine("Ошибка, введите число");
                }
                return true;
            }
        }
        public class Window
        {
            Check check = new Check();
            public string problem;
            public List<Villager> notSortedQueueVilagers = new List<Villager>();
            public Queue<Villager> queueVilagers;
            public void PrintAllVillagers()
            {
                for (int i = 0; i < notSortedQueueVilagers.Count; i++)
                {
                    Console.WriteLine(i + ": " + notSortedQueueVilagers[i].name);
                }
            }
            public void SortVillagers()
            {
                Console.WriteLine("Окно " + problem);
                PrintAllVillagers();
                for (int i = 0; i < notSortedQueueVilagers.Count; i++)
                {
                    if (notSortedQueueVilagers[i].scandalousness >= 5)
                    {
                        int userChoose;
                        Console.Write(notSortedQueueVilagers[i].name + " очень наглый/ая. Скольких он обгонит? ");
                        check.UserInutWithCheckInteger(out userChoose);
                        if (i - userChoose > 0)
                        {
                            Villager rotate = notSortedQueueVilagers[i - userChoose];
                            notSortedQueueVilagers[i - userChoose] = notSortedQueueVilagers[i];
                            notSortedQueueVilagers[i] = rotate;
                        }
                    }
                }
                queueVilagers = new Queue<Villager>(notSortedQueueVilagers);
            }
            public void WorkWithVillager()
            {
                while (queueVilagers.Count > 0)
                {
                    Villager villager = queueVilagers.Dequeue();
                    Console.WriteLine(villager.numberOfpasport + ": " + villager.name);
                }
            }
        }
        public class Zina
        {
            Window[] allWindows;
            public Stack<Villager> stackVilagers = new Stack<Villager>();
            public void InsertAllStack()
            {
                stackVilagers.Push(new Villager("Карина", 9217, "Подключение", 10, true));
                stackVilagers.Push(new Villager("Александра", 3467, "Другое", 2, false));
                stackVilagers.Push(new Villager("Мария", 4738, "Оплата", 3, true));
                stackVilagers.Push(new Villager("Аделя", 2111, "Оплата", 6, true));
                stackVilagers.Push(new Villager("Дарья", 3478, "Другое", 1, true));
                stackVilagers.Push(new Villager("Алия", 3462, "Подключение", 9, true));
                stackVilagers.Push(new Villager("Алсу", 3427, "Оплата", 5, false));
                stackVilagers.Push(new Villager("Диана", 9245, "Другое", 5, true));
                stackVilagers.Push(new Villager("Полина", 3426, "Подключение", 9, false));
                stackVilagers.Push(new Villager("Элина", 2309, "Оплата", 0, true));

            }
            public Zina(Window[] allWindows)
            {
                this.allWindows = allWindows;
                InsertAllStack();
            }
            public void Distribution()
            {
                while (stackVilagers.Count > 0)
                {
                    Villager villager = stackVilagers.Pop();
                    if (villager.isSmart)
                    {
                        for (int i = 0; i < allWindows.Length; i++)
                        {
                            if (villager.problem == allWindows[i].problem)
                            {
                                allWindows[i].notSortedQueueVilagers.Add(villager);
                            }
                        }
                    }
                    else
                    {
                        Random random = new Random();
                        int villageChoose = random.Next(0, allWindows.Length);
                        allWindows[villageChoose].notSortedQueueVilagers.Add(villager);
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3, история о жэке");
            string[] problems = { "Подключение", "Оплата", "Другое" };
            Window[] allWindows = new Window[3];
            for (int i = 0; i < 3; i++)
            {
                allWindows[i] = new Window();
                allWindows[i].problem = problems[i];
            }
            Zina zina = new Zina(allWindows);
            zina.Distribution();
            for (int i = 0; i < allWindows.Length; i++)
            {
                allWindows[i].SortVillagers();
                allWindows[i].WorkWithVillager();
            }
            Console.WriteLine();
        }
    }
}
