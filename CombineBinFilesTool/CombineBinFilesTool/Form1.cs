using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CombineBinFilesTool
{
    public partial class Form1 : Form
    {

        //TextBox的默认值
        //private const String Boot_DEFAULT_TEXT = "128";
        //private const String App_DEFAULT_TEXT = "512";
        //private const String CRC_DEFAULT_TEXT = "40";
        private  string CrcFileFold = "";
        private string BootFileTemp = "";
        private string AppFileTemp = "";
        public Form1()
        {
            InitializeComponent();
            CommonUsages.Init();

            //从配置文件中读取默认值（即上次保存的值）
            SetDefaultText(BootFileSize, CommonUsages.DefaultBootBinFileSize);
            SetDefaultText(AppFileSize, CommonUsages.DefaultAppBinFileSize);
            SetDefaultText(CRCSize, CommonUsages.DefaultCrcFileSize);
            if (CommonUsages.DefaultCrcCheckSize.Trim().Equals("200"))
            {
                CRC200.Checked = true;
            }
            else
            { 
                CRC512.Checked = true;
            }
            string Version ="v" + Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0,3);
            this.Text = "bin文件合并" + Version;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btBoot_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "bin文件|*.bin";
            ofd.Title = "请选择bin文件";

            ofd.InitialDirectory = CommonUsages.DefaultFolder;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tBBootFolder.Text = ofd.FileName;
                CommonUsages.DefaultFolder = Path.GetFullPath(ofd.FileName);
            }
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    tBBootFolder.Text = folderBrowserDialog1.SelectedPath;
            //}
        }

        private void btApp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "bin文件|*.bin";
            ofd.Title = "请选择bin文件";
            ofd.InitialDirectory = CommonUsages.DefaultFolder;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tBAppFolder.Text = ofd.FileName;
                CommonUsages.DefaultFolder = Path.GetFullPath(ofd.FileName);
            }
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    tBAppFolder.Text = folderBrowserDialog1.SelectedPath;
            //}
        }

        private void btCombineFiles_Click(object sender, EventArgs e)
        {
            //CRC校验大小，我看STM32和RTMIM使用的校验值不同。一个是200K，一个是512K
            int Length = 0;
            if (CRC200.Checked)
            {
                Length = 200 * 1024;
            }
            else if (CRC512.Checked)
            {
                Length = 512 * 1024;
            }
            //string sdg3256 = @"C:\Users\user\Desktop\BIN文件合并\最终的文件\bin_更新\bin\lcm.bin";
            //if (CommonUsages.CheckCrc16(sdg3256, Length))
            //{
            //    string sdg = CommonUsages.CrcString;
            //}

            //文件校验
            if (CheckFile())
            {
                //填充bin文件到指定大小
                if (!FillFile(tBBootFolder.Text, long.Parse(BootFileSize.Text.Trim()) * 1024 ))
                {
                    CommonUsages.MyMsgBox(" boot文件夹下bin文件拼接失败", CommonUsages.MsgBoxTypeEnum.Error);
                    return;
                }
                if (!FillFile(tBAppFolder.Text, long.Parse(AppFileSize.Text.Trim()) * 1024))
                {
                    CommonUsages.MyMsgBox(" app文件夹下bin文件拼接失败", CommonUsages.MsgBoxTypeEnum.Error);
                    return;
                }

                //CRC校验,只校验app地下的，还是扩展拼接后的
                string CrcFileTemp = Path.GetDirectoryName(tBAppFolder.Text) + @"\" + Path.GetFileNameWithoutExtension(tBAppFolder.Text) + "_temp.bin";
                if (!CommonUsages.CheckCrc16(CrcFileTemp, Length))
                {
                    CommonUsages.MyMsgBox(" app文件夹下bin文件crc校验失败", CommonUsages.MsgBoxTypeEnum.Error);
                    return;
                }
                //string sdg3256 = @"C:\Users\user\Desktop\BIN文件合并\最终的文件\bin_更新\bin\lcm.bin";
                //if (CommonUsages.CheckCrc16(sdg3256, Length))
                //{
                //    string sdg = CommonUsages.CrcString;
                //}


                //crc文件需要新建
                if (!CreatCrcFile(Path.GetDirectoryName(tBAppFolder.Text)))
                {
                    CommonUsages.MyMsgBox(" crc文件创建失败", CommonUsages.MsgBoxTypeEnum.Error);
                    return;

                }


                //合并文件
                if (!CombineFiles())
                {
                    CommonUsages.MyMsgBox(" 合并文件失败", CommonUsages.MsgBoxTypeEnum.Error);
                    return;
                }
                else
                {
                    CommonUsages.MyMsgBox(" 合并文件成功", CommonUsages.MsgBoxTypeEnum.Info);
                    return;
                }
            }

        }
        private bool CheckFile()
        {
            //校验文件大小
            if (File.Exists(tBBootFolder.Text))
            {
                if (GetFileSize(tBBootFolder.Text) > double.Parse(BootFileSize.Text))
                {
                    CommonUsages.MyMsgBox(" boot loader文件夹下bin文件超过指定大小", CommonUsages.MsgBoxTypeEnum.Error);
                    return false;
                }
            }
            else
            {
                CommonUsages.MyMsgBox("boot loader文件夹下bin文件文件不存在", CommonUsages.MsgBoxTypeEnum.Error);
                return false;
            }

            if (File.Exists(tBAppFolder.Text))
            {
                if (GetFileSize(tBAppFolder.Text) > double.Parse(AppFileSize.Text))
                {
                    CommonUsages.MyMsgBox(" app文件夹下bin文件超过指定大小", CommonUsages.MsgBoxTypeEnum.Error);
                    return false;
                }
            }
            else
            {
                CommonUsages.MyMsgBox("app文件夹下bin文件文件不存在", CommonUsages.MsgBoxTypeEnum.Error);
                return false;
            }
            //CRC校验,只校验app地下的，还是扩展拼接后的
            //CommonUsages.CheckCrc16(tBBootFolder.Text);
            return true;
        }
        private double GetFileSize(string file)
        {
            if (File.Exists(file))
            {
                return new FileInfo(file).Length / 1024.00;
            }
            else
                return 0.00;

        }

        private bool FillFile(string fileName, long length)
        {
            
            string FileTemp = Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName) + "_temp.bin";
            
            if (!File.Exists(FileTemp))
            {
                //File.Create(FileTemp);
                File.Copy(fileName, FileTemp);
            }
            else
            {
                File.Delete(FileTemp);
                File.Copy(fileName, FileTemp);
            }
            //string saveFileName = fileName;
            using (FileStream fs = new FileStream(FileTemp, FileMode.Append, FileAccess.Write))
            {
                //方法1
                //byte[] byte124 = System.Text.Encoding.ASCII.GetBytes(0xff);


                //byte[] byte1 = System.Text.Encoding.ASCII.GetBytes("12345678");
                //fs.Position = 0;
                //fs.Write(byte1, 0, byte1.Length);

                //byte[] byte2 = System.Text.Encoding.ASCII.GetBytes("abcdef");
                //fs.Position = byte1.Length;
                //fs.Write(byte2, 0, byte2.Length);

                //byte[] byte3 = System.Text.Encoding.ASCII.GetBytes("ABCDEF");
                //fs.Position = byte1.Length + byte2.Length;
                //fs.Write(byte3, 0, byte3.Length);

                //方法2
                long dataLength = length - fs.Length;
                BinaryWriter bw = new BinaryWriter(fs);
                // bw.BaseStream.Length
                while (fs.Length < length)
                {
                   // bw.Write((UInt16)0xffff);

                    bw.Write((Byte)0xff);
                }

            }//end using
            return true;
        }

        private void SetDefaultText(TextBox textBox, string defaultaValue)
        {
            textBox.Text = defaultaValue;
            textBox.ForeColor = Color.Gray;
        }

        private bool CreatCrcFile(string Directory)
        {
            try
            {
                string FileTemp = Directory + @"\" + "crc.bin";

                using (FileStream fs = new FileStream(FileTemp, FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write((ushort)0xffff);
                }
                //string saveFileName = fileName;
                using (FileStream fs = new FileStream(FileTemp, FileMode.Append, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);

                    //存在文件中的时候低8为在前，高8为在后
                    //string CrcValue = CommonUsages.CrcString.Split('_')[1] + CommonUsages.CrcString.Split('_')[0];
                    //uint crc = uint.Parse(CrcValue);
                    //bw.Write(crc);
                    bw.Write(CommonUsages.CrcByte);

                    //方法2
                    long dataLength = int.Parse(CRCSize.Text.Trim()) * 1024 - fs.Length;                  
                    // bw.BaseStream.Length
                    while (fs.Length < dataLength)
                    {
                        bw.Write((uint)0xFFFFFFFF);
                        //bw.Write();
                    }

                }//end using
                CrcFileFold = FileTemp;
                return true;
            }
            catch (Exception ex)
            {
                CommonUsages.MyMsgBox(ex.Message, CommonUsages.MsgBoxTypeEnum.Error);
                return false;
            }
            
        }

        private bool CombineFiles()
        {
            try
            {
                
                string fileBootFolder = Path.GetDirectoryName(tBBootFolder.Text) + @"\" + Path.GetFileNameWithoutExtension(tBBootFolder.Text) + "_temp.bin"; 
                string fileApp = Path.GetDirectoryName(tBAppFolder.Text) + @"\" + Path.GetFileNameWithoutExtension(tBAppFolder.Text) + "_temp.bin"; 
                string fileCrc = CrcFileFold;
                string targetpath = Path.GetDirectoryName(tBAppFolder.Text) + @"\" + "boot_app_crc.bin";
                
                FileStream fsr1 = new FileStream(fileBootFolder, FileMode.Open, FileAccess.Read);
                FileStream fsr2 = new FileStream(fileApp, FileMode.Open, FileAccess.Read);
                FileStream fsr3 = new FileStream(fileCrc, FileMode.Open, FileAccess.Read);
                byte[] btArr = new byte[fsr1.Length + fsr2.Length + fsr3.Length];
                fsr1.Read(btArr, 0, Convert.ToInt32(fsr1.Length));
                fsr2.Read(btArr, Convert.ToInt32(fsr1.Length), Convert.ToInt32(fsr2.Length));
                fsr3.Read(btArr, Convert.ToInt32(fsr1.Length)+ Convert.ToInt32(fsr2.Length), Convert.ToInt32(fsr3.Length));
                fsr1.Close();
                fsr2.Close();
                fsr3.Close();
                FileStream fsw = new FileStream(targetpath, FileMode.Create, FileAccess.Write);
                fsw.Write(btArr, 0, btArr.Length);
                fsw.Flush();
                fsw.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private static byte HexStringToByte(string str)
        {
            byte bt;
            if (str != "")
            {
                bt = Convert.ToByte(str, 16);
                return bt;
            }
            return 0;
        }

        #region 事件触发
        //private void BootFileSize_Enter(object sender, EventArgs e)
        //{

        //    if (BootFileSize.Text == Boot_DEFAULT_TEXT)
        //    {
        //        BootFileSize.Text = "";
        //        BootFileSize.ForeColor = Color.Black;
        //    }

        //}

        //private void BootFileSize_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(BootFileSize.Text))
        //        SetDefaultText(BootFileSize, Boot_DEFAULT_TEXT);
        //}

        //private void AppFileSize_Enter(object sender, EventArgs e)
        //{
        //    if (AppFileSize.Text == App_DEFAULT_TEXT)
        //    {
        //        AppFileSize.Text = "";
        //        AppFileSize.ForeColor = Color.Black;
        //    }
        //}

        //private void AppFileSize_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(AppFileSize.Text))
        //        SetDefaultText(AppFileSize, App_DEFAULT_TEXT);
        //}

        //private void CRCSize_Enter(object sender, EventArgs e)
        //{
        //    if (CRCSize.Text == CRC_DEFAULT_TEXT)
        //    {
        //        CRCSize.Text = "";
        //        CRCSize.ForeColor = Color.Black;
        //    }
        //}

        //private void CRCSize_Leave(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(CRCSize.Text))
        //        SetDefaultText(CRCSize, CRC_DEFAULT_TEXT);
        //}
       

        private void Form1_Activated(object sender, EventArgs e)
        {
            //为了防止焦点选中文本框，虽然找个控件设置默认焦点
            label1.Focus();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            labelhide.Select();  //label1的visible属性设为false

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultFolder", CommonUsages.DefaultFolder);
            CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultBootBinFileSize", BootFileSize.Text.Trim());
            CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultAppBinFileSize", AppFileSize.Text.Trim());
            CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultCrcFileSize", CRCSize.Text.Trim());

            if (CRC200.Checked)
            {
                CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultCrcCheckSize", "200");
            }
            else
            {
                CommonUsages.UpdateXml(CommonUsages.ConfigFolder, "defaultCrcCheckSize", "512");
            }
           
        }
        #endregion
    }
}
