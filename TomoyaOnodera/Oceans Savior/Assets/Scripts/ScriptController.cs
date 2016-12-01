using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // uGUIの機能を使うお約束

public class ScriptController : MonoBehaviour {
	
	// スクリプト
	public string[] scenarios;
	public  Text uiText;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;	// 1文字の表示にかかる時間

	private int currentLine = 0;
	private string currentText = string.Empty;	// 現在の文字列
	private float timeUntilDisplay = 0;			// 表示にかかる時間
	private float timeElapsed = 1;				// 文字列の表示を開始した時間
	private int lastUpdateCharacter = -1;		// 表示中の文字数

	// 初期設定の判定
	bool bSetNextLine = false;


	void Start () 
	{
		// 前回のテキストを消す
		uiText.text = currentText.Substring(0, 0);
		// 前回の名前を消す
		GameObject.Find ("NameController").GetComponent<NameController> ().Unload();
		// シナリオのフラグを設定
		GameObject.Find ("ScenarioSystem").GetComponent<ScenarioSystem> ().SetScenarioFlag (true);
	}

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Update () 
	{
		// スプライトのα値が1なら処理をする
		if(GameObject.Find("Frame_txt").GetComponent<Alpha>().GetAlpha() >= 1.0f)
		{
			// 一度だけ処理される
			if (bSetNextLine == false)
			{
				SetNextLine ();
				bSetNextLine = true;
			}
				
			// 文字の表示が完了してるならクリック時に次の行を表示する
			if( IsCompleteDisplayText )
			{
				if(currentLine <= scenarios.Length && Input.GetMouseButtonDown(0))
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
				uiText.text = currentText.Substring(1, displayCharacterCount-1);
				lastUpdateCharacter = displayCharacterCount;
			}
		}
	}

	void SetNextLine()
	{
		// シナリオ再生のフラグを切る
		if(currentLine == scenarios.Length)
		{
			GameObject.Find ("ScenarioSystem").GetComponent<ScenarioSystem> ().SetScenarioFlag (false);
			// オブジェクトの破壊
			Destroy(this.gameObject);
		}

		// 次の文字列に切り替え
		currentText = scenarios[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;

		// セリフ名の切り替え
		string Chara = currentText.Substring(0, 1);
		int i = int.Parse (Chara);
		GameObject.Find ("NameController").GetComponent<NameController> ().SetNextLine (i);
		// スプライトの色設定

	}
}
