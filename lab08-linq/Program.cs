using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab08_linq
{
    public class Program //so I can test it
    {
        static void Main(string[] args)
        {
            JObject json = ConvertJson();
            //pring to verify I read the json file
            //Console.WriteLine("what is the json " + json);
            Console.WriteLine("trying to drill into" + json[0]);
            //its reading in as one

            //print
            //for (int i =0; i < readFile.Length; i++)
            //{
            //    Console.WriteLine(readFile[i]);
            //}

            Console.ReadLine(); // to stop it from auto exiting
        }

        public static JObject ConvertJson()
        {
            using (StreamReader reader = File.OpenText(@"C:\Users\Julie L\Projects\cf401\githubrepository\labs\lab08\lab08-linq\data.json"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                //philip hints to bring o into a string and then use jsonconvert()
                //then philip suggest to give that to the root and the root will do super magic that none of TAs can tell of the underthe hood
                return o;
            }
        }
    }
}
