using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	void Start() {
		StartCoroutine(Wait());
	}

	public IEnumerator Wait() {
		yield return new WaitForSeconds(1);
		print("Loading Scene: "+ GameManager.NextScene);
		SceneManager.LoadScene(GameManager.NextScene);
		yield return null;
	}
}
