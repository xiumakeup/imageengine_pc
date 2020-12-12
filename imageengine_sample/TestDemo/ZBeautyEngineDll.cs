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
    class ZBeautyEngineDll
    {
        // 必须调用
        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern IntPtr Beauty_InitBeautyEngine(String filePath);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_UninitBeautyEngine(IntPtr handle);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int Beauty_ProcessBuffer(IntPtr handle, IntPtr srcData, int width, int height, int stride);


        // 可选择调用
        //#define PIXELFORMAT_BGRA   0  // 
        //#define PIXELFORMAT_RGBA   1  // 
        //#define PIXELFORMAT_NV21   2  // yyyy vu
        //#define PIXELFORMAT_NV12   3  // yyyy uv
        //#define PIXELFORMAT_I420   4  // yyyy u v
        //#define PIXELFORMAT_YV12   5  // yyyy v u
        //#define PIXELFORMAT_I422   6  // yyyy uu vv
        //#define PIXELFORMAT_YV16   7  // yyyy vv uu
        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetPixelFMT(IntPtr handle, int pixFMT);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetFacePoints(IntPtr handle, int faceCount, int[] points);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_ClearParams(IntPtr handle);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetSoftenRatio(IntPtr handle, int softenRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetWhitenRatio(IntPtr handle, int writenRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetFilterID(IntPtr handle, int filterID);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetFilterRatio(IntPtr handle, int filterRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetSkinDetectionEnable(IntPtr handle, int skinDetectionEnable);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetDefreckleAutoEnable(IntPtr handle, int defreckleAutoEnable);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetEyeBagRemoveRatio(IntPtr handle, int eyeBagRemoveRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetLightEyeRatio(IntPtr handle, int lightEyeRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetEyeWarpRatio(IntPtr handle, int eyeWarpRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetFaceLiftRatio(IntPtr handle, int faceLiftRatio);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetLipsColorRatio(IntPtr handle, int lipsColorRatio);
       
        // lipsColor[3]
        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetLipsColor(IntPtr handle, int[] lipsColor);

        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetHighnoseRatio(IntPtr handle, int highnoseRatio);


        // defrecklePosition[2]
        [DllImport("XIUSDK_BeautyEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void Beauty_SetDefreckleMenualRadiusAndPosition(IntPtr handle, int defreckleRadius, int[] defrecklePosition);


        private IntPtr instance = IntPtr.Zero;

        public ZBeautyEngineDll()
        {
            //int gray
            String filePath = System.Windows.Forms.Application.StartupPath;
            instance = Beauty_InitBeautyEngine(filePath);
        }

        ~ZBeautyEngineDll()
        {
            if (instance != IntPtr.Zero)
            {
                Beauty_UninitBeautyEngine(instance);
                instance = IntPtr.Zero;
            }
        }

        // featurePoints update
        public Bitmap DoFaceLift(Bitmap srcBitmap, int[] featurePoints, int ratio) //瘦脸
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetFaceLiftRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;

        }

        // featurePoints update
        public Bitmap DoEyeWarp(Bitmap srcBitmap, int[] featurePoints, int ratio) //大眼
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetEyeWarpRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }

        // featurePoints update
        public Bitmap DoEyeBagRemoval(Bitmap srcBitmap, int[] featurePoints, int ratio) //去眼袋
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetEyeBagRemoveRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }


        // featurePoints update
        public Bitmap DoLightEye(Bitmap srcBitmap, int[] featurePoints, int ratio) //亮眼
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetLightEyeRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }

        //
        public Bitmap DoLipsRosy(Bitmap srcBitmap, int[] featurePoints, int ratio, int[] color) //唇色
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetLipsColorRatio(instance, ratio);
            Beauty_SetLipsColor(instance, color);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }


        // featurePoints update
        public Bitmap DoHighNose(Bitmap srcBitmap, int[] featurePoints, int ratio) //高鼻梁
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetHighnoseRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }


        public Bitmap DoDefreckleMenual(Bitmap srcBitmap, Point pos, int radius) // 手动祛斑
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetDefreckleMenualRadiusAndPosition(instance, radius, new int[] { pos.X, pos.Y });
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);
            src.UnlockBits(srcData);
            return src;
        }

        public Bitmap DoSkinWhitening(Bitmap srcBitmap, int ratio) // 美白
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetWhitenRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }

        public Bitmap DoSoftSkin(Bitmap srcBitmap, int[] featurePoints, int ratio) // 磨皮
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, featurePoints == null ? 0 : 1, featurePoints);
            Beauty_SetSoftenRatio(instance, ratio);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }

        public Bitmap DoDefreckleAuto(Bitmap srcBitmap, int[] featurePoints, Boolean enable) // 自动祛斑
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetFacePoints(instance, 1, featurePoints);
            Beauty_SetDefreckleAutoEnable(instance, enable?1:0);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);
            src.UnlockBits(srcData);
            return src;
        }
        public Bitmap DoSkinColor(Bitmap srcBitmap, int ratio) // 肤色
        {
            Bitmap src = new Bitmap(srcBitmap);

            return src;
        }

        public Bitmap DoFastSoftSkin(Bitmap srcBitmap, int softRatio, int whiteRatio, int filterId) // 快速美颜
        {
            Bitmap src = new Bitmap(srcBitmap);
            int w = src.Width;
            int h = src.Height;
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;

            Beauty_ClearParams(instance);
            Beauty_SetSoftenRatio(instance, softRatio);
            Beauty_SetWhitenRatio(instance, whiteRatio);
            Beauty_SetFilterID(instance, filterId);
            Beauty_SetFilterRatio(instance, 80);
            Beauty_ProcessBuffer(instance, srcData.Scan0, w, h, stride);

            src.UnlockBits(srcData);
            return src;
        }


        public Bitmap DoSkinTonic(Bitmap srcBitmap, int[] featurePoints, Color color, int tonicRatio) // 粉底
        {
            Bitmap src = new Bitmap(srcBitmap);

            return src;
        }


        public Bitmap DoMakeupOneKey(Bitmap srcBitmap, int[] featurePoints)
        {
            Bitmap src = new Bitmap(srcBitmap);

            return src;
        }



    }
}



