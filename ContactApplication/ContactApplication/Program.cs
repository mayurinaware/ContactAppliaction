using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryContactApp;
namespace ContactApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Class1 a = new Class1();
            List<string> contacts = new List<string>();
            var dict = new Dictionary<string, int>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1)Add Contact 2)Search 3)exit");
                string input = Console.ReadLine();
                int caseValue;
                if (int.TryParse(input, out caseValue))
                {
                    switch (caseValue)
                    {
                        case 1:
                            Console.WriteLine("Enter Name:");
                            string name = Console.ReadLine();
                            contacts.Add(name);
                            break;
                        case 2:
                            Console.WriteLine("Enter Name:");
                            string value = Console.ReadLine();
                            dict = a.searchContact(contacts, value);
                            //sort the dict according to the ranks print dict
                            var res = dict.OrderBy(d => d.Value).Select(d => d.Key).ToArray();
                            foreach (var p in res)
                            {
                                Console.WriteLine(p);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Happy Searching");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
    

}
