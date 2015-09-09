using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public GameObject spaceshipBulletPrefab;
	public float speed = 1f;
	public float turnSpeed = 1f;
	public float fireRate = 0.5f;

	private float accelRate = 0f;
	private Animator animator;
	private Vector3 screenSW;
	private Vector3 screenNE;
	private float wrapPadding = 1f;
	private bool hit = false;
	private float nextFire;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		screenSW = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.transform.localPosition.y));
		screenNE = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.localPosition.y));
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical");
		float rotation = Input.GetAxis ("Horizontal");
		if(rotation > 0){
			TurnRight(rotation);
		} else if (rotation < 0){
			TurnLeft(rotation);
		}
		if(translation >= 0.9f){
			Move(translation);
		} else {
			Idle();
		}
		if(Input.GetButton("Jump")){
			ShootBullet();
		}
		rigidbody2D.AddForce (transform.up * (speed * accelRate));
		if(transform.localPosition.x < screenSW.x - wrapPadding){
			transform.localPosition = new Vector3(screenNE.x, transform.localPosition.y, transform.localPosition.z);
		} else if (transform.localPosition.x > screenNE.x + wrapPadding){
			transform.localPosition = new Vector3(screenSW.x, transform.localPosition.y, transform.localPosition.z);
		}
		if(transform.localPosition.y < screenSW.y - wrapPadding){
			transform.localPosition = new Vector3(transform.localPosition.x, screenNE.y, transform.localPosition.z);
		} else if (transform.localPosition.y > screenNE.y + wrapPadding){
			transform.localPosition = new Vector3(transform.localPosition.x, screenSW.y, transform.localPosition.z);
		}
	}

	public void TurnRight (float rotation = 1f){
		if(hit){
			return;
		}
		transform.Rotate (Vector3.back * (rotation * turnSpeed));
	}

	public void TurnLeft (float rotation = 1f){
		if(hit){
			return;
		}
		transform.Rotate (Vector3.forward * (rotation * -turnSpeed));
	}

	public void Move (float accel){
		if(hit){
			return;
		}
		accelRate = accel;
		//animator.SetInteger ("State", 1);
	}

	public void Idle (){
		if(hit){
			return;
		}
		accelRate = accelRate * 0.99f;
		//animator.SetInteger ("State", 0);
	}
	public void ShootBullet (){
		if(hit){
			return;
		}
		if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(spaceshipBulletPrefab, transform.localPosition, transform.localRotation);
		}
	}
}






































