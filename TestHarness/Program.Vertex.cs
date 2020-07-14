using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TigerGraphComponents;

namespace TestHarnes
{
    partial class Program
    {

        static void CallVertexMethods()
        {
            dynamic result = "";

            try
            {
                //string result = _tgConn.ExecuteGetQuery("GetUserEventsItems", "inputUser=1");

                //string result = _tgConn.ExecuteGetQuery("test1", null);
                //string result = _tgConn.GetEcho();
                //string result = _tgConn.Get_EndPoints(true, true, true);
                //string result = _tgConn.Get_Statistics(60, 10);
                //string result = _tgConn.Get_Version();
                //string result = _tgConn.Get_Ver("product", false);
                //string result = _tgConn.Get_LicenseInfo();
                //string result = _tgConn.Post_Echo();


                //result = _tgConn.GetVertexTypes(true);

                //result = _tgConn.GetVertexType("Person");

                //result = _tgConn.GetVertexCount("*", "", false);

                //Upsert Vertex
                // ***  Random samples below
                //string _Variables_JSON = "{ \"callLength\" : { \"value\" : 10, \"op\" : \"add\" } }";
                //result = _tgConn.UpsertVertex("PhoneCall", "15588225488134883643251429541241", _Variables_JSON);

                //string _Variables_JSON = "{ \"title\" : { \"value\" : \"zzDeleteme\", \"op\" : \"+\" } }";
                //string _Variables_JSON = "{ \"title\" : { \"value\" : \"zzDeleteme\", \"op\" : \"+\" }, \"fileName\" : { \"value\" : \"zzDeleteme\", \"op\" : \"+\" } }";
                //string _Variables_JSON = "{ \"title\" : { \"value\" : \"zzDeleteme333\", \"op\" : \"+\" }, \"fileName\" : { \"value\" : \"zzDeleteme333444\"} }";
                //result = _tgConn.UpsertVertex("ConceptItemContent", "E3605013-5183-43E3-A57E-52D0F7703C03", _Variables_JSON);

                //string json = "\"vertices\": {\"Phone\": {\"1238\": {}}}";
                //string json = "\"vertices\": {\"PhoneCall\": {\"1239\": {\"callLength\": {\"value\": 19, \"op\": \"max\"}}}}";
                //result = _tgConn.UpsertData(json, null);
                //phoneNumber

                //string json = "{\"vertices\": {\"Phone\": \"1234\"}}"; 
                //result = _tgConn.UpsertData(null, json);


                ////Upsert Vertices
                //string _Vertices = "{\"50\": {\"phoneNumber\": {\"value\": \"555\"}}, \"51\": {\"phoneNumber\": {\"value\": \"666\"}}}";
                //result = _tgConn.UpsertData("Phone", _Vertices);


                //This is a sample of good Json with 2 attributes (no operators yet)
                //{"Voter": {"E3605013-5183-43E3-A57E-52D0F7703C03": {"firstName": {"value": "Deleleteme"},"lastName": {"value": "Deleleteme2"}}}}
                //string json = vert.ToJsonForUpsert();
                //string json2 =   "{\"Voter\": {\"E3605013-5183-43E3-A57E-52D0F7703C03\": {\"firstName\": {\"value\": \"Deleleteme\"}} }}";
                ////string json2 = "{\"Voter\": {\"E3605013-5183-43E3-A57E-52D0F7703C03\": {\"firstName\": {\"value\": \"Deleleteme\"},\"lastName\": {\"value\": \"Deleleteme2\"}}}}";
                //result = _tgConn.UpsertData(json);

                ///Upsert Single vertex using the Vertex class
                //Vertex vert = new Vertex();
                //string json;
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C05";
                //vert.VertexType = "Voter";
                //vert.Attributes.Add("firstName", "Jon");
                //vert.Attributes.Add("lastName", "Herk");
                //json = vert.ToJsonForSingleVertexUpsert();

                ////json = "{\"vertices\":  {\"Voter\": {\"E3605013-5183-43E3-A57E-52D0F7703C05\":{}}}}";

                //result = _tgConn.UpsertData(json);


                //////Upsert a list of vertices
                //VertexList list = new VertexList();
                //Vertex vert = new Vertex();
                //string json;
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C05";
                //vert.VertexType = "Voter";
                //vert.Attributes.Add("firstName", "Jon");
                //vert.Attributes.Add("lastName", "Herk");
                //list.Add(vert);


                //vert = new Vertex();
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C06";
                //vert.VertexType = "Voter";
                //vert.Attributes.Add("firstName", "Parker");
                //vert.Attributes.Add("lastName", "Erickson");
                //list.Add(vert);

                //json = list.ToJsonForUpsert();
                ////json = "{\"vertices\": {\"Voter\": {\"E3605013-5183-43E3-A57E-52D0F7703C05\": {\"firstName\": {\"value\": \"Jon\"},\"lastName\": {\"value\": \"Herk\"}},\"E3605013-5183-43E3-A57E-52D0F7703C06\": {\"firstName\": {\"value\": \"Parker\"},\"lastName\": {\"value\": \"Erickson\"}}}}}";
                //result = _tgConn.UpsertData(json);



                //// Create 2 vertices in prep for an edge upsert.
                Vertex vert = new Vertex();
                string json;
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //vert.VertexType = "EvalEvent";
                //vert.Attributes.Add("rating", 2);
                //vert.Attributes.Add("why", "Just because");
                //json = vert.ToJsonForSingleVertexUpsert();
                //result = _tgConn.UpsertData(json);

                //vert = new Vertex();
                //vert.Id = "E3605013-5183-43E3-A57E-52D0F7703C01";
                //vert.VertexType = "ConceptItem";
                //vert.Attributes.Add("name", "Big cat");
                //json = vert.ToJsonForSingleVertexUpsert();
                //result = _tgConn.UpsertData(json);





                //List<string> lst = new List<string>();
                //lst.Add("PhoneCall");
                //result = _tgConn.GetVertexStats(lst, false);

                //result = _tgConn.DeleteVertices("ConceptItemContent", "id=E3605013-5183-43E3-A57E-52D0F7703C03", "", "", false, 0);

                //result = _tgConn.DeleteVertices("Phone", "phoneNumber=555", "", "", false, 0);

                //result = _tgConn.DeleteVerticesById("PhoneCall", "13188234720138888216071443730737", false, 0);

                //object result = _tgConn.GetVertices("PhoneCall", "callLength", "callLength=0", "1", "", 0);

                //result = _tgConn.GetVertices("Concept");






                //object result = _tgConn.GetVerticesById("PhoneCall", "15588225488134883643251429541241");

                //long id = 1;
                //result = _tgConn.GetVerticesById("Concept", id);


                //result = _tgConn.GetVertices("PhoneCall", "", "", "5");

                //object Ids = 1168196;
                //List<object> Ids  = new List<object>();
                //Ids.Add(1168196);
                //Ids.Add(1168248);
                //Ids.Add(1168300);
                //object[] Ids = new object[3];
                //Ids[0] = 1168196;
                //Ids[1] = 1168248;
                //Ids[2] = 1168300;

                //result = _tgConn.GetVerticesById("Person", Ids);

                //string result = _tgConn.Post_GetEdgeStats("User2Round", false);
                //string obj1 = "xxx";
                //var tpl = (a: "xxx", b: 123);
                //var val = _tgConn.IsInstance(tpl, tpl.GetType());

                Console.WriteLine(result);
                Debugger.Break();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Debugger.Break();
            }
        }




    }
}
