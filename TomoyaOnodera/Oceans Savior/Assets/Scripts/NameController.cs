using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class NameController : MonoBehaviour {

	public string[] scenarios;
	public  Text uiText;
	public int currentLine ;					// 0がスイスイ、1が私
	private string currentText = string.Empty;	// 現在の文字列

	void Start()
	{
		SetNextLine();
	}

	void Update () 
	{
		uiText.text = currentText.Substring(0, currentText.Length);
	}

	void SetNextLine()
	{
		// 次の文字列に切り替え
		currentText = scenarios[currentLine];
	}
}
