using UnityEngine;
using System.Collections;

public class UnderwaterFog : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.

	//Define variable

	public int underwaterLevel = 7;
	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;
	new Camera camera;

	void Start () {
		//Set the background color
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
		RenderSettings.fogStartDistance = 1.0f;
		camera = GetComponent<Camera>();
		camera.backgroundColor = new Color (0.1f, 0.25f, 0.42f, 1);
	}

	void Update () {
		
		if (transform.position.y < underwaterLevel) {
				
				RenderSettings.fog = true;
				RenderSettings.fogColor = new Color (0.1f, 0.25f, 0.42f, 0.6f);
				RenderSettings.fogDensity = 0.04f;
				RenderSettings.skybox = noSkybox;
			if (GameObject.Find ("Turtle").transform.position.z < 1) {
				RenderSettings.fogDensity = 0.0005f;
			}
			
			} else {
				RenderSettings.fog = defaultFog;
				RenderSettings.fogColor = defaultFogColor;
				RenderSettings.fogDensity = defaultFogDensity;
				RenderSettings.skybox = defaultSkybox;
			}


	}
}