using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadGame()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
