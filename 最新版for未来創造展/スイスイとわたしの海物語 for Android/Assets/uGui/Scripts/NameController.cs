using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameController : MonoBehaviour {

	public string[] scenarios;
	public  Text uiText;
	public int currentLine ;					// 0がスイスイ、1が私
	private string currentText = string.Empty;	// 現在の文字列

	void Start()
	{
	}

	void Update () 
	{
		uiText.text = currentText.Substring(0, currentText.Length);
	}

	public void SetNextLine(int i)
	{
		// 次の文字列に切り替え
		currentText = scenarios[i];
	}

	public void Unload()
	{
		// 前回のテキストを消す
		uiText.text = currentText = "";
	}
}
