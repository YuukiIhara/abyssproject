//********************************************************************************************************************
// タイトル:		シーン処理
// プログラム名:	scene2D.h
//********************************************************************************************************************
#ifndef _SCENE2D_H_
#define _SCENE2D_H_

//********************************************************************************************************************
// インクルードファイル
//********************************************************************************************************************
#include "main.h"
#include "scene.h"

//********************************************************************************************************************
// クラス
//********************************************************************************************************************
// シーンクラス
class CScene2D : public CScene
{
public:
	CScene2D();								// コンストラクタ
	~CScene2D();							// デストラクタ
	static CScene2D* Create(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	HRESULT Init(void);
	HRESULT Init(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	void Uninit(void);
	void Update(void);
	void Draw(void);
	void BindTexture(LPDIRECT3DTEXTURE9 pTexture);

	void			SetVtxBuff(void);
	D3DXVECTOR3		GetPos(void);
	void			SetPos(D3DXVECTOR3 pos);
	void			SetUV(D3DXVECTOR2* pUV);

private:
	LPDIRECT3DTEXTURE9		m_pTexture;		// テクスチャへのポインタ
	LPDIRECT3DVERTEXBUFFER9 m_pVtxBuff;		// 頂点バッファへのポインタ
	bool					m_bLoadTexture;	// テクスチャが読み込まれたかどうか
	D3DXVECTOR3				m_pos;			// ポリゴンの位置
	D3DXVECTOR2				m_uv[4];		// ４頂点のUV座標
};

#endif
