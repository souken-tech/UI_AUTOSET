using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_AUTOSET
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel tableLayoutPanel;

        UI_AUTOSET ui_set;

        public Form1()
        {
            InitializeComponent();

            //コンストラクタにUIを置きたいパネルと設定のJsonを渡す。
            ui_set = new UI_AUTOSET(ref panel1, "data.json");
            //UIをセット
            ui_set.LoadAndSetUI();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            GetTextBoxValues();
        }

        private void GetTextBoxValues()
        {

            // テキストボックスの値を取得
            Dictionary<string, string> textBoxValues = ui_set.GetTextBoxValues();

            string message= string.Empty;

            // 値を確認（ここではコンソールに出力）
            foreach (var kvp in textBoxValues)
            {
                Console.WriteLine($"TextBox Name: {kvp.Key}, Value: {kvp.Value}");
                message = message + $"TextBox Name: {kvp.Key}, Value: {kvp.Value}" + Environment.NewLine;

            }

            MessageBox.Show(message);
        }
    }
}
