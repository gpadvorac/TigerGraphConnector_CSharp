using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerGraphComponents;
using TigerGraphConnector;

namespace TestHarnes
{
    partial class Program
    {
        static void CallEdgeMethods()
        {
            try
            {

                dynamic result="";

                //result = _tgConn.GetEdgeTypes();
                //result = _tgConn.GetEdgeType("hasPhoneCall");
                //result = _tgConn.GetEdgeType("hasHotelStay");

                //Get Edge Count
                //Showing alternate ways to call this function
                //Get
                //result = _tgConn.GetEdgeCount("PhoneCall", "15588225488134883643251429541241", "", "", "", "");
                //result = _tgConn.GetEdgeCount("Phone", "15588881022", "*", "", "", "");
                //result = _tgConn.GetEdgeCount("", "", "hasPhoneCall", "PhoneCall", "15588225488134883643251429541241", "");
                //result = _tgConn.GetEdgeCount("", "", "hasPhoneCall", "", "", "");
                //result = _tgConn.GetEdgeCount("", "", "", "", "", "");

                //Post
                //result = _tgConn.GetEdgeCount("", "", "*", "", "", "");
                //result = _tgConn.GetEdgeCount("", "", "hasPhoneCall", "", "", "");
                //result = _tgConn.GetEdgeCount("Person", "1169304", "", "", "", "");


                //pr("getEdgeCount", conn.getEdgeCount(sourceVertexType="Person", sourceVertexId="1169304"))

                ////Upsert Edges
                //From vertex for format reference:  
                //string _Variables_JSON = "{ \"callLength\" : { \"value\" : 10, \"op\" : \"add\" } }";
                //string _Variables_JSON = "{ \"testAtt_Text\" : { \"value\":\"xxx\", \"op\":\"=\"} }";
                //result = _tgConn.UpsertEdge("Phone", "15588881022", "hasPhoneCall", "PhoneCall", "15588225488134883643251429541241", _Variables_JSON);

                //string json = CreateEdge_GetJson();
                //result = _tgConn.UpsertData(null, json);

                //string json = CreateEdge_NoAttributes_GetJson();
                //result = _tgConn.UpsertEdge(json);

                // string _Variables_JSON = "{ \"testAtt_Text\" : { \"value\":\"xxx\", \"op\":\"=\"} }";
                //[("iub_g3", "srs_d_2", {"prop1": "alpha", "prop2": "2019-01-01"})]

                ////var list = new List<Tuple<string, string, object>>();
                ////list.Add(new Tuple<string, string, object>("15588881022", "15588225488134883643251429541241", "{ \"testAtt_Text\": \"Yogi\", \"testAtt_UINT\": \"99\"}"));
                ////list.Add(new Tuple<string, string, object>("15588881022", "15588225488134883643251429541241", "{ \"testAtt_Text\": \"Yogi\"}"));
                ////list.Add(new Tuple<string, string, object>("iub_g3", "srs_d_2", "{ \"prop1\": \"alpha\", \"prop2\": \"2019-01-01\"}"));
                ////list.Add(new Tuple<string, string, object>("iub_g3", "srs_d_2", "{ \"prop1\": \"alpha\", \"prop2\": \"2019-01-01\"}"));
                ////list.Add(new Tuple<string, string, object>("iub_g3", "srs_d_2", "{ \"prop1\": \"alpha\", \"prop2\": \"2019-01-01\"}"));
                ////result = _tgConn.UpsertEdges("Phone", "hasPhoneCall", "PhoneCall", list);

                ////// Upsert a single edge
                //Edge edge = new Edge();
                //edge.FromVertexType = "EvalEvent";
                //edge.FromId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //edge.EdgeType = "EvalEvent_Has_ConceptItem";
                //edge.ToVertexType = "ConceptItem";
                //edge.ToId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //edge.Attributes.Add("isChosen", true);
                //string json = edge.ToJsonForSingleEdgeUpsert();

                //result = _tgConn.UpsertData(json);




                //// Upsert a list of edges
                EdgeList list = new EdgeList();
                string json;
                Edge edge = new Edge();
                edge.FromVertexType = "EvalEvent";
                edge.FromId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                edge.EdgeType = "EvalEvent_Has_ConceptItem";
                edge.ToVertexType = "ConceptItem";
                edge.ToId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                //edge.Attributes.Add("isChosen", true);
                //json = edge.ToJsonForSingleEdgeUpsert();
                list.Add(edge);

                edge = new Edge();
                edge.FromVertexType = "EvalEvent";
                edge.FromId = "E3605013-5183-43E3-A57E-52D0F7703C00";
                edge.EdgeType = "EvalEvent_Has_ConceptItem";
                edge.ToVertexType = "ConceptItem";
                edge.ToId = "E3605013-5183-43E3-A57E-52D0F7703C01";
                //edge.Attributes.Add("isChosen", true);
                list.Add(edge);

                json = list.ToJsonForUpsert();
                result = _tgConn.UpsertData(json);





                //Get Edges
                //result = _tgConn.GetEdges("Phone", "15888889120", "hasPhoneCall", "PhoneCall", "15888889120137882016501420699012", "", "", "1", "", 0);

                //GetEdgeStats
                //result = _tgConn.GetEdgeStats("hasPhoneCall", false);

                //Delete Edges
                //result = _tgConn.DeleteEdges("Phone", "15888889120", "hasPhoneCall", "PhoneCall", "15888889120137882016501420699012", "", "1", "", 0);
                //result = _tgConn.DeleteEdges("Person", "1168248");

                Console.WriteLine(result.ToString());
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
