using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cntroller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count; // для нашего счета

	void Start() { // связываем координаты с шаром
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();

	}

	void FixedUpdate() {
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHor, 0.0f, moveVer);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}
	}
	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 3) {
			winText.text = "You win!";
		}
	}

}
