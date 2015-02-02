using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	public float moveSpeed = 5f;
	public float shotDelay = 0.1f;
	public Cannon[] cannons;
	public bool canShot;

	IEnumerator Start(){
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
		rigidbody2D.velocity = direction * moveSpeed;
	}


}
