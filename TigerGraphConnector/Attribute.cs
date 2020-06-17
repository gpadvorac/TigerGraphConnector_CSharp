using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphConnector
{


    public class Attr
    {
        public enum DataType
        {
            INT,
            UINT,
            FLOAT,
            DOUBLE,
            BOOL,
            STRING
        }

        string _name;
        object _value;
        string _op;
        DataType _attDataType;



        public Attr(string name, object value, string op, DataType attDataType = DataType.STRING)
        {
            _name = name;
            _value = value;
            _op = op;
            _attDataType = attDataType;
        }



        public string Name { get => _name; set => _name = value; }
        public object Value { get => _value; set => _value = value; }
        public string Op { get => _op; set => _op = value; }
        public DataType AttDataType { get => _attDataType; set => _attDataType = value; }
    }

    public class AttributeList : List<Attr>
    {

        public AttributeList() { }

        /// <summary>
        /// Example:
        /// {"name": {"value": "Smaug","op": "+"},"age": {"value": 42,"op": "+"}}
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            StringBuilder sbAtt = new StringBuilder();
            foreach (var att in this)
            {
                if (sbAtt.Length > 0)
                {
                    sbAtt.Append(",");
                }
                sbAtt.Append("\"" + att.Name + "\": {\"value\": " + GetAttributeSerializedValue(att));
                if (string.IsNullOrEmpty(att.Op))
                {
                    sbAtt.Append("}");
                }
                else
                {
                    sbAtt.Append(",\"op\": \"" + att.Op + "\"}");
                }
            }
            return sbAtt.ToString();
        }

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
    }

}
