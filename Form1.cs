using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Timers;
using System.CodeDom;

namespace SmartLampLight
{
    public partial class Form1 : Form
    {

        private string path;
        private string serialNum = "";
        //private string phone = "";
        private string apk = "";
        private string defaultCommand = "adb ";

        // timer
        private System.Timers.Timer timer;
        private int timerCount = 0;


        Dictionary<string, string> mode = new Dictionary<string, string>()
            {
                {"00", "독서모드   "}, {"01", "창의력모드"}, {"02","수리모드   "}, {"03","수면모드   "}
            };
        Dictionary<string, string> autoMode = new Dictionary<string, string>()
        {
            {"00","자동"}, {"01", "수동"}
        };
        

        //using cmd shell
        System.Diagnostics.ProcessStartInfo proInfo;
        System.Diagnostics.Process pro;
        System.Diagnostics.Process proc;

        private BackgroundWorker bw = null;
        private bool stopFlag = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void openProcess(System.Diagnostics.Process proc)
        {
            proc.StartInfo = proInfo;
            proc.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cmd shell setting
            proInfo = new System.Diagnostics.ProcessStartInfo();
            proc = new System.Diagnostics.Process();
            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;

            //recieve cmd data
            proInfo.RedirectStandardOutput = true;
            // send data to cmd
            proInfo.RedirectStandardInput = true;
            // recive cmd error
            proInfo.RedirectStandardError = true;

            proc.StartInfo = proInfo;
            proc.Start();

            // path
            path = Application.StartupPath + "/";

            // progressbar
            installProgressBar.Step = 10;
            installProgressBar.Value = 0;
            installProgressBar.Maximum = 100;
            installingLabel.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // get adb devices
            getDevices();

            // get apk files
            //getApk();
        }
        /*
        private void getApk()
        {
            // get apk files
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
            foreach (var item in di.GetFiles())
            {
                if (System.IO.Path.GetExtension(item.Name).Equals(".apk"))
                {
                    apkBox.Items.Add(item.Name);
                }
            }
        }
        */
        private void getDevices()
        {
            // cmd shell setting
            proc = new System.Diagnostics.Process();
            proc.StartInfo = proInfo;
            proc.Start();

            // get adb devices
            proc.StandardInput.Write(@"adb devices" + Environment.NewLine);
            proc.StandardInput.Close();
            string[] result = proc.StandardOutput.ReadToEnd().Split('\n');
            int i = 0;
            for (i = 0; i < result.Length; i++)
            {
                if (result[i][0] == 'L')
                {
                    i++;
                    break;
                }
            }
            for (; i < result.Length; i++)
            {
                if (result[i].IndexOf("device") != -1)
                {
                    string temp = result[i].Split('\t')[0];
                    serialNumberBox.Items.Add(temp);
                }
            }
            proc.WaitForExit();
            proc.Close();
        }

        private void serialNumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //phone = "-s " + serialNumberBox.GetItemText(serialNumberBox.SelectedItem);
            serialNum = serialNumberBox.GetItemText(serialNumberBox.SelectedItem);

            //
            /*
            for(int i=0; i<serialNumberBox.Items.Count; i++)
            {
                if(serialNumberBox.Items[i].ToString().Length == 8)
                {
                    serialNum = "-s " + serialNumberBox.Items[i].ToString();
                    break;
                }
            }
            */
        }
        

