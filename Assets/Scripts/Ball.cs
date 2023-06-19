using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float radius;
    public Vector3 position;
    public Vector3 v;
    private Vector3 a;
    private bool isWithinBox;

    Ball(Vector3 pos, Vector3 v, bool isWithinBox) {
        this.radius = Random.value * 2f;
        this.position = pos;
        this.v = v;
        this.a = new Vector3(0, -9.81f, 0);
        this.isWithinBox = isWithinBox;
    }

    // Start is called before the first frame update
    void Start() {
        transform.localScale = new Vector3(2*radius, 2*radius, 2*radius);
    }
}
