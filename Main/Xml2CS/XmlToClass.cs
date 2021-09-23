using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Main
{
    public class XmlToClass
    {
        public enum XmlFileType
        {
            Int,
            String,
            ListInt,
            ListString,
        }
        //private const string _type = "#type#";
        //private const string _property = "#property#";
        //private const string _namespace = "#namespace#";
        private const string _field = "#field#";
        private const string _class = "#class#";
        private const string _method = "#method#";

        //private const string property = @"
        //        private #type# _#field#;
        //        public #type# #property#
        //        {
        //            get{ return _#field#; }
        //            set{ _#field# = value; }
        //        }
        //        ";

        private const string filetextstart =
    @"using System;
using System.Xml;
using System.Collections.Generic;
using MFrameWork;

public class #class#:BasePrototype
{
#field#
    protected override void OnLoadData(XmlNode data)
    {
#method#
    }
}";



        public void ToClass(string xml, string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            XmlNode node = null;
            //取出表依赖的类
            node = doc.FirstChild;
            node = node.NextSibling;
            string type = node.Attributes["type"].Value;
            XmlNodeList nodeList = node.ChildNodes;
            string field = string.Empty;
            string method = string.Empty;
            if (nodeList.Count > 0)
            {
                string fileContent = filetextstart.Replace(_class, type);
                StringBuilder sbfield = new StringBuilder();
                StringBuilder sbmethod = new StringBuilder();

                for (int cnt = 0; cnt < nodeList[0].Attributes.Count; cnt++)
                {
                    string name = nodeList[0].Attributes[cnt].Name;
                    string value = nodeList[0].Attributes[cnt].Value;
                    if (CheckIsvalid(name))
                    {
                        string fieldValue;
                        string methodValue;

                        ConvertToString(name, value, out fieldValue, out methodValue);

                        sbfield.AppendLine("    " + fieldValue);
                        sbmethod.AppendLine("        " + methodValue);

                    }

                }


                fileContent = fileContent.Replace(_field, sbfield.ToString());
                fileContent = fileContent.Replace(_method, sbmethod.ToString());

                SaveToProject(path, type, fileContent);
            }

        }

        private void ConvertToString(string name, string value, out string combine, out string method)
        {
            combine = "public {0} {1} { get;private set;}";
            method = string.Empty;
            string fieldType = string.Empty;
            string sm;
            XmlFileType type = TryConvertType(value, out sm);
            switch (type)
            {
                case XmlFileType.Int:
                    fieldType = "int";
                    method = name + " = Utility.Xml.GetAttribute<int>(data, \"" + name + "\");";
                    break;
                case XmlFileType.String:
                    fieldType = "string";
                    method = name + " = Utility.Xml.GetAttribute<string>(data, \"" + name + "\");";
                    break;
                case XmlFileType.ListInt:
                    fieldType = "int[]";
                    method = name + " = Utility.Xml.ParseString<int>(XmlUtil.GetAttribute<string>(data, \"" + name +
                             "\"), new char[] { '" + sm + "' });";
                    break;
                case XmlFileType.ListString:
                    fieldType = "string[]";
                    method = name + " = Utility.Xml.ParseString<string>(XmlUtil.GetAttribute<string>(data, \"" + name +
                             "\"), new char[] { '" + sm + "' });";
                    break;
                default:
                    break;
            }
            combine = Format(combine, fieldType, name);
        }

        private XmlFileType TryConvertType(string value, out string sm)
        {
            int num;
            sm = string.Empty;
            if (int.TryParse(value, out num))
            {
                return XmlFileType.Int;
            }
            if (value.Contains(","))
            {
                sm = ",";
                string[] strs = value.Split(new char[] { ',', '|' });
                if (strs.Length != 0)
                {
                    if (int.TryParse(strs[0], out num))
                    {
                        return XmlFileType.ListInt;
                    }
                    else
                    {
                        // return XmlFileType.ListString;
                    }
                }
            }
            if (value.Contains("|"))
            {
                sm = "|";
                string[] strs = value.Split(new char[] { '|' });
                if (strs.Length != 0)
                {

                    if (int.TryParse(strs[0], out num))
                    {
                        return XmlFileType.ListInt;
                    }
                    else
                    {
                        // return XmlFileType.ListString;
                    }
                }
            }
            return XmlFileType.String;
        }

        private bool CheckIsvalid(string name)
        {
            string newName = name.ToLower();
            switch (newName)
            {
                case "name":
                case "desc":
                case "id":
                case "icon":
                case "backIcon1":
                case "backIcon2":
                case "quality":
                    return false;
            }
            if (newName.Contains("cehua"))
            {
                return false;
            }
            return true;
        }

        public static void SaveToProject(string path, string type, string content)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileFullName = path + @"\" + type + ".cs";
                using (FileStream fs = new FileStream(fileFullName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(content);
                    }
                }
            }
        }

        /// <summary>
        ///格式化失败，返回原字符串
        /// </summary>
        public static string FormatFailReturnOrigin(string str, params object[] param)
        {
            if (CheckStringFormatParam(str, param))
            {
                for (int cnt = 0; cnt < param.Length; cnt++)
                {
                    str = str.Replace("{" + cnt + "}", param[cnt].ToString());
                }
            }
            return str;
        }
        /// <summary>
        /// 代替 string.Format
        /// </summary>
        public static string Format(string str, params object[] param)
        {
            string content = str;
            if (CheckStringFormatParam(content, param))
            {
                for (int cnt = 0; cnt < param.Length; cnt++)
                {

                    content = content.Replace("{" + cnt + "}", param[cnt].ToString());
                }
                return content;
            }
            return str;
        }

        public static bool CheckStringFormatParam(string str, params object[] param)
        {
            if (param.Length == 0)
            {
                return false;
            }
            for (int cnt = 0; cnt < param.Length; cnt++)
            {
                if (param[cnt] == null)
                {
                    return false;
                }
            }
            int idx = 0;
            for (int cnt = 0; cnt < str.Length; cnt++)
            {
                if (str[cnt].ToString() == "{")
                {
                    if (cnt + 2 < str.Length)
                    {
                        if (str[cnt + 1].ToString() == idx.ToString() && str[cnt + 2].ToString() == "}")
                        {
                            idx++;
                            cnt += 2;
                        }
                    }
                }
            }
            if (idx != param.Length)
            {
                return false;
            }
            return true;
        }
    }
}
