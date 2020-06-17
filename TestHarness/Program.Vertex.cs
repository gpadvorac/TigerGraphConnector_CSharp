using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestHarnes
{
    partial class Program
    {

        static void CallVertexMethods()
        {
            dynamic result;

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
                //string _Variables_JSON = "{ \"callLength\" : { \"value\" : 10, \"op\" : \"add\" } }";
                //result = _tgConn.UpsertVertex("PhoneCall", "15588225488134883643251429541241", _Variables_JSON);


                //string json = Create_VertexTypeItem_GetJson_NoAttribute();
                //string json = "\"vertices\": {\"Phone\": {\"1238\": {}}}";
                //string json = "\"vertices\": {\"PhoneCall\": {\"1239\": {\"callLength\": {\"value\": 19, \"op\": \"max\"}}}}";
                //result = _tgConn.UpsertData(json, null);
                //phoneNumber

                //////Upsert muliplte vertices and vertex types
                //var vets = GetVertices();
                //string json = vets.ToJson(false);
                //result = _tgConn.UpsertData(json, null);

                //string json = "{\"vertices\": {\"Phone\": \"1234\"}}";      // Create_VertexTypeItem_GetJson_Phone();
                //result = _tgConn.UpsertData(null, json);

                var verts = GetVertices();
                result = verts.ToJson_ByType("Phone", true);

                //Upsert Vertices
                //string _Vertices = "{\"50\": {\"phoneNumber\": {\"value\": \"555\"}}, \"51\": {\"phoneNumber\": {\"value\": \"666\"}}}";
                //result = _tgConn.UpsertVertices("Phone", _Vertices);



                //string json = Create_VertexTypeItem_GetJson_NoAttribute();
                //result = _tgConn.UpsertVertex(json);

                //string json = Create_VertexTypeItem_GetJson();
                //result = _tgConn.UpsertData(json, null);



                //List<string> lst = new List<string>();
                //lst.Add("PhoneCall");
                //result = _tgConn.GetVertexStats(lst, false);

                //result = _tgConn.DeleteVertices("Phone", "phoneNumber=555", "", "", false, 0);

                //result = _tgConn.DeleteVerticesById("PhoneCall", "13188234720138888216071443730737", false, 0);

                //object result = _tgConn.GetVertices("PhoneCall", "callLength", "callLength=0", "1", "", 0);

                //object result = _tgConn.GetVerticesById("PhoneCall", "15588225488134883643251429541241");

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
