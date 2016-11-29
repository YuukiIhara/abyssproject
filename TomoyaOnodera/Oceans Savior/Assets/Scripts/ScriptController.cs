using UnityEngine;
using System.Collections;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScriptController : MonoBehaviour {

	public string[] scenarios;
	public  Text uiText;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;	// 1文字の表示にかかる時間

	private int currentLine = 0;
	private string currentText = string.Empty;	// 現在の文字列
	private float timeUntilDisplay = 0;			// 表示にかかる時間
	private float timeElapsed = 1;				// 文字列の表示を開始した時間
	private int lastUpdateCharacter = -1;		// 表示中の文字数



	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		SetNextLine();
	}

	void Update () 
	{
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if( IsCompleteDisplayText )
		{
			if(currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
			{
				SetNextLine();
			}
		}
		else
		{
			// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0))
			{
				timeUntilDisplay = 0;
			}
		}

		// 文字を一文字ずつ表示
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}

	void SetNextLine()
	{
		// 次の文字列に切り替え
		currentText = scenarios[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;
	}
}
