using UnityEngine;
using System.Collections;

public class ResultManager : MonoBehaviour {

	// リザルト開始のフラグ
	bool bFlag = true;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	// リザルトの開始
	public  void ResultStart()
	{
		bFlag = true;
	}

	// フラグの受け渡し
	public bool GetFlag()
	{
		return bFlag;
	}
}
