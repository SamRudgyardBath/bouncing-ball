using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int noOfBalls = 5;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < noOfBalls; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-5f,5f), 0, Random.Range(-5f,5f));
            GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
