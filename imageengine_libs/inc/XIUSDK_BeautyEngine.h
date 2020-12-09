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
 File name:    XIUSDK_BeautyEngine.h
 Description:  beautyEngine sdk 包含人脸美化模块/滤镜模块
 Author:       xiusdk
 Version:      V1.2
 Date:         20200101-20231230
 qq group:     567648913(加群获取最新信息)
*****************************************************************************/
#ifndef XIUSDK_BeautyEngine_h
#define XIUSDK_BeautyEngine_h


#ifdef _MSC_VER
#   ifdef __cplusplus
#       ifdef ZBEAUTY_STATIC_LIB
#           define ZBEAUTY_API  extern "C"
#       else
#           ifdef ZBEAUTY_SDK_EXPORTS
#               define ZBEAUTY_API extern "C" __declspec(dllexport)
#           else
#               define ZBEAUTY_API extern "C" __declspec(dllimport)
#           endif
#       endif
#   else
#       ifdef ZBEAUTY_STATIC_LIB
#           define ZBEAUTY_API
#       else
#           ifdef ZBEAUTY_SDK_EXPORTS
#               define ZBEAUTY_API __declspec(dllexport)
#           else
#               define ZBEAUTY_API __declspec(dllimport)
#           endif
#       endif
#   endif
#else /* _MSC_VER */
#   ifdef __cplusplus
#       ifdef ZBEAUTY_SDK_EXPORTS
#           define ZBEAUTY_API extern "C" __attribute__((visibility ("default")))
#       else
#           define ZBEAUTY_API extern "C"
#       endif
#   else
#       ifdef ZBEAUTY_SDK_EXPORTS
#           define ZBEAUTY_API __attribute__((visibility ("default")))
#       else
#           define ZBEAUTY_API
#       endif
#   endif
#endif

typedef void* BeautyHandle;

#define BEAUTY_E_MEMMORY        (-1)
#define BEAUTY_E_FILE           (-2)
#define BEAUTY_E_PARAMETER      (-3)
#define BEAUTY_E_IMAGEFORMAT    (-4)
#define BEAUTY_OK               ( 0)

#define PIXELFORMAT_BGRA   0  // 
#define PIXELFORMAT_RGBA   1  // 
#define PIXELFORMAT_NV21   2  // yyyy vu
#define PIXELFORMAT_NV12   3  // yyyy uv
#define PIXELFORMAT_I420   4  // yyyy u v
#define PIXELFORMAT_YV12   5  // yyyy v u
#define PIXELFORMAT_I422   6  // yyyy uu vv
#define PIXELFORMAT_YV16   7  // yyyy vv uu




/// create beauty engine instance
ZBEAUTY_API BeautyHandle Beauty_InitBeautyEngine(const char* filePath);
/// destory beauty engine instance
ZBEAUTY_API void Beauty_UninitBeautyEngine(BeautyHandle handle);
/// beauty api
ZBEAUTY_API int Beauty_ProcessBuffer(BeautyHandle handle, unsigned char *srcData, int width, int height, int stride);
/// default pixel buffer BGRA
ZBEAUTY_API void Beauty_SetPixelFMT(BeautyHandle handle, int pixFMT);
ZBEAUTY_API void Beauty_ClearParams(BeautyHandle handle);
///
ZBEAUTY_API void Beauty_SetFacePoints(BeautyHandle handle, int faceCount, int points[]);
/// softenRatio, reference value: 60
ZBEAUTY_API void Beauty_SetSoftenRatio(BeautyHandle handle, int softenRatio);
/// writenRatio, reference value: 20
ZBEAUTY_API void Beauty_SetWhitenRatio(BeautyHandle handle,int whitenRatio);
/// filterID, reference value: 0~36
ZBEAUTY_API void Beauty_SetFilterID(BeautyHandle handle, int filterID);
/// filterRatio, reference value: 80
ZBEAUTY_API void Beauty_SetFilterRatio(BeautyHandle handle, int filterRatio);


/// defreckleAutoEnable, enable: 1, disable:0
ZBEAUTY_API void Beauty_SetDefreckleAutoEnable(BeautyHandle handle, int defreckleAutoEnable);
/// defreckleMenualRadius, reference value: 5;  defrecklePosition, x,y coordinate of image
ZBEAUTY_API void Beauty_SetDefreckleMenualRadiusAndPosition(BeautyHandle handle, int defreckleRadius, int defrecklePosition[]);
/// eyeBagRemoveRatio, reference value: 60
ZBEAUTY_API void Beauty_SetEyeBagRemoveRatio(BeautyHandle handle, int eyeBagRemoveRatio);
/// lightEyeRatio, reference value: 60
ZBEAUTY_API void Beauty_SetLightEyeRatio(BeautyHandle handle, int lightEyeRatio);
/// eyeWarpRatio, reference value: 60
ZBEAUTY_API void Beauty_SetEyeWarpRatio(BeautyHandle handle, int eyeWarpRatio);
/// faceLiftRatio, reference value: 60
ZBEAUTY_API void Beauty_SetFaceLiftRatio(BeautyHandle handle, int faceLiftRatio);
/// colorLipsRatio, reference value: 60
ZBEAUTY_API void Beauty_SetLipsColorRatio(BeautyHandle handle, int lipsColorRatio);
/// lipsColor[3]
ZBEAUTY_API void Beauty_SetLipsColor(BeautyHandle handle, int lipsColor[3]);
/// highnoseRatio, reference value: 60
ZBEAUTY_API void Beauty_SetHighnoseRatio(BeautyHandle handle, int highnoseRatio);

