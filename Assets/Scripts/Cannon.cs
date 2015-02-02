using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public GameObject bulletPrefab;
	public float velocity = 1000.0f;
	public float shotDelay = 0.2f;
	private bool shooting = false;

	public void Shoot(){
		if (!shooting) {
			StartCoroutine(ShootCoroutine());
		}
	}

	IEnumerator ShootCoroutine(){
		shooting = true;
		GenerateBullet ();
		yield return new WaitForSeconds(shotDelay);
		shooting = false;
	}

	void GenerateBullet(){
		GameObject bulletInstance = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
		Rigidbody2D bulletPhysics = bulletInstance.transform.GetComponent<Rigidbody2D> () as Rigidbody2D;
		bulletPhysics.AddForce (transform.up * velocity);
	}
}
