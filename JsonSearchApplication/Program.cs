using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using YamlDotNet.Serialization;


namespace JsonSearchApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            searchTheJsonFile("shared","false","users");
        }

        public static bool checkSearchableItems(String searchKey,String fileName)
        {

            StreamReader jsonFile = new StreamReader(fileName+".json");
            string userJson = jsonFile.ReadToEnd();
            int count = 0;

            var jss = new JavaScriptSerializer();
            var table = jss.Deserialize<dynamic>(userJson);

            dynamic users = JsonConvert.DeserializeObject<dynamic>(userJson);

            foreach (var user in users)
            {
                //String val=user.GetType().GetProperty("Item").GetValue(user, null);
                if (user[searchKey] != null)
                {
                    count++;
                }                
            }

            if(count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void searchTheJsonFile(String searchBy, String searchTerm, String objectToSearch)
        {

            if (checkSearchableItems(searchBy, objectToSearch))
            {
                StreamReader jsonFile = new StreamReader(objectToSearch + ".json");
                string userJson = jsonFile.ReadToEnd();
                dynamic users = JsonConvert.DeserializeObject<dynamic>(userJson);

                foreach (var user in users)
                {
                    if(user[searchBy] == searchTerm)
                    {
                        Console.WriteLine(user);
                    }
                    
                }

            }

        }
    }
}
