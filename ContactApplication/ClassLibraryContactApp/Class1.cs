using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryContactApp
{
    public class Class1
    {
        public Class1() { }
        public Dictionary<string, int> searchContact(List<string> contacts, string value)
        {
            var result = new Dictionary<string, int>();
            // search for the strings starting with the input value
            var searchres = from s1 in contacts
                            where s1.StartsWith(value, StringComparison.CurrentCultureIgnoreCase)
                            select s1;
            // if result is empty search with surnames starting with input value
            if (searchres == null || searchres.Count() == 0)
            {
                searchres = from s1 in contacts
                            where s1.ToUpper().Contains(" " + value.ToUpper())
                            select s1;
            }
            //rank the search result
            foreach (var name in searchres)
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
