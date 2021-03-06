﻿/*----------------------------------------------------------------------------------------------
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
using System.Linq;
using System.Drawing.Imaging;

namespace TestDemo
{
    public partial class HistagramForm : CCWin.Skin_Mac
    {
        public HistagramForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            curBitmap = new Bitmap(path);
            DrawHistogram(curBitmap, 0);
            comboBox1.SelectedIndex = 0;
        }
        private Bitmap curBitmap = null;
        private void DrawHistogram(Bitmap tmp, int channel)
        {
            if (tmp != null)
            {
                int w = tmp.Width;
                int h = tmp.Height;
                int[] gray = new int[256];
                int[] r = new int[256];
                int[] g = new int[256];
                int[] b = new int[256];
                BitmapData srcData = tmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                IntPtr srcPtr = srcData.Scan0;
                int srcSize = srcData.Stride * srcData.Height;

                byte[] srcBytes = new byte[srcSize];

                System.Runtime.InteropServices.Marshal.Copy(srcPtr, srcBytes, 0, srcSize);

                int pos = 0;
                int offset = srcData.Stride - w * 4;
                for (int j = 0; j < h; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        int v0 = srcBytes[pos++];
                        int v1 = srcBytes[pos++];
                        int v2 = srcBytes[pos++];

                        gray[(v0 + v1 + v2) / 3]++;
                        b[v0]++;
                        g[v1]++;
                        r[v2]++;
                    }
                    pos += offset;
                }
                tmp.UnlockBits(srcData);
                Bitmap grayHisBmp = new Bitmap(System.Windows.Forms.Application.StartupPath + "\\hisBmp.jpg");
                Graphics grayGra = Graphics.FromImage(grayHisBmp);
                Point start;
                Point end;
                Pen p0 = new Pen(Color.Black, 1);
                Pen p1 = new Pen(Color.Red, 1);
                Pen p2 = new Pen(Color.Green, 1);
                Pen p3 = new Pen(Color.Blue, 1);
                int grayMax = gray.Max();
                int rMax = r.Max();
                int gMax = g.Max();
                int bMax = b.Max();
                switch (channel)
                {
                    case 0:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - gray[i] * 150 / (grayMax));
                            grayGra.DrawLine(p0, start, end);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - r[i] * 150 / (rMax));
                            grayGra.DrawLine(p1, start, end);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - g[i] * 150 / (gMax));
                            grayGra.DrawLine(p2, start, end);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - b[i] * 150 / (bMax));
                            grayGra.DrawLine(p3, start, end);
                        }
                        break;
                }
                grayGra.Dispose();
                pictureBox1.Image = (Image)grayHisBmp;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawHistogram(curBitmap, comboBox1.SelectedIndex);
        }
    }
}