        private void installButton_Click(object sender, EventArgs e)
        {
            if (serialNum == "")
            //if (phone == "" || phone.Length == 8)
            {
                MessageBox.Show("Please select the serial number of Phone!", "System");
                return;
            }
            if (apk == "" || apk == null)
            {
                MessageBox.Show("Please select the apk file!", "System");
                return;
            }

            //string command = defaultCommand + phone + " install -t " + apk;
            string command = defaultCommand + "-s " + serialNum + " install -t " + apk;
            proc = new System.Diagnostics.Process();
            proc.StartInfo = proInfo;
            proc.Start();

            installProgressBar.Visible = true;
            installingLabel.Text = "installing..0%";
            installingLabel.Visible = true;
            // using new thread
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(timer_tick);
            timer.Start();


            proc.StandardInput.Write(@command + Environment.NewLine);
            proc.StandardInput.Close();
            proc.WaitForExit();

            string[] result = proc.StandardOutput.ReadToEnd().Split('\n');
            int flag = 0;
            for(int i = 0; i < result.Length; i++)
            {
                if(result[i].ToLower().IndexOf("success") != -1)
                {
                    flag = 1;
                    break;
                }
            }
            if (timer.Enabled)
            {
                timer.Close();
                timerCount = 0;
            }

            if (flag == 1)
            {
                if (timer.Enabled)
                {
                    installProgressBar.Value = 100;
                    installingLabel.Text = "please wait...";
                }
                MessageBox.Show("Success!", "System");
            }
            else
                MessageBox.Show("Failed to install apk file.\nPlease check!", "System");

            proc.Close();
            installProgressBar.Visible = false;
            installingLabel.Visible = false;
            installProgressBar.Value = 0;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            installingLabel.Text = "installing.." + installProgressBar.Value + "%";
            installProgressBar.PerformStep();

            if (++timerCount == 11)
            {
                installingLabel.Text = "please wait...";
                timer.Stop();
                timerCount = 0;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (serialNum == "" || serialNum.Length != 8)
            {
                MessageBox.Show("Please select Serial Number first!");
                return;
            }

            stopThread(bw);
            showBox.Items.Clear();
            bw = null;

            // cmd shell setting
            proc = new System.Diagnostics.Process();
            proc.StartInfo = proInfo;
            proc.Start();

            string command = defaultCommand + "-s " + serialNum + " logcat -c";
            proc.StandardInput.Write(@command + Environment.NewLine);
            proc.StandardInput.Close();

            proc.WaitForExit();
            proc.Close();

            stopFlag = false;
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (bw != null) return;

            if (stopFlag)
            {
                stopFlag = false;
                showBox.Items.Clear();
            }

            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = false;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += getLog;
            bw.RunWorkerAsync();

            /*
            Thread th = new Thread(getLog);
            threadPool = th;
            th.Start();
            */
        }

        private void getLog(object sender, DoWorkEventArgs e)
        {   
            if(bw.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            if(serialNum == "" || serialNum.Length != 8)
            {
                MessageBox.Show("Please select Serial Number first!");
                return;
            }

            pro = new System.Diagnostics.Process();
            pro.StartInfo = proInfo;
            pro.Start();


            // set mcu
            string command = defaultCommand + "-s " + serialNum + " shell ";
            //pro.StandardInput.Write(@command + Environment.NewLine);
            string t = command + "\"setprop log.mcu 1\"";
            //pro.StandardInput.Write(@t + Environment.NewLine);
            t = command + "\"setprop persist.infr.mcu_log 1\"";
            pro.StandardInput.Write(@t + Environment.NewLine);
            //pro.StandardInput.Close();
            /*
            string tt = command + "\"getprop | grep mcu\"";
            //pro.StandardInput.Write(@"getprop | grep mcu" + Environment.NewLine);
            pro.StandardInput.Write(@tt + Environment.NewLine);
            */
            pro.StandardInput.Close();
            pro.WaitForExit();
            pro.Close();


            pro = new System.Diagnostics.Process();
            pro.StartInfo = proInfo;
            pro.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(logHandler);
            pro.Start();

            // get mcu value
            command += "\"logcat -s SmartLampMcuComm\"";
            pro.StandardInput.Write(@command + Environment.NewLine);
            pro.StandardInput.Close();



            pro.BeginOutputReadLine();
            //pro.WaitForExit();
            //pro.Close();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopThread(bw);
            bw = null;
            stopFlag = true;
        }

        private void stopThread(BackgroundWorker t)
        {   
            if(t != null)
            {
                t.CancelAsync();

                if (pro != null)
                {
                    pro.CancelOutputRead();
                    pro.Close();
                    pro = null;
                }
            }
        }

    
        private void logHandler(object sender, System.Diagnostics.DataReceivedEventArgs line)
        {
            if (line == null) return;
            string[] temp = new string[18];
            temp.Initialize();

            if(line.Data == null)
            {
                stopThread(bw);
                bw = null;
                stopFlag = true;
                MessageBox.Show("[Error] Please check your usb,\ntry once more!", "System");
                return;
            }

            string output = line.Data.ToString();
            if (output.IndexOf("-s") != -1) return;
            if (output.IndexOf("SmartLampMcuComm") == -1) return;
            if (output.IndexOf("(") != -1) return;
                removeBlank(output, temp);
            string stat = "";
            if (temp[10] == "00") stat = "OFF";
            else if (temp[10] == "01") stat = "ON ";
            else return;

            string modeName;
            mode.TryGetValue(temp[12], out modeName);
            string autoName;
            autoMode.TryGetValue(temp[14], out autoName);
            string tmp = temp[0] + "  " + temp[1] + "   " + temp[6] + "\t" + stat + "\t" + autoName + "\t" + modeName + "\tBrightness: " + temp[11];
            //tmp = temp[0] + "\t" + temp[1] + "\tMode: " + modeName + "\tBrightness: " + temp[11];

            setShowBox(tmp);
            
        }

        private delegate void setShowBoxInvoker(string text);
        private void setShowBox(string text) {
            if (showBox.InvokeRequired)
            {
                //showBox.Invoke(new setShowBoxInvoker(setShowBox), text);
                showBox.BeginInvoke(new setShowBoxInvoker(setShowBox), text);
                string hi = text;
            }
            else
            {
                showBox.Items.Add(text);
                showBox.TopIndex = showBox.Items.Count - 1;
            }
        }
        

        private void removeBlank(string line, string[] arr)
        {
            int j = 0;
            bool flag = false;

            for(int i = 0; i < line.Length; i++)
            {
                if(line[i] != ' ' && line[i]!= '\t')
                {
                    if (flag)
                    {
                        j++;
                        flag = false;
                    }
                    arr[j] += line[i];
                }
                else
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                }
            }
        }

        private void serialRefreshButton_Click(object sender, EventArgs e)
        {
            serialNumberBox.Items.Clear();
            serialNum = "";
            getDevices();
        }

        private void apkBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openApkDialog = new OpenFileDialog();
            openApkDialog.Title = "Find apk file";
            openApkDialog.Filter = "(*.apk)|*.apk";
            openApkDialog.InitialDirectory = "C:\\";

            if(openApkDialog.ShowDialog() == DialogResult.OK)
            {
                apk = openApkDialog.FileName;
                apkNameBox.Text = apk.Split('\\')[apk.Split('\\').Length - 1];
            }

        }

        private void downAllButton_Click(object sender, EventArgs e)
        {
            if(serialNum == "" || serialNum.Length != 8)
            {
                MessageBox.Show("Please select serial Number!");
                return;
            }

            proc = new System.Diagnostics.Process();
            proc.StartInfo = proInfo;
            proc.Start();

            string filename = "logcat_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string command = defaultCommand + "-s " + serialNum + " logcat -d > " + path + filename;
            proc.StandardInput.Write(@command + Environment.NewLine);
            proc.StandardInput.Close();
            proc.WaitForExit();
            proc.Close();

            MessageBox.Show("All done!\nCheck " + filename, "System");
        }

        private void downSelButton_Click(object sender, EventArgs e)
        {
            string filename;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Set download Path";
            saveDialog.OverwritePrompt = true;
            saveDialog.Filter = "Text File | *.txt";

            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveDialog.FileName;
                List<string> lst = new List<string>();

                foreach(string line in showBox.SelectedItems)
                {
                    lst.Add(line);
                }
                System.IO.File.WriteAllLines(filename, lst);
                showBox.ClearSelected();
                MessageBox.Show("Done!", "System");
            }
            
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://github.com/sookylee");
        }
    }
}
