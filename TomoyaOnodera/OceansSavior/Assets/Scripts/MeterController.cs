using UnityEngine;
using System.Collections;

public class MeterController : MonoBehaviour {

	// 子オブジェクト取得
	public GameObject[] Meter;
	// メーター進速度
	public int nSpeed;
	//　子オブジェクトのポジション保存変数
	Vector3[] posSave;
	// 対象物に当たっているのか判定
	bool bHit = false; 
	// オブジェクトが壊れたかの判定
	bool bBreak = false;
	// 時間のカウント
	int nTimeCount = 0;

	void Start () 
	{
		// 保存変数構造体の初期化
		posSave = new Vector3[Meter.Length];

		// メーターのポジションを保存する処理
		for(int i = 0;i < Meter.Length;i++)
		{
			posSave[i] = Meter[i].transform.position;
		}
	}


	void Update () 
	{
		// デバック用当たり判定
		if (Input.GetKey (KeyCode.Return)) {
			bHit = true;
		} else {
			bHit = false;
		}

		// 当たり処理
		if (bHit == true && GameObject.Find ("Scope").GetComponent<ScopeColor> ().GetMoveFlag() == false)
		{
			// スコープの色変更
			if (nTimeCount == 0)
			{
				GameObject.Find ("Scope").GetComponent<ScopeColor> ().SetColor ();
			}
			// メーターを進める
			if (nTimeCount % nSpeed == 0 && nTimeCount / nSpeed < Meter.Length-1)
			{
				Meter [nTimeCount / nSpeed].GetComponent<MeterColor> ().SetColor ();
			} 
			else if(nTimeCount / nSpeed == Meter.Length) 
			{
				// オブジェクトが壊れた判定を設定
				bBreak = true;
				GameObject.Find ("Scope").GetComponent<ScopeColor> ().SetMoveFlag ();
				// スコープとメーターがはじけ飛ぶ処理
				for(int i = 0;i < Meter.Length-1;i++)
				{
					Meter[i].GetComponent<MeterColor> ().SetMoveFlag(i);
				}
			}
			// カウントを進める
			nTimeCount++;
		} else 
		{
			nTimeCount = 0;
		}
	}

	// あたり判定の受け渡し
	public bool GetHit()
	{
		return bHit;
	}
	// 当たり安定の設定とオブジェクトが壊れたかの判定を受け渡す
	public bool SetHit()
	{
		bHit = false;
		return bBreak;
	}

	// 初期化処理
	public Vector3 SetMeterPosition(int i)
	{
		// オブジェクトが破壊されてない状態に設定
		bBreak = false;
		return posSave[i];
	}
}
