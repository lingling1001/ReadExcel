using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class FormSetting : Form
    {
        private string _pathExcel;//Excel 路径
        private string _pathXml;//XML 路径
        private string _pathCS;//输出CS 路径
        private Dictionary<string, string> _mapTempPath = new Dictionary<string, string>();
        private Dictionary<string, string> _mapOriginalPath = new Dictionary<string, string>();

        private MainForm _mainForm;
        public FormSetting(MainForm mainForm)
        {
            _mainForm = mainForm;
            mainForm.Enabled = false;
            InitializeComponent();


        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _mapTempPath.Clear();
            _mapOriginalPath.Clear();
            List<string> keys = new List<string>();
            keys.Add(SettingDefine.PATH_KEY_XML);
            keys.Add(SettingDefine.PATH_KEY_EXCEL);
            keys.Add(SettingDefine.PATH_KEY_CS);

            foreach (var item in keys)
            {
                string value = SettingManager.Instance.GetConfig(item);
                _mapTempPath.Add(item, value);
                _mapOriginalPath.Add(item, value);
            }
            RefreshPathXml();
            RefreshPathExcel();
            RefreshPathCS();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveAllConfig();
            ClearAllData();
            this.Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
            this.Close();

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _mainForm.Enabled = true;

        }

        private void btnSelectXml_Click(object sender, EventArgs e)
        {
            SelectPath(SettingDefine.PATH_KEY_XML, _pathXml);
            RefreshPathXml();
        }

        private void btnSelectExcel_Click(object sender, EventArgs e)
        {
            SelectPath(SettingDefine.PATH_KEY_EXCEL, _pathExcel);
            RefreshPathExcel();
        }
        /// <summary>
        /// 选择路径
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Defpath">默认路径</param>
        private void SelectPath(string key, string Defpath)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = string.IsNullOrEmpty(Defpath) ? "C:" : Defpath;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show(dialog.SelectedPath, result.ToString());
                SetConfigTempValue(key, dialog.SelectedPath);
            }

        }


        private void RefreshPathXml()
        {
            _pathXml = _mapTempPath[SettingDefine.PATH_KEY_XML];
            this.texXml.Text = _pathXml;
        }
        private void RefreshPathExcel()
        {
            _pathExcel = _mapTempPath[SettingDefine.PATH_KEY_EXCEL];
            this.texExcel.Text = _pathExcel;
        }
        private void RefreshPathCS()
        {
            _pathCS = _mapTempPath[SettingDefine.PATH_KEY_CS];
            this.texCS.Text = _pathCS;
        }
        private void btnCS_Click(object sender, EventArgs e)
        {
            SelectPath(SettingDefine.PATH_KEY_CS, _pathCS);
            RefreshPathCS();
        }

        private void SetConfigTempValue(string key, string selectedPath)
        {
            _mapTempPath[key] = selectedPath;
        }
        private void SetConfigValue(string key, string selectedPath)
        {
            SettingManager.Instance.SetConfig(key, selectedPath);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CheckCanShowCloseTip())
            {
                DialogResult result = MessageBox.Show("是否应用设置？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveAllConfig();
                }
                e.Cancel = false;
            }
            base.OnClosing(e);

        }
        /// <summary>
        /// 路径是否有变化
        /// </summary>
        private bool CheckCanShowCloseTip()
        {
            foreach (var item in _mapOriginalPath)
            {
                if (item.Value != (_mapTempPath[item.Key]))
                {
                    return true;
                }
            }
            return false;
        }

        private void SaveAllConfig()
        {
            foreach (var item in _mapTempPath)
            {
                _mapOriginalPath[item.Key] = item.Value;
                SetConfigValue(item.Key, item.Value);
            }
        }

        private void texCS_TextChanged(object sender, EventArgs e)
        {
            SetConfigTempValue(SettingDefine.PATH_KEY_CS, texCS.Text);
        }

        private void texXml_TextChanged(object sender, EventArgs e)
        {
            SetConfigTempValue(SettingDefine.PATH_KEY_XML, texXml.Text);
        }

        private void texExcel_TextChanged(object sender, EventArgs e)
        {
            SetConfigTempValue(SettingDefine.PATH_KEY_EXCEL, texExcel.Text);

        }

        private void ClearAllData()
        {
            _mapOriginalPath.Clear();
            _mapTempPath.Clear();
        }
    }


}
