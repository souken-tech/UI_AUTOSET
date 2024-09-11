using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;  // Install Newtonsoft.Json via NuGet
using System.IO;
using static UI_AUTOSET.Form1;

namespace UI_AUTOSET
{
    public class UI_AUTOSET
    {
        private Panel panel;
        private string settingJsonFilePath;
        private TableLayoutPanel tableLayoutPanel;

        // コンストラクタ
        public UI_AUTOSET(ref Panel panel, string settingJsonFilePath)
        {
            this.panel = panel;
            this.settingJsonFilePath = settingJsonFilePath;

            Initialize();
        }


        // 初期化メソッド
        private void Initialize()
        {
            panel.AutoScroll=true;

            // TableLayoutPanelの設定
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 1  // 1列のみ
            };

            // PanelにTableLayoutPanelを追加
            panel.Controls.Add(tableLayoutPanel);

            // JSONファイルから設定を読み込み、UIを作成
            //LoadAndSetUI();
        }

        // JSONファイルを読み込み、UIを生成するメソッド
        public void LoadAndSetUI()
        {
            if (!File.Exists(settingJsonFilePath))
            {
                MessageBox.Show("設定ファイルが見つかりません: " + settingJsonFilePath);
                return;
            }

            // JSONデータの読み込み
            string jsonData = File.ReadAllText(settingJsonFilePath);

            // JSONをオブジェクトにデシリアライズ
            var items = JsonConvert.DeserializeObject<List<JsonItem>>(jsonData);

            // TableLayoutPanelにパネルとコントロールを追加
            AddRowsToTableLayout(items);
        }

        // TableLayoutPanelに行を追加するメソッド
        private void AddRowsToTableLayout(List<JsonItem> items)
        {
            tableLayoutPanel.RowCount = items.Count;

            foreach (var item in items)
            {
                // 新しいパネルを作成
                Panel rowPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Height = 40,
                    AutoSize = true
                };

                // ラベルの追加
                Label label = new Label
                {
                    Text = item.Label,
                    Width = 100,
                    Location = new System.Drawing.Point(10, 10)
                };

                // テキストボックスの追加
                TextBox textBox = new TextBox
                {
                    Name = item.Textbox,  // テキストボックスの名前にJSONから取得した名前を設定
                    Width = 200,
                    Location = new System.Drawing.Point(120, 10)
                };

                // パネルにラベルとテキストボックスを追加
                rowPanel.Controls.Add(label);
                rowPanel.Controls.Add(textBox);

                // TableLayoutPanelにパネルを追加
                tableLayoutPanel.Controls.Add(rowPanel);
            }
        }

        // JSONデータをマッピングするクラス
        public class JsonItem
        {
            public string Label { get; set; }
            public string Textbox { get; set; }
        }


        // テキストボックスの値を取得するメソッド
        public Dictionary<string, string> GetTextBoxValues()
        {
            var textBoxValues = new Dictionary<string, string>();

            // tableLayoutPanel内のコントロールをすべて確認
            foreach (Control rowPanel in tableLayoutPanel.Controls)
            {
                // 各Panelのコントロールを確認
                foreach (Control control in rowPanel.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        // テキストボックスのNameとTextをDictionaryに追加
                        textBoxValues.Add(textBox.Name, textBox.Text);
                    }
                }
            }

            return textBoxValues;
        }
    }
}
