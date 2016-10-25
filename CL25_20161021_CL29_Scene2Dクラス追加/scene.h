//********************************************************************************************************************
// タイトル:		シーン処理
// プログラム名:	scene.h
//********************************************************************************************************************
#ifndef _SCENE_H_
#define _SCENE_H_

//********************************************************************************************************************
// インクルードファイル
//********************************************************************************************************************
#include "main.h"

//********************************************************************************************************************
// クラス
//********************************************************************************************************************
// シーンクラス
class CScene
{
public:
	CScene();								// コンストラクタ
	virtual ~CScene();						// デストラクタ
	virtual HRESULT Init(void) = 0;
	virtual void Uninit(void) = 0;
	virtual void Update(void) = 0;
	virtual void Draw(void) = 0;
private:
};

#endif
