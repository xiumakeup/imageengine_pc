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
 File name:    XIUSDK_PhotoEngine.h
 Description:  photoEngine sdk 包含图像美化模块/滤镜模块
 Author:       xiusdk
 Version:      V1.2
 Date:         20190101-
 qq group:     567648913(加群获取最新信息)
 *****************************************************************************/
#ifndef XIUSDK_PhotoEngine_h
#define XIUSDK_PhotoEngine_h

 ///////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//PS blend mode
static const int BLEND_MODE_DARKEN = 1;
static const int BLEND_MODE_MULTIPLY = 2;
static const int BLEND_MODE_COLORBURN = 3;
static const int BLEND_MODE_LINEARBURN = 4;
static const int BLEND_MODE_DARKNESS = 5;
static const int BLEND_MODE_LIGHTEN = 6;
static const int BLEND_MODE_SCREEN = 7;
static const int BLEND_MODE_COLORDODGE = 8;
static const int BLEND_MODE_COLORLINEARDODGE = 9;
static const int BLEND_MODE_LIGHTCOLOR = 10;
static const int BLEND_MODE_OVERLAY = 11;
static const int BLEND_MODE_SOFTLIGHT = 12;
static const int BLEND_MODE_HARDLIGHT = 13;
static const int BLEND_MODE_VIVIDLIGHT = 14;
static const int BLEND_MODE_LINEARLIGHT = 15;
static const int BLEND_MODE_PINLIGHT = 16;
static const int BLEND_MODE_SOLIDCOLORMIXING = 17;
static const int BLEND_MODE_DIFFERENCE = 18;
static const int BLEND_MODE_EXCLUSION = 19;
static const int BLEND_MODE_SUBTRACTION = 20;
static const int BLEND_MODE_DIVIDE = 21;
///////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////
// 滤镜ID
const int FILTER_IDA = 0;
const int FILTER_IDB = 100;
const int FILTER_IDC = 200;
const int FILTER_IDD = 300;
//////////////////////////////////////////////////////////////////////////
//Filter width no mask
const int FILTER_IDA_NONE = FILTER_IDA + 0;
const int FILTER_IDA_1977 = FILTER_IDA + 1;
const int FILTER_IDA_INKWELL = FILTER_IDA + 2;
const int FILTER_IDA_KELVIN = FILTER_IDA + 3;
const int FILTER_IDA_NASHVILLE = FILTER_IDA + 4;
const int FILTER_IDA_VALENCIA = FILTER_IDA + 5;
const int FILTER_IDA_XPROII = FILTER_IDA + 6;
const int FILTER_IDA_BRANNAN = FILTER_IDA + 7;
const int FILTER_IDA_WALDEN = FILTER_IDA + 8;
const int FILTER_IDA_ADEN = FILTER_IDA + 9;//add
const int FILTER_IDA_ASHBY = FILTER_IDA + 10;
const int FILTER_IDA_BROOKLYN = FILTER_IDA + 11;
const int FILTER_IDA_CHARMES = FILTER_IDA + 12;
const int FILTER_IDA_CLARENDON = FILTER_IDA + 13;
const int FILTER_IDA_CREMA = FILTER_IDA + 14;
const int FILTER_IDA_DOGPACH = FILTER_IDA + 15;
const int FILTER_IDA_GINGHAM = FILTER_IDA + 16;
const int FILTER_IDA_GINZA = FILTER_IDA + 17;
const int FILTER_IDA_HEFE = FILTER_IDA + 18;
const int FILTER_IDA_HELENA = FILTER_IDA + 19;
const int FILTER_IDA_JUNO = FILTER_IDA + 20;
const int FILTER_IDA_LARK = FILTER_IDA + 21;
const int FILTER_IDA_LUDWIG = FILTER_IDA + 22;
const int FILTER_IDA_MAVEN = FILTER_IDA + 23;
const int FILTER_IDA_MOON = FILTER_IDA + 24;
const int FILTER_IDA_REYES = FILTER_IDA + 25;
const int FILTER_IDA_SKYLINE = FILTER_IDA + 26;
const int FILTER_IDA_SLUMBER = FILTER_IDA + 27;
const int FILTER_IDA_STINSON = FILTER_IDA + 28;
const int FILTER_IDA_VESPER = FILTER_IDA + 29;
///////////////////////////////////////////////////////////////////////
const int FILTER_IDB_WARMER = FILTER_IDB + 0;//一键美颜_暖暖
const int FILTER_IDB_CLEAR = FILTER_IDB + 1;//一键美颜_清晰
const int FILTER_IDB_WHITESKINNED = FILTER_IDB + 2;//一键美颜_白皙
const int FILTER_IDB_COOL = FILTER_IDB + 3;//一键美颜_冷艳
const int FILTER_IDB_ELEGANT = FILTER_IDB + 4;//LOMO_淡雅
const int FILTER_IDB_ANCIENT = FILTER_IDB + 5;//LOMO_复古
const int FILTER_IDB_GETE = FILTER_IDB + 6;//LOMO_哥特风
const int FILTER_IDB_BRONZE = FILTER_IDB + 7;//LOMO_古铜色
const int FILTER_IDB_LAKECOLOR = FILTER_IDB + 8;//LOMO_湖水
const int FILTER_IDB_SLLY = FILTER_IDB + 9;//LOMO_深蓝泪雨
const int FILTER_IDB_SLIVER = FILTER_IDB + 10;//格调_银色
const int FILTER_IDB_FILM = FILTER_IDB + 11;//格调_胶片
const int FILTER_IDB_SUNNY = FILTER_IDB + 12;//格调_丽日
const int FILTER_IDB_WWOZ = FILTER_IDB + 13;//格调_绿野仙踪
const int FILTER_IDB_LOVERS = FILTER_IDB + 14;//格调_迷情
const int FILTER_IDB_LATTE = FILTER_IDB + 15;//格调_拿铁
const int FILTER_IDB_JAPANESE = FILTER_IDB + 16;//格调_日系
const int FILTER_IDB_SANDGLASS = FILTER_IDB + 17;//格调_沙漏
const int FILTER_IDB_AFTEA = FILTER_IDB + 18;//格调_午茶
const int FILTER_IDB_SHEEPSCROLL = FILTER_IDB + 19;//格调_羊皮卷
const int FILTER_IDB_PICNIC = FILTER_IDB + 20;//格调_野餐
const int FILTER_IDB_ICESPIRIT = FILTER_IDB + 21;//美颜_冰灵
const int FILTER_IDB_REFINED = FILTER_IDB + 22;//美颜_典雅
const int FILTER_IDB_BLUESTYLE = FILTER_IDB + 23;//美颜_蓝调
const int FILTER_IDB_LOLITA = FILTER_IDB + 24;//美颜_萝莉
const int FILTER_IDB_LKK = FILTER_IDB + 25;//美颜_洛可可
const int FILTER_IDB_NUANHUANG = FILTER_IDB + 26;//美颜_暖黄
const int FILTER_IDB_RCOOL = FILTER_IDB + 27;//美颜_清凉
const int FILTER_IDB_JSTYLE = FILTER_IDB + 28;//美颜_日系人像
const int FILTER_IDB_SOFTLIGHT = FILTER_IDB + 29;//美颜_柔光
const int FILTER_IDB_TIANMEI = FILTER_IDB + 30;//美颜_甜美可人
const int FILTER_IDB_WEIMEI = FILTER_IDB + 31;//美颜_唯美
const int FILTER_IDB_PURPLEDREAM = FILTER_IDB + 32;//美颜_紫色幻想
const int FILTER_IDB_FOOD = FILTER_IDB + 33;//智能_美食
const int FILTER_IDB_HUAYAN = FILTER_IDB + 34;//花颜
//////////////////////////////////////////////////////////////////////////
const int FILTER_IDC_MOVIE = FILTER_IDC + 0; //LOMO_电影
const int FILTER_IDC_MAPLELEAF = FILTER_IDC + 1; //LOMO_枫叶
const int FILTER_IDC_COOLFLAME = FILTER_IDC + 2; //LOMO_冷焰
const int FILTER_IDC_WARMAUTUMN = FILTER_IDC + 3; //LOMO_暖秋
const int FILTER_IDC_CYAN = FILTER_IDC + 4; //LOMO_青色
const int FILTER_IDC_ZEAL = FILTER_IDC + 5; //LOMO_热情
const int FILTER_IDC_FASHION = FILTER_IDC + 6; //LOMO_时尚
const int FILTER_IDC_EKTAR = FILTER_IDC + 7; //弗莱胶片 -- ektar
const int FILTER_IDC_GOLD = FILTER_IDC + 8; //弗莱胶片 -- gold
const int FILTER_IDC_VISTA = FILTER_IDC + 9; //弗莱胶片 -- vista
const int FILTER_IDC_XTAR = FILTER_IDC + 10;//弗莱胶片 -- xtra
const int FILTER_IDC_RUDDY = FILTER_IDC + 11;//魔法美肤 -- 红润
const int FILTER_IDC_SUNSHINE = FILTER_IDC + 12;//魔法美肤 -- 暖暖阳光
const int FILTER_IDC_FRESH = FILTER_IDC + 13;//魔法美肤 -- 清新丽人
const int FILTER_IDC_SWEET = FILTER_IDC + 14;//魔法美肤 -- 甜美可人
const int FILTER_IDC_BLACKWHITE = FILTER_IDC + 15;//魔法美肤 -- 艺术黑白
const int FILTER_IDC_WHITENING = FILTER_IDC + 16;//魔法美肤 -- 自然美白
const int FILTER_IDC_JPELEGANT = FILTER_IDC + 17;//日系 -- 淡雅
const int FILTER_IDC_JPJELLY = FILTER_IDC + 18;//日系 -- 果冻
const int FILTER_IDC_JPFRESH = FILTER_IDC + 19;//日系 -- 清新
const int FILTER_IDC_JPSWEET = FILTER_IDC + 20;//日系 -- 甜美
const int FILTER_IDC_JPAESTHETICISM = FILTER_IDC + 21;//日系 -- 唯美
const int FILTER_IDC_JPWARM = FILTER_IDC + 22;//日系 -- 温暖
//////////////////////////////////////////////////////////////////////////
// filter effects
const int FILTER_IDD_CARTOON = FILTER_IDD + 0; //
const int FILTER_IDD_DARK = FILTER_IDD + 1; //暗调
const int FILTER_IDD_GLOW = FILTER_IDD + 2;
const int FILTER_IDD_LOMO = FILTER_IDD + 3;
const int FILTER_IDD_NEON = FILTER_IDD + 4; //霓虹
const int FILTER_IDD_OILPAINT = FILTER_IDD + 5; //油画
const int FILTER_IDD_PUNCH = FILTER_IDD + 6; //冲印
const int FILTER_IDD_REMINISCE = FILTER_IDD + 7; //怀旧
const int FILTER_IDD_SKETCH = FILTER_IDD + 8; //素描
const int FILTER_IDD_GRAPHIC = FILTER_IDD + 9; //连环画
const int FILTER_IDD_ABAOSE = FILTER_IDD + 10; //阿宝色
const int FILTER_IDD_LEGE = FILTER_IDD + 11;//乐高像素拼图
const int FILTER_IDD_LANGMAN = FILTER_IDD + 12;//浪漫
const int FILTER_IDD_LUOZHUANG = FILTER_IDD + 13;//裸妆
const int FILTER_IDD_NENHONG = FILTER_IDD + 14;//嫩红
const int FILTER_IDD_QINGTOU = FILTER_IDD + 15;//清透
const int FILTER_IDD_ZHENBAI = FILTER_IDD + 16;//臻白
const int FILTER_IDD_ZIRAN = FILTER_IDD + 17;//自然
/////////////////////////////////////////////////////////////////////////


#ifdef _MSC_VER
#    ifdef __cplusplus
#        ifdef ZPHOTO_STATIC_LIB
#            define ZPHOTO_API  extern "C"
#        else
#            ifdef ZPHOTO_DLL_EXPORTS
#                define ZPHOTO_API extern "C" __declspec(dllexport)
#            else
#                define ZPHOTO_API extern "C" __declspec(dllimport)
#            endif
#        endif
#    else
#        ifdef ZPHOTO_STATIC_LIB
#            define ZPHOTO_API
#        else
#            ifdef ZPHOTO_DLL_EXPORTS
#                define ZPHOTO_API __declspec(dllexport)
#            else
#                define ZPHOTO_API __declspec(dllimport)
#            endif
#        endif
#    endif
#else /* _MSC_VER */
#    ifdef __cplusplus
#        ifdef ZPHOTO_DLL_EXPORTS
#            define ZPHOTO_API extern "C" __attribute__((visibility ("default")))
#        else
#            define ZPHOTO_API extern "C"
#        endif
#    else
#        ifdef ZPHOTO_DLL_EXPORTS
#            define ZPHOTO_API __attribute__((visibility ("default")))
#        else
#            define ZPHOTO_API
#        endif
#    endif
#endif




//basic fun
/*************************************************
 Function:    ZPHOTO_SaturationAdjust
 Description: 饱和度调节.
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 saturation:  saturation value, range is [0,512]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_SaturationAdjust(unsigned char* srcData, int width, int height, int stride, int saturation);
/*************************************************
 Function:    ZPHOTO_Posterize
 Description: 色调分离.
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 clusterNum:  色调数，范围[2,255]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Posterize(unsigned char *srcData, int width, int height, int stride, int clusterNum);
/*************************************************
 Function:    ZPHOTO_OverExposure
 Description: 过度曝光.
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_OverExposure(unsigned char *srcData, int width, int height, int stride);//过度曝光
/*************************************************
 Function:    ZPHOTO_LightnessAdjust
 Description: 明度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 lightness    明度值，[-100,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_LightnessAdjust(unsigned char* srcData, int width, int height, int stride, int lightness);//明度调节
/*************************************************
 Function:    ZPHOTO_Invert
 Description: 反相
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Invert(unsigned char *srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_HueAndSaturationAdjust
 Description: 色相饱和度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 hue          色相值，范围[-180,180]
 saturation   饱和度值，范围为[-100,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_HueAndSaturationAdjust(unsigned char* srcData, int width, int height, int stride, int hue, int saturation);
/*************************************************
 Function:    ZPHOTO_HistagramEqualize
 Description: 色调均化
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_HistagramEqualize(unsigned char* srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_Desaturate
 Description: 去色
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Desaturate(unsigned char *srcData, int width, int height, int stride, int ratio);
/*************************************************
 Function:    ZPHOTO_CurveAdjust
 Description: 曲线调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 destChannel  通道选择，Gray通道-0，R通道-1，G通道-2，B通道-3
 inputLeftLimit   输入最小值，范围[0,255]
 inputMiddle      输入中间值，范围[0,255]
 inputRightLimit  输入最大值，范围[0,255]
 outputLeftLimit  输出最小值，范围[0,255]
 outputRightLimit 输出最大值，范围[0,255]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_CurveAdjust(unsigned char * srcData, int width, int height, int stride, int DestChannel, unsigned char InputLeftLimit, unsigned char InputMiddle, unsigned char InputRightLimit, unsigned char OutputLeftLimit, unsigned char OutputRightLimit);

/*************************************************
 Function:    ZPHOTO_CurveAdjust
 Description: 色阶调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 destChannel  通道选择，Gray通道-0，R通道-1，G通道-2，B通道-3
 inputLeftLimit   输入最小值，范围[0,255]
 inputMiddle      输入中间值，范围[0,9.99]
 inputRightLimit  输入最大值，范围[0,255]
 outputLeftLimit  输出最小值，范围[0,255]
 outputRightLimit 输出最大值，范围[0,255]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ColorLevelAdjust(unsigned char * srcData, int width, int height, int stride, int destChannel, unsigned char inputLeftLimit, float inputMiddle, unsigned char inputRightLimit, unsigned char outputLeftLimit, unsigned char outputRightLimit);
/*************************************************
 Function:    ZPHOTO_NLinearBrightContrastAdjust
 Description: 非线性亮度对比度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 brightness   亮度值，范围[-255,255]
 contrast     对比度值，范围[-255,255]
 threshold    调节阈值，范围[0,255]，默认值为128
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_NLinearBrightContrastAdjust(unsigned char* srcData, int width, int height, int stride, int bright, int contrast, int threshold);
/*************************************************
 Function:    ZPHOTO_LinearBrightContrastAdjust
 Description: 线性亮度对比度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 brightness   亮度值，范围[-255,255]
 contrast     对比度值，范围[-255,255]
 threshold    调节阈值，范围[0,255]，默认值为128
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_LinearBrightContrastAdjust(unsigned char* srcData, int width, int height, int stride, int brightness, int contrast, int threshold);
/*************************************************
 Function:    ZPHOTO_Blackwhite
 Description: 黑白
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 kRed         红色比例,范围[-200,300]
 kGreen       绿色比例,范围[-200,300]
 kBlue        蓝色比例,范围[-200,300]
 kYellow      黄色比例,范围[-200,300]
 kCyan        青色比例,范围[-200,300]
 kMagenta     洋红比例,范围[-200,300]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Blackwhite(unsigned char *srcData, int width, int height, int stride, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);

/*************************************************
 Function:    ZPHOTO_AutoContrastAdjust
 Description: 自动对比度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_AutoContrastAdjust(unsigned char *srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_AutoContrastAdjustWithParameters
 Description: 参数限制的自动对比度调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 shadowCorrectRatio    阴影修剪比例，范围[0.00,9.99]
 highlightCorrectRatio 高光修剪比例，范围[0.00,9.99]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_AutoContrastAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);
/*************************************************
 Function:    ZPHOTO_AutoColorGradationAdjust
 Description: 自动色阶调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_AutoColorGradationAdjust(unsigned char *srcData, int width, int height, int stride);//自动色阶
/*************************************************
 Function:    ZPHOTO_AutoColorGradationAdjustWithParameters
 Description: 参数限制的自动色阶调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 shadowCorrectRatio    阴影修剪比例，范围[0.00,9.99]
 highlightCorrectRatio 高光修剪比例，范围[0.00,9.99]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_AutoColorGradationAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);
/*************************************************
 Function:    ZPHOTO_Threshold
 Description: 阈值(二值化)
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 threshold    阈值，范围[0,255]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Threshold(unsigned char *srcData, int width, int height, int stride, int threshold);
/*************************************************
 Function:    ZPHOTO_ChannelMixProcess
 Description: 通道混合器
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 channel      Red-0,Green-1,Blue-2,Gray-3
 kr-Red       通道比例，范围[-200,200]
 kg-Green     通道比例，范围[-200,200]
 kb-Blue      通道比例，范围[-200,200]
 N            常数调节比例，范围[-200,200]
 singleColor  是否单色，单色-true，彩色-false
 constAdjust  是否执行常数比例调节，调节-true,不调节-false
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ChannelMixProcess(unsigned char* srcData, int width, int height, int stride, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust);
/*************************************************
 Function:    ZPHOTO_FastGaussFilter
 Description: 高斯模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 radius       高斯模糊半径，范围[0,1000]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_FastGaussFilter(unsigned char* srcData, int width, int height, int stride, unsigned char* dstData, float radius);//高斯滤波
/*************************************************
 Function:    ZPHOTO_FastestGaussFilter
 Description: 极速高斯模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 radius       高斯模糊半径，范围[0,1000]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_FastestGaussFilter(unsigned char* srcData, int width, int height, int stride, unsigned char* dstData, float radius);//高斯滤波
/*************************************************
 Function:    ZPHOTO_HighPass
 Description: 高反差保留
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 radius       高斯模糊半径，范围[0,1000]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_HighPass(unsigned char* srcData, int width, int height, int stride, unsigned char* dstData, float mRadius);//高反差保留
/*************************************************
 Function:    ZPHOTO_USM
 Description: USM锐化
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 radius       高斯半径，范围为[0,1000]
 amount       锐化程度，范围为[0,500]
 threshold    锐化阈值，范围为[0,255]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_USM(unsigned char* srcData, int width, int height, int stride, unsigned char* dstData, float radius, int amount, int threshold);
/*************************************************
 Function:    ZPHOTO_FindEdges
 Description: 查找边缘
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_FindEdges(unsigned char *srcData, int width, int height, int stride, unsigned char *dstData);
/////////////////////////////////////////////////////////////////////////////////////////////////////


//图层混合功能
/*************************************************
 Function:    ZPHOTO_ModeDarken
 Description: 变暗模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeDarken(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeMultiply
 Description: 正片叠底模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeMultiply(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeColorBurn
 Description: 颜色加深模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeColorBurn(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeLinearBurn
 Description: 线性渐变模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeLinearBurn(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeDarkness
 Description: 深色模式
 Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
 baseGreen    输入基础像素G值，范围[0,255]，执行后作为输出结果
 baseBlue     输入基础像素B值，范围[0,255]，执行后作为输出结果
 mixRed       输入混合像素R值，范围[0,255]
 mixRed       输入混合像素G值，范围[0,255]
 mixRed       输入混合像素B值，范围[0,255]
 Output:      non.
 Return:      0-成功，其他失败.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeDarkness(int *baseRed, int *baseGreen, int *baseBlue, int mixRed, int mixGreen, int mixBlue);
/*************************************************
 Function:    ZPHOTO_ModeLighten
 Description: 变亮模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeLighten(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeScreen
 Description: 滤色模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeScreen(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeColorDodge
 Description: 颜色减淡模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeColorDodge(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeColorLinearDodge
 Description: 颜色线性减淡模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeColorLinearDodge(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeLightColor
 Description: 浅色模式
 Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
 baseGreen    输入基础像素G值，范围[0,255]，执行后作为输出结果
 baseBlue     输入基础像素B值，范围[0,255]，执行后作为输出结果
 mixRed       输入混合像素R值，范围[0,255]
 mixRed       输入混合像素G值，范围[0,255]
 mixRed       输入混合像素B值，范围[0,255]
 Output:      non.
 Return:      0-成功，其他失败.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeLightColor(int *baseRed, int *baseGreen, int *baseBlue, int mixRed, int mixGreen, int mixBlue);
/*************************************************
 Function:    ZPHOTO_ModeOverlay
 Description: 叠加模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeOverlay(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeSoftLight
 Description: 柔光模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeSoftLight(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeHardLight
 Description: 强光模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeHardLight(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeVividLight
 Description: 亮光模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeVividLight(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeLinearLight
 Description: 线性光模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeLinearLight(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModePinLight
 Description: 点光模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModePinLight(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeSolidColorMixing
 Description: 实色混合模式
 Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
 baseGreen    输入基础像素G值，范围[0,255]，执行后作为输出结果
 baseBlue     输入基础像素B值，范围[0,255]，执行后作为输出结果
 mixRed       输入混合像素R值，范围[0,255]
 mixRed       输入混合像素G值，范围[0,255]
 mixRed       输入混合像素B值，范围[0,255]
 Output:      non.
 Return:      0-成功，其他失败.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeSolidColorMixing(int *baseRed, int *baseGreen, int *baseBlue, int mixRed, int mixGreen, int mixBlue);
/*************************************************
 Function:    ZPHOTO_ModeDifference
 Description: 差值模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeDifference(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeExclusion
 Description: 排除模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeExclusion(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeSubtraction
 Description: 减去模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeSubtraction(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeDivide
 Description: 划分模式
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeDivide(int basePixel, int mixPixel);
/*************************************************
 Function:    ZPHOTO_ModeDesaturate
 Description: 去色
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeDesaturate(int red, int green, int blue);
/*************************************************
 Function:    ZPHOTO_ModeColorInvert
 Description: 反相
 Input:       basePixel-输入基础像素值，范围[0,255]
 mixPixel     输入混合像素值，范围[0,255]
 Output:      non.
 Return:      图层混合结果值，范围[0,255].
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ModeColorInvert(int *red, int *green, int *blue);
/*************************************************
 Function:    ZPHOTO_ImageBlendEffect
 Description: 图层混合
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 mixData      混合图层图像Buffer，大小与基础图层图像一致
 blendMode    图层混合模式
 Output:      non.
 Return:      0-成功，其他失败.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageBlendEffect(unsigned char* baseData, int width, int height, int stride, unsigned char* mixData, int blendMode);
/////////////////////////////////////////////////////////////////////////////////////////////////////

//扩展功能
/*************************************************
 Function:    ZPHOTO_ColorTemperatureAdjust
 Description: 色温调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    色温强度，范围[-50,50]；intensity < 0，冷色；intensity = 0,原图；intensity > 0，暖色；
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ColorTemperatureAdjust(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_ShadowAdjust
 Description: 阴影调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity-阴影强度值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ShadowAdjust(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_HighlightAdjust
 Description: 高光调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    高光强度值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_HighlightAdjust(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_HighlightShadowPreciseAdjust
 Description: 高光阴影调节
 Input:       srcData-原始图像，格式为32位BGRA格式
 width/height:image info
 stride:      bytes per row
 highlight    高光强度值，取值范围为[-200,100]
 shadow       阴影强度值，取值范围为[-200,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_HighlightShadowPreciseAdjust(unsigned char* srcData, int width, int height, int stride, float highlight, float shadow);
/*************************************************
 Function:    ZPHOTO_ExposureAdjust
 Description: 曝光调节
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    曝光强度值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ExposureAdjust(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_CalcWH
 Description: 计算图像变换之后的宽高及变换矩阵H，该接口先于ZPHOTO_ImageTransformation调用
 inputImgSize 输入图像宽高信息
 angle        旋转角度值，取值范围为[-360-360]
 scale        缩放变换值，取值大于0
 transform_method           变换方法：
 transform_scale          缩放变换, 取值为0；
 transform_rotation       旋转变换, 取值为1；
 transform_rotation_scale 缩放旋转变换, 取值为2；
 transform_affine         仿射变换, 取值为3；
 transform_mirror_h       水平镜像变换, 取值为4；
 transform_mirror_v       垂直镜像变换, 取值为5；
 transform_offset         平移变换, 取值为6；
 outputImgSize            输出图像宽高信息
 H            变换矩阵数组，长度为6
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_CalcWH(int inputImgSize[2], float angle, float scale, int transform_method, int outputImgSize[2], float H[]);
/*************************************************
 Function:    ZPHOTO_ImageTransformation
 Description: 图像变换
 Input:       srcData-原始图像，格式为32位BGRA格式
 srcImgSize   原始图像宽高信息数组
 dstData      结果图像Buffer，大小由接口ZPHOTO_CalcWH获得
 dstImgSize   目标图像宽高信息数组
 H            变换矩阵数组，长度为6
 Interpolation_method       插值方法选择：interpolation_bilinear,interpolation_nearest
 transform_method           变换方法：
 transform_scale          缩放变换, 取值为0；
 transform_rotation       旋转变换, 取值为1；
 transform_rotation_scale 缩放旋转变换, 取值为2；
 transform_affine         仿射变换, 取值为3；
 transform_mirror_h       水平镜像变换, 取值为4；
 transform_mirror_v       垂直镜像变换, 取值为5；
 transform_offset         平移变换, 取值为6；
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageTransformation(unsigned char *srcData, int srcImgSize[2], unsigned char *dstData, int dstImgSize[2], float H[], int Interpolation_method, int Transform_method);
/*************************************************
 Function:    ZPHOTO_FastMeanFilter
 Description: 均值模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 radius       均值滤波半径，取值范围为[0,width / 2]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_FastMeanFilter(unsigned char* srcData, int width, int height, int stride, unsigned char* dstData, int radius);
/*************************************************
 Function:    ZPHOTO_SobelFilter
 Description: Sobel边缘检测
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 dstData      结果图像，大小与原图一致
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_SobelFilter(unsigned char *srcData, int width, int height, int stride, unsigned char *dstData);

//For Android Development
/*************************************************
 Function:    ZPHOTO_RGBA2BGRA
 Description: RGBA格式转BGRA格式，主要为android设置
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_RGBA2BGRA(unsigned char* srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_BGRA2RGBA
 Description: BGRA格式转RGBA格式，主要为android设置
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_BGRA2RGBA(unsigned char* srcData, int width, int height, int stride);

/*************************************************
 Function:    ZPHOTO_Fragment
 Description: 碎片
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Fragment(unsigned char *srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_MotionBlur
 Description: 运动模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 angle        运动模糊角度值，取值范围为[0,360]
 distance     运动模糊距离值，取值范围为[0,200]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_MotionBlur(unsigned char* srcData, int width, int height, int stride, int angle, int distance);
/*************************************************
 Function:    ZPHOTO_SurfaceBlur
 Description: 表面模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 threshold    表面模糊阈值值，取值范围为[0,255]
 radius       表面模糊半径值，取值范围为[0,10]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_SurfaceBlur(unsigned char *srcData, int width, int height, int stride, int threshold, int radius);
/*************************************************
 Function:    ZPHOTO_RadialBlur
 Description: 旋转模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cenX         选钻模糊中心X坐标
 cenY         旋转模糊中心Y坐标
 amount       旋转模糊程度数量，范围为[1-100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_RadialBlur(unsigned char* srcData, int width, int height, int stride, int cenX, int cenY, int amount);
/*************************************************
 Function:    ZPHOTO_ZoomBlur
 Description: 缩放模糊
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cenX         缩放模糊中心X坐标
 cenY         缩放模糊中心Y坐标
 sampleRadius 缩放模糊半径，范围为[0-255]
 amount       缩放模糊程度数量,范围为[1-100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ZoomBlur(unsigned char* srcData, int width, int height, int stride, int cenX, int cenY, int sampleRadius, int amount);
/*************************************************
 Function:    ZPHOTO_Relief
 Description: 浮雕
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 angle        浮雕角度，范围为[0-360]
 amount       浮雕程度数量,范围为[0-500]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Relief(unsigned char *srcData, int width, int height, int stride, int angle, int amount);
/*************************************************
 Function:    ZPHOTO_Mean
 Description: 平均
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Mean(unsigned char *srcData, int width, int height, int stride);
/*************************************************
 Function:    ZPHOTO_Mosaic
 Description: 马赛克
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 size-Mosaic  半径,范围为[0,200]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Mosaic(unsigned char* srcData, int width, int height, int stride, int size);
/*************************************************
 Function:    ZPHOTO_ColorBalance
 Description: 色彩平衡
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cyan         青色，范围为[-100,100]
 magenta      洋红，范围为[-100,100]
 yellow       黄色，范围为[-100,100]
 channel      通道选择，RGB-0,R-1,G-2,B-3
 preserveLuminosity-true: 保留明度，false:不保留明度
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ColorBalance(unsigned char* srcData, int width, int height, int stride, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity);
/*************************************************
 Function:    ZPHOTO_Diffusion
 Description: 扩散
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    扩散程度，范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_Diffusion(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_LSNBlur
 Description: LSNBlur
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 radius       LSNBlur半径，范围为[0,200]
 delta        范围为[0,500]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_LSNBlur(unsigned char* srcData, int width, int height, int stride, int radius, int delta);
/*************************************************
 Function:    ZPHOTO_MedianFilter
 Description: 中值滤波(中间色)
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 radius       表面模糊半径值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_MedianFilter(unsigned char *srcData, int width, int height, int stride, unsigned char* dstData, int radius);
/*************************************************
 Function:    ZPHOTO_MaxFilter
 Description: 最大值滤波(最大值)
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 radius       表面模糊半径值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_MaxFilter(unsigned char *srcData, int width, int height, int stride, unsigned char* dstData, int radius);
/*************************************************
 Function:    ZPHOTO_MinFilter
 Description: 最小值滤波(最小值)
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 radius       表面模糊半径值，取值范围为[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_MinFilter(unsigned char *srcData, int width, int height, int stride, unsigned char* dstData, int radius);
/*************************************************
 Function:    ZPHOTO_GlowingEdges
 Description: 照亮边缘滤镜
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 edgeSize       边缘宽度值，取值范围为[1,14]
 edgeLightness  边缘亮度值，取值范围为[0,20]
 edgeSmoothness 平滑度，取值范围为[1,15]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_GlowingEdges(unsigned char* srcData, int width, int height, int stride, int edgeSize, int edgeLightness, int edgeSmoothness);
/*************************************************
 Function:    ZPHOTO_ImageWarpPinch
 Description: Pinch 变形
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cenX         变形中心点Y坐标
 cenY         变形中心点X坐标
 intensity    挤压变形程度，范围[10,20]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageWarpPinch(unsigned char *srcData, int width, int height, int stride, int cenX, int cenY, int intensity);
/*************************************************
 Function:    ZPHOTO_ImageWarpWave
 Description: Wave 变形
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    变形程度，范围[0, 100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageWarpWave(unsigned char *srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_ImageWarpZoom
 Description: Zoom 变形
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cenX         变形中心点X坐标
 cenY         变形中心点Y坐标
 radius       变形半径，范围[0, 500]
 unit         缩放因子，范围[0,10]，小于1为缩小效果，大于1为放大效果
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageWarpZoom(unsigned char* srcData, int width, int height, int stride, int cenX, int cenY, int radius, float unit);
/*************************************************
 Function:    ZPHOTO_ImageWarpMagicMirror
 Description: MagicMirror 变形
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 cenX         变形中心点X坐标
 cenY         变形中心点Y坐标
 radius       变形半径，范围[0, 500]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_ImageWarpMagicMirror(unsigned char* srcData, int width, int height, int stride, int cenX, int cenY, int radius);
/*************************************************
 Function:    ZPHOTO_RGBToYUV
 Description: RGB转YUV
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Y            像素Y分量
 U            像素U分量
 V            像素V分量
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToYUV(int Red, int Green, int Blue, int* Y, int* U, int* V);
/*************************************************
 Function:    ZPHOTO_YUVToRGB
 Description: YUV转RGB
 Input:
 Y            像素Y分量
 U            像素U分量
 V            像素V分量
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_YUVToRGB(int Y, int U, int V, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToYCbCr
 Description: RGB转YCbCr
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Y            像素Y分量
 Cb           像素Cb分量
 Cr           像素Cr分量
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToYCbCr(int R, int G, int B, int*Y, int*Cb, int* Cr);
/*************************************************
 Function:    ZPHOTO_YCbCrToRGB
 Description: YCbCr转RGB
 Input:
 Y            像素Y分量
 Cb           像素Cb分量
 Cr           像素Cr分量
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_YCbCrToRGB(int Y, int Cb, int Cr, int*Red, int*Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToXYZ
 Description: RGB转XYZ
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 X            像素X分量
 Y            像素Y分量
 Z            像素Z分量
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToXYZ(int Red, int Green, int Blue, int* X, int* Y, int* Z);
/*************************************************
 Function:    ZPHOTO_XYZToRGB
 Description: XYZ转RGB
 Input:
 X            像素X分量
 Y            像素Y分量
 Z            像素Z分量
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_XYZToRGB(int X, int Y, int Z, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToHSL
 Description: RGB转HSL
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 h            像素hue分量，范围[0,360]
 s            像素saturation分量，范围[0,1]
 l            像素lightness分量,范围[0,1]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToHSL(int Red, int Green, int Blue, int* h, int* s, int* l);
/*************************************************
 Function:    ZPHOTO_HSLToRGB
 Description: HSL转RGB
 Input:
 h            像素hue分量，范围[0,360]
 s            像素saturation分量，范围[0,1]
 l            像素lightness分量,范围[0,1]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_HSLToRGB(int h, int s, int l, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToHSV
 Description: RGB转HSV
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 h            像素hue分量，范围[0,360]
 s            像素saturation分量，范围[0,1]
 v            像素lightness分量,范围[0,1]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToHSV(int Red, int Green, int Blue, double* h, double* s, double* v);
/*************************************************
 Function:    ZPHOTO_HSVToRGB
 Description: HSL转RGB
 Input:
 h            像素hue分量，范围[0,360]
 s            像素saturation分量，范围[0,1]
 v            像素lightness分量,范围[0,1]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_HSVToRGB(double h, double s, double v, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToCMYK
 Description: RGB转CMYK
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 C            像素C分量，范围[0,512]
 M            像素M分量，范围[0,512]
 Y            像素Y分量, 范围[0,512]
 K            像素K分量, 范围[0,512]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToCMYK(int Red, int Green, int Blue, int* C, int* M, int* Y, int * K);
/*************************************************
 Function:    ZPHOTO_CMYKToRGB
 Description: CMYK转RGB
 Input:
 C            像素C分量，范围[0,512]
 M            像素M分量，范围[0,512]
 Y            像素Y分量, 范围[0,512]
 K            像素K分量, 范围[0,512]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_CMYKToRGB(int C, int M, int Y, int K, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToYDbDr
 Description: RGB转YDbDr
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Y            像素Y分量，范围[0,255]
 Db           像素Db分量，范围[0,255]
 Dr           像素Dr分量, 范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToYDbDr(int Red, int Green, int Blue, int* Y, int* Db, int* Dr);
/*************************************************
 Function:    ZPHOTO_YDbDrToRGB
 Description: YDbDr转RGB
 Input:
 Y            像素Y分量，范围[0,255]
 Db           像素Db分量，范围[0,255]
 Dr           像素Dr分量, 范围[0,255]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_YDbDrToRGB(int Y, int Db, int Dr, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToYIQ
 Description: RGB转YIQ
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Y            像素Y分量，范围[0,1]
 I            像素I分量，范围[-0.5957,0.5957]
 Q            像素Q分量, 范围[-0.5226,0.5226]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToYIQ(int Red, int Green, int Blue, double* Y, double* I, double* Q);
/*************************************************
 Function:    ZPHOTO_YIQToRGB
 Description: YIQ转RGB
 Input:
 Y            像素Y分量，范围[0,1]
 I            像素I分量，范围[-0.5957,0.5957]
 Q            像素Q分量, 范围[-0.5226,0.5226]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_YIQToRGB(double Y, double I, double Q, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_RGBToLab
 Description: RGB转LAB
 Input:
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 L            像素Y分量，范围[0,255]
 A            像素I分量，范围[0,255]
 B            像素Q分量, 范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_RGBToLab(int Red, int Green, int Blue, int* L, int *A, int *B);
/*************************************************
 Function:    ZPHOTO_LabToRGB
 Description: LAB转RGB
 Input:
 L            像素Y分量，范围[0,255]
 A            像素I分量，范围[0,255]
 B            像素Q分量, 范围[0,255]
 Red          像素R分量，范围[0,255]
 Green        像素G分量，范围[0,255]
 Blue         像素B分量，范围[0,255]
 Output:      non.
 Return:      non.
 Others:      non.
 *************************************************/
