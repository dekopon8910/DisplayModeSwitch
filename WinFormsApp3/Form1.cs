using System.Diagnostics;
using System.Xml.Linq;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool flag = true;
        string multi = "Display mode : Multi";
        string single = "Display mode : Single";
        string auto = "Switch mode : Auto";
        string manual = "Switch mode : Manual";
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// 対称のファイルを選択しリストに追加する
            /// </summary>
            Dictionary<string, string> targetFileDic = MyClass.SelectTarget();
            MyClass.SaveTargetPath(targetFileDic["path"]);
            MyClass.SaveTargetName(targetFileDic["name"]);

            if (targetFileDic["path"] != string.Empty && !listView1.Items.ContainsKey(targetFileDic["name"]))
            {
                Icon img = Icon.ExtractAssociatedIcon(targetFileDic["path"]);
                int i = listView1.Items.Count;
                imageList1.Images.Add(img);
                listView1.Items.Add(targetFileDic["name"], i);
                img.Dispose();
            }
        }

        /// <summary>
        /// リスト上のファイルが起動しているか確認する
        /// 起動していればディスプレイモードを切り替える
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                string[] targetNames = MyClass.ReadListNames();
                foreach (string name in targetNames)
                {

                    if (name.Replace(Environment.NewLine, string.Empty) != string.Empty)
                    {
                        if (labelMode.Text == multi)
                        {
                            if (MyClass.CheckTarget(name))
                            {
                                MyClass.DisplayModeSwitch("single");
                                labelMode.Text = single;
                            }
                        }
                        else
                        {
                            if (!MyClass.CheckTarget(name))
                            {
                                MyClass.DisplayModeSwitch("multi");
                                labelMode.Text = multi;
                            }
                        }
                    }
                }
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            flag = false;
            labelSwitchMode.Text = manual;
            if (labelMode.Text == multi)
            {
                MyClass.DisplayModeSwitch("single");
                labelMode.Text = single;

            }
            else
            {
                MyClass.DisplayModeSwitch("multi");
                labelMode.Text = multi;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SystemInformation.MonitorCount > 1)
            {
                
                labelMode.Text = multi;
            }
            else
            {
                
                labelMode.Text = single;
            }

            labelSwitchMode.Text = auto;

            string[] paths = MyClass.ReadListPaths();
            string[] names = MyClass.ReadListNames();
            if (File.Exists(Environment.CurrentDirectory + "\\paths.txt") && File.Exists(Environment.CurrentDirectory + "\\names.txt"))
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    if (paths[i] != string.Empty)
                    {
                        Icon img = Icon.ExtractAssociatedIcon(paths[i]);
                        imageList1.Images.Add(img);
                        listView1.Items.Add(names[i], i);
                        img.Dispose();
                    }
                }
            }


        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            flag = true;
            labelSwitchMode.Text = auto;
        }
    }
}
