using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScoreManager : MonoBehaviour {

	const int	SCORE_DIGIT_MAX=4; 
	const float LERPTIME_MAX=1.0f;
	const float ADD_LERPTIME=0.1f;
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

	void Start ()
	{
		// スコアの初期化
		for (int i = 0; i < SCORE_DIGIT_MAX; i++) 
		{
			image = ScoreRenderer [i].GetComponent<Image> ();
			image.sprite = ScoreSprite [0];
		}
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
			LerpTime+=ADD_LERPTIME;
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
}


