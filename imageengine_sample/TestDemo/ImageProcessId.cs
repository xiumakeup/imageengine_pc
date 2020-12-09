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

namespace TestDemo
{
    class ImageProcessId
    {
        public const int ID_NONE = 0;
        public const int ID_ROTATE = 1;                      //旋转
        public const int ID_ZOOM = 2;                        //缩放
        public const int ID_HMIRROR = 3;                     //水平翻转
        public const int ID_VMIRROR = 4;                     //垂直翻转
        public const int ID_AUTO_COLORGRADATION = 5;         //自动色调
        public const int ID_AUTO_CONTRAST = 6;               //自动对比度
        public const int ID_HISTAGRAMEQUALIZE = 7;           //色调均化
        public const int ID_BRIGHTCONTRAST = 8;              //亮度对比度
        public const int ID_COLORLEVEL = 9;                  //色阶
        public const int ID_HSL = 10;                        //色相饱和度亮度
        public const int ID_COLORBALANCE = 11;               //色彩平衡
        public const int ID_INVERT = 12;                     //反相
        public const int ID_POSTERIZE = 13;                  //色调分离
        public const int ID_THRESHOLD = 14;                  //阈值
        public const int ID_DESATURATE = 15;                 //去色
        public const int ID_HIGHLIGHTSHADOW = 16;            //高光阴影
        public const int ID_EXPOSURE = 17;                   //曝光
        public const int ID_COLORTEMPEATURE = 18;            //色温
        public const int ID_FINDEDGES = 19;                  //查找边缘
        public const int ID_RELIEF = 20;                     //浮雕
        public const int ID_DIFUSSION = 21;                  //扩散
        public const int ID_OVEREXPOSURE = 22;               //曝光过度
        public const int ID_SURFACEBLUR = 23;                //表面模糊
        public const int ID_MOTIONBLUR = 24;                 //动感模糊
        public const int ID_MEANBLUR = 25;                   //均值模糊
        public const int ID_GAUSSBLUR = 26;                  //高斯模糊
        public const int ID_RADIAL = 27;                     //旋转模糊
        public const int ID_ZOOMBLUR = 28;                   //缩放模糊
        public const int ID_MEAN = 29;                       //平均
        public const int ID_MOSCIA = 30;                     //马赛克
        public const int ID_FRAGMENT = 31;                   //碎片
        public const int ID_HIGHPASS = 32;                   //高反差保留
        public const int ID_USM = 33;                        //USM锐化
        public const int ID_CHANNELMIXER = 34;               //通道混合器
        public const int ID_BLACKWHITE = 35;                 //黑白
        public const int ID_GAMMA = 36;                      //Gamma
        public const int ID_MEDIANFILTER = 37;               //中间色
        public const int ID_MAXFILTER = 38;                  //最大值
        public const int ID_MINFILTER = 39;                  //最小值
        public const int ID_VIRTURALFILTER = 40;             //虚化
        public const int ID_IMAGEWARP_PINCH = 41;            //Pinch变形
        public const int ID_IMAGEWARP_WAVE = 42;             //Wave变形
        public const int ID_IMAGEWARP_ZOOMIN = 43;           //缩小
        public const int ID_IMAGEWARP_ZOOMOUT = 44;          //放大
        public const int ID_IMAGEWARP_MAGICMIRROR = 45;      //哈哈镜

        //public const int ID_MAKEUP_SKINCOLOR = 100;          //肤色调节
        public const int ID_MAKEUP_SKINWHITE = 101;          //美白
        public const int ID_MAKEUP_SOFTSKIN = 102;           //磨皮
        public const int ID_MAKEUP_EYEWARP  = 103;           //大眼
        public const int ID_MAKEUP_FACELIFT = 104;           //瘦脸
        public const int ID_MAKEUP_LIPSROSY = 105;           //美唇
        public const int ID_MAKEUP_LIGHTEYE = 106;           //亮眼
        public const int ID_MAKEUP_EYEBAGREMOVE = 107;       //去眼袋
        public const int ID_MAKEUP_HIGHNOSE   = 108;          //高鼻梁
        public const int ID_MAKEUP_DEFRECKLE  = 109;          //自动祛斑
        public const int ID_MAKEUP_FACEDETECT = 110;          //人脸检测
        //public const int ID_MAKEUP_SKINTONIC  = 111;          //自动祛斑
        public const int ID_MAKEUP_DEFRECKLE_AUTO = 112;          //自动祛斑

        //public const int ID_MAKEUP_BEAUTY_ONE = 150;          //妆容一
        //public const int ID_MAKEUP_BEAUTY_TWO = 151;          //妆容二



    }
}
