using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float moveSpeed = 5f;
	public float shotDelay = 0.1f;
	public Cannon[] cannons;
	public bool canShot;

	IEnumerator ActivateCanions(){
		if (canShot) {
			while (true) {
				Shoot();
				yield return new WaitForSeconds(shotDelay);
			}
		}
	}

	void Shoot(){
		foreach(Cannon can in cannons){
			can.Shoot();
		}
	}

	public void Move(Vector2 direction){
		GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
	}

	void OnBecameVisible(){
		StartCoroutine ("ActivateCanions");
	}

	void OnBecameInvisible(){
		StopCoroutine ("ActivateCanions");
	}


}
