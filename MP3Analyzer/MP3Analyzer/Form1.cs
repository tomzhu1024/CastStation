using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MP3Analyzer
{
    public partial class Form1 : Form
    {
        FileStream fs;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            }
            btnAnalyze.Enabled = true;
        }

        // No try-catch is used here because this program is only
        // aimed for debug use, all exception can be caught by IDE
        // and be later analyzed.
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            //read id3v2 from file
            byte[] ID3V2_HEADER_IDENTIFIER = new byte[3];
            byte[] ID3V2_HEADER_VERSION = new byte[2];
            byte[] ID3V2_HEADER_FLAG = new byte[1];
            byte[] ID3V2_HEADER_SIZE = new byte[4];
            fs.Read(ID3V2_HEADER_IDENTIFIER, 0, 3);
            fs.Read(ID3V2_HEADER_VERSION, 0, 2);
            fs.Read(ID3V2_HEADER_FLAG, 0, 1);
            fs.Read(ID3V2_HEADER_SIZE, 0, 4);

            //check id3v2
            if (ID3V2_HEADER_IDENTIFIER[0] != 0x49
                || ID3V2_HEADER_IDENTIFIER[1] != 0x44
                || ID3V2_HEADER_IDENTIFIER[2] != 0x33
                || ID3V2_HEADER_VERSION[0] != 03
                || ID3V2_HEADER_VERSION[1] != 00)
            {
                //id3v2 not exists
                fs.Seek(0, SeekOrigin.Begin);
                return;
            }

            int ID3V2_SIZE;
            ID3V2_SIZE = (ID3V2_HEADER_SIZE[0] & 0x7F) * 0x200000
                + (ID3V2_HEADER_SIZE[1] & 0x7F) * 0x4000
                + (ID3V2_HEADER_SIZE[2] & 0x7F) * 0x80
                + (ID3V2_HEADER_SIZE[3] & 0x7F);

            //skip the id3v2 info
            fs.Seek(ID3V2_SIZE, SeekOrigin.Current);

            //repeat to read data frame
            int[] BITRATE_LIST = new int[] { 0, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 0 };
            float[] SMP_FREQ_LIST = new float[] { 44.1F, 48, 32, 0 };

            int FRAME_NO = 0;

            listView1.BeginUpdate();
            listView1.Items.Clear();

            while (fs.Position < fs.Length)
            {
                byte[] FRAME_HEAD = new byte[4];
                fs.Read(FRAME_HEAD, 0, 4);

                if (FRAME_HEAD[0] != 0xFF || (FRAME_HEAD[1] != 0xFB && FRAME_HEAD[1] != 0xFA))
                {
                    break;
                }

                //帧长 = ((采样个数 * (1 / 采样率)) * 帧的比特率) / 8 + 帧的填充大小    （比特率单位kbps）
                int FRAME_BITRATE = BITRATE_LIST[FRAME_HEAD[2] / 0x10];
                float FRAME_SMP_FREQ = SMP_FREQ_LIST[(FRAME_HEAD[2] % 0x10) / 0x04];
                byte FRAME_OFFSET = (byte)((FRAME_HEAD[2] % 4) / 2);
                int FRAME_LENGTH = (int)Math.Floor(1152 * FRAME_BITRATE / FRAME_SMP_FREQ / 8 + FRAME_OFFSET);

                //帧时 = 采样个数/比特率 （比特率单位kbps、帧时单位ms）
                int FRAME_TIME = 1152 / (int)FRAME_SMP_FREQ;

                //ui update
                ListViewItem lvi = new ListViewItem();
                lvi.Text = FRAME_NO.ToString();
                lvi.SubItems.Add(FRAME_LENGTH.ToString());
                lvi.SubItems.Add(FRAME_TIME.ToString());
                lvi.SubItems.Add(FRAME_BITRATE.ToString());
                lvi.SubItems.Add(FRAME_SMP_FREQ.ToString());
                lvi.SubItems.Add(FRAME_OFFSET.ToString());
                listView1.Items.Add(lvi);

                FRAME_NO++;
                //move to nex frame if possible
                fs.Seek(FRAME_LENGTH - 4, SeekOrigin.Current);
            }

            listView1.EndUpdate();
        }
    }
}
