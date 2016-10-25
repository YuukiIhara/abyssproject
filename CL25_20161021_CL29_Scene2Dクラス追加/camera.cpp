//********************************************************************************************************************
// タイトル:		カメラ処理
// プログラム名:	camera.cpp
//********************************************************************************************************************
//********************************************************************************************************************
// インクルードファイル
//********************************************************************************************************************
#include "camera.h"
#include "renderer.h"

//********************************************************************************************************************
// マクロ定義
//********************************************************************************************************************
#define	VIEW_ANGLE				(D3DXToRadian(45.0f))							// ビュー平面の視野角
#define	VIEW_ASPECT				((float)SCREEN_WIDTH / (float)SCREEN_HEIGHT)	// ビュー平面のアスペクト比
#define	VIEW_NEAR_Z				(10.0f)											// ビュー平面のNearZ値
#define	VIEW_FAR_Z				(10000.0f)										// ビュー平面のFarZ値

//********************************************************************************************************************
// インライン関数
//********************************************************************************************************************

//********************************************************************************************************************
// 静的メンバ変数の宣言
//********************************************************************************************************************

//**********************************************************************************************************************************************
// 
// CCameraクラスの実体
//
//**********************************************************************************************************************************************
//********************************************************************************************************************
// funcinfo：コンストラクタ
//********************************************************************************************************************
CCamera::CCamera()
{
	D3DXMatrixIdentity(&m_mtxView);
	D3DXMatrixIdentity(&m_mtxProjection);

	m_posV = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
	m_posR = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
	m_vecU = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );
	m_posVDest = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
	m_posRDest = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
	m_rot = D3DXVECTOR3(0.0f, 0.0f, 0.0f);
	
	m_fDistance = 0.0f;
	m_fInitialDistance = 0.0f;
	m_fInitialSin = 0.0f;
	m_fInitialCos = 0.0f;
}
//********************************************************************************************************************
// funcinfo：デストラクタ
//********************************************************************************************************************
CCamera::~CCamera()
{

}
//********************************************************************************************************************
// funcinfo：初期化処理
//********************************************************************************************************************
HRESULT CCamera::Init(void)
{
	// 視点初期化
	m_posV = D3DXVECTOR3( 0.0f, 500.0f, -500.0f );
	// 注視点初期化
	m_posR = D3DXVECTOR3( 0.0f, 0.0f, 0.0f );
	// 上方向ベクトル初期化
	m_vecU = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );
	// 視点の目的位置
	m_posVDest = m_posV;
	// 注視点の目的位置
	m_posRDest = m_posR;
	// カメラ向き（回転角）の初期化
	m_rot = D3DXVECTOR3(0.0f, 0.0f, 0.0f);
	
	// 視点と注視点の距離を求める
	m_fDistance = sqrt(powf(m_posR.x - m_posV.x, 2.0f) +  powf(m_posR.y - m_posV.y, 2.0f) + powf(m_posR.z - m_posV.z, 2.0f));
	// 始めの視点と注視点の距離
	m_fInitialDistance = m_fDistance;
	// 始めの視点と注視点が作る直角三角形の角度の初期化
	m_fInitialSin = fabs((m_posR.y - m_posV.y) / m_fInitialDistance);
	m_fInitialCos = fabs((m_posR.z - m_posV.z) / m_fInitialDistance);

	return S_OK;
}
//********************************************************************************************************************
// funcinfo：終了処理
//********************************************************************************************************************
void CCamera::Uninit(void)
{
	
}
//********************************************************************************************************************
// funcinfo：更新処理
//********************************************************************************************************************
void CCamera::Update(void)
{

}
//********************************************************************************************************************
// funcinfo：セット処理
//********************************************************************************************************************
void CCamera::Set(void)
{
	LPDIRECT3DDEVICE9 pDevice = GetRenderer() -> GetDevice();
	D3DXMATRIX mtxScl, mtxRot, mtxTranslate;

	// ビューマトリックスの初期化
	D3DXMatrixIdentity(&m_mtxView);
	// ビューマトリックスの作成
	D3DXMatrixLookAtLH(&m_mtxView, &m_posV, &m_posR, &m_vecU);
	// ビューマトリックスの設定
	pDevice -> SetTransform(D3DTS_VIEW, &m_mtxView);
	// プロジェクションマトリックスの初期化
	D3DXMatrixIdentity(&m_mtxProjection);
	// プロジェクションマトリックスの作成
	D3DXMatrixPerspectiveFovLH(&m_mtxProjection, VIEW_ANGLE, VIEW_ASPECT, VIEW_NEAR_Z, VIEW_FAR_Z);
	// プロジェクションマトリックスの設定(透視変換の設定)
	pDevice -> SetTransform(D3DTS_PROJECTION, &m_mtxProjection);
}

