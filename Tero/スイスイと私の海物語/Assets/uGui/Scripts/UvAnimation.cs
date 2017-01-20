using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UvAnimation : MonoBehaviour {

	// イメージの宣言
	RawImage rawImage;
	// エネルギーオブジェクトの取得
	public GameObject energy;
	// レクトトランスフォームの宣言
	new Transform  transform;

	public float TEX_PATTERN_DIVIDE_X;						// アニメーションパターンのテクスチャ内での分割数(Ｘ方向)
	public float TEX_PATTERN_DIVIDE_Y;						// アニメーションパターンのテクスチャ内での分割数(Ｙ方向)
	float TEX_PATTERN_SIZE_X;     							// １パターンのテクスチャサイズ(Ｘ方向)(1.0f/X方向分割数)
	float TEX_PATTERN_SIZE_Y;								// １パターンのテクスチャサイズ(Ｙ方向)(1.0f/Y方向分割数)
	float NUM_ANIM_PATTERN;									// アニメーションのパターン数(X方向分割数×Y方向分割数)
	public float TIME_CHANGE_PATTERN;						// アニメーションの切り替わるタイミング(フレーム数)

	// 変数宣言
	int nAnimeCount = 0;									// 時間のカウント
	int nAnimePattern = 0;								// 現在のアニメーションパターン

	void Start()
	{
		// レクトトランスフォームの取得
		transform = GetComponent<Transform> ();

		// ロウイメージの初期化
		rawImage = GetComponent<RawImage> ();
		TEX_PATTERN_SIZE_X = (1.0f/TEX_PATTERN_DIVIDE_X);
		TEX_PATTERN_SIZE_Y = (1.0f/TEX_PATTERN_DIVIDE_Y);
		NUM_ANIM_PATTERN = (TEX_PATTERN_DIVIDE_X * TEX_PATTERN_DIVIDE_Y);
	}

	void Update() 
	{
		// ポジションの設定
		Vector3 Addnum = new Vector2 (energy.GetComponent<RectTransform>().position.x + (energy.GetComponent<RectTransform>().sizeDelta.x/2.1f)-5.0f,energy.GetComponent<RectTransform>().position.y);
		transform.position = Addnum;

		// アニメーションカウントをインクリメント
		nAnimeCount++;

		// パターンを進める
		if ((nAnimeCount % TIME_CHANGE_PATTERN) == 0)
		{
			nAnimePattern = (int)((float)(nAnimePattern + 1) % NUM_ANIM_PATTERN);
			if (nAnimePattern == NUM_ANIM_PATTERN)nAnimePattern = 0;

			// 宣言
			float fPosXLeft, fPosXRight;
			float fPosYUp, fPosYDown;

			// テクスチャ座標の設定ーここは計算が入る
			fPosXLeft	= (nAnimePattern%TEX_PATTERN_DIVIDE_X) * TEX_PATTERN_SIZE_X;
			fPosXRight	= fPosXLeft + TEX_PATTERN_SIZE_X;
			fPosYUp		= (TEX_PATTERN_SIZE_Y*(TEX_PATTERN_DIVIDE_Y-1.0f))-((int)(nAnimePattern/TEX_PATTERN_DIVIDE_X) * TEX_PATTERN_SIZE_Y);
			fPosYDown	= fPosYUp+TEX_PATTERN_SIZE_Y;

			// UV設定
			rawImage.uvRect = new Rect(fPosXLeft,fPosYUp,TEX_PATTERN_SIZE_X,TEX_PATTERN_SIZE_Y);

		}
	}
}
