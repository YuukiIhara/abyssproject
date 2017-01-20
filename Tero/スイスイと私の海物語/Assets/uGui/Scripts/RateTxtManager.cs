using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class RateTxtManager : MonoBehaviour {

	// トランスフォームの宣言
	new Transform  transform;
	// 回転角
	float rot = Mathf.PI/2.0f;
	// 時間のカウント
	int TimeCnt = 0; 
	// 終了のフラグ
	bool bEndFlag = false;

	const int	SCORE_DIGIT_MAX=4; 
	const float LERPTIME_MAX=1.0f;
	private int Score = 0;
	public int DestScore;

	//private GameObject[] ScoreObject=new GameObject[SCORE_DIGIT_MAX];
	//private SpriteRenderer[] ScoreRenderer=new SpriteRenderer[SCORE_DIGIT_MAX];
	public GameObject[] ScoreRenderer;
	public Sprite[] ScoreSprite=new Sprite[10];
	// Use this for initialization
	// イメージの宣言
	Image image;

	void Start ()
	{
		// トランスフォームの取得
		transform = GetComponent<Transform> ();
		// スコアの初期化
		for (int i = 0; i < SCORE_DIGIT_MAX; i++) 
		{
			image = ScoreRenderer [i].GetComponent<Image> ();
			image.sprite = ScoreSprite [0];
		}
		// スコアのアルファ値変更
		GameObject.Find ("RateNumber1").GetComponent<ScoreAlpha>().SetAlpha(false);
		GameObject.Find ("RateNumber2").GetComponent<ScoreAlpha>().SetAlpha(false);
		GameObject.Find ("RateNumber3").GetComponent<ScoreAlpha>().SetAlpha(false);
		GameObject.Find ("RateNumber4").GetComponent<ScoreAlpha>().SetAlpha(false);
		GameObject.Find ("RateNumber1").GetComponent<ScoreAlpha>().InitAlpha(0.0f);
		GameObject.Find ("RateNumber2").GetComponent<ScoreAlpha>().InitAlpha(0.0f);
		GameObject.Find ("RateNumber3").GetComponent<ScoreAlpha>().InitAlpha(0.0f);
		GameObject.Find ("RateNumber4").GetComponent<ScoreAlpha>().InitAlpha(0.0f);
	}

	// Update is called once per frame
	void Update () {
		int score=0;
		int num=1;
		if(DestScore!=Score)
		{
			Score = DestScore;

		}
		//float score_tex_pos;
		score=Score;
		for(int i=0;i<SCORE_DIGIT_MAX-1;i++)
		{
			num=num*10;
		}

		for(int i=0;i<SCORE_DIGIT_MAX;i++)
		{
			// スプライトの配列設定
			image = ScoreRenderer [i].GetComponent<Image>();

			if(Score >= num)
			{
				image.sprite = ScoreSprite[score/num];
			}
			else
			{
				if(i==SCORE_DIGIT_MAX-1)
				{
					image.sprite = ScoreSprite[0];
				}
				else
				{
					image.sprite =ScoreSprite[10];
				}
			}
			score=score%num;
			num=num/10;
		}

		// レートの表示処理
		if (GameObject.Find ("Energy").GetComponent<Energy> ().GetEndFlag ())
		{
			// 時間経過の測定
			TimeCnt++;

			if(TimeCnt <= 20)
			{
				// スコアの変更
				DestScore = GameObject.Find ("Energy").GetComponent<Energy> ().GetEnergyRate();

				// 回転角の加算処理
				rot += (Mathf.PI/2.0f)/20.0f;
				// 縦のサイズを加算
				Vector3 Addnum = new Vector2 (Mathf.Sin(rot)*0.29f,Mathf.Sin(rot)*0.29f);
				transform.localScale -= Addnum;
				// スコアのアルファ値変更
				GameObject.Find ("RateNumber1").GetComponent<ScoreAlpha>().SetAlpha(true);
				GameObject.Find ("RateNumber2").GetComponent<ScoreAlpha>().SetAlpha(true);
				GameObject.Find ("RateNumber3").GetComponent<ScoreAlpha>().SetAlpha(true);
				GameObject.Find ("RateNumber4").GetComponent<ScoreAlpha>().SetAlpha(true);
			}
			if(TimeCnt == 100)
			{
				bEndFlag = true;
			}
		}
	}

	// 終了フラグの受け渡し
	public bool GetEndFlag()
	{
		return bEndFlag;
	}
}


