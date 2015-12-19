using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public GameObject loadingImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNewScene (string _SceneName)

	{
		loadingImage.SetActive(true);
		Application.LoadLevel(_SceneName);

	}
}
