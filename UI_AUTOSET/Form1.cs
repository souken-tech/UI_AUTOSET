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

        private void Form1_Load(object sender, EventArgs e)
        {

        }





    }
}
