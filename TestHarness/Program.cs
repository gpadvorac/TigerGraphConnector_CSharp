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
                _tgConn = new TigerGraphConnection(url, restppPort, gsPort, graphName, true, secret, token, tokenExpiration, lifeTime, userName, passWord);
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


                Dictionary<string, object> parms = new Dictionary<string, object>();
                parms.Add("usr", 1);
                parms.Add("rnd", 1);
                result = _tgConn.RunInstalledQuery("GetVoterRndEvals", parms);

                //Dictionary<string, object> parms = new Dictionary<string, object>();
                //parms.Add("source", 274);
                //result = _tgConn.RunInstalledQuery("personKnowsWho", parms);

                //result = _tgConn.GetVer("realtime");
                //result = _tgConn.GetLicenseInfo();

                //result = GetVertices();

                //result = CreateEdges_GetJson();
                //result = CreateEdge_GetJson();
                //result = CreateEdge_NoAttributes_GetJson();

                //EdgeList edges = GetEdges();
                //result = edges.ToJson(false);

                //result = Create_VertexTypeItem_GetJson();
                //result = Create_VertexTypeItem_GetJson_NoAttribute();

                //result = CreateAttribute_GetJson();

                //string vert = Create_VertexTypeItem_GetJson();
                //string edg = CreateEdge_GetJson();
                //result = _tgConn.UpsertData(vert, edg);

                //string query = "select * from USER where id_card_no == 1168196";
                //result = _tgConn.RunInterpretedQuery(query, "");


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


        static VertexDictionary GetVertices()
        {
            VertexDictionary verts = new VertexDictionary();
            VertexTypeItem vertItem = new VertexTypeItem("Phone", "123", null);

            verts.Add("Phone", vertItem);
            vertItem = new VertexTypeItem("Phone", "124", null);
            verts.Add("Phone", vertItem);

            vertItem = new VertexTypeItem("PhoneCall", "123", null);

            verts.Add("PhoneCall", vertItem);

            vertItem = new VertexTypeItem("PhoneCall", "124", null);
            // Add some attributes to this one.
            Attr att;
            att = new Attr("eventDate", "33", "+", Attr.DataType.UINT);
            vertItem.Attributes.Add(att);
            att = new Attr("callLength", "120", "+", Attr.DataType.UINT);
            vertItem.Attributes.Add(att);
            att = new Attr("callType", "commedy", "+", Attr.DataType.STRING);
            vertItem.Attributes.Add(att);
            verts.Add("PhoneCall", vertItem);

            return verts;
        }

        static string Create_VertexTypeItem_GetJson()
        {
            VertexTypeItem vert = new VertexTypeItem("Person", "1235", null);

            Attr att = new Attr("fullName", "Jack Jones", "+", Attr.DataType.STRING);
            vert.Attributes.Add(att);

            att = new Attr("dob", "200-07-09", "+", Attr.DataType.STRING);
            vert.Attributes.Add(att);

            att = new Attr("email", "JJ@TG.com", "+", Attr.DataType.STRING);
            vert.Attributes.Add(att);

            att = new Attr("gender", "Male", "+", Attr.DataType.STRING);
            vert.Attributes.Add(att);

            att = new Attr("ethic_group", "Orange", "+", Attr.DataType.STRING);
            vert.Attributes.Add(att);

            string output = "{" + vert.ToJson(false) + "}";
            return output;
        }

        static string Create_VertexTypeItem_GetJson_NoAttribute()
        {
            VertexTypeItem vert = new VertexTypeItem("Person", "12347", null);
            string output = "{" + vert.ToJson(false) + "}";
            return output;
        }

        static string Create_VertexTypeItem_GetJson_Phone()
        {
            VertexTypeItem vert = new VertexTypeItem("Phone", "1234", null);

            string output = "{" + vert.ToJson(false) + "}";
            return output;
        }

    
        static EdgeList GetEdges()
        {
            EdgeList edges = new EdgeList();
            Edge edg = new Edge("Phone", "123", "hasPhoneCall", "PhoneCall", "123", null);
            Attr att;
            //att = new Attr("testAtt_Text", "aaaaa", "+", Attr.DataType.STRING);
            //edg.Attributes.Add(att);

            //att = new Attr("testAtt_INT", "1111", "+", Attr.DataType.INT);
            //edg.Attributes.Add(att);

            //att = new Attr("testAtt_UINT", "1122", "+", Attr.DataType.UINT);
            //edg.Attributes.Add(att);

            edges.Add(edg);

            edg = new Edge("Phone", "123", "hasPhoneCall", "PhoneCall", "124", null);
            //att = new Attr("testAtt_Text", "bbbb", "+", Attr.DataType.STRING);
            //edg.Attributes.Add(att);

            //att = new Attr("testAtt_INT", "2222", "+", Attr.DataType.INT);
            //edg.Attributes.Add(att);

            //att = new Attr("testAtt_UINT", "2233", "+", Attr.DataType.UINT);
            //edg.Attributes.Add(att);

            edges.Add(edg);
            return edges;
        }

        static string CreateEdge_GetJson()
        {
            Edge edg = new Edge("Phone", "1234", "hasPhoneCall", "PhoneCall", "1234", null);

            Attr att = new Attr("testAtt_Text", "TestVal1", "+", Attr.DataType.STRING);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_INT", "123456", "+", Attr.DataType.INT);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_UINT", "654321", "+", Attr.DataType.UINT);
            edg.Attributes.Add(att);

            string output = "{" + edg.ToJson() + "}";
            return output;
        }

        static string CreateEdges_GetJson()
        {
            EdgeList list = new EdgeList();

            Edge edg = new Edge("Phone", "15588881022", "hasPhoneCall", "PhoneCall", "15588225488134883643251429541242", null);
            Attr att = new Attr("testAtt_Text", "TestVal1", "+", Attr.DataType.STRING);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_INT", "123456", "+", Attr.DataType.INT);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_UINT", "654321", "+", Attr.DataType.UINT);
            edg.Attributes.Add(att);

            list.Add(edg);

            edg = new Edge("Phone", "15588881022", "hasPhoneCall", "PhoneCall", "15588225488134883643251429541243", null);
            att = new Attr("testAtt_Text", "TestVal2", "+", Attr.DataType.STRING);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_INT", "123457", "+", Attr.DataType.INT);
            edg.Attributes.Add(att);

            att = new Attr("testAtt_UINT", "654322", "+", Attr.DataType.UINT);
            edg.Attributes.Add(att);

            list.Add(edg);

            string output = "{" + list.ToJson(false) + "}";
            return output;
        }

        static string CreateEdge_NoAttributes_GetJson()
        {
            Edge edg = new Edge("Person", "1169534", "hasPhoneCall", "Phone", "15588881022", null);           
            string output = "{" + edg.ToJson() + "}";
            return output;
        }


        static string CreateAttribute_GetJson()
        {
            AttributeList list = new AttributeList();
            list.Add(new Attr("name", "Smaug", "+"));
            list.Add(new Attr("age", 42, "+", Attr.DataType.INT));
            return list.ToJson();
        }

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
