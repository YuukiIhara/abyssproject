using UnityEngine;
using System.Collections;

public class UnderwaterFog : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.

	//Define variable

	public int underwaterLevel = 7;
	//The scene's default fog settings
	private bool lowfog;
	private bool highfog;
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;
	new Camera camera;
	private bool lowambient;
	private bool highambient;
	private bool cave = false;
	void Start () {
		//Set the background color
		lowambient = false;
		highambient = false;
		lowfog = false;
		highfog = false;
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
		RenderSettings.fogDensity = 0.04f;
		RenderSettings.fogStartDistance = 1.0f;
		camera = GetComponent<Camera>();
		camera.backgroundColor = new Color (0.1f, 0.25f, 0.42f, 1);
	}

	void Update () {
		
		if (transform.position.y < underwaterLevel) {
				
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color (0.1f, 0.25f, 0.42f, 0.6f);
			RenderSettings.skybox = noSkybox;
			if (GameObject.Find ("Turtle").transform.position.z < 50 && !lowfog) {
				FogDown ();
			}
			if (GameObject.Find ("Turtle").transform.position.z < -60 && lowfog) {
				FogUp ();
			}
			if (GameObject.Find ("Turtle").transform.position.z < -1760) {
				//RenderSettings.fogDensity = 0.0006f;
				if (!cave) {
					RenderSettings.fog = false;
					RenderSettings.skybox = defaultSkybox;
				}

			}
			if (GameObject.Find ("Turtle").transform.position.z < -1790 && !highambient) {
				//RenderSettings.ambientIntensity = 1.7f;
				//DynamicGI.UpdateEnvironment();
				highambient = true;
			}
			if (GameObject.Find ("Turtle").transform.position.z < -2140 && !lowambient) {
				//RenderSettings.fogDensity = 0.0006f;
				cave = true;
				RenderSettings.fog = true;
				RenderSettings.skybox = noSkybox;
				//RenderSettings.ambientIntensity = 0.3f;
				//DynamicGI.UpdateEnvironment();
				lowambient = true;
			}
		}
	}
	void FogDown(){
		if (!lowfog) {
			RenderSettings.fogDensity -= 0.00015f;
			if (RenderSettings.fogDensity <= 0.0006f) {
				lowfog = true;
			}
		}

	}
	void FogUp(){
		if (!highfog) {
			RenderSettings.fogDensity += 0.00005f;
			if (RenderSettings.fogDensity >= 0.005f) {
				highfog = true;
			}
		}
	}
}