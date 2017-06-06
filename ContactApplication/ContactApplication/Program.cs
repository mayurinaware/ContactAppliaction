using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = new List<string>();
            var dict = new Dictionary<string, int>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1)Add Contact 2)Search 3)exit");
                string input=Console.ReadLine();
                int caseValue;
                if(int.TryParse(input,out caseValue))
                {
                    switch(caseValue)
                    {
                        case 1:
                            Console.WriteLine("Enter Name:");
                            string name = Console.ReadLine();
                            contacts.Add(name);
                            break;
                        case 2:
                            Console.WriteLine("Enter Name:");
                            string value = Console.ReadLine();
                            dict=searchContact(contacts, value);
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

        private static Dictionary<string, int> searchContact(List<string> contacts, string value)
        {
            var result = new Dictionary<string, int>();
            // search for the strings starting with the input value
            var searchres =from s1 in contacts
                where s1.StartsWith(value,StringComparison.CurrentCultureIgnoreCase)
                select s1;
            // if result is empty search with surnames starting with input value
            if (searchres == null || searchres.Count()==0)
            { 
                searchres= from s1 in contacts
                           where s1.ToUpper().Contains(" "+value.ToUpper())
                           select s1;
            }
            //rank the search result
            foreach(var name in searchres)
            {
                /*
                 if the name equal exact value then rank 1
                 else if the name has surname then rank 2
                 else rank 3
                 */
                if (name.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                    result.Add(name, 1);
                else if (name.Contains(" "))
                    result.Add(name, 2);
                else
                    result.Add(name, 3);
            }

            return result;
        }

    }
}
