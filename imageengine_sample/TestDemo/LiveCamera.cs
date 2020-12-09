/*----------------------------------------------------------------------------------------------
*
* This file is XIUSDK's property. It contains XIUSDK's trade secret, proprietary and
* confidential information.
*
* The information and code contained in this file is only for authorized XIUSDK employees
* to design, create, modify, or review.
*
* DO NOT DISTRIBUTE, DO NOT DUPLICATE OR TRANSMIT IN ANY FORM WITHOUT PROPER AUTHORIZATION.
*
* If you are not an intended recipient of this file, you must not copy, distribute, modify,
* or take any action in reliance on it.
*
* If you have received this file in error, please immediately notify XIUSDK and
* permanently delete the original and any copy of any file and any printout thereof.
*
*---------------------------------------------------------------------------------------------*/
/*****************************************************************************
 Copyright:    www.xiusdk.cn(all rights reserved)
 Description:  beautyEngine sdk 包含人脸美化模块/滤镜模块
 Author:       xiusdk
 Version:      V1.2
 Date:         20200101-20231230
 qq group:     567648913(加群获取最新信息)
*****************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing.Imaging;

namespace TestDemo
{
    public partial class LiveCamera : CCWin.Skin_Mac
    {
        public LiveCamera()
        {
            InitializeComponent();
            
        }

        #region 变量定义
        // statistics length
        private const int statLength = 15;
        // statistics array
        private bool startdetect = true;
        private bool DeviceExist = false;
        private int width = 0;
        private int height = 0;
        //Soft skin 设置
        private int skinWhiteRatio = 0;
        private int skinSoftRatio = 0;
        private int filterId = 0;
        private ZBeautyEngineDll softSkin = new ZBeautyEngineDll();
        private VideoCaptureDeviceForm videoCaptureDeviceForm = null;
        private VideoCaptureDevice videoSource = null;
        
        //delegate void SetImageDelegate(Bitmap image);
        #endregion

        //关闭视频函数
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        private void LiveCamera_FormClosing(object sender, FormClosingEventArgs e)
        {         
              CloseVideoSource(); 
        }

        void videoSource_NewFrame(object sender, NewFrameEventArgs e)
        {
            if (e.Frame == null)
                return;
            Bitmap img = (Bitmap)e.Frame.Clone();
            
            //do processing here
            img = softSkin.DoFastSoftSkin(img, skinSoftRatio, skinWhiteRatio, filterId);
            pictureBox1.Image = img;
   
        }

        // 选择camera设备
        private void button2_Click(object sender, EventArgs e)
        {
            videoCaptureDeviceForm = new VideoCaptureDeviceForm();
            if (videoCaptureDeviceForm.ShowDialog(this) == DialogResult.OK)
            {
                if (videoCaptureDeviceForm.VideoDevice != null)
                {
                    DeviceExist = true;
                }
            }
        }
  
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoCaptureDeviceForm.VideoDevice); // 选择一个设备
                    
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    CloseVideoSource();
                    videoSource.Start();
                    timer1.Enabled = true;
                    button1.Text = "结束";
                }
            }
            else
            {   
                if (videoSource != null)
                {
                    if (videoSource.IsRunning)
                    {
                        timer1.Enabled = false;
                        CloseVideoSource();
                        button1.Text = "开始";
                    }
                }
            }
            
        }





        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null && !startdetect)
            {
                Pen p = new Pen(Color.Yellow, 2);
                e.Graphics.DrawString("分辨率：" + width.ToString() + "X" + height.ToString(), new Font("宋体", 10, FontStyle.Bold), Brushes.Gold, 0, 0);
                e.Dispose();
            }
        }

        //美白
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBar1.Value.ToString();
            skinWhiteRatio = hScrollBar1.Value;
        }
        //磨皮
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar2.Value.ToString();
            skinSoftRatio = hScrollBar2.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterId++;
            if (filterId > 20)
                filterId = 0;
        }
        private int count = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(pictureBox1.Image);
            temp.Save(Application.StartupPath + "\\LiveCameraImageSave\\" + (count++).ToString() + ".jpg", ImageFormat.Jpeg);
            pictureBox2.Image = (Image)temp;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + "\\LiveCameraImageSave");
        }


    }
}
