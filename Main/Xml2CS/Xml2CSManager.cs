using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public class Xml2CSManager : Singleton<Xml2CSManager>
    {
        public void XmlToCS(string pathXml = "")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = pathXml;
            openFileDialog.Filter = "文本文件|*.*|xml文件|*.xml|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = SettingManager.Instance.GetConfig(SettingDefine.PATH_KEY_CS);
                if (string.IsNullOrEmpty(savePath))
                {
                    savePath = @"C:\";
                }
                string fName = openFileDialog.FileName;
                XmlToClass toCs = new XmlToClass();
                toCs.ToClass(fName, savePath);
            }
        }
    }
}
