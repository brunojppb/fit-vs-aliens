using UnityEngine;
using System.Collections;

public class WavesGenerator : MonoBehaviour {

	[Header("Waves array")]
	//waves prefabs
	public GameObject[] waves;
	public Animator mascotImg;
	public AudioSource toast;


	private int currentWave = 0;

	IEnumerator Start(){

		while (currentWave < waves.Length) {
			GameObject wave = Instantiate(waves[currentWave], transform.position, Quaternion.identity) as GameObject;

			wave.transform.parent = this.transform;

			while(wave.transform.childCount != 0)
				yield return new WaitForEndOfFrame();

			//Show the mascot face if the player kill all the
			//enemies of the waves 1 and 3
			if(currentWave == 0 || currentWave == 2){
				StartCoroutine("ShowMascot");
			}


			//Delete the old wave
			Destroy(wave);

			currentWave++;
		}
	}

	IEnumerator ShowMascot(){
		mascotImg.SetTrigger("toggle");
		yield return new WaitForSeconds (0.1f);
		toast.Play ();
		yield return new WaitForSeconds (0.8f);
		mascotImg.SetTrigger("toggle");
	}

}
