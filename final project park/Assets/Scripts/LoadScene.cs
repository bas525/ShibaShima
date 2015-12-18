using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {

	public GameObject loadingImage;
	public AudioSource bgm;
	public AudioClip clicknoise;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadNewScene(string _sceneName)
	{
		bgm.PlayOneShot(clicknoise);
		if(loadingImage != null){
		loadingImage.SetActive(true);
		}
		Application.LoadLevel(_sceneName);
	}
}
