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
	HRESULT Init(void);
	void Uninit(void);
	void Update(void);
	void Draw(void);
private:
	LPDIRECT3DTEXTURE9		m_pTexture;		// テクスチャへのポインタ
	LPDIRECT3DVERTEXBUFFER9 m_pVtxBuff;		// 頂点バッファへのポインタ
	D3DXVECTOR3				m_pos;			// ポリゴンの位置
};

#endif
