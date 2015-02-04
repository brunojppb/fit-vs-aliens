using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		string layerName = LayerMask.LayerToName (other.gameObject.layer);

		if (layerName == "Bullet (Enemy)") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
