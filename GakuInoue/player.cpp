//********************************************************************************************************************
// タイトル:		プレイヤー処理
// プログラム名:	player.cpp
//********************************************************************************************************************
//********************************************************************************************************************
// インクルードファイル
//********************************************************************************************************************
#include "main.h"
#include "manager.h"
#include "renderer.h"
#include "input.h"
#include "scene.h"
#include "player.h"
#include "bullet.h"

//********************************************************************************************************************
// マクロ定義
//********************************************************************************************************************

//********************************************************************************************************************
// 構造体定義
//********************************************************************************************************************

//********************************************************************************************************************
// インライン関数
//********************************************************************************************************************

//********************************************************************************************************************
// 静的メンバ変数の宣言
//********************************************************************************************************************
LPDIRECT3DTEXTURE9 CPlayer::m_pTexture = NULL;

//**********************************************************************************************************************************************
// 
// CPlayerクラスの実体
//
//**********************************************************************************************************************************************
//********************************************************************************************************************
// funcinfo：コンストラクタ
//********************************************************************************************************************
CPlayer::CPlayer()
{
	
}
//********************************************************************************************************************
// funcinfo：デストラクタ
//********************************************************************************************************************
CPlayer::~CPlayer()
{

}
//********************************************************************************************************************
// funcinfo：初期化処理
//********************************************************************************************************************
HRESULT CPlayer::Init(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot)
{
	CScene2D::Init( nType, pos, rot );

	SetObjType(CScene::OBJTYPE_PLAYER);

	return S_OK;
}
//********************************************************************************************************************
// funcinfo：終了処理
//********************************************************************************************************************
void CPlayer::Uninit(void)
{
	CScene2D::Uninit();
}
//********************************************************************************************************************
// funcinfo：更新処理
//********************************************************************************************************************
void CPlayer::Update(void)
{
	D3DXVECTOR3 pos = CScene2D::GetPos();
	
	if( CManager::GetInputKeyboard() -> GetKeyPress( DIK_RIGHT ) )
	{
		pos += D3DXVECTOR3( 10.0f, 0.0f, 0.0f );
	}
	if( CManager::GetInputKeyboard() -> GetKeyPress( DIK_LEFT ) )
	{
		pos += D3DXVECTOR3( -10.0f, 0.0f, 0.0f );
	}
	if( CManager::GetInputKeyboard() -> GetKeyPress( DIK_UP ) )
	{
		pos += D3DXVECTOR3( 0.0f, -10.0f, 0.0f );
	}
	if( CManager::GetInputKeyboard() -> GetKeyPress( DIK_DOWN ) )
	{
		pos += D3DXVECTOR3( 0.0f, 10.0f, 0.0f );
	}

	CScene2D::SetPos(pos);

	if( CManager::GetInputKeyboard() -> GetKeyTrigger( DIK_SPACE ) )
	{
		CBullet::Create(0, pos, D3DXVECTOR3( 0.0f, 0.0f, 0.0f ));
	}
}
//********************************************************************************************************************
// funcinfo：描画処理
//********************************************************************************************************************
void CPlayer::Draw(void)
{
	CScene2D::Draw();
}
//********************************************************************************************************************
// funcinfo：CPlayerオブジェクトを作成
//********************************************************************************************************************
CPlayer* CPlayer::Create(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot)
{
	CPlayer *pPlayer;
	pPlayer = new CPlayer;
	pPlayer -> Init( nType, pos, rot );

	// テクスチャの割り当て
	pPlayer -> BindTexture(m_pTexture);

	return pPlayer;
}
//********************************************************************************************************************
// funcinfo：テクスチャをロード
//********************************************************************************************************************
HRESULT CPlayer::Load(void)
{
	// デバイスの取得
	LPDIRECT3DDEVICE9 pDevice;
	pDevice = CManager::GetRenderer() -> GetDevice();

	if(m_pTexture == NULL)
	{
		// テクスチャの生成
		D3DXCreateTextureFromFile(pDevice, "data/TEXTURE/player000.png ", &m_pTexture);
	}

	return S_OK;
}
//********************************************************************************************************************
// funcinfo：テクスチャの破棄
//********************************************************************************************************************
void CPlayer::Unload(void)
{
	// テクスチャの破棄
	if(m_pTexture != NULL)
	{	//バッファーの解放
		m_pTexture -> Release();
		m_pTexture = NULL;
	}
}