using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphConnector
{


    public class EdgeList : List<Edge>
    {
        public EdgeList() { }

        /// <summary>
        /// Json will not be wrapped with outer curly brackets which need to be added by the calling methods.
        /// </summary>
        /// <param name="returnBodyOnly"></param>
        /// <returns></returns>
        public string ToJson(bool returnBodyOnly)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Edge item in this)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.ToJson_BodyOnly());
                }
                else
                {
                    sb.Append(", " + item.ToJson_BodyOnly());
                }
            }

            if (returnBodyOnly)
            {
                return sb.ToString();
            }
            else
            {
                return "\"edges\": {" + sb.ToString() + "}";
            }

        }
    }


    /// <summary>
    /// Used as a bucket to send edge data to methods such as EdgeUpsert.
    /// Contains Edge data such as attributes and attribute operators need for upserts.
    /// Will secrialize these properties to Json for upsert commands
    /// ToDo:  Deserialize a Json object and load data into this class
    /// </summary>
    public class Edge
    {

        string _sourceVertexType;
        string _sourceVertexId;
        string _edgeType;
        string _targetVertexType;
        string _targetVertexId;
        AttributeList _attributes = new AttributeList();

        public Edge() { }

        public Edge(string srcVertType, string srcVertId, string edgeType, string tgtVertType, string tgtVertId, object attributes = null )
        {
            _sourceVertexType = srcVertType;
            _sourceVertexId = srcVertId;
            _edgeType = edgeType;
            _targetVertexType = tgtVertType;
            _targetVertexId = tgtVertId;

            
            if(attributes!=null)
            {
                if(attributes is AttributeList)
                {
                    _attributes = attributes as AttributeList;
                }
                else if(attributes is string)
                {
                    //ToDo:  Add method to parse attributes from Json into one or more Attribute types and their corresponding properties.
                    //       or from an object[]
                }
            }
        }

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"edges\": {");
            sb.Append("\"" + _sourceVertexType + "\": {\"" + _sourceVertexId + "\": {");
            sb.Append("\"" + _edgeType + "\": {");
            if (_attributes == null || _attributes.Count == 0)
            {
                sb.Append("\"" + _targetVertexType + "\":\"" + _targetVertexId + "\"");

            }
            else
            {
                sb.Append("\"" + _targetVertexType + "\": {\"" + _targetVertexId + "\"");
                sb.Append(": {" + _attributes.ToJson() + "}}");
            }
            sb.Append("}}}}");
            return sb.ToString();
        }

        /// <summary>
        /// Does not contain the top element:  ' "edges": { '  (withoug the single quotes)
        /// </summary>
        /// <returns></returns>
        public string ToJson_BodyOnly()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\"" + _sourceVertexType + "\": {\"" + _sourceVertexId + "\": {");
            sb.Append("\"" + _edgeType + "\": {");
            sb.Append("\"" + _targetVertexType + "\": {\"" + _targetVertexId + "\"");
            sb.Append(": {" + _attributes.ToJson() + "}}");
            sb.Append("}}}");
            return sb.ToString();
        }

        private string GetAttributeSerializedValue(Attr att)
        {
            if(att.AttDataType == Attr.DataType.STRING)
            {
                return "\"" + att.Value + "\"";
            }
            else
            {
                return att.Value.ToString();
            }
        }

        public string SourceVertexType { get => _sourceVertexType; set => _sourceVertexType = value; }
        public string SourceVertexId { get => _sourceVertexId; set => _sourceVertexId = value; }
        public string EdgeType { get => _edgeType; set => _edgeType = value; }
        public string TargetVertexType { get => _targetVertexType; set => _targetVertexType = value; }
        public string TargetVertexId { get => _targetVertexId; set => _targetVertexId = value; }
        public AttributeList Attributes { get => _attributes; set => _attributes = value; }
    }


}
