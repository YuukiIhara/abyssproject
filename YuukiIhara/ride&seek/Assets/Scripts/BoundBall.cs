using UnityEngine;
using System.Collections;

public class BoundBall : MonoBehaviour {

	public float moveSpeed = 5f;
	public float rotationSpeed = 360f;

	CharacterController characterController;
	Animator animator;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if (direction.sqrMagnitude > 0.01f) {
			// １フレーム後の新しい向きforwardを計算
			Vector3 forward = Vector3.Slerp (
				                  transform.forward, 	// 現在の向き
				                  direction,			// キー入力の方向
				                  rotationSpeed * Time.deltaTime / Vector3.Angle (transform.forward, direction)
			                  );
			transform.LookAt (transform.position + forward);
		}
		// Psitionを使わずにCharacterControllerのMoveを使うことで衝突判定などが可能になる
		characterController.Move (direction * moveSpeed * Time.deltaTime);

		animator.SetFloat ("Speed", characterController.velocity.magnitude);
	}
}
