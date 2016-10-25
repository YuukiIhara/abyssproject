//=============================================================================
//
// メイン処理 [main.h]
// Author : Yuuki Iara
//
//=============================================================================
#ifndef _MAIN_H_
#define _MAIN_H_

//*****************************************************************************
// ヘッダファイル
//*****************************************************************************
#include "windows.h"
#include "d3dx9.h"

//*****************************************************************************
// ライブラリファイル
// [構成プロパティ]->[リンカー]->[入力]->[追加の依存ファイル]に記述しても可能
//*****************************************************************************
#pragma comment (lib, "d3d9.lib")
#pragma comment (lib, "d3dx9.lib")
#pragma comment (lib, "dxguid.lib")
#pragma comment (lib, "winmm.lib")

//********************************************************************************************************************
// 前方宣言
//********************************************************************************************************************
class CRenderer;
class CScene;
class CCamera;
class CLight;

//*****************************************************************************
// マクロ定義
//*****************************************************************************
#define SCREEN_WIDTH	(1280)		// ウインドウの幅
#define SCREEN_HEIGHT	(720)		// ウインドウの高さ

//*****************************************************************************
// 構造体定義
//*****************************************************************************

//*****************************************************************************
// プロトタイプ宣言
//*****************************************************************************
int GetFPS(void);
CRenderer *GetRenderer(void);
CCamera *GetCamera(void);
CLight *GetLight(void);
CScene *GetScene(void);

#endif