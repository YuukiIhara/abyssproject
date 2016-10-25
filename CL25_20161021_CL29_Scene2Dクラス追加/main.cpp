//=============================================================================
//
// メイン処理 [main.cpp]
// Author : Yuuki Ihara
//
//=============================================================================
#include "main.h"
#include "renderer.h"
#include "scene.h"
#include "scene2D.h"
#include "scene3D.h"
#include "camera.h"
#include "light.h"

//*****************************************************************************
// マクロ定義
//*****************************************************************************
#define CLASS_NAME		"AppClass"			// ウインドウのクラス名
#define WINDOW_NAME		"ポリゴンの描画"	// ウインドウのキャプション名

//*****************************************************************************
// プロトタイプ宣言
//*****************************************************************************
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

//*****************************************************************************
// グローバル変数:
//*****************************************************************************
int				g_nCountFPS;			// FPSカウンタ
CRenderer*		g_pRenderer = NULL;		// レンダラーへのポインタ
CScene*			g_pScene = NULL;
CCamera*		g_pCamera = NULL;
CLight*			g_pLight = NULL;

//=============================================================================
// メイン関数
//=============================================================================
int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	WNDCLASSEX wcex =
	{
		sizeof(WNDCLASSEX),
		CS_CLASSDC,
		WndProc,
		0,
		0,
		hInstance,
		NULL,
		LoadCursor(NULL, IDC_ARROW),
		(HBRUSH)(COLOR_WINDOW + 1),
		NULL,
		CLASS_NAME,
		NULL
	};
	RECT rect = {0, 0, SCREEN_WIDTH, SCREEN_HEIGHT};
	HWND hWnd;
	MSG msg;
	DWORD dwCurrentTime;
	DWORD dwFrameCount;
	DWORD dwExecLastTime;
	DWORD dwFPSLastTime;
	
	// ウィンドウクラスの登録
	RegisterClassEx(&wcex);

	// 指定したクライアント領域を確保するために必要なウィンドウ座標を計算
	AdjustWindowRect(&rect, WS_OVERLAPPEDWINDOW, false);

	// ウィンドウの作成
	hWnd = CreateWindow(CLASS_NAME,
						WINDOW_NAME,
						WS_OVERLAPPEDWINDOW,
						CW_USEDEFAULT,
						CW_USEDEFAULT,
						(rect.right - rect.left),
						(rect.bottom - rect.top),
						NULL,
						NULL,
						hInstance,
						NULL);

	// レンダラーの生成
	g_pRenderer = new CRenderer;
	if(FAILED(g_pRenderer -> Init(hWnd, true)))
	{
		return -1;
	}
	// オブジェクトの生成
	g_pScene = new CScene3D;
	if(g_pScene != NULL)
	{
		g_pScene -> Init();
	}
	// カメラの生成
	g_pCamera = new CCamera;
	if(g_pCamera != NULL)
	{
		g_pCamera -> Init();
	}
	// ライトの生成
	g_pLight = new CLight;
	if(g_pLight != NULL)
	{
		g_pLight -> Init();
	}

	// 分解能を設定
	timeBeginPeriod(1);

	// フレームカウント初期化
	dwCurrentTime =
	dwFrameCount = 0;
	dwExecLastTime = 
	dwFPSLastTime = timeGetTime();

	// ウインドウの表示
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	
	// メッセージループ
	while(1)
	{
        if(PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if(msg.message == WM_QUIT)
			{// PostQuitMessage()が呼ばれたらループ終了
				break;
			}
			else
			{
				// メッセージの翻訳とディスパッチ
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
        }
		else
		{
			dwCurrentTime = timeGetTime();
			if((dwCurrentTime - dwFPSLastTime) >= 500)	// 0.5秒ごとに実行
			{
#ifdef _DEBUG
				g_nCountFPS = dwFrameCount * 1000 / (dwCurrentTime - dwFPSLastTime);
#endif
				dwFPSLastTime = dwCurrentTime;
				dwFrameCount = 0;
			}

			if((dwCurrentTime - dwExecLastTime) >= (1000 / 60))
			{
				dwExecLastTime = dwCurrentTime;

				// 更新処理
				g_pRenderer -> Update();

				// 描画処理
				g_pRenderer -> Draw();

				dwFrameCount++;
			}
		}
	}

	// オブジェクトの破棄
	if(g_pScene != NULL)
	{
		g_pScene -> Uninit();
		delete g_pScene;
		g_pScene = NULL;
	}
	// カメラの破棄
	if(g_pCamera != NULL)
	{
		g_pCamera -> Uninit();
		delete g_pCamera;
		g_pCamera = NULL;
	}
	// ライトの破棄
	if(g_pLight != NULL)
	{
		g_pLight -> Uninit();
		delete g_pLight;
		g_pLight = NULL;
	}
	// レンダラーの破棄
	if( g_pRenderer != NULL )
	{
		g_pRenderer -> Uninit();
		delete g_pRenderer;
		g_pRenderer = NULL;
	}

	// ウィンドウクラスの登録を解除
	UnregisterClass(CLASS_NAME, wcex.hInstance);

	// 分解能を戻す
	timeEndPeriod(1);

	return (int)msg.wParam;
}

//=============================================================================
// プロシージャ
//=============================================================================
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch(uMsg)
	{
	case WM_CREATE:
		break;

	case WM_DESTROY:
		PostQuitMessage(0);
		break;

	case WM_KEYDOWN:
		switch(wParam)
		{
		case VK_ESCAPE:					// [ESC]キーが押された
			DestroyWindow(hWnd);		// ウィンドウを破棄するよう指示する
			break;
		}
		break;

	default:
		break;
	}

	return DefWindowProc(hWnd, uMsg, wParam, lParam);
}

//=============================================================================
// FPSカウントを取得
//=============================================================================
int GetFPS(void)
{
	return g_nCountFPS;
}
//=============================================================================
// レンダラーの取得
//=============================================================================
CRenderer *GetRenderer(void)
{
	return g_pRenderer;
}
//=============================================================================
// カメラの取得
//=============================================================================
CCamera *GetCamera(void)
{
	return g_pCamera;
}
//=============================================================================
// ライトの取得
//=============================================================================
CLight *GetLight(void)
{
	return g_pLight;
}
//=============================================================================
// シーンの取得
//=============================================================================
CScene *GetScene(void)
{
	return g_pScene;
}

