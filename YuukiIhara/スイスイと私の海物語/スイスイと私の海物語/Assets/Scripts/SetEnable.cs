using UnityEngine;
using System.Collections;

public class SetEnable : MonoBehaviour {

	//private GameObject[]　children = new GameObject[ transform.childCount ];

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			//child.GetComponent<Animator>().enabled = false;
			//child.GetComponent<ChildActiveChanger> ().ChangeActive (false);
			//child.transform.FindChild ("SeaAnemone").GetComponent<SkinnedMeshRenderer> ().enabled = false;
			//child.transform.FindChild ("joint1").gameObject.SetActive (false);
		}
		/*foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}*/
		//gameObject.GetComponentInParent<Animator>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// レンダラーコンポーネントが適用されているオブジェクトに貼り付けて
	// レンダラーがカメラの範囲内外に移り変わったとき一度だけ呼ばれる関数
	void OnBecameInvisible () 
	{
		//enabled = false;
		//gameObject.SetActive(false);
		//GetComponent<SkinnedMeshRenderer>().enabled = false;
		//GetComponent<Animator>().enabled = false;
		//gameObject.GetComponentInParent<Animator>().enabled = false;
		foreach (Transform child in transform)
		{
			//child.GetComponent<Animator>().enabled = false;
			child.GetComponent<ChildActiveChanger> ().ChangeActive (false);
			//child.transform.FindChild ("SeaAnemone").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		}
		/*foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}*/
	}

	void OnBecameVisible () 
	{
		//enabled = true;
		//gameObject.SetActive(false);
		//GetComponent<SkinnedMeshRenderer> ().enabled = true;
		//GetComponent<Animator>().enabled = true;
		//gameObject.GetComponentInParent<Animator>().enabled = true;
		foreach (Transform child in transform)
		{
			//child.GetComponent<Animator>().enabled = true;
			child.GetComponent<ChildActiveChanger> ().ChangeActive (true);
			//child.transform.FindChild ("SeaAnemone").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		}
		/*foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}*/
	}
}
