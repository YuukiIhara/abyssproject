//********************************************************************************************************************
// タイトル:		爆発処理
// プログラム名:	explosion.h
//********************************************************************************************************************
#ifndef _EXPLOSION_H_
#define _EXPLOSION_H_

//********************************************************************************************************************
// インクルードファイル
//********************************************************************************************************************
#include "main.h"
#include "scene2D.h"

//********************************************************************************************************************
// クラス
//********************************************************************************************************************
// シーンクラス
class CExplosion : public CScene2D
{
public:
	CExplosion();							// コンストラクタ
	~CExplosion();							// デストラクタ
	static CExplosion* Create(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	HRESULT Init(int nType, D3DXVECTOR3 pos, D3DXVECTOR3 rot);
	void Uninit(void);
	void Update(void);
	void Draw(void);
	static HRESULT Load(void);
	static void Unload(void);
private:
	static LPDIRECT3DTEXTURE9 m_pTexture;

	int		m_nCntAnim;
	int		m_nPatAnim;
	int		m_nDivideX;
	int		m_nDivideY;
	int		m_nPatChangeFrame;
};

#endif