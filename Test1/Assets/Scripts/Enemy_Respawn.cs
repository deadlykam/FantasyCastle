using UnityEngine;
using System.Collections;

public class Enemy_Respawn : MonoBehaviour {

	public GameObject enemy;
	public float spawnTimer;
	public Transform[] spawnPoints;
	public int enemy_Number;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
