using UnityEngine;
using System.Collections;

public class Butt : MonoBehaviour {

	public GameObject dog;

	[Header("Starting Position")]
	public float StartPosX;
	public float StartPosY;
	public float StartPosZ;
	
	[Header("Health")]
	public int health = 3;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0) {
			Destroy(dog);
		}
	}
	
	void OnTriggerEnter(Collider col)
	{
		
		if(col.tag == "Nose")
		{
			health--;
			dog.transform.position = new Vector3(StartPosX, StartPosY, StartPosZ);
		}

	}
}
