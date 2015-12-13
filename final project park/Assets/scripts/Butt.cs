using UnityEngine;
using System.Collections;

public class Butt : MonoBehaviour {

	public GameObject dog;

	[Header("Starting Position")]
	public float StartPosX;
	public float StartPosY;
	public float StartPosZ;
	
	[Header("Sniffed")]
	public bool sniffed;
	public Butt opponent;
	public GameObject Ind;
	public GameObject opInd;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		
		if(col.tag == "Nose" && !sniffed)
		{
			sniffed = true;
			Ind.SetActive(true);
			opInd.SetActive(false);
			opponent.sniffed = false;
			dog.transform.position = new Vector3(StartPosX, StartPosY, StartPosZ);
		}

	}
}
