using System;
using System.Collections.Generic;

namespace GenericDictionary
{
    internal class Program { 
        static void Main(string[] args)
        {
            casestudy1();
            casestudy2();
        }
        private static void casestudy1() {
            var stateCodeMap = new Dictionary<string, string>();
            stateCodeMap.Add("TN", "TamilNadu");
            stateCodeMap.Add("KL", "Kerala");
            stateCodeMap.Add("MP", "Madhya Pradesh");
            stateCodeMap.Add("ND", "NewDelhi");
            stateCodeMap["TN"] = "Tamil Nadu";
            foreach (var key in stateCodeMap.Keys) {
                Console.Write(key+" : ");
                Console.WriteLine(stateCodeMap[key]);
            }
            if (stateCodeMap.ContainsKey("TN2"))
            {
                Console.WriteLine("The key is present");
            }
            else {
                Console.WriteLine("The key is not present");
            }
        }
        private static void casestudy2() {
            string[] Locations = { "Chennai", "Mumbai", "Delhi", "Kerala", "Chennai","chennai" };
            var map = new Dictionary<string, int>();
            foreach(string location in Locations)
            {
                //if (!map.ContainsKey(location.ToUpper())) //THe upper is checked. But while ading location, it is added Pascal. So While adding, error occurs
                //Search how we added the Key. Otherwise It will search for UPPer case and try to add, but error occurs.
                if (!map.ContainsKey(location))
                    map.Add(location,1);
                    else
                    map[location] = map[location] + 1;               
            }
            foreach (var key in map.Keys)
            {
                Console.Write(key + " : ");
                Console.WriteLine(map[key]);
            }
        }

    }

}