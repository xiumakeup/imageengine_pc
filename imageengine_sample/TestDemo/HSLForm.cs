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
    public partial class HSLForm : CCWin.Skin_Mac
    {
        public HSLForm(string path)
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
        private Bitmap curBitmap = null;
        private int hue = 0;
        private int satruation = 0;
        private int lightness = 0;
        private Bitmap tmp = null;
        public int getHue
        {
            get { return hue; }
        }
        public int getSaturation
        {
            get { return satruation; }
        }
        public int getLightness
        {
            get { return lightness; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            hue = hScrollBar1.Value;
            satruation = hScrollBar2.Value;
            lightness = hScrollBar3.Value; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //hue
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox1.Text = hScrollBar1.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
        //saturation
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox2.Text = hScrollBar2.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
        //lightness
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox3.Text = hScrollBar3.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
    }
}
