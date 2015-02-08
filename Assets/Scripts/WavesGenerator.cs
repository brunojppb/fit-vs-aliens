using UnityEngine;
using System.Collections;

public class WavesGenerator : MonoBehaviour {

	[Header("Waves array")]
	//waves prefabs
	public GameObject[] waves;


	private int currentWave = 0;

	IEnumerator Start(){

		while (currentWave < waves.Length) {
			GameObject wave = Instantiate(waves[currentWave], transform.position, Quaternion.identity) as GameObject;

			wave.transform.parent = this.transform;

			while(wave.transform.childCount != 0)
				yield return new WaitForEndOfFrame();

			//Delete the old wave
			Destroy(wave);

			currentWave++;
		}

	}

}
