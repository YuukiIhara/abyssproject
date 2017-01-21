using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//サウンドオブジェクトを取得
	public GameObject[] Sound; 

	// 音のフェードフラグ
	int[] nVolumeFlag;
	// 再生中かの判定
	bool[] bSoundFlag;

	//CoOrds g_Sound new CoOrds{Sound[0],0,0.0f};

	// Use this for initialization
	void Start () 
	{
		// 初期化
		nVolumeFlag = new int[Sound.Length];
		bSoundFlag = new bool[Sound.Length];
		//初期化処理
		for(int nCnt = 0;nCnt < Sound.Length;nCnt++)
		{
			// ボリュームのフラグを初期化
			nVolumeFlag[nCnt] = 0;
			// 再生中かの判定を初期化
			bSoundFlag[nCnt] = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// サウンド処理
		for(int nCnt = 0;nCnt < Sound.Length;nCnt++)
		{
			// ボリュームの変更
			if(nVolumeFlag[nCnt] != 0)
			{
				switch (nVolumeFlag[nCnt])
				{
					// フェードイン再生
				case 1:
					Sound [nCnt].GetComponent<AudioSource> ().volume -= 0.005f;
					// 終了処理
					if(Sound [nCnt].GetComponent<AudioSource> ().volume <= 0.0f)
					{
						Sound [nCnt].GetComponent<AudioSource> ().Stop ();
						nVolumeFlag[nCnt] = 0;
						Sound [nCnt].GetComponent<AudioSource> ().volume = 1.0f;
						bSoundFlag [nCnt] = false;
					}
					break;
				
					// フェードアウト再生
				case 2:
					Sound [nCnt].GetComponent<AudioSource> ().volume += 0.005f;
					// 終了処理
					if (Sound [nCnt].GetComponent<AudioSource> ().volume >= 1.0f)
					{
						nVolumeFlag[nCnt] = 0;
						Sound [nCnt].GetComponent<AudioSource> ().volume = 1.0f;
					}
					break;
				}
			}
		}
	}

	// nNumber		再生するサウンド番号
	// bFlag		trueなら再生：falseなら停止
	// nVolumeFlag	0なら音量1で通常の再生
	//				1なら音量1でフェードイン再生
	//				2なら音量0でフェードアウト再生
	public void SetSound(int nNumber,bool bFlag,int nvolumeFlag)
	{
		// サウンドの再生または停止
		if (bFlag && Sound [nNumber].GetComponent<AudioSource> ().isPlaying == false) 
		{
			Sound [nNumber].GetComponent<AudioSource> ().Play ();
		}
		else if(bFlag == false && Sound [nNumber].GetComponent<AudioSource> ().isPlaying == true)
		{
			Sound [nNumber].GetComponent<AudioSource> ().Stop ();
		}

		// 音量の設定
		switch (nvolumeFlag)
		{
		// 通常再生
		case 0:
			Sound [nNumber].GetComponent<AudioSource> ().volume = 1.0f;
			nVolumeFlag [nNumber] = 0;
			bSoundFlag [nNumber] = true;
			break;

		// フェードイン再生
		case 1:
			Sound [nNumber].GetComponent<AudioSource> ().volume = 1.0f;
			nVolumeFlag[nNumber] = 1;
			bSoundFlag [nNumber] = true;
			break;

		// フェードアウト再生
		case 2:
			Sound [nNumber].GetComponent<AudioSource> ().volume = 0.0f;
			nVolumeFlag[nNumber] = 2;
			bSoundFlag [nNumber] = true;
			break;
		}
	}
}
