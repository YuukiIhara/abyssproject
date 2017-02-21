using UnityEngine;
using System.Collections;

public class Path1Turtle : MonoBehaviour
{
	public int pathTime = 15;
	public bool resume = false;
	public bool CoralGet = false;
	public bool once = false;
	private Material defaultSkybox;
	public GameObject Scenario1;
	public GameObject Aim;
	// Use this for initialization
	void Start()
	{
		defaultSkybox = RenderSettings.skybox;
		GameObject.Find ("SoundManager").GetComponent<SoundManager> ().SetSound(6,true,2);

	}
	void Update()
	{
		if (Scenario1.GetComponent<ScriptController> ().Flag) {
			Aim.GetComponent<Aim>().FirstCoral = true;
			CoralGet = true;
	
		}
		if (CoralGet) {
			
			if (!once) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Tutorial Path 1"), "time", pathTime, "orienttopath", true, "easetype", iTween.EaseType.linear));
				once = true;
			}
		}

	}
}
