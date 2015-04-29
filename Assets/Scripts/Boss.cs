using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public int health = 10;
	public Cannon[] cannions;
	public GameObject[] explosionEffects;
	private bool moveDirection = true;

	// Use this for initialization
	void Start () {
		StartCoroutine("MoveAround");
		StartCoroutine("Shoot");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		string layerName = LayerMask.LayerToName (other.gameObject.layer);
		if (layerName != "Bullet (Player)")
			return;

		Destroy (other.gameObject);
		GamePlayUI.addPoints ();
		if (health > 0) {
						health--;
		} else {
			Destroy(this.gameObject);
		}
	}

	IEnumerator Shoot(){
		while (true) {
			foreach(Cannon can in cannions) {
				can.Shoot();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	IEnumerator MoveAround(){
		int counter = 0;
		while (true) {
			if (moveDirection) {
				transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
				counter++;
				yield return new WaitForSeconds(0.01f);
				if(counter >= 300)
					moveDirection = false;
			}
			else {
				transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
				counter--;
				yield return new WaitForSeconds(0.01f);
				if(counter <= 0)
					moveDirection = true;
			}
		}
	}
}
