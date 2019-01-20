using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lab08_linq.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab08_linq
{
    public class Program //so I can test it
    {
        static void Main(string[] args)
        {
            //read json file
            string outputString;
            using (StreamReader reader = new StreamReader(@"C:\Users\Julie L\Projects\cf401\githubrepository\labs\lab08\lab08-linq\data.json"))
            {
                //converting json into a string
                outputString = reader.ReadToEnd();
            }
            // convert the json to classes
            RootObject tempRoot = JsonConvert.DeserializeObject<RootObject>(outputString);

            Console.WriteLine("============query 1 All the neighborhoods=================");
            //query 1
            var query1 = from neighborhoodTemp1 in tempRoot.features
                         select neighborhoodTemp1;
            foreach (var item in query1)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("============query 2 Took out the Null neighborhoods=================");

            //query 2
            var query2 = from neighborhoodTemp2 in query1
                       where neighborhoodTemp2.properties.neighborhood != ""
                       select neighborhoodTemp2;

            foreach (var item in query2)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("==============query 3 only the distinct neighborhoods===============");

            //query 3
            //this takes the previous list and then groups all the same named neighborhoods and then selectes just the first of the groups therefore making it distinct
            var query3 = query2.GroupBy(g => g.properties.neighborhood).Select(s => s.First());
            foreach (var item in query3)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("=============query 4 consolidated query================");
            
            //query 4
            var query4 = from neighborhoodTemp4 in tempRoot.features
                         where neighborhoodTemp4.properties.neighborhood != ""
                         group neighborhoodTemp4 by neighborhoodTemp4.properties.neighborhood into hoodGroup
                         select hoodGroup.First();
            foreach (var item in query4)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("============Query 5 re-write query 3 in Linq=================");
            //query 5; rewriting 3 in linq
            var query5 = from neighborhoodTemp4 in tempRoot.features
                         where neighborhoodTemp4.properties.neighborhood != ""
                         select neighborhoodTemp4;
            foreach (var item in query5)
            {
                Console.WriteLine(item.properties.neighborhood);
            }

            Console.ReadLine(); //to stop the program from auto exit
        }

    }
}
