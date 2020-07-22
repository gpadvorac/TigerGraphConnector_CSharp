using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml;
using TigerGraphComponents;
using TigerGraphConnector;

namespace TestHarnes
{
    partial class Program
    {
        static TigerGraphConnection _tgConn;

        static void Main(string[] args)
        {
            InitializeConnectionFromDataStore();
            //CallVertexMethods();
            //CallEdgeMethods();
            CallOtherMethods();
            //Set_TokenExpiration();
        }


        /// <summary>
        /// Fetch configureation data.  In production this would probably come from a database.
        /// </summary>
        static void InitializeConnectionFromDataStore()
        {
            try
            {
                string url = ConfigurationManager.AppSettings["URL"];
                string graphName = ConfigurationManager.AppSettings["GraphName"];
                string userName = ConfigurationManager.AppSettings["UserName"];
                string passWord = ConfigurationManager.AppSettings["PWD"];
                string token = ConfigurationManager.AppSettings["Token"];
                string secret = ConfigurationManager.AppSettings["Secret"];
                int restppPort = int.Parse(ConfigurationManager.AppSettings["RESTppPort"]);
                int gsPort =  int.Parse(ConfigurationManager.AppSettings["GsPort"]);
                long tokenExpiration = long.Parse(ConfigurationManager.AppSettings["TokenExpiration"]);
                int lifeTime = int.Parse(ConfigurationManager.AppSettings["LifeTime"]);
                _tgConn = new TigerGraphConnection(url, restppPort, gsPort, graphName, true, false, secret, token, tokenExpiration, lifeTime, userName, passWord);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debugger.Break();
            }
        }


        static void CallOtherMethods()
        {
            try
            {
                dynamic result = "";
                //_tgConn.RefreshToken();
                //result = _tgConn.TestToken();

                //result = _tgConn.GetEcho();
                //result = _tgConn.GetSchema(false);
                //result = _tgConn.GetSchema(true);
                //result = _tgConn.GetUDTs();
                //result = _tgConn.GetUDT("myTuple");
                //result = _tgConn.DeleteToken("xxx", false);
                //result = _tgConn.DeleteToken("6cib7517qv5ri7asec5ec0a2q2343etl", false);


                ////* I'm fetching variables here incase I need to use a config for a different source for this test.
                //string url = ConfigurationManager.AppSettings["URL"];
                //string secret = ConfigurationManager.AppSettings["Secret"];
                //result = TigerGraphConnection.GetNewToken(url + ":9000", secret, 2592000);
                //Debugger.Break();


                //result = _tgConn.ExecuteGetQuery("personKnowsWho", "source=274");


                //Dictionary<string, object> parms = new Dictionary<string, object>();
                //parms.Add("inputSponsor", "A43CA257-B5DD-4373-8EFE-07927D294B8A");
                //result = _tgConn.RunInstalledQuery("GetConcept_BySponsor", parms);

                //Dictionary<string, object> parms = new Dictionary<string, object>();
                //parms.Add("source", 274);
                //result = _tgConn.RunInstalledQuery("personKnowsWho", parms);

                //result = _tgConn.GetVer("realtime");
                //result = _tgConn.GetLicenseInfo();



                //// UpsertData - List of Vertices and List of Edges

                //VertexList list = new VertexList();
                //Vertex vert = new Vertex();
                //string json;
                //vert = new Vertex();
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //vert.VertexType = "ConceptItem";
                //vert.Attributes.Add("name", "Big cat");
                //list.Add(vert);

                //vert = new Vertex();
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C06";
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C01";
                //vert.VertexType = "ConceptItem";
                //vert.Attributes.Add("name", "Big dog");
                //list.Add(vert);
                //json = list.ToJsonForUpsert();


                //EdgeList list2 = new EdgeList();
                //string json2;
                //Edge edge = new Edge();
                //edge.FromVertexType = "EvalEvent";
                //edge.FromId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //edge.EdgeType = "EvalEvent_Has_ConceptItem";
                //edge.ToVertexType = "ConceptItem";
                //edge.ToId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                ////edge.Attributes.Add("isChosen", true);
                //list2.Add(edge);

                //edge = new Edge();
                //edge.FromVertexType = "EvalEvent";
                //edge.FromId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //edge.EdgeType = "EvalEvent_Has_ConceptItem";
                //edge.ToVertexType = "ConceptItem";
                //edge.ToId = "E3605013-5183-43E3-A57E-52D0F7703C01";
                ////edge.Attributes.Add("isChosen", true);
                //list2.Add(edge);

                //json2 = list2.ToJsonForUpsert();

                //string jsonAll = json.Remove(json.Length - 1) + ", " + json2.Remove(0, 1);
                string jsonAll = "{\"vertices\":  {\"ConceptItemContent\": {\"3E26E747-CE82-496B-841D-21DDB8CB5C2A\":{\"title\": {\"value\": \"zzz\"}, \"description\": {\"value\": \"\"}, \"fileType\": {\"value\": \"\"}, \"fileName\": {\"value\": \"Modem1.jpg\"}, \"filePath\": {\"value\": \"\"}, \"sortOrder\": {\"value\": 1}}}}, \"edges\": {\"ConceptItem\": {\"9C4E6C58-4657-464C-B526-0E5EDF0BD643\": {\"ConceptItem_Has_ConceptItemContent\": {\"ConceptItemContent\": {\"3E26E747-CE82-496B-841D-21DDB8CB5C2A\": {}}}}}}}";
                result = _tgConn.UpsertData(jsonAll);

                Console.WriteLine(result.ToString());
                Debugger.Break();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Debugger.Break();
            }
        }

        #region Other Test Methods




        /// <summary>
        /// I was looking for a way to get the expiration without updating the token with a new expiration.  Doesn't look like this is possible for now.  
        /// 
        /// </summary>
        static void Set_TokenExpiration()
        {
            string url, secret, apiToken, lifetime;
            url = ConfigurationManager.AppSettings["URL"];
            secret = ConfigurationManager.AppSettings["Secret"];
            apiToken = ConfigurationManager.AppSettings["Token"];
            lifetime = "130";
            var client = new RestClient(url + ":9000/requesttoken?secret=" + secret + "&token=" + apiToken + "&lifetime=" + lifetime);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            IRestResponse response = client.Execute(request);
            dynamic responseContent = JsonConvert.DeserializeObject(response.Content);

            Console.WriteLine(responseContent);
            Debugger.Break();
        }

        #endregion Other Test Methods



    }
}
