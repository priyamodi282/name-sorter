using System;
using System.IO;
using System.Reflection;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string project_path = (Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Split("bin")[0];
            Console.Write("name-sorter ./");
            string unsorted_filename = Console.ReadLine();
            string path = project_path + unsorted_filename;// unsorted-names-list.txt";
            string[] unsorted_array = File.ReadAllLines(path);
            Console.WriteLine("Unsorted List : ");
            foreach (var item in unsorted_array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************************************************");
            string temp;
            int i, j, l;
            l = unsorted_array.Length;
            for (i = 0; i < l; i++)
            {
                for (j = 0; j < l - 1; j++)
                {
                    if (unsorted_array[j] != "")
                    {
                        if (unsorted_array[j].Substring(unsorted_array[j].LastIndexOf(' ') + 1).CompareTo(unsorted_array[j + 1].Substring(unsorted_array[j + 1].LastIndexOf(' ') + 1)) > 0)
                        {
                            temp = unsorted_array[j];
                            unsorted_array[j] = unsorted_array[j + 1];
                            unsorted_array[j + 1] = temp;
                        }
                    }
                }
            }
            Console.WriteLine("Sorted List : ");
            System.IO.File.WriteAllText(project_path + "sorted-names-list.txt", string.Empty);
            foreach (var item in unsorted_array)
            {
                Console.WriteLine(item);
                using (StreamWriter writer = System.IO.File.AppendText(project_path + "sorted-names-list.txt")) 
                {
                    writer.WriteLine(item);
                }
            }
            Console.ReadKey(true);
        }
    }
}
