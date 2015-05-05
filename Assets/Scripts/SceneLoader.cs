using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public Animator storyText;
	public AudioSource gameMusic;

	public void LoadGameplay(){
		Application.LoadLevel ("GamePlay");
	}

	public void StartStoryAnimation(){
		StartCoroutine("StartAnimation");
	}

	IEnumerator StartAnimation(){
		yield return new WaitForSeconds (2.0f);
		gameMusic.Play ();
		yield return new WaitForSeconds (2.0f);
		this.storyText.enabled = true;

	}
}
