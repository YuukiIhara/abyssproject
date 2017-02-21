using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class Energy : MonoBehaviour {

	// エネルギーの合計
	public int nMaxCoral;
	public int nEnergy;
	int nMaxEnergy;
	float Score = 0.0f;
	// ヨコサイズ辺りの伸び幅
	float fWidSize = 0.0f;

	// 加算する割合
	float ADD_LERPTIME=0.0007f;
	// 割合
	float LerpTime=0.0000f;
	// 1回だけ入るフラグ
	bool bFlag = true;

	// 終了フラぐ
	bool bEndFlag = false;
	// エネルギーの割合
	int nEnergyRate = 0;

	// レクトトランスフォームの宣言
	RectTransform  rectTransform;

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		rectTransform= GetComponent<RectTransform> ();
		nMaxEnergy = nMaxCoral * nEnergy;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ResultEnergy(int value) 
	{
		// 割合を増やす
		LerpTime += ADD_LERPTIME;
		// 1回だけ入る処理
		if (bFlag)
		{
			// 横サイズ辺りの伸び幅を計算
			fWidSize = 1365.0f / nMaxEnergy;
			Score = value;
			bFlag = false;
		}
		if (LerpTime <= 1.000000f) {
			float Addnum = (fWidSize * (Score * LerpTime));
			rectTransform.sizeDelta += new Vector2 (Addnum, 0.0f);
			Score -= Score * LerpTime;
			//表示するエネルギーの割合 += fWidSize*(value * LerpTime)；
		} 
		if(LerpTime > 0.1f)
		{
			if(bEndFlag == false)
			{
				// 終了のフラグを立てる
				bEndFlag = true;
				// 割合の取得
				nEnergyRate = (int)(((float)value/(float)nMaxEnergy)*100.0f);
			}
		}

	}

	// 終了フラグの受け渡し
	public bool GetEndFlag()
	{
		return bEndFlag;
	}
	// エネルギーの割合の受け渡し
	public int GetEnergyRate()
	{
		return nEnergyRate;
	}
}