ZPHOTO_API void ZPHOTO_LabToRGB(int L, int A, int B, int* Red, int* Green, int* Blue);
/*************************************************
 Function:    ZPHOTO_GammaCorrect
 Description: Gamma调整
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 intensity    Gamma参数，范围[1,50]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_GammaCorrect(unsigned char* srcData, int width, int height, int stride, int intensity);
/*************************************************
 Function:    ZPHOTO_VirtualFilter
 Description: 虚化滤镜
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 x             虚化圆点x坐标
 y             虚化圆点y坐标
 blurIntensity 虚化程度参数，范围[1,100]
 radius        虚化半径，范围[0,+]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_VirtualFilter(unsigned char* srcData, int width, int height, int stride, int x, int y, int blurIntensity, int radius);
/*************************************************
 Function:    ZPHOTO_SharpenLaplace
 Description: 锐化滤镜
 Input:       original image buffer, BGRA-32bit pixel format, data output after modified
 width/height:image info
 stride:      bytes per row
 ratio        锐化程度参数，范围[0,100]
 Output:      non.
 Return:      0 success,else fail.
 Others:      non.
 *************************************************/
ZPHOTO_API int ZPHOTO_SharpenLaplace(unsigned char* srcData,int width, int height,int stride,int ratio);

/*************************************************
Function:    ZPHOTO_Filter
Description: ZPHOTO滤镜
Input:       original image buffer, BGRA-32bit pixel format, data output after modified
width/height:image info
stride:      bytes per row
FilterId     滤镜ID，取值参考头文件滤镜索引值
Output:      non.
Return:      0 success,else fail.
Others:      non.
*************************************************/
ZPHOTO_API int ZPHOTO_Filter(unsigned char* srcData, int width, int height, int stride, int FilterId);
/*************************************************
Function:    ZPHOTO_Filter
Description: ZPHOTO带模板滤镜，
Input:       original image buffer, BGRA-32bit pixel format, data output after modified
width/height:image info
stride:      bytes per row of original image
Input:       mask buffer, BGRA-32bit pixel format
mWith/mHeight mask width and height
mStride:      bytes per row of mask image
FilterId     滤镜ID，取值参考头文件滤镜索引值
Output:      non.
Return:      0 success,else fail.
Others:      non.
*************************************************/
ZPHOTO_API int ZPHOTO_UniversalFilter(unsigned char* srcData, int width, int height, int stride, unsigned char* maskData, int mWidth, int mHeight, int mStride, int mergeMode, int ratio);



#endif

