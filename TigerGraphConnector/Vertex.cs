using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphConnector
{


    /// <summary>
    /// A collection of vertices grouped by type.
    /// Each group is a list of individual vertices:  List<VertexTypeItem>
    /// VertexTypeItem represents in item (an individual vertex) 
    /// </summary>
    public class VertexDictionary : Dictionary<string, List<VertexTypeItem>>
    {

        public VertexDictionary() { }


        public new void Add(string key, VertexTypeItem value)
        {

            if (this.ContainsKey(key))
            {
                this[key].Add(value);
            }
            else
            {
                List<VertexTypeItem> list = new List<VertexTypeItem>();
                list.Add(value);
                base.Add(value.VertextType, list);
            }
        }

        /// <summary>
        /// Not Allowed!
        /// The value 'List<VertexTypeItem>' is not allowed. Use 'VertexTypeItem' instead.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public new void Add(string key, List<VertexTypeItem> value)
        {
            throw new Exception("The value 'List<VertexTypeItem>' is not allowed. Use 'VertexTypeItem' instead.");
        }
        internal void Add(List<VertexTypeItem> value)
        {
            throw new Exception("We did not expect Vertices.: internal void Add(List<VertexTypeItem> value) to execute. Please document how this occred and report it.  Thanks.");
            //base.Add("xxx", value);
        }


        public dynamic GetVertexTypeItem(string vertextType, object vertextId)
        {
            dynamic typeGroup = this[vertextType];
            return typeGroup;
        }

        /// <summary>
        /// Json will not be wrapped with outer curly brackets which need to be added by the calling methods.
        /// </summary>
        /// <param name="vertexType">Filter the vertices in this class instance by type.</param>
        /// <param name="returnBodyOnly">When false, the outer element "vertices" will be added.
        /// Example:
        ///     true:   "Phone": {"123": {}, "124": {}}
        ///     false:  "vertices": {"Phone": {"123": {}, "124": {}}}
        /// </param>
        /// <returns></returns>
        public string ToJson_ByType(string vertexType, bool returnBodyOnly)
        {
            StringBuilder sb = new StringBuilder();
            if (this.ContainsKey(vertexType))
            {
                foreach (var item in this[vertexType])
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(item.ToJson(true));
                    }
                    else
                    {
                        sb.Append(", " + item.ToJson(true));
                    }
                }
                if (returnBodyOnly)
                {
                    return "\"" + vertexType + "\": {" + sb.ToString() + "}";
                }
                else
                {
                    return "\"vertices\": {\"" + vertexType + "\": {" + sb.ToString() + "}}";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Json will not be wrapped with outer curly brackets which need to be added by the calling methods.
        /// </summary>
        /// <param name="returnBodyOnly">When false, the outer element "vertices" will be added.
        /// Example:
        ///     true:   "Phone": {"1238": {}}
        ///     false:  "vertices": {"Phone": {"1238": {}}}
        /// </param>
        /// <returns></returns>
        public string ToJson(bool returnBodyOnly)
        {
            StringBuilder sb = new StringBuilder();
            if (this.Count == 0) { return ""; }

            foreach (KeyValuePair<string, List<VertexTypeItem>> item in this)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.Append("\"" + item.Key + "\": {");
                StringBuilder sbVert = new StringBuilder();
                foreach (VertexTypeItem vert in item.Value)
                {

                    if (sbVert.Length > 0)
                    {
                        sbVert.Append(", ");
                    }
                    sbVert.Append(vert.ToJson(true));
                }
                sb.Append(sbVert.ToString() + "}");
            }

            if (returnBodyOnly)
            {
                return sb.ToString();
            }
            else
            {
                return "\"vertices\": {" + sb.ToString() + "}";
            }
        }

    }



    public class VertexTypeItem
    {

        string _vertextType;
        string _vertextId;
        AttributeList _attributes = new AttributeList();

        public VertexTypeItem(string vertextType, string vertexId, object attributes = null)
        {
            _vertextType = vertextType;
            _vertextId = vertexId;

            if (attributes != null)
            {
                if (attributes is AttributeList)
                {
                    _attributes = attributes as AttributeList;
                }
                else if (attributes is string)
                {
                    //ToDo:  Add method to parse attributes from Json into one or more Attribute types and their corresponding properties.
                    //       or from an object[]
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnBodyOnly">If true - Does not contain the top element:  ' "vertices": { '  (withoug the single quotes)</param>
        /// <returns></returns>
        public string ToJson(bool returnBodyOnly)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("\"vertices\": {");

            //sb.Append("\"" + _vertextType + "\": {\"" + _vertextId + "\"");
            sb.Append("\"" + _vertextId + "\"");
            sb.Append(": {" + _attributes.ToJson() + "}");
            //sb.Append("}");
            if(returnBodyOnly)
            {
                return sb.ToString();
            }
            else
            {
                return "\"vertices\": {" + sb.ToString() + "}";
            }

            
        }

        ///// <summary>
        ///// Does not contain the top element:  ' "vertices": { '  (withoug the single quotes)
        ///// </summary>
        ///// <returns></returns>
        //public string ToJson_BodyOnly()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("\"" + _vertextType + "\": {\"" + _vertextId + "\"");
        //    sb.Append(": {" + _attributes.ToJson() + "}}");
        //   // sb.Append("}");
        //    return sb.ToString();
        //}


        private string GetAttributeSerializedValue(Attr att)
        {
            if (att.AttDataType == Attr.DataType.STRING)
            {
                return "\"" + att.Value + "\"";
            }
            else
            {
                return att.Value.ToString();
            }
        }

        public string VertextType { get => _vertextType; set => _vertextType = value; }
        public string VertextId { get => _vertextId; set => _vertextId = value; }
        public AttributeList Attributes { get => _attributes; set => _attributes = value; }
    }




    public class VertexList : List<VertexTypeItem>
    {
        public VertexList() { }

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            foreach (VertexTypeItem item in this)
            {
                if (sb.Length == 0)
                {
                    sb.Append(item.ToJson(true));
                }
                else
                {
                    sb.Append(", " + item.ToJson(true));
                }
            }
            return "\"vertices\": {" + sb.ToString() + "}";
        }
    }

}
