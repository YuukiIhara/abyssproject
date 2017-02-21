using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScoreManager : MonoBehaviour {

	const int	SCORE_DIGIT_MAX=4; 
	const float LERPTIME_MAX=1.0f;
	float AddLEerptime=0.02f;
	private int Score = 0;
	public int DestScore;
	private int FromScore=0;
	private float LerpTime=0.0000f;

	//private GameObject[] ScoreObject=new GameObject[SCORE_DIGIT_MAX];
	//private SpriteRenderer[] ScoreRenderer=new SpriteRenderer[SCORE_DIGIT_MAX];
	public GameObject[] ScoreRenderer;
	public Sprite[] ScoreSprite=new Sprite[10];
	// Use this for initialization
	// イメージの宣言
	Image image;
	// 1回だけ入るフラグ
	bool bFlag = true;
	// 取得したエネルギーの合計
	int nMaxEnergy;

	// Energyの変数宣言
	public GameObject Energy;

	void Start ()
	{
		// スコアの初期化
		for (int i = 0; i < SCORE_DIGIT_MAX; i++) 
		{
			image = ScoreRenderer [i].GetComponent<Image> ();
			image.sprite = ScoreSprite [0];
		}
		// Energyの初期化
		//Energy = GameObject.Find ("Energy");
	}
	
	// Update is called once per frame
	void Update () {

		int score=0;
		int num=1;
		if(DestScore!=Score)
		{
			float fScore=Score;
			float fFromScore=FromScore;
			float fDestScore=DestScore;
			fScore = Mathf.Lerp((float)fFromScore,(float)fDestScore,LerpTime);
			LerpTime+=AddLEerptime;
			Score=(int)fScore;

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

	}
	public void AddScore(int score)
	{
		DestScore +=score;
		FromScore=Score;
		LerpTime=0.0f;

	}

	public int GetScore()
	{
		return Score;
	}

	// リザルト処理
	public void ResultScore()
	{
		// 1回だけ入る処理
		if (bFlag)
		{
			// 1回だけ入る処理
			AddLEerptime = 0.009f;
			nMaxEnergy = DestScore;
			bFlag = false;

			// スコアの減算
			FromScore=DestScore;
			DestScore -= DestScore;
			LerpTime=0.0f;
		}
		// スコアの減算
		//DestScore -= (int)((float)DestScore * LerpTime);
		//FromScore = (int)((float)DestScore * LerpTime);

		// エネルギーの加算
		Energy.GetComponent<Energy> ().ResultEnergy(nMaxEnergy);

	}
}


