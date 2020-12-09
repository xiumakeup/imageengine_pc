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
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace TestDemo
{
    public partial class Form1 : CCWin.Skin_Mac
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
        }

        #region  V Defination
        //image path
        private String curFileName = null;
        //current image
        private Bitmap curBitmap = null;
        //source image
        private Bitmap srcBitmap = null;
        //zphotoengine instance
        private ZPhotoEngineDll zPhoto = null;

        //temp image for makeup
        public static Bitmap tempBitmap = null;
        private int faceNum = 0;
        private int baseLMLen = 101;
        private int[] landMark;

        #endregion

        #region  Image open and save
        //打开图像函数
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                   "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                   "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                   "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            ofd.ShowHelp = true;
            ofd.Title = "打开图像文件";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                curFileName = ofd.FileName;
                try
                {
                    curBitmap = (Bitmap)System.Drawing.Image.FromFile(curFileName);

                    if (Math.Max(curBitmap.Width, curBitmap.Height) > 1280)
                    {
                        srcBitmap = new Bitmap(curBitmap, 1280 * curBitmap.Width / Math.Max(curBitmap.Width, curBitmap.Height), 1280 * curBitmap.Height / Math.Max(curBitmap.Width, curBitmap.Height));
                        curBitmap = new Bitmap(srcBitmap);
                    }
                    else
                    {
                        srcBitmap = new Bitmap(curBitmap);
                    }

                }
                catch (Exception exp)
                { MessageBox.Show(exp.Message); }
            }
        }
        //保存图像函数
        public void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG文件(*.png)|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
            }

        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            if(curBitmap != null)
            {
                landMark = new int[baseLMLen*2];
                using (YNFaceDetector detector = new YNFaceDetector())
                {
                    String startup = System.Windows.Forms.Application.StartupPath;
                    YNFaceDetector.YNRESULT res = detector.loadModels(startup + "\\models\\yn_model_detect.tar");
                    if(res != YNFaceDetector.YNRESULT.YN_OK)
                    {
                        faceNum = 0;
                        MessageBox.Show("人脸模型加载失败！！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    YNFaceDetector.YNFaces[] result = detector.Detect(curBitmap);
                    if (result != null && result.Count() > 0)
                    {
                        faceNum = 1;
                        for (int i = 0; i < baseLMLen; i++)
                        {
                            landMark[i * 2 + 0] = (int)result[0].shape.pts[i].x;
                            landMark[i * 2 + 1] = (int)result[0].shape.pts[i].y;
                        }

                        MakeupProcess(ImageProcessId.ID_MAKEUP_FACEDETECT);
                    }
                    else
                    {
                        faceNum = 0;
                        //MessageBox.Show("获取人脸点位失败！！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                pictureBox1.Image = (Image)curBitmap;
                toolStripStatusLabel2.Text = "图像宽高: (" + curBitmap.Width.ToString() + "," + curBitmap.Height.ToString() + ")";
            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFile();
            }
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xiusdk.cn");
        }
        #endregion

        #region  Filter
        private void FilterProcess(int filterID)
        {
            if (pictureBox1.Image != null && (!processing))
            {
                pictureBox1.Image = (Image)zPhoto.EffectFilterById(curBitmap, filterID);
            }
            else if (!processing)
            {
                MessageForm msgForm = new MessageForm("请先打开一幅图像！");
                msgForm.Show();
            }
            else
            {
                MessageForm mf = new MessageForm("正在处理中，请稍候！");
                mf.ShowDialog();
            }
        }
        // 1977
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int filterID = 1;
            FilterProcess(filterID);
        }

        private void inkwellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 2;
            FilterProcess(filterID);
        }

        private void kelvinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 3;
            FilterProcess(filterID);
        }

        private void nashvilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 4;
            FilterProcess(filterID);
        }

        private void valenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 5;
            FilterProcess(filterID);
        }

        private void xPROIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 6;
            FilterProcess(filterID);
        }

        private void bRANNANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 7;
            FilterProcess(filterID);
        }

        private void wALDENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 8;
            FilterProcess(filterID);
        }

        private void aDENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 9;
            FilterProcess(filterID);
        }

        private void aSHBYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 10;
            FilterProcess(filterID);
        }

        private void bROOKLYNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 11;
            FilterProcess(filterID);
        }

        private void cHARMESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 12;
            FilterProcess(filterID);
        }

        private void cLARENDONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 13;
            FilterProcess(filterID);
        }

        private void cREMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 14;
            FilterProcess(filterID);
        }

        private void dOGPACHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 15;
            FilterProcess(filterID);
        }

        private void gINGHAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 16;
            FilterProcess(filterID);
        }

        private void gINZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 17;
            FilterProcess(filterID);
        }

        private void hEFEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 18;
            FilterProcess(filterID);
        }

        private void hELENAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 19;
            FilterProcess(filterID);
        }

        private void jUNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 20;
            FilterProcess(filterID);
        }

        private void lARKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 21;
            FilterProcess(filterID);
        }

        private void lUDWIGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 22;
            FilterProcess(filterID);
        }

        private void mAVENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 23;
            FilterProcess(filterID);
        }

        private void mOONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 24;
            FilterProcess(filterID);
        }

        private void rEYESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 25;
            FilterProcess(filterID);
        }

        private void sKYLINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 26;
            FilterProcess(filterID);
        }

        private void sLUMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 27;
            FilterProcess(filterID);
        }

        private void sTINSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 28;
            FilterProcess(filterID);
        }

        private void vESPERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 29;
            FilterProcess(filterID);
        }

        private void 暖暖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 100;
            FilterProcess(filterID);
        }

        private void 清晰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 101;
            FilterProcess(filterID);
        }

        private void 白皙ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 102;
            FilterProcess(filterID);
        }

        private void 冷艳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 103;
            FilterProcess(filterID);
        }

        private void 淡雅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 104;
            FilterProcess(filterID);
        }

        private void 复古ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 105;
            FilterProcess(filterID);
        }

        private void 哥特风ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 106;
            FilterProcess(filterID);
        }

        private void 古铜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 107;
            FilterProcess(filterID);
        }

        private void 湖水ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 108;
            FilterProcess(filterID);
        }

        private void 深蓝泪雨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 109;
            FilterProcess(filterID);
        }

        private void 银色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 110;
            FilterProcess(filterID);
        }

        private void 胶片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 111;
            FilterProcess(filterID);
        }

        private void 丽日ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 112;
            FilterProcess(filterID);
        }

        private void 绿野仙踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 113;
            FilterProcess(filterID);
        }

        private void 迷情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 114;
            FilterProcess(filterID);
        }

        private void 拿铁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 115;
            FilterProcess(filterID);
        }

        private void 日系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 116;
            FilterProcess(filterID);
        }

        private void 沙漏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 117;
            FilterProcess(filterID);
        }

        private void 午茶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 118;
            FilterProcess(filterID);
        }

        private void 羊皮卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 119;
            FilterProcess(filterID);
        }

        private void 野餐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 120;
            FilterProcess(filterID);
        }

        private void 日系ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 121;
            FilterProcess(filterID);
        }

        private void 沙漏ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 122;
            FilterProcess(filterID);
        }

        private void 午茶ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 123;
            FilterProcess(filterID);
        }

        private void 羊皮卷ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 124;
            FilterProcess(filterID);
        }

        private void 野餐ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 125;
            FilterProcess(filterID);
        }

        private void 暖黄ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 126;
            FilterProcess(filterID);
        }

        private void 清凉ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 127;
            FilterProcess(filterID);
        }

        private void 日系人像ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 128;
            FilterProcess(filterID);
        }

        private void 柔光ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 129;
            FilterProcess(filterID);
        }

        private void 甜美可人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 130;
            FilterProcess(filterID);
        }

        private void 唯美ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 131;
            FilterProcess(filterID);
        }

        private void 紫色幻想ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 132;
            FilterProcess(filterID);
        }

        private void 美食ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 133;
            FilterProcess(filterID);
        }

        private void zP花颜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 134;
            FilterProcess(filterID);
        }
        //
        private void 电影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 200;
            FilterProcess(filterID);
        }

        private void 枫叶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 201;
            FilterProcess(filterID);
        }

        private void 冷焰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 202;
            FilterProcess(filterID);
        }

        private void 暖秋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 203;
            FilterProcess(filterID);
        }

        private void 青色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 204;
            FilterProcess(filterID);
        }

        private void 热情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 205;
            FilterProcess(filterID);
        }

        private void 时尚ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 206;
            FilterProcess(filterID);
        }

        private void eKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 207;
            FilterProcess(filterID);
        }

        private void gOLDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 208;
            FilterProcess(filterID);
        }

        private void vISTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 209;
            FilterProcess(filterID);
        }

        private void xTRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 210;
            FilterProcess(filterID);
        }

        private void 红润ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 211;
            FilterProcess(filterID);
        }

        private void 暖暖阳光ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 212;
            FilterProcess(filterID);
        }

        private void 清新丽人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 213;
            FilterProcess(filterID);
        }

        private void 甜美可人ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 214;
            FilterProcess(filterID);
        }

        private void 艺术黑白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 215;
            FilterProcess(filterID);
        }

        private void 自然美白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 216;
            FilterProcess(filterID);
        }

        private void 淡雅ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 217;
            FilterProcess(filterID);
        }

        private void 果冻ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 218;
            FilterProcess(filterID);
        }

        private void 清新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 219;
            FilterProcess(filterID);
        }

        private void 甜美ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 220;
            FilterProcess(filterID);
        }

        private void 唯美ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int filterID = 221;
            FilterProcess(filterID);
        }

        private void 温暖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 222;
            FilterProcess(filterID);
        }

        //
        private void 卡通ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 300;
            FilterProcess(filterID);
        }

        private void 黑白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 301;
            FilterProcess(filterID);
        }

        private void gLOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 302;
            FilterProcess(filterID);
        }

        private void lOMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 303;
            FilterProcess(filterID);
        }

        private void 乡愁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 304;
            FilterProcess(filterID);
        }

        private void 油画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 305;
            FilterProcess(filterID);
        }

        private void pUNCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 306;
            FilterProcess(filterID);
        }

        private void 怀旧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 307;
            FilterProcess(filterID);
        }

        private void 素描ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 308;
            FilterProcess(filterID);
        }

        private void 连环画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 309;
            FilterProcess(filterID);
        }

        private void 阿宝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 310;
            FilterProcess(filterID);
        }
        private void zP乐高像素拼图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 311;
            FilterProcess(filterID);
        }
        private void zP浪漫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 312;
            FilterProcess(filterID);
        }
        private void zP裸妆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 313;
            FilterProcess(filterID);
        }
        private void zP嫩红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 314;
            FilterProcess(filterID);
        }

        private void zP清透ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 315;
            FilterProcess(filterID);
        }

        private void zP臻白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 316;
            FilterProcess(filterID);
        }

        private void zP自然ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filterID = 317;
            FilterProcess(filterID);
        }
        private void 滤镜自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                FilterForm filter = new FilterForm();
                if (filter.ShowDialog() == DialogResult.OK)
                {
                    int filterId = filter.getMode;
                    string maskPath = filter.getMaskPath;
                    pictureBox1.Image = (Image)zPhoto.UniversalFilterProcess(curBitmap, new Bitmap(maskPath), filterId, 100);
                }
            }
        }
        #endregion

        #region Thread for image processing
        //Aysn image process for UI refreshing
        //define delegate for image process.
        public delegate void AysnImageProcessDelegate(int id);
        private bool processing = false;
        private void BeginImageProcess(int id)
        {
            if (processing)
            {
                MessageForm mf = new MessageForm("正在处理中，请稍候！");
                {
                    mf.ShowDialog();
                }
                return;
            }
            this.Invoke((EventHandler)delegate
            {
                toolStripStatusLabel3.Text = "当前进度：正在处理中......";
                toolStripStatusLabel3.BackColor = Color.Red;
                processing = true;
            });
            AysnImageProcessDelegate sysndelegate = new AysnImageProcessDelegate(ImageProcessing);
            sysndelegate.BeginInvoke(id, ImageProcessDone, sysndelegate);
            //return sysndelegate.BeginInvoke(id, ImageProcessDone, sysndelegate);
        }
        private void ImageProcessDone(IAsyncResult result)
        {
            AysnImageProcessDelegate aysnDelegate = result.AsyncState as AysnImageProcessDelegate;
            if (aysnDelegate != null)
            {
                pictureBox1.Image = (Image)curBitmap;
            }
            this.Invoke((EventHandler)delegate
            {
                toolStripStatusLabel3.Text = "当前进度：完成";
                toolStripStatusLabel3.BackColor = Color.Transparent;
                processing = false;
            });
        }
        private void ImageProcessing(int id)
        {
            if (pictureBox1.Image == null)
                return;
            switch (id)
            {
                case ImageProcessId.ID_ROTATE:
                    RotateForm rotate = new RotateForm(curFileName);
                    if (rotate.ShowDialog() == DialogResult.OK)
                    {
                        int degree = rotate.getDegree;
                        curBitmap = zPhoto.TransformRotation(curBitmap, degree, 1, 0);
                    }
                    break;
                case ImageProcessId.ID_ZOOM:
                    ZoomForm zoom = new ZoomForm();
                    if (zoom.ShowDialog() == DialogResult.OK)
                    {
                        float scale = zoom.getScale;
                        curBitmap = zPhoto.TransformScale(curBitmap, scale, 1, 0);
                    }
                    break;
                case ImageProcessId.ID_HMIRROR:
                    curBitmap = zPhoto.TransformMirror(curBitmap, 4);
                    break;
                case ImageProcessId.ID_VMIRROR:
                    curBitmap = zPhoto.TransformMirror(curBitmap, 5);
                    break;
                case ImageProcessId.ID_AUTO_COLORGRADATION:
                    curBitmap = zPhoto.AutoColorGradationAdjust(curBitmap);
                    break;
                case ImageProcessId.ID_AUTO_CONTRAST:
                    curBitmap = zPhoto.AutoContrastAdjust(curBitmap);
                    break;
                case ImageProcessId.ID_HISTAGRAMEQUALIZE:
                    curBitmap = zPhoto.HistagramEqualize(curBitmap);
                    break;
                case ImageProcessId.ID_BRIGHTCONTRAST:
                    BrightContrastForm bc = new BrightContrastForm(curFileName);
                    if (bc.ShowDialog() == DialogResult.OK)
                    {
                        int bright = bc.getBright;
                        int contrast = bc.getContrast;
                        if (bc.getVersion)
                        {
                            curBitmap = zPhoto.NLinearBrightContrastAdjust(curBitmap, bright, contrast, 128);
                        }
                        else
                        {
                            curBitmap = zPhoto.LinearBrightContrastAdjust(curBitmap, bright, contrast, 128);
                        }
                    }
                    break;
                case ImageProcessId.ID_COLORLEVEL:
                    LevelForm form = new LevelForm(curFileName);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int lInput = form.getLeftInput;
                        double mInput = form.getMidInput;
                        int rInput = form.getRightInput;
                        int lOutput = form.getLeftOutput;
                        int rOutput = form.getRightOutput;
                        int channel = form.getChannel;
                        curBitmap = zPhoto.ColorLevelProcess(curBitmap, channel, lInput, (float)mInput, rInput, lOutput, rOutput);
                    }
                    break;
                case ImageProcessId.ID_HSL:
                    HSLForm hsl = new HSLForm(curFileName);
                    if (hsl.ShowDialog() == DialogResult.OK)
                    {
                        int h = hsl.getHue;
                        int s = hsl.getSaturation;
                        int l = hsl.getLightness;
                        curBitmap = zPhoto.HueSaturationAdjust(curBitmap, h, s);
                        curBitmap = zPhoto.LightnessAdjustProcess(curBitmap, l);

                    }
                    break;
                case ImageProcessId.ID_COLORBALANCE:
                    ColorbalanceForm corB = new ColorbalanceForm(curFileName);
                    if (corB.ShowDialog() == DialogResult.OK)
                    {
                        int cyan = corB.getCyan;
                        int magenta = corB.getMagenta;
                        int yellow = corB.getYellow;
                        curBitmap = zPhoto.ColorBalanceProcess(curBitmap, cyan, magenta, yellow, 0, corB.getLum);
                    }
                    break;
                case ImageProcessId.ID_INVERT:
                    curBitmap = zPhoto.Invert(curBitmap);
                    break;
                case ImageProcessId.ID_POSTERIZE:
                    PosterizeForm poster = new PosterizeForm(curFileName);
                    if (poster.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.Posterize(curBitmap, poster.getLevelNum);
                    }
                    break;
                case ImageProcessId.ID_THRESHOLD:
                    ThresholdForm threForm = new ThresholdForm(curFileName);
                    if (threForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.Threshold(curBitmap, threForm.getThresold);
                    }
                    break;
                case ImageProcessId.ID_DESATURATE:
                    curBitmap = zPhoto.Desaturate(curBitmap);
                    break;
                case ImageProcessId.ID_HIGHLIGHTSHADOW:
                    HighlightShadowForm hsform = new HighlightShadowForm(curFileName);
                    if (hsform.ShowDialog() == DialogResult.OK)
                    {
                        int shadow = hsform.getShadow;
                        int highlight = hsform.getHighlight;
                        //curBitmap = zPhoto.HighlightShadowPreciseAdjustProcess(curBitmap, highlight, shadow);
                        Bitmap tmp = zPhoto.ShadowAdjust(curBitmap, shadow, 100);
                        curBitmap = zPhoto.HighlightAdjust(tmp, highlight, 100);
                    }
                    break;
                case ImageProcessId.ID_EXPOSURE:
                    ExposureForm eform = new ExposureForm(curFileName);
                    if (eform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = eform.getIntensity;
                        curBitmap = zPhoto.ExposureAdjust(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_COLORTEMPEATURE:
                    TempreatureForm teform = new TempreatureForm(curFileName);
                    if (teform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = teform.getTempeature;
                        curBitmap = zPhoto.ColorTemperatureProcess(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_FINDEDGES:
                    curBitmap = zPhoto.FindEdgesProcess(curBitmap);
                    break;
                case ImageProcessId.ID_RELIEF:
                    ReliefForm rform = new ReliefForm(curFileName);
                    if (rform.ShowDialog() == DialogResult.OK)
                    {
                        int angle = rform.getAngle;
                        int amount = rform.getAmount;
                        curBitmap = zPhoto.Relief(curBitmap, angle, amount);
                    }
                    break;
                case ImageProcessId.ID_DIFUSSION:
                    DifussionForm dform = new DifussionForm(curFileName);
                    if (dform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = dform.getIntensity;
                        curBitmap = zPhoto.DiffusionProcess(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_OVEREXPOSURE:
                    curBitmap = zPhoto.OverExposure(curBitmap);
                    break;
                case ImageProcessId.ID_SURFACEBLUR:
                    SurfaceBlurForm srform = new SurfaceBlurForm(curFileName);
                    if (srform.ShowDialog() == DialogResult.OK)
                    {
                        int radius = srform.getRadius;
                        int threshold = srform.getThreshld;
                        curBitmap = zPhoto.SurfaceBlur(curBitmap, threshold, radius);
                    }
                    break;
                case ImageProcessId.ID_MOTIONBLUR:
                    MotionBlurForm moform = new MotionBlurForm(curFileName);
                    if (moform.ShowDialog() == DialogResult.OK)
                    {
                        int angle = moform.getAngle;
                        int distance = moform.getDistance;
                        curBitmap = zPhoto.MotionBlur(curBitmap, angle, distance);
                    }
                    break;
                case ImageProcessId.ID_MEANBLUR:
                    MeanBlurForm meform = new MeanBlurForm(curFileName);
                    if (meform.ShowDialog() == DialogResult.OK)
                    {
                        int radius = meform.getRadius;
                        curBitmap = zPhoto.MeanFilterProcess(curBitmap, radius);
                    }
                    break;
                case ImageProcessId.ID_GAUSSBLUR:
                    GaussBlurForm gauform = new GaussBlurForm(curFileName);
                    if (gauform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = gauform.getRadius;
                        curBitmap = zPhoto.GaussFilterProcess(curBitmap, (float)radius);
                    }
                    break;
                case ImageProcessId.ID_RADIAL:
                    RadialBlurForm raform = new RadialBlurForm(curFileName);
                    if (raform.ShowDialog() == DialogResult.OK)
                    {
                        int amount = raform.getAmount;
                        curBitmap = zPhoto.RadialBlurProcess(curBitmap, amount);
                    }
                    break;
                case ImageProcessId.ID_ZOOMBLUR:
                    ZoomBlurForm zoomform = new ZoomBlurForm(curFileName);
                    if (zoomform.ShowDialog() == DialogResult.OK)
                    {
                        int amount = zoomform.getAmount;
                        int radius = zoomform.getRadius;
                        curBitmap = zPhoto.ZoomBlurProcess(curBitmap, radius, amount);
                    }
                    break;
                case ImageProcessId.ID_MEAN:
                    curBitmap = zPhoto.MeanProcess(curBitmap);
                    break;
                case ImageProcessId.ID_MOSCIA:
                    MosciaForm mosciaform = new MosciaForm(curFileName);
                    if (mosciaform.ShowDialog() == DialogResult.OK)
                    {
                        int blockSize = mosciaform.getBlocksize;
                        curBitmap = zPhoto.MosaicProcess(curBitmap, blockSize);
                    }
                    break;
                case ImageProcessId.ID_FRAGMENT:
                    curBitmap = zPhoto.Fragment(curBitmap);
                    break;
                case ImageProcessId.ID_HIGHPASS:
                    HighpassForm hpform = new HighpassForm(curFileName);
                    if (hpform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = hpform.getRadius;
                        curBitmap = zPhoto.HighPassProcess(curBitmap, (float)radius);
                    }
                    break;
                case ImageProcessId.ID_USM:
                    USMForm usmform = new USMForm(curFileName);
                    if (usmform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = usmform.getRadius;
                        int amount = usmform.getAmount;
                        int threshold = usmform.getThreshold;
                        curBitmap = zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
                    }
                    break;
                case ImageProcessId.ID_CHANNELMIXER:
                    ChannelMixForm cmform = new ChannelMixForm(curFileName);
                    if (cmform.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(cmform.getResImage);
                    }
                    break;
                case ImageProcessId.ID_BLACKWHITE:
                    BlackWhiteForm whform = new BlackWhiteForm(curFileName);
                    if (whform.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.BlackwhiteProcess(curBitmap, whform.getKRed, whform.getKGreen, whform.getKBlue, whform.getKYellow, whform.getKCyan, whform.getKMagenta);
                    }
                    break;
                case ImageProcessId.ID_GAMMA:
                    GammaForm gammaForm = new GammaForm(curFileName);
                    if (gammaForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.GammaCorrectProcess(curBitmap, gammaForm.getGamma);
                    }
                    break;
                case ImageProcessId.ID_MEDIANFILTER:
                    MedianForm medianForm = new MedianForm(curFileName);
                    if (medianForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MedianFilterProcess(curBitmap, medianForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_MAXFILTER:
                    MaxForm maxForm = new MaxForm(curFileName);
                    if (maxForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MaxFilterProcess(curBitmap, maxForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_MINFILTER:
                    MinForm minForm = new MinForm(curFileName);
                    if (minForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MinFilterProcess(curBitmap, minForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_IMAGEWARP_PINCH:
                    curBitmap = zPhoto.ImageWarpPinchProcess(curBitmap, curBitmap.Width / 2, curBitmap.Height / 2, 10);
                    break;
                case ImageProcessId.ID_IMAGEWARP_WAVE:
                    curBitmap = zPhoto.ImageWarpWaveProcess(curBitmap, 60);
                    break;
                case ImageProcessId.ID_IMAGEWARP_MAGICMIRROR:
                    curBitmap = zPhoto.ImageWarpMagicMirrorProcess(curBitmap, curBitmap.Width / 2, curBitmap.Height / 2, curBitmap.Width / 3);
                    break;
                case ImageProcessId.ID_IMAGEWARP_ZOOMIN:
                    curBitmap = zPhoto.ImageWarpZoomProcess(curBitmap, curBitmap.Width / 2, curBitmap.Height / 2, curBitmap.Width / 3, 0.5f);
                    break;
                case ImageProcessId.ID_IMAGEWARP_ZOOMOUT:
                    curBitmap = zPhoto.ImageWarpZoomProcess(curBitmap, curBitmap.Width / 2, curBitmap.Height / 2, curBitmap.Width / 3, 2.0f);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region UI response
        private void 图像旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ROTATE);
        }

        private void 恢复原图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curFileName != null)
            {
                curBitmap = new Bitmap(curFileName);
                pictureBox1.Image = (Image)curBitmap;
            }
        }

        private void 图像缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ZOOM);
        }


        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HMIRROR);
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_VMIRROR);
        }

        private void 自动色调ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_AUTO_COLORGRADATION);
        }

        private void 自动对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_AUTO_CONTRAST);
        }

        private void 色调均化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HISTAGRAMEQUALIZE);
        }

        private void 亮度对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_BRIGHTCONTRAST);
        }

        private void 色阶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORLEVEL);
        }

        private void 色相饱和度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HSL);
        }

        private void 色彩平衡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORBALANCE);
        }

        private void 反相ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_INVERT);
        }

        private void 色调分离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_POSTERIZE);
        }

        private void 阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_THRESHOLD);
        }
        private void 去色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_DESATURATE);
        }

        private void 高光阴影调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HIGHLIGHTSHADOW);
        }

        private void 曝光调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_EXPOSURE);
        }

        private void 色温调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORTEMPEATURE);
        }

        private void 查找边缘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_FINDEDGES);
        }

        private void 浮雕效果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_RELIEF);
        }

        private void 扩散ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_DIFUSSION);
        }

        private void 曝光过度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_OVEREXPOSURE);
        }

        private void 表面模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_SURFACEBLUR);
        }

        private void 动感模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MOTIONBLUR);
        }

        private void 均值模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEANBLUR);
        }

        private void 高斯模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_GAUSSBLUR);
        }

        private void 旋转模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_RADIAL);
        }

        private void 缩放模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ZOOMBLUR);
        }

        private void 平均ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEAN);
        }

        private void 马赛克ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MOSCIA);
        }

        private void 碎片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_FRAGMENT);
        }

        private void 高反差保留ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HIGHPASS);
        }

        private void uSM锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_USM);
        }
        private void 通道混合器ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_CHANNELMIXER);

        }

        private void 黑白ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_BLACKWHITE);
        }
        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                HistagramForm form = new HistagramForm(curFileName);
                form.Show();
            }
        }
        private void gamma调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_GAMMA);
        }
        private void 中间色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEDIANFILTER);
        }

        private void 最大值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MAXFILTER);
        }

        private void 最小值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MINFILTER);
        }
        private void pinchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_PINCH);
        }

        private void waveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_WAVE);
        }
        private void magicMirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_MAGICMIRROR);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_ZOOMIN);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_ZOOMOUT);
        }
        #endregion

        #region Makeup
        public void RefreshDisplay(Bitmap resBitmap)
        {
            //pictureBox1.Image = (Image)new Bitmap(resBitmap);
            pictureBox1.Image = (Image)resBitmap;

        }
        private void MakeupProcess(int imageprocessId)
        {
            if (pictureBox1.Image == null)
                return;
            switch (imageprocessId)
            {
                case ImageProcessId.ID_MAKEUP_SKINWHITE: // 美白
                    SkinWhiteForm swForm = new SkinWhiteForm(curBitmap);
                    swForm.Owner = this;
                    if (swForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;


                //case ImageProcessId.ID_MAKEUP_SKINCOLOR: // 肤色
                //    SkinColorForm scForm = new SkinColorForm(curBitmap);
                //    scForm.Owner = this;
                //    if (scForm.ShowDialog() == DialogResult.OK)
                //    {
                //        curBitmap = new Bitmap(pictureBox1.Image);
                //    }
                //    pictureBox1.Image = (Image)curBitmap;
                //    break;


                case ImageProcessId.ID_MAKEUP_SOFTSKIN: //磨皮
                    SoftskinForm ssForm = new SoftskinForm(curBitmap, landMark);
                    ssForm.Owner = this;
                    if (ssForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;

                case ImageProcessId.ID_MAKEUP_EYEWARP: // 大眼
                    EyewarpForm ewForm = new EyewarpForm(curBitmap, landMark);
                    ewForm.Owner = this;
                    if (ewForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;

                case ImageProcessId.ID_MAKEUP_FACELIFT: // 瘦脸
                    FaceLiftForm faceliftForm = new FaceLiftForm(curBitmap, landMark);
                    faceliftForm.Owner = this;
                    if (faceliftForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;


                case ImageProcessId.ID_MAKEUP_EYEBAGREMOVE: //去眼袋
                    EyebagForm egForm = new EyebagForm(curBitmap, landMark);
                    egForm.Owner = this;
                    if (egForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;

                case ImageProcessId.ID_MAKEUP_HIGHNOSE://高鼻梁
                    HighnoseForm hnForm = new HighnoseForm(curBitmap, landMark);
                    hnForm.Owner = this;
                    if (hnForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;


                case ImageProcessId.ID_MAKEUP_DEFRECKLE://手动祛斑
                    DefreckleForm dfForm = new DefreckleForm(curBitmap);
                    dfForm.Owner = this;
                    if (dfForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;



                case ImageProcessId.ID_MAKEUP_LIPSROSY://唇彩
                    LipsRosyForm lrForm = new LipsRosyForm(curBitmap, landMark);
                    lrForm.Owner = this;
                    if (lrForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;



                case ImageProcessId.ID_MAKEUP_LIGHTEYE://亮眼
                    EyeLightForm leForm = new EyeLightForm(curBitmap, landMark);
                    leForm.Owner = this;
                    if (leForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;



                case ImageProcessId.ID_MAKEUP_DEFRECKLE_AUTO: // 自动祛斑
                    DefreckleAutoForm defreckleAutoForm = new DefreckleAutoForm(curBitmap, landMark);
                    defreckleAutoForm.Owner = this;
                    if (defreckleAutoForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;


                case ImageProcessId.ID_VIRTURALFILTER:
                    VirturalFilterForm virturalForm = new VirturalFilterForm(curBitmap);
                    virturalForm.Owner = this;
                    if (virturalForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(pictureBox1.Image);
                    }
                    pictureBox1.Image = (Image)curBitmap;
                    break;


                    //case ImageProcessId.ID_MAKEUP_SKINTONIC: //粉底
                    //    SkinTonicForm stForm = new SkinTonicForm(curBitmap, landMark);
                    //    stForm.Owner = this;
                    //    if (stForm.ShowDialog() == DialogResult.OK)
                    //    {
                    //        curBitmap = new Bitmap(pictureBox1.Image);
                    //    }
                    //    pictureBox1.Image = (Image)curBitmap;
                    //    break;

                    //case ImageProcessId.ID_MAKEUP_BEAUTY_ONE: //妆容一
                    //    ZBeautyEngineDll zMakeup1 = new ZBeautyEngineDll();
                    //    pictureBox1.Image = (Image)zMakeup1.DoMakeupOneKey(curBitmap, landMark);
                    //    break;

                    //case ImageProcessId.ID_MAKEUP_BEAUTY_TWO: //妆容二
                    //    ZBeautyEngineDll zMakeup2 = new ZBeautyEngineDll();
                    //    pictureBox1.Image = (Image)zMakeup2.DoMakeupOneKey(curBitmap, landMark);
                    //    break;


                    //case ImageProcessId.ID_MAKEUP_FACEDETECT:
                    //    if (faceInfos[0] != 0)
                    //    {
                    //        Graphics g = Graphics.FromImage(curBitmap);
                    //        int n = faceInfos[0];
                    //        int w, h, x, y, pos;
                    //        for (int i = 0; i < n; i++)
                    //        {
                    //            pos = 1 + i * baseLMLen;
                    //            x = faceInfos[pos];
                    //            y = faceInfos[pos + 1];
                    //            w = faceInfos[pos + 2];
                    //            h = faceInfos[pos + 3];
                    //            g.DrawRectangle(new Pen(Color.Red, 5), x, y, w, h);
                    //        }
                    //        g.Dispose();
                    //        pictureBox1.Image = (Image)curBitmap;
                    //    }
                    //    break;

            }
        }

        private void 美白ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeupProcess(ImageProcessId.ID_MAKEUP_SKINWHITE);
        }

        //private void 肤色调节ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MakeupProcess(ImageProcessId.ID_MAKEUP_SKINCOLOR);
        //}

        private void 人物磨皮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeupProcess(ImageProcessId.ID_MAKEUP_SOFTSKIN);
        }

        private void 大眼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("face detection failed !!");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_EYEWARP);
        }

        private void 瘦脸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_FACELIFT);
        }

        private void 去眼袋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_EYEBAGREMOVE);
        }

        private void 高鼻梁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_HIGHNOSE);
        }

        private void 祛斑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_DEFRECKLE);
        }

        private void 美唇ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_LIPSROSY);
        }

        private void 亮眼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_LIGHTEYE);
        }

        private void 自动祛斑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_DEFRECKLE_AUTO);
        }

        //private void 手动祛斑ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (faceNum < 1)
        //    {
        //        MessageForm mf = new MessageForm("Face detect failed !");
        //        mf.Show();
        //        return;
        //    }
        //    
        //}

        //private void 粉底ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (faceNum < 1)
        //    {
        //        MessageForm mf = new MessageForm("Face detect failed !");
        //        mf.Show();
        //        return;
        //    }
        //    MakeupProcess(ImageProcessId.ID_MAKEUP_SKINTONIC);
        //}

        private void 人脸检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (faceNum < 1)
            {
                MessageForm mf = new MessageForm("Face detect failed !");
                mf.Show();
                return;
            }
            MakeupProcess(ImageProcessId.ID_MAKEUP_FACEDETECT);
        }

        private void 图像虚化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeupProcess(ImageProcessId.ID_VIRTURALFILTER);
        }


        #endregion


        #region Makeup_All

        //private void 妆容一ToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    if (faceNum < 1)
        //    {
        //        MessageForm mf = new MessageForm("Face detect failed !");
        //        mf.Show();
        //        return;
        //    }
        //    MakeupProcess(ImageProcessId.ID_MAKEUP_BEAUTY_ONE);

        //}

        #endregion

        private void 实时美颜ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LiveCamera liveCameraForm = new LiveCamera();
            liveCameraForm.ShowDialog();

        }


    }
}