//// filterId
//const int RT_FILTER_ID_BEAUTY = 0;
//const int RT_FILTER_BEAUTY_CLEAR = RT_FILTER_ID_BEAUTY + 1;
//const int RT_FILTER_BEAUTY_WHITESKINNED = RT_FILTER_ID_BEAUTY + 2;
//const int RT_FILTER_BEAUTY_COOL = RT_FILTER_ID_BEAUTY + 3;
//const int RT_FILTER_BEAUTY_ICESPIRIT = RT_FILTER_ID_BEAUTY + 4;
//const int RT_FILTER_BEAUTY_REFINED = RT_FILTER_ID_BEAUTY + 5;
//const int RT_FILTER_BEAUTY_BLUESTYLE = RT_FILTER_ID_BEAUTY + 6;
//const int RT_FILTER_BEAUTY_LOLITA = RT_FILTER_ID_BEAUTY + 7;
//const int RT_FILTER_BEAUTY_LKK = RT_FILTER_ID_BEAUTY + 8;
//const int RT_FILTER_BEAUTY_NUANHUANG = RT_FILTER_ID_BEAUTY + 9;
//const int RT_FILTER_BEAUTY_RCOOL = RT_FILTER_ID_BEAUTY + 10;
//const int RT_FILTER_BEAUTY_JSTYLE = RT_FILTER_ID_BEAUTY + 11;
//const int RT_FILTER_BEAUTY_SOFTLIGHT = RT_FILTER_ID_BEAUTY + 12;
//const int RT_FILTER_BEAUTY_TIANMEI = RT_FILTER_ID_BEAUTY + 13;
//const int RT_FILTER_BEAUTY_WEIMEI = RT_FILTER_ID_BEAUTY + 14;
//const int RT_FILTER_BEAUTY_FRESH = RT_FILTER_ID_BEAUTY + 15;
//const int RT_FILTER_BEAUTY_JPJELLY = RT_FILTER_ID_BEAUTY + 16;
//const int RT_FILTER_BEAUTY_HUAYAN = RT_FILTER_ID_BEAUTY + 17;
//const int RT_FILTER_BEAUTY_LUOZHUANG = RT_FILTER_ID_BEAUTY + 18;
//const int RT_FILTER_BEAUTY_NENHONG = RT_FILTER_ID_BEAUTY + 19;
//const int RT_FILTER_BEAUTY_BLACKWHITE = RT_FILTER_ID_BEAUTY + 20;
//const int RT_FILTER_BEAUTY_WHITENING = RT_FILTER_ID_BEAUTY + 21;
//const int RT_FILTER_BEAUTY_RUDDY = RT_FILTER_ID_BEAUTY + 22;
//const int RT_FILTER_BEAUTY_JPAESTHETICISM = RT_FILTER_ID_BEAUTY + 23;
//const int RT_FILTER_BEAUTY_PURPLEDREAM = RT_FILTER_ID_BEAUTY + 24;
//const int RT_FILTER_BEAUTY_JPELEGANT = RT_FILTER_ID_BEAUTY + 25;
//const int RT_FILTER_BEAUTY_JPFRESH = RT_FILTER_ID_BEAUTY + 26;
//const int RT_FILTER_BEAUTY_JPSWEET = RT_FILTER_ID_BEAUTY + 27;
//const int RT_FILTER_BEAUTY_JPWARM = RT_FILTER_ID_BEAUTY + 28;
//const int RT_FILTER_BEAUTY_SUNSHINE = RT_FILTER_ID_BEAUTY + 29;
//const int RT_FILTER_BEAUTY_SWEET = RT_FILTER_ID_BEAUTY + 30;
//const int RT_FILTER_BEAUTY_ABAOSE = RT_FILTER_ID_BEAUTY + 31;
//const int RT_FILTER_BEAUTY_LANGMAN = RT_FILTER_ID_BEAUTY + 32;
//const int RT_FILTER_BEAUTY_QINGTOU = RT_FILTER_ID_BEAUTY + 33;
//const int RT_FILTER_BEAUTY_ZHENBAI = RT_FILTER_ID_BEAUTY + 34;
//const int RT_FILTER_BEAUTY_ZIRAN = RT_FILTER_ID_BEAUTY + 35;
//const int RT_FILTER_BEAUTY_WARMER = RT_FILTER_ID_BEAUTY + 36;

#endif

