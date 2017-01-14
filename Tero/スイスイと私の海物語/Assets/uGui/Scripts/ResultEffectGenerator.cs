using UnityEngine;
using System.Collections;

public class ResultEffectGenerator : MonoBehaviour {

	// プレハブの取得
	public GameObject resultPrefab; 
	// エネルギーオブジェクトの取得
	public GameObject energy;
	// レクトトランスフォームの宣言
	new Transform  transform;

	// オブジェクト生成間隔
	public int nObjInterval;
	int IntervalCnt = 0;

	// Use this for initialization
	void Start () 
	{
		// レクトトランスフォームの取得
		transform = GetComponent<Transform> ();
		/*
		// エフェクトを一気に生成
		for(int i = 0; i < 8; i ++)
		{
			// 生成位置決め
			Vector2 pos = new Vector2 (energy.GetComponent<RectTransform>().position.x + energy.GetComponent<RectTransform>().sizeDelta.x,energy.GetComponent<RectTransform>().position.y + (-35.0f+(i*8.0f)));
			// プレハブからインスタンスを生成
			GameObject obj = (GameObject)Instantiate (resultPrefab,pos, Quaternion.identity);
			// 子オブジェクトに登録
			obj.transform.parent = transform;
		}*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		// インターバルのカウント
		IntervalCnt ++;

		if(IntervalCnt % nObjInterval == 0)
		{
			/*// 生成位置決め
			Vector2 pos = new Vector2 (energy.GetComponent<RectTransform>().position.x + energy.GetComponent<RectTransform>().sizeDelta.x,energy.GetComponent<RectTransform>().position.y + Random.Range(-18.0f,18.0f));
			// プレハブからインスタンスを生成
			GameObject obj = (GameObject)Instantiate (resultPrefab,pos, Quaternion.identity);
			// 子オブジェクトに登録
			obj.transform.parent = transform;*/
		}
	}
}
