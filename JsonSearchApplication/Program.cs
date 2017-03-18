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
            startApplication();
            //searchTheJsonFile("_id","1","users");
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
                dynamic data = loadDataFromJsonFile(objectToSearch);

                foreach (var contentData in data)
                {
                    if(contentData[searchBy] == searchTerm)
                    {
                        Console.WriteLine(contentData);
                    }
                    
                }

            }

        }

        public static dynamic loadDataFromJsonFile(String fileName)
        {
            StreamReader jsonFile = new StreamReader(fileName + ".json");
            string readContent = jsonFile.ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(readContent);

            return data;

        }

        public static void startSearch(String objectToSearch)
        {

        }

        public static void startApplication()
        {
            Console.WriteLine("Welcome to Search Application in C#"+"\r\n"+"Type \"quit\" to exit at any time, press \'Enter\' to continue"+"\n\n\n\n");
            Console.WriteLine("\t"+" Select search options:"+"\r\n\t"+"  * Press 1 to search Zendesk"+"\r\n\t"+"  * Press 2 to view list of searchable fields"+"\r\n\t"+"  * Type \'Quit\' to exit"+"\r\n\r\n");
        }

        public static void menuInput(String input)
        {
            switch (input)
            {
                case "1":
                case "":
                    Console.Clear();
                    Console.WriteLine("Select 1) Users 2) Tickets or 3) Organizations 4)Exit out quickly\r\n");
                    String userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            startSearch("users");
                            break;
                        case "2":
                            startSearch("tickets");
                            break;
                        case "3":
                            startSearch("organizations");
                            break;
                        case "4":
                            break;
                        default:
                            Console.WriteLine("Incorrect input! Try again"+"\r\n");
                            menuInput("");
                            break;
                    }
                    break;

            }


        }
    }
}
