﻿#region License statement
/* SnakeTail is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3 of the License.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SnakeTail
{
    public partial class TailConfigForm : Form
    {
        public TailFileConfig TailFileConfig { get; private set; }
        bool _displayFileTab;

        public TailConfigForm(TailFileConfig tailFileConfig, bool displayFileTab)
        {
            InitializeComponent();
            TailFileConfig = tailFileConfig;
            _displayFileTab = displayFileTab;
        }

        private void TailConfigForm_Load(object sender, EventArgs e)
        {
            _windowTitleEdt.Text = TailFileConfig.Title;
            _windowIconEdt.Text = TailFileConfig.IconFile;

            if (_displayFileTab)
            {
                _filePathEdt.Text = TailFileConfig.FilePath;

                _fileEncodingCmb.Items.Add(Encoding.Default);
                _fileEncodingCmb.Items.Add(Encoding.UTF8);
                _fileEncodingCmb.Items.Add(Encoding.ASCII);
                _fileEncodingCmb.Items.Add(Encoding.Unicode);
                _fileEncodingCmb.SelectedItem = TailFileConfig.EnumFileEncoding;

                _fileCacheSizeEdt.Text = TailFileConfig.FileCacheSize.ToString();

                _fileLogHitEdt.Text = TailFileConfig.LogHitText;

                _windowServiceEdt.Text = TailFileConfig.ServiceName;
            }
            else
            {
                _tabControl.TabPages.Remove(_tabPageFile);
            }
        }

        private void _acceptBtn_Click(object sender, EventArgs e)
        {
            TailFileConfig.Title = _windowTitleEdt.Text;
            TailFileConfig.IconFile = _windowIconEdt.Text;

            if (_displayFileTab)
            {
                TailFileConfig.FilePath = _filePathEdt.Text;

                TailFileConfig.EnumFileEncoding = (Encoding)_fileEncodingCmb.SelectedItem;

                TailFileConfig.FileCacheSize = Int32.Parse(_fileCacheSizeEdt.Text);

                TailFileConfig.LogHitText = _fileLogHitEdt.Text;

                TailFileConfig.ServiceName = _windowServiceEdt.Text;
            }
        }

        private void _textColorBtn_Click(object sender, EventArgs e)
        {
            FontDialog fdlgText = new FontDialog();
            if (TailFileConfig.FormFont != null)
                fdlgText.Font = TailFileConfig.FormFont;
            if (TailFileConfig.FormTextColor != null)
                fdlgText.Color = TailFileConfig.FormTextColor.Value;
            fdlgText.ShowColor = true;
            if (fdlgText.ShowDialog() == DialogResult.OK)
            {
                TailFileConfig.FormFont = fdlgText.Font;
                TailFileConfig.FormTextColor = fdlgText.Color;
            }
        }

        private void _backColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (TailFileConfig.FormBackColor != null)
                colorDlg.Color = TailFileConfig.FormBackColor.Value;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                TailFileConfig.FormBackColor = colorDlg.Color;
            }
            
        }
    }
}