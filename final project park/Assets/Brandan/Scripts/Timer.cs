using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [Header("Timer")]
	public int timer;
	
	[Header("Players")]
	public Player_1 player1;
	public Player_2 player2;
	public GameObject P1;
	public GameObject P2;
	public bool sniff1;
	public bool sniff2;
	
	[Header("Camera Control")]
	public GameObject CamTime;
	public GameObject Cam1;
	public GameObject Cam2;
	private bool camSet = false;
	
	[Header("Win Camera")]
	public GameObject Win1;
	public GameObject Win2;
	private bool GameOver = false;
	/*
	[Header("Power Control")]
	public GameObject speed;
	public GameObject bark;
	public float respawnS;
	public float respawnB;
	*/
	[Header("Spawn Bad Mushrooms")]
	public GameObject[] BadMushrooms;
	public float badMushroomRespawn;
	private float nextBadMushroom = 5;
	public int badMushroomTotal;

	[Header("Spawn Good Mushrooms")]
	public GameObject[] GoodMushrooms;
	public float goodMushroomRespawn;
	private float nextGoodMushroom;
	public int goodMushroomTotal;


	[Header("Spawn Dog Bone")]
	public GameObject[] DogBones;
	public float dogBoneRespawn;
	private float nextDogBone;
	public int dogBoneTotal;
	
	[Header("Spawn Chocolate")]
	public GameObject[] Chocolates;
	public float chocolateRespawn;
	private float nextChocolate;
	public int chocolateTotal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {		
		sniff1 = player1.sniffed;
		sniff2 = player2.sniffed;
		if(!camSet) {
			CamTime.SetActive(false); Cam1.SetActive(false); Cam2.SetActive(false);
			Cam1.SetActive(true); Cam2.SetActive(true); CamTime.SetActive(true);
		}
	    timer = 40 - (int) Time.time;
		if(timer < 0 && !GameOver) {
			timer = 0;
			CamTime.SetActive(false); Cam1.SetActive(false); Cam2.SetActive(false);
			if(!sniff1) {
				Win1.SetActive(true);
				Destroy(P2);
			}
			if(!sniff2){
				Win2.SetActive(true);
				Destroy(P1);
			}
		}
		string textBuffer = timer.ToString();
		if(timer < 100) {
			textBuffer = "0" + textBuffer;
		}
		if(timer < 10) {
			textBuffer = "0" + textBuffer;
		}
		GetComponent<TextMesh>().text = textBuffer;
		/*
		if(!speed.activeSelf && respawnS == 0) {
			respawnS = Time.time + 20;
		}
		if(!bark.activeSelf && respawnB == 0) {
			respawnB = Time.time + 20;
		}
		if(Time.time > respawnS && !speed.activeSelf) {
			speed.SetActive(true);
			respawnS = 0;
		}
		if(Time.time > respawnB && !bark.activeSelf) {
			bark.SetActive(true);
			respawnB = 0;
		}
		*/
		if(Time.time > nextBadMushroom && badMushroomTotal < BadMushrooms.Length) {
			int rand = Random.Range(0, BadMushrooms.Length);
			while(BadMushrooms[rand].activeSelf) {
				rand = Random.Range(0, BadMushrooms.Length);
			}
			BadMushrooms[rand].SetActive(true);
			badMushroomTotal += 1;
			nextBadMushroom = Time.time + badMushroomRespawn;
		}

		if(Time.time > nextGoodMushroom && goodMushroomTotal < GoodMushrooms.Length) {
			int rand = Random.Range(0, GoodMushrooms.Length);
			while(GoodMushrooms[rand].activeSelf) {
				rand = Random.Range(0, GoodMushrooms.Length);
			}
			GoodMushrooms[rand].SetActive(true);
			goodMushroomTotal += 1;
			nextGoodMushroom = Time.time + goodMushroomRespawn;
		}
		if(Time.time > nextDogBone && dogBoneTotal < DogBones.Length) {
			int rand = Random.Range(0, DogBones.Length );
			while(DogBones[rand].activeSelf) {
				rand = Random.Range(0, DogBones.Length);
			}
			DogBones[rand].SetActive(true);
			dogBoneTotal += 1;
			nextDogBone = Time.time + dogBoneRespawn;
		}
		if(Time.time > nextChocolate && chocolateTotal < Chocolates.Length) {
			int rand = Random.Range(0, Chocolates.Length);
			while(Chocolates[rand].activeSelf) {
				rand = Random.Range(0, Chocolates.Length);
			}
			Chocolates[rand].SetActive(true);
			chocolateTotal += 1;
			nextChocolate = Time.time + nextChocolate;
		}
	}
}
