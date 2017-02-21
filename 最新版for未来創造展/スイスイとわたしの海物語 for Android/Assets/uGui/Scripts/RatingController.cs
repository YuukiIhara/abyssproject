using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RatingController : MonoBehaviour {
	
	public string[] scenarios;
	public  Text uiText;				
	private string currentText = string.Empty;
	// 一度だけ入る処理
	bool bFlag = true;

	// ResultRateの変数宣言
	GameObject ResultRate;
	// Energyの変数宣言
	GameObject Energy;

	void Start()
	{
		// ResultRateの初期化
		ResultRate = GameObject.Find ("ResultRate");
		// Energyの初期化
		Energy = GameObject.Find ("Energy");
	}

	void Update () 
	{
		// 表示する評価の切り替え
		if(ResultRate.GetComponent<ResultRate> ().GetEndFlag() == true  && bFlag == true)
		{
			int i = 0;
			i = Energy.GetComponent<Energy> ().GetEnergyRate ();

			if(i >= 0 && i < 30)
			{
				i = 0;
			}
			if(i >= 30 && i < 60)
			{
				i = 1;
			}
			if(i >= 60 && i < 100)
			{
				i = 2;
			}
			if(i == 100)
			{
				i = 3;
			}
			// 文字列切り替え処理
			currentText = scenarios[i];
			// 文字列の長さを指定する
			uiText.text = currentText.Substring(0, currentText.Length);

			bFlag = false;
		}
	}

}
