using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {
    private Vector3 startPos;
    private float newXPos = 0f;
    public float moveSpeed = 1f;
    public float moveDistance = 4f;
    public GameObject Bomb;
    public float timeUntilSpawn = 0f;
    public float startTime = 0f;
    public float secondsBetweenSpawn = 3f;
    public float offsetSpawner = 0f;
	// Use this for initialization
    void Start() {
        startPos = transform.position;
    }
    
    void SpawnBomb () {

        GameObject myBomb = Instantiate(Bomb) as GameObject;

        myBomb.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        newXPos = offsetSpawner + Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);

        transform.position = new Vector3(newXPos, startPos.y, startPos.z);

        timeUntilSpawn = Time.time - startTime;

        if (timeUntilSpawn >= secondsBetweenSpawn) {
            startTime = Time.time;
            timeUntilSpawn = 0;
            SpawnBomb();
        }
	}
}
