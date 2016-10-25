//=============================================================================
//
// ���C������ [main.cpp]
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
// �}�N����`
//*****************************************************************************
#define CLASS_NAME		"AppClass"			// �E�C���h�E�̃N���X��
#define WINDOW_NAME		"�|���S���̕`��"	// �E�C���h�E�̃L���v�V������

//*****************************************************************************
// �v���g�^�C�v�錾
//*****************************************************************************
LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

//*****************************************************************************
// �O���[�o���ϐ�:
//*****************************************************************************
int				g_nCountFPS;			// FPS�J�E���^
CRenderer*		g_pRenderer = NULL;		// �����_���[�ւ̃|�C���^
CScene*			g_pScene = NULL;
CCamera*		g_pCamera = NULL;
CLight*			g_pLight = NULL;

//=============================================================================
// ���C���֐�
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
	
	// �E�B���h�E�N���X�̓o�^
	RegisterClassEx(&wcex);

	// �w�肵���N���C�A���g�̈���m�ۂ��邽�߂ɕK�v�ȃE�B���h�E���W���v�Z
	AdjustWindowRect(&rect, WS_OVERLAPPEDWINDOW, false);

	// �E�B���h�E�̍쐬
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

	// �����_���[�̐���
	g_pRenderer = new CRenderer;
	if(FAILED(g_pRenderer -> Init(hWnd, true)))
	{
		return -1;
	}
	// �I�u�W�F�N�g�̐���
	g_pScene = new CScene3D;
	if(g_pScene != NULL)
	{
		g_pScene -> Init();
	}
	// �J�����̐���
	g_pCamera = new CCamera;
	if(g_pCamera != NULL)
	{
		g_pCamera -> Init();
	}
	// ���C�g�̐���
	g_pLight = new CLight;
	if(g_pLight != NULL)
	{
		g_pLight -> Init();
	}

	// ����\��ݒ�
	timeBeginPeriod(1);

	// �t���[���J�E���g������
	dwCurrentTime =
	dwFrameCount = 0;
	dwExecLastTime = 
	dwFPSLastTime = timeGetTime();

	// �E�C���h�E�̕\��
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);
	
	// ���b�Z�[�W���[�v
	while(1)
	{
        if(PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if(msg.message == WM_QUIT)
			{// PostQuitMessage()���Ă΂ꂽ�烋�[�v�I��
				break;
			}
			else
			{
				// ���b�Z�[�W�̖|��ƃf�B�X�p�b�`
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
        }
		else
		{
			dwCurrentTime = timeGetTime();
			if((dwCurrentTime - dwFPSLastTime) >= 500)	// 0.5�b���ƂɎ��s
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

				// �X�V����
				g_pRenderer -> Update();

				// �`�揈��
				g_pRenderer -> Draw();

				dwFrameCount++;
			}
		}
	}

	// �I�u�W�F�N�g�̔j��
	if(g_pScene != NULL)
	{
		g_pScene -> Uninit();
		delete g_pScene;
		g_pScene = NULL;
	}
	// �J�����̔j��
	if(g_pCamera != NULL)
	{
		g_pCamera -> Uninit();
		delete g_pCamera;
		g_pCamera = NULL;
	}
	// ���C�g�̔j��
	if(g_pLight != NULL)
	{
		g_pLight -> Uninit();
		delete g_pLight;
		g_pLight = NULL;
	}
	// �����_���[�̔j��
	if( g_pRenderer != NULL )
	{
		g_pRenderer -> Uninit();
		delete g_pRenderer;
		g_pRenderer = NULL;
	}

	// �E�B���h�E�N���X�̓o�^������
	UnregisterClass(CLASS_NAME, wcex.hInstance);

	// ����\��߂�
	timeEndPeriod(1);

	return (int)msg.wParam;
}

//=============================================================================
// �v���V�[�W��
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
		case VK_ESCAPE:					// [ESC]�L�[�������ꂽ
			DestroyWindow(hWnd);		// �E�B���h�E��j������悤�w������
			break;
		}
		break;

	default:
		break;
	}

	return DefWindowProc(hWnd, uMsg, wParam, lParam);
}

//=============================================================================
// FPS�J�E���g���擾
//=============================================================================
int GetFPS(void)
{
	return g_nCountFPS;
}
//=============================================================================
// �����_���[�̎擾
//=============================================================================
CRenderer *GetRenderer(void)
{
	return g_pRenderer;
}
//=============================================================================
// �J�����̎擾
//=============================================================================
CCamera *GetCamera(void)
{
	return g_pCamera;
}
//=============================================================================
// ���C�g�̎擾
//=============================================================================
CLight *GetLight(void)
{
	return g_pLight;
}
//=============================================================================
// �V�[���̎擾
//=============================================================================
CScene *GetScene(void)
{
	return g_pScene;
}

