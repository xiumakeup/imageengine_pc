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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TestDemo
{
    class ZPhotoEngineDll
    {

        #region PS基本变换模块
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Desaturate(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Threshold(IntPtr srcData, int width, int height, int stride, int threshold);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_SaturationAdjust(IntPtr srcData, int width, int height, int stride, int hue);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Posterize(IntPtr srcData, int width, int height, int stride, int clusterNum);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_OverExposure(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_LightnessAdjust(IntPtr srcData, int width, int height, int stride, int lightness);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Invert(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HueAndSaturationAdjust(IntPtr srcData, int width, int height, int stride, int hue, int saturation);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HistagramEqualize(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_CurveAdjust(IntPtr srcData, int width, int height, int stride, int DestChannel, int InputLeftLimit, int InputMiddle, int InputRightLimit, int OutputLeftLimit, int OutputRightLimit);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_NLinearBrightContrastAdjust(IntPtr srcData, int width, int height, int stride, int bright, int contrast, int threshold);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_LinearBrightContrastAdjust(IntPtr srcData, int width, int height, int stride, int brightness, int contrast, int threshold);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_AutoContrastAdjust(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_AutoColorGradationAdjust(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ChannelMixProcess(IntPtr srcData, int width, int height, int stride, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Fragment(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_SurfaceBlur(IntPtr srcData, int width, int height, int stride, int threshold, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_RadialBlur(IntPtr srcData, int width, int height, int stride, int cenX, int cenY, int amount);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ZoomBlur(IntPtr srcData, int width, int height, int stride, int cenX, int cenY, int sampleRadius, int amount);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Relief(IntPtr srcData, int width, int height, int stride, int angle, int amount);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Mosaic(IntPtr srcData, int width, int height, int stride, int size);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorBalance(IntPtr srcData, int width, int height, int stride, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Diffusion(IntPtr srcData, int width, int height, int stride, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FastGaussFilter(IntPtr srcData, int width, int height, int stride, IntPtr dstData, float radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FastestGaussFilter(IntPtr srcData, int width, int height, int stride, IntPtr dstData, float radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HighPass(IntPtr srcData, int width, int height, int stride, IntPtr dstData, float mRadius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_USM(IntPtr srcData, int width, int height, int stride, IntPtr dstData, float radius, int amount, int threshold);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FindEdges(IntPtr srcData, int width, int height, int stride, IntPtr dstData);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ShadowAdjust(IntPtr srcData, int width, int height, int stride, int intensity, int ratio);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HighlightAdjust(IntPtr srcData, int width, int height, int stride, int intensity, int ratio);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ExposureAdjust(IntPtr srcData, int width, int height, int stride, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorTemperatureAdjust(IntPtr srcData, int width, int height, int stride, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_CalcWH(int[] inputImgSize, float angle, float scale, int transform_method, int[] outputImgSize, float[] H);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageTransformation(IntPtr pSrc, int[] srcImgSize, IntPtr pDst, int[] dstImgSize, float[] H, int Interpolation_method, int transform_method);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_MotionBlur(IntPtr srcData, int width, int height, int stride, int angle, int distance);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Mean(IntPtr srcData, int width, int height, int stride);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FastMeanFilter(IntPtr srcData, int width, int height ,int stride, IntPtr dstData,int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorLevelAdjust(IntPtr srcData, int width, int height, int stride, int destChannel, byte inputLeftLimit, float inputMiddle, byte inputRightLimit, byte outputLeftLimit, byte outputRightLimit);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Blackwhite(IntPtr srcData, int width, int height, int stride, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_GammaCorrect(IntPtr srcData, int width, int height, int stride, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MedianFilter(IntPtr srcData, int width, int height, int stride, IntPtr dstData, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MaxFilter(IntPtr srcData, int width, int height, int stride, IntPtr dstData, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MinFilter(IntPtr srcData, int width, int height, int stride, IntPtr dstData, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern int ZPHOTO_VirtualFilter(IntPtr srcData, int width, int height, int stride, int x, int y, int blurIntensity, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_GlowingEdges(IntPtr srcData, int width, int height, int stride, int edgeSize, int edgeLightness, int edgeSmoothness);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageWarpPinch(IntPtr srcData, int width, int height, int stride, int cenX, int cenY, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageWarpWave(IntPtr srcData, int width, int height, int stride, int intensity);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageWarpMagicMirror(IntPtr srcData, int width, int height, int stride, int cenX, int cenY, int radius);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageWarpZoom(IntPtr srcData, int width, int height, int stride, int cenX, int cenY, int radius, float unit);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HighlightShadowPreciseAdjust(IntPtr srcData,int width, int height, int stride, float highlight, float shadow);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region 颜色空间转换模块
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToYUV(int Red, int Green, int Blue, ref int Y, ref int U, ref int V);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_YUVToRGB(int Y, int U, int V, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToYCbCr(int R, int G, int B, ref int Y, ref int Cb, ref int Cr);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_YCbCrToRGB(int Y, int Cb, int Cr, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToXYZ(int Red, int Green, int Blue, ref int X, ref int Y, ref int Z);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_XYZToRGB(int X, int Y, int Z, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToHSL(int Red, int Green, int Blue, ref int h, ref int s, ref int l);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_HSLToRGB(int h, int s, int l, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]///////////////
        private static extern void ZPHOTO_RGBToHSV(int Red, int Green, int Blue, ref double h, ref double s, ref double v);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_HSVToRGB(double h, double s, double v, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToYIQ(int Red, int Green, int Blue, ref double Y, ref double I, ref double Q);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_YIQToRGB(double Y, double I, double Q, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToYDbDr(int Red, int Green, int Blue, ref int Y, ref int Db, ref int Dr);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_YDbDrToRGB(int Y, int Db, int Dr, ref int Red, ref int Green, ref int Blue);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToCMYK(int Red, int Green, int Blue, ref int C, ref int M, ref int Y, ref int K);
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_CMYKToRGB(int C, int M, int Y, int K, ref int Red, ref int Green, ref int Blue);
        #endregion

        #region 滤镜模块
        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Filter(IntPtr srcData, int width, int height, int strideint, int FilterId);

        [DllImport("XIUSDK_PhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_UniversalFilter(IntPtr srcData, int width, int height, int stride, IntPtr maskData, int mWidth, int mHeight, int mStride, int mergeMode, int ratio);
        #endregion



        public Bitmap HighlightShadowPreciseAdjustProcess(Bitmap src, float highlight, float shadow)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HighlightShadowPreciseAdjust(srcData.Scan0, w, h, srcData.Stride, highlight, shadow);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap ImageWarpMagicMirrorProcess(Bitmap src, int cenX, int cenY, int radius)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ImageWarpMagicMirror(srcData.Scan0, w, h, srcData.Stride, cenX, cenY, radius);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap ImageWarpZoomProcess(Bitmap src, int cenX, int cenY, int radius, float unit)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ImageWarpZoom(srcData.Scan0, w, h, srcData.Stride, cenX, cenY, radius, unit);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap ImageWarpWaveProcess(Bitmap src, int intensity)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ImageWarpWave(srcData.Scan0, w, h, srcData.Stride, intensity);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap ImageWarpPinchProcess(Bitmap src, int cenX, int cenY, int intensity)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ImageWarpPinch(srcData.Scan0, w, h, srcData.Stride, cenX, cenY, intensity);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap GlowingEdgesProcess(Bitmap src, int edgeSize, int edgeLightness, int edgeSmoothness)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_GlowingEdges(srcData.Scan0, w, h, srcData.Stride, edgeSize, edgeLightness, edgeSmoothness);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap VirtualFilterProcess(Bitmap src, int x, int y, int blurIntensity, int radius)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_VirtualFilter(srcData.Scan0, w, h, srcData.Stride, x, y, blurIntensity, radius);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MedianFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            Bitmap dst = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MedianFilter(srcData.Scan0, w, h, srcData.Stride, dstData.Scan0, size);
            a.UnlockBits(srcData);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap MaxFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            Bitmap dst = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MaxFilter(srcData.Scan0, w, h, srcData.Stride, dstData.Scan0, size);
            a.UnlockBits(srcData);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap MinFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            Bitmap dst = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MinFilter(srcData.Scan0, w, h, srcData.Stride, dstData.Scan0, size);
            a.UnlockBits(srcData);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap GammaCorrectProcess(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_GammaCorrect(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ChannelMixProcess(Bitmap src, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ChannelMixProcess(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, channel, kr, kg, kb, N, singleColor, constAdjust);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap MeanProcess(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Mean(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap AutoColorGradationAdjust(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_AutoColorGradationAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap AutoContrastAdjust(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_AutoContrastAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HistagramEqualize(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HistagramEqualize(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap MotionBlur(Bitmap src, int angle, int distance)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MotionBlur(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, angle, distance);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap TransformRotation(Bitmap src, float angle, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, angle, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation(srcData.Scan0, srcImgSize, dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformScale(Bitmap src, float scale, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, scale, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation(srcData.Scan0, srcImgSize, dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformRotationScale(Bitmap src, float angle, float scale, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, angle, scale, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation(srcData.Scan0, srcImgSize, dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformAffine(Bitmap src, float[] H, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            //float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation(srcData.Scan0, srcImgSize, dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
        public Bitmap Threshold(Bitmap src, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Threshold(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }

        public Bitmap TransformMirror(Bitmap srcBitmap, int transform_method)
        {
            Bitmap src = new Bitmap(srcBitmap);
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;

            int Interpolation_method = 0;
            ZPHOTO_ImageTransformation(srcData.Scan0, srcImgSize, dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap Fragment(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Fragment(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HueSaturationAdjust(Bitmap src, int hue, int saturation)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HueAndSaturationAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, hue, saturation);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ColorTemperatureProcess(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ColorTemperatureAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap Posterize(Bitmap src, int clusterNum)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Posterize(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, clusterNum);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Desaturate(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Desaturate(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap OverExposure(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_OverExposure(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ExposureAdjust(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ExposureAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap LightnessAdjustProcess(Bitmap src, int lightness)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_LightnessAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, lightness);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ShadowAdjust(Bitmap src, int intensity, int ratio)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ShadowAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity, ratio);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HighlightAdjust(Bitmap src, int intensity, int ratio)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HighlightAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity, ratio);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Invert(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Invert(srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap SurfaceBlur(Bitmap src, int threshold, int radius)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_SurfaceBlur(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, threshold, radius);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap NLinearBrightContrastAdjust(Bitmap src, int bright, int contrast, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_NLinearBrightContrastAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, bright, contrast, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap LinearBrightContrastAdjust(Bitmap src, int bright, int contrast, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_LinearBrightContrastAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, bright, contrast, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap FindEdgesProcess(Bitmap src)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap dst = new Bitmap(src);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FindEdges(srcData.Scan0, a.Width, a.Height, srcData.Stride, dstData.Scan0);
            a.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
        public Bitmap GaussFilterProcess(Bitmap src, float radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap dst = new Bitmap(src);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FastestGaussFilter(srcData.Scan0, a.Width, a.Height, srcData.Stride, dstData.Scan0, radius);
            a.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
        public Bitmap MeanFilterProcess(Bitmap src, int radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap dst = new Bitmap(src);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FastMeanFilter(srcData.Scan0, a.Width, a.Height, srcData.Stride, dstData.Scan0, radius);
            a.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
        public Bitmap HighPassProcess(Bitmap src, float radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap dst = new Bitmap(src);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HighPass(srcData.Scan0, a.Width, a.Height, srcData.Stride, dstData.Scan0, radius);
            a.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
        public Bitmap USMProcess(Bitmap src, float radius, int amount, int threshold)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap dst = new Bitmap(src);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_USM(srcData.Scan0, a.Width, a.Height, srcData.Stride, dstData.Scan0, radius, amount, threshold);
            a.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }

        public Bitmap SaturationProcess(Bitmap src, int hue)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_SaturationAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, hue);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ColorBalanceProcess(Bitmap src, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ColorBalance(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, cyan, magenta, yellow, channel, preserveLuminosity);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Relief(Bitmap src, int angle, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Relief(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, angle, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap DiffusionProcess(Bitmap src, int intensity)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Diffusion(srcData.Scan0, a.Width, a.Height, srcData.Stride, intensity);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MosaicProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Mosaic(srcData.Scan0, a.Width, a.Height, srcData.Stride, size);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap RadialBlurProcess(Bitmap src, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_RadialBlur(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, dst.Width / 2, dst.Height / 2, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ZoomBlurProcess(Bitmap src, int radius, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ZoomBlur(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, dst.Width / 2, dst.Height / 2, radius, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ColorLevelProcess(Bitmap src, int DestChannel, int InputLeftLimit, float InputMiddle, int InputRightLimit, int OutputLeftLimit, int OutputRightLimit)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            //f_TCurveAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, DestChannel, InputLeftLimit, InputMiddle, InputRightLimit, OutputLeftLimit, OutputRightLimit);
            ZPHOTO_ColorLevelAdjust(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, DestChannel, (byte)InputLeftLimit, InputMiddle, (byte)InputRightLimit, (byte)OutputLeftLimit, (byte)OutputRightLimit);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap BlackwhiteProcess(Bitmap src, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Blackwhite(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            dst.UnlockBits(srcData);
            return dst;
        }



        public Bitmap EffectFilterById(Bitmap src, int filterId)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            DateTime start = DateTime.Now;
            ZPHOTO_Filter(srcData.Scan0, dst.Width, dst.Height, srcData.Stride, filterId);
            DateTime end = DateTime.Now;
            string t = (end - start).ToString();
            dst.UnlockBits(srcData);
            return dst;
        }


        public Bitmap UniversalFilterProcess(Bitmap src, Bitmap mask, int mode, int ratio)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Bitmap msk = new Bitmap(mask);
            BitmapData maskData = msk.LockBits(new Rectangle(0, 0, msk.Width, msk.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_UniversalFilter(srcData.Scan0, a.Width, a.Height, srcData.Stride, maskData.Scan0, msk.Width, msk.Height, maskData.Stride, mode, ratio);
            a.UnlockBits(srcData);
            msk.UnlockBits(maskData);
            return a;
        }




    }
}
