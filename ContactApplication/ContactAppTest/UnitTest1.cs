using System;
using ClassLibraryContactApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContactAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1 a = new Class1();
            List<string> ContactList = new List<string> { "Chriss Harris", "Chriss", "HarryPotter" };
            Dictionary<string, int> expected1 = new Dictionary<string, int>();
            
            expected1.Add("Chriss Harris", 2);
            expected1.Add("Chriss", 1);
            string value = "chriss";
            Dictionary<string, int> dict = a.searchContact(ContactList, value);
            Assert.AreEqual(expected1.Count,dict.Count);
            Assert.AreEqual(ToAssertableString(expected1), ToAssertableString(dict));

        }
        public string ToAssertableString(Dictionary<string,int> dictionary)
        {
            var pairStrings = dictionary.Select(p => p.Key + ": " + string.Join(", ", p.Value));
            return string.Join("; ", pairStrings);
        }
    }
}
