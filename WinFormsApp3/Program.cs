using System.Diagnostics;
using System.Text;

namespace WinFormsApp3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    ///<summary>
    ///目的：FPSゲームを起動中にデュアルディスプレイからシングルディスプレイに切り替える
    ///終了したら元に戻す
    ///
    /// 必要な動作
    /// ディスプレイ動作切り替え
    /// 対称のアプリの特定、起動中か確認
    /// リストに対称のアプリを表示
    ///</summary>
    
    public static class MyClass
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern UInt32 SetDisplayConfig(
            UInt32 numPathArrayElements,
            IntPtr pathArray,
            UInt32 numModeInfoArrayElements,
            IntPtr modeInfoArray,
            UInt32 flags
         );

        static readonly string savePath = Environment.CurrentDirectory + "\\paths.txt";
        static readonly string saveName = Environment.CurrentDirectory + "\\names.txt";
        public static void DisplayModeSwitch(string mode)
        {
            if (mode == "multi")
            {
                SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, 0x00000004 | 0x00000080);
            }
            else if (mode == "single")
            {
                SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, 0x00000001 | 0x00000080);
            }
        }
        public static Dictionary<string, string> SelectTarget()
        {
            string filePath = string.Empty;
            string fileName = string.Empty;
            var dic = new Dictionary<string, string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe";


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName.Replace(".exe", "");
                }
            }
            dic.Add("path", filePath);
            dic.Add("name", fileName);

            return dic;
        }

        public static void SaveTargetName(string name)
        {
            if (!File.Exists(saveName))
            {
                File.Create(saveName).Dispose();
            }

            string temp = string.Empty;
            using (StreamReader sr = new StreamReader(saveName))
            {
                temp = sr.ReadToEnd();
            }


            string[] names = temp.Split(Environment.NewLine);
            if (!names.Contains(name))
            {
                using (StreamWriter sw = new StreamWriter(saveName, true, Encoding.UTF8))
                {
                    sw.WriteLine(name);
                }
            }
        }

        public static void SaveTargetPath(string path)
        {
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Dispose();
            }

            string temp = string.Empty;
            using (StreamReader sr = new StreamReader(savePath))
            {
                temp = sr.ReadToEnd();
            }


            string[] paths = temp.Split(Environment.NewLine);
            if (!paths.Contains(path))
            {
                using (StreamWriter sw = new StreamWriter(savePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(path);
                }
            }
        }

        public static string[] ReadListNames()
        {
            string[] names = Array.Empty<string>();
            if (File.Exists(saveName))
            {
                using (StreamReader sr = new StreamReader(saveName))
                {
                    names = sr.ReadToEnd().Split(Environment.NewLine);
                }
            }

            return names;
        }

        public static string[] ReadListPaths()
        {
            string[] paths = Array.Empty<string>();
            if (File.Exists(savePath))
            {
                using (StreamReader sr = new StreamReader(savePath))
                {
                    paths = sr.ReadToEnd().Split(Environment.NewLine);
                }
            }

            return paths;
        }


        public static bool CheckTarget(string name)
        {
            Process[] pArray = Process.GetProcessesByName(name);
            if (pArray.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}