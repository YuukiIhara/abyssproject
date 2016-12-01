using UnityEngine;
using System.Collections;

public class AutoDestroyEffect : MonoBehaviour {

    ParticleSystem Particle;

	// Use this for initialization
	void Start () {
        Particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        // パーティクルの再生時間が終了したらGameObjectを削除
        if (Particle.isPlaying == false) Destroy(gameObject);
	}
}
