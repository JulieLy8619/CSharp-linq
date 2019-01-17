using System;
using System.Collections.Generic;
using System.IO;
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


            //RootObject json = ConvertJson();
            //pring to verify I read the json file
            //Console.WriteLine("what is the json " + json);
            //Console.WriteLine("trying to drill into" + tempRoot.type); //philip says i can't test to see data is in this until i do a LINQ query
            //its reading in as one

            //print
            //for (int i =0; i < readFile.Length; i++)
            //{
            //    Console.WriteLine(readFile[i]);
            //}

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
