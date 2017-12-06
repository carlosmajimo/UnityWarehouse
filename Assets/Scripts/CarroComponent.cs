using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroComponent : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	float moveVertical;
	float moveHorizontal;

	void Start(){

		rb = GetComponent<Rigidbody> ();

	}

	void Update (){
		moveVertical = Input.GetAxis ("Vertical");
		moveHorizontal = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate (){

		move ();
		turn ();

	}

	void move(){

		Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;

		rb.MovePosition (rb.position + movement);
	}

	void turn(){

		float turn = moveHorizontal * speed * speed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		rb.MoveRotation (rb.rotation * turnRotation);
	}
}
