using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Main
{
    /// <summary>
    ///TODO ： 应该新开线程。。。
    /// </summary>
    public partial class MainForm : Form
    {


        private string _pathExcel;//Excel 路径
        private string _pathXml;//XML 路径

        /// <summary>
        /// 存储文件路径信息
        /// </summary>
        private Dictionary<string, ExFileInfo[]> _mapFilesInfo = new Dictionary<string, ExFileInfo[]>();
        //private Thread theardEx;
        public MainForm()
        {
            InitializeComponent();
            SettingManager.Instance.SetSettingInfo(new SettingConfiguration());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshPath();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clbList.Items.Clear();
            RefreshPath();

        }


        private void listBoxLogInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void listBoxLogInfo_DrawItem(object sender, DrawItemEventArgs e)
        {


        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!HasKey(SettingDefine.PATH_KEY_EXCEL, true))
            {
                return;
            }
            if (!HasKey(SettingDefine.PATH_KEY_XML, true))
            {
                return;
            }
            listBoxLogInfo.Items.Clear();
            ExprotXml();
            // listBoxLogInfo.Items.Add(CreateXmlFile(list, xmlPath));

        }

        private void ExprotXml()
        {
            string key = string.Empty;
            for (int cnt = 0; cnt < clbList.Items.Count; cnt++)
            {
                if (clbList.GetItemCheckState(cnt) == CheckState.Checked)
                {
                    key = clbList.Items[cnt].ToString();
                    break; ;
                }
            }
            ExFileInfo[] infos = null;
            if (_mapFilesInfo.ContainsKey(key))
            {
                infos = _mapFilesInfo[key];
            }
            if (infos == null)
            {
                MessageBox.Show("请选中需要导出的表", "错误！");
                return;
            }
            List<List<string>> list = ReadExcelToTable(infos[0].FileFullPath);
            ErrorMsg msg = new ErrorMsg();
            if (CreateXmlFile(list, infos, out msg.Msg))
            {
                MessageBox.Show(" 导出成功 ", "好了");
            }
            else
            {
                MessageBox.Show(" 导出失败 ", "失败");
            }
            listBoxLogInfo.Items.Add(msg);

        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            if (!HasKey(SettingDefine.PATH_KEY_EXCEL, true))
            {
                return;
            }
            if (!HasKey(SettingDefine.PATH_KEY_XML, true))
            {
                return;
            }
            listBoxLogInfo.Items.Clear();
            foreach (var item in _mapFilesInfo)
            {
                string path = item.Value[0].FileFullPath;
                List<List<string>> list = ReadExcelToTable(path);
                ErrorMsg msg = new ErrorMsg();
                string xmlPath = path.Replace(_pathExcel, _pathXml);
                xmlPath = xmlPath.Replace(".xlsx", ".xml");
                CreateXmlFile(list, item.Value, out msg.Msg);
                listBoxLogInfo.Items.Add(msg);
            }
            MessageBox.Show(" OK ", "完成");

        }

        /// <summary>
        /// 选择/取消  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (clbList.Items == null || clbList.Items.Count == 0)
            {
                return;
            }
            int count = clbList.Items.Count;
            for (int cnt = 0; cnt < count; cnt++)
            {
                if (clbList.GetItemChecked(cnt) != checkBoxAll.Checked)
                {
                    clbList.SetItemChecked(cnt, checkBoxAll.Checked);
                }
            }

        }



        private void RefreshPath()
        {
            _pathExcel = SettingManager.Instance.GetConfig(SettingDefine.PATH_KEY_EXCEL);

            _pathXml = SettingManager.Instance.GetConfig(SettingDefine.PATH_KEY_XML);

            RefreshFileList(_pathExcel);
        }


        /// <summary>
        /// 根据选择路径 加载Excel 列表
        /// </summary>
        private void RefreshFileList(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            _mapFilesInfo.Clear();
            List<string> listFiles = new List<string>();
            FileTools.GetObjectDirFiles(path, listFiles, ".xlsx");
            for (int cnt = 0; cnt < listFiles.Count; cnt++)
            {
                ExFileInfo[] infos = new ExFileInfo[2];
                infos[0] = new ExFileInfo();
                infos[1] = new ExFileInfo();


                infos[0].FileFullPath = listFiles[cnt];
                infos[0].FileFolder = Path.GetDirectoryName(infos[0].FileFullPath);
                infos[0].FileName = Path.GetFileName(infos[0].FileFullPath);
                //infos[0].FilePath = infos[0].FileFullPath.Replace(_pathExcel + "\\", string.Empty);


                infos[1].FileFullPath = infos[0].FileFullPath.Replace(_pathExcel, _pathXml);

                infos[1].FileFolder = Path.GetDirectoryName(infos[1].FileFullPath);
                infos[1].FileName = Path.GetFileName(infos[1].FileFullPath);
                //infos[1].FilePath = infos[1].FileFullPath.Replace(_pathXml + "\\", string.Empty);

                // info.XmlFilePath=info.fi
                clbList.Items.Add(infos[0], true);
                _mapFilesInfo.Add(infos[0].ToString(), infos);
            }


        }

        public bool CreateXmlFile(List<List<string>> listContent, ExFileInfo[] infos, out string msg)
        {
            if (listContent.Count < 4)
            {
                //listBoxLogInfo.Items.Add();
                msg = "Error : " + infos[0].FileFolder;
                return false;
            }
            //第0行 表名  1备注 2备注  3属性名  4+内容。
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点    
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);

            string rootName = listContent[0][0];
            XmlElement xml = xmlDoc.CreateElement("Root");
            xml.SetAttribute("type", rootName);
            xmlDoc.AppendChild(xml);
            string titleName = listContent[1][0];

            for (int row = 4; row < listContent.Count; row++)
            {
                XmlElement content = xmlDoc.CreateElement(titleName);
                bool isCanAdd = true;
                for (int cnt = 0; cnt < listContent[3].Count; cnt++)
                {
                    string key = listContent[3][cnt].Trim();
                    if (string.IsNullOrEmpty(key))
                    {
                        break;
                    }
                    string value = listContent[row][cnt];
                    if (cnt == 0 && string.IsNullOrEmpty(value))
                    {
                        isCanAdd = false;
                        break;
                    }
                    content.SetAttribute(key, value);
                }
                if (isCanAdd)
                {
                    xml.AppendChild(content);
                }
            }
            try
            {
                if (!File.Exists(infos[1].FileFolder))
                {
                    Directory.CreateDirectory(infos[1].FileFolder);
                }
                string strFileName = infos[1].FileFolder + "\\" + titleName + ".xml";
                xmlDoc.Save(strFileName);
                msg = "保存文件" + titleName + ".xml";
                return true;
            }
            catch (Exception e)
            {
                //显示错误信息    
                Console.WriteLine(e.Message);
                msg = e.Message;
                return false;
            }
        }

        private bool HasKey(string key, bool showTips)
        {
            bool isNull = string.IsNullOrEmpty(SettingManager.Instance.GetConfig(key));
            if (showTips && isNull)
            {
                MessageBox.Show("需要点击下方的选择路径", "错误！");
            }
            return !isNull;
        }







        //根据excle的路径把第一个sheel中的内容放入datatable
        public List<List<string>> ReadExcelToTable(string path)//excel存放的路径
        {
            List<List<string>> listStrs = new List<List<string>>();
            string addrs = string.Empty;
            using (ExcelPackage p = new ExcelPackage())
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    p.Load(stream);
                    ExcelWorksheet worksheet = p.Workbook.Worksheets[1];
                    object[,] cellInfos = worksheet.Cells.Value as object[,];
                    for (int i = cellInfos.GetLowerBound(0); i <= cellInfos.GetUpperBound(0); i++)
                    {
                        List<string> list = new List<string>();
                        //Arr.GetLowerBound(0);其中的0表示取第一维的下限，一般数组索引是0开始，为0
                        //同理可得Arr.GetUpperBound(0);其中的0表示取第一维的上限，在本例中是3行2列的数组，所以为3-1=2
                        for (int j = cellInfos.GetLowerBound(1); j <= cellInfos.GetUpperBound(1); j++)
                        {
                            //Arr.GetLowerBound(1);其中的1表示取第二维的下限，一般数组索引是0开始，为0
                            //同理可得Arr.GetUpperBound(1);其中的1表示取第二维的上限，在本例中是3行2列的数组，所以为2-1=1
                            //遍历数组的元素
                            Console.WriteLine(cellInfos[i, j]);
                            if (cellInfos[i, j] != null)
                            {
                                list.Add(cellInfos[i, j].ToString());
                            }
                            else
                            {
                                list.Add(string.Empty);
                            }
                        }
                        ////读取到空内容 返回掉
                        //if (i > 4 && cellInfos[i, 0] != null && string.IsNullOrEmpty(cellInfos[i, 0].ToString()))
                        //{
                        //    break;
                        //}
                        listStrs.Add(list);
                    }
                }
                return listStrs;
            }


        }

        private void toolSetting_Click(object sender, EventArgs e)
        {
            FormSetting setting = new FormSetting(this);
            setting.Show();


        }

        private void StripMenuItemXML2CS_Click(object sender, EventArgs e)
        {
            string path = SettingManager.Instance.GetConfig(SettingDefine.PATH_KEY_CS);
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show(" CS目录未设置 ", "错误");
                return;
            }
            Xml2CSManager.Instance.XmlToCS(_pathXml);
            DialogResult res = MessageBox.Show(" 导出成功,是否打开目录 ", "好了");
            if (res == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }
    }

    public class ExFileInfo
    {
        public string FileFullPath;
        public string FilePath;//文件相对路径。
        public string FileFolder;
        public string FileName;
        public override string ToString()
        {
            return FileName;
        }
    }

    public class ErrorMsg
    {
        public bool IsError;
        public string Msg;
        public string Path;

        public override string ToString()
        {
            return Msg;
        }
    }
}
