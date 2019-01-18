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


            //LINQ
            //List<Feature> neighborhoodsToDisplay = new List<Feature> {  };
            //Properties[] neighborhoodsToDisplay = new Properties[];

            //query 1
            var query1 = from neighborhoodTemp in tempRoot.features
                       select neighborhoodTemp;
            foreach (var item in query1)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("=============================");

            //query 2
            var query2 = from neighborhoodTemp in query1
                       where neighborhoodTemp.properties.neighborhood !=null
                       select neighborhoodTemp;

            foreach (var item in query2)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("=============================");

            //query 3
            var query3 = query2.Distinct();
            foreach (var item in query3)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
            Console.WriteLine("=============================");

            //query 4
            var query4 = tempRoot.features.Where(n => n.properties.neighborhood.Length > 0)
                .GroupBy(global => global.properties.neighborhood)
                .Select(s => s.First()); //why is this .First
            foreach (var item in query4)
            {
                Console.WriteLine(item.properties.neighborhood);
            }

            Console.ReadLine(); //to stop the program from auto exit
        }


        //public static RootObject ConvertJson()
        //{
            //using (StreamReader reader = File.OpenText(@"C:\Users\Julie L\Projects\cf401\githubrepository\labs\lab08\lab08-linq\data.json"))
            //{
            //    //JObject readJsonFile = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            //    string readJsonFile = (string)JToken.ReadFrom(new JsonTextReader(reader));
            //    JObject readJsonFileToo = JObject.Parse(readJsonFile);
            //    //philip hints to bring o into a string and then use jsonconvert()
            //    //then philip suggest to give that to the root and the root will do super magic that none of TAs can tell of the underthe hood
            //    //string output = JsonConvert.SerializeObject(readJsonFile);
            //    //RootObject deserializedProduct = JsonConvert.DeserializeObject<RootObject>(output);
            //    //return readJsonFile;
            //}

            //if convert to path do the ../../../data.json (don't worry about the @
            
        //}
    }
}
