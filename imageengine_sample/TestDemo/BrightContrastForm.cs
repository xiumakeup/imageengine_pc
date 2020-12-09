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

namespace TestDemo
{
    public partial class BrightContrastForm : CCWin.Skin_Mac
    {
        public BrightContrastForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)curBitmap;
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private int brightness = 0;
        private int contrast = 0;
        private bool versionNew = true;
        private Bitmap curBitmap = null;
        public int getBright
        {
            get { return brightness; }
        }
        public int getContrast
        {
            get { return contrast; }
        }
        public bool getVersion
        {
            get { return versionNew; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //brightness = hScrollBar1.Value;
                //contrast = hScrollBar2.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //bright
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox1.Text = hScrollBar1.Value.ToString();
                brightness = hScrollBar1.Value;
                contrast = hScrollBar2.Value;
                if (versionNew)
                {
                    pictureBox1.Image = zPhoto.NLinearBrightContrastAdjust(curBitmap, brightness,contrast, 128);
                }
                else
                {
                    pictureBox1.Image = zPhoto.LinearBrightContrastAdjust(curBitmap, brightness, contrast, 128);
                }
            }
        }
        //contrast
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox2.Text = hScrollBar2.Value.ToString();
                brightness = hScrollBar1.Value;
                contrast = hScrollBar2.Value;
                if (versionNew)
                {
                    pictureBox1.Image = zPhoto.NLinearBrightContrastAdjust(curBitmap, brightness, contrast, 128);
                }
                else
                {
                    pictureBox1.Image = zPhoto.LinearBrightContrastAdjust(curBitmap, brightness, contrast, 128);
                }
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                versionNew = false;
                //hScrollBar1.Maximum = 159;
                //hScrollBar1.Minimum = -150;
                //hScrollBar2.Maximum = 109;
                //hScrollBar2.Minimum = -50;
                hScrollBar1.Value = 0;
                hScrollBar2.Value = 0;
                textBox1.Text = hScrollBar1.Value.ToString();
                textBox2.Text = hScrollBar2.Value.ToString();
                brightness = 0;
                contrast = 0;
            }
            else
            {
                versionNew = true;
                //hScrollBar1.Maximum = 109;
                //hScrollBar1.Minimum = -100;
                //hScrollBar2.Maximum = 109;
                //hScrollBar2.Minimum = -100;
                hScrollBar1.Value = 0;
                hScrollBar2.Value = 0;
                textBox1.Text = hScrollBar1.Value.ToString();
                textBox2.Text = hScrollBar2.Value.ToString();
                brightness = 0;
                contrast = 0;
            }
        }
    }
}
