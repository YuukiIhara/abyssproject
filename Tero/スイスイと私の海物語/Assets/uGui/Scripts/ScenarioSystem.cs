using UnityEngine;
using System.Collections;

public class ScenarioSystem : MonoBehaviour {

	// シナリオの再生フラグ
	bool ScenarioFlag = false;

	void Start ()
	{
	
	}

	void Update ()
	{
	
	}

	// フラグの受け渡し
	public bool GetScenarioFlag()
	{
		return ScenarioFlag;
	}

	// フラグの設定
	public void SetScenarioFlag(bool flag)
	{
		ScenarioFlag = flag;
	}
}
