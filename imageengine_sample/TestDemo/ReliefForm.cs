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
    public partial class ReliefForm : CCWin.Skin_Mac
    {
        public ReliefForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int angle = 90;
        private int amount = 500;
        public int getAngle
        {
            get { return angle; }
        }
        public int getAmount
        {
            get { return amount; }
        }
        //角度
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }
        //数量
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            angle = skinHScrollBar1.Value;
            amount = skinHScrollBar2.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
