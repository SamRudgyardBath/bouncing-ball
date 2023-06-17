using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Public Attributes
    public Transform worldLoc;
    public float radius;
    public float cubeLength;
    public float coeffRestitution = 0.5f;
    #endregion
    #region Private Attributes
    private Vector3 pos;
    private Vector3 v;
    private Vector3 a;
    private bool isWithinBox;
    private int noOfSubsteps = 5;
    #endregion

    // Start is called before the first frame update
    void Start() {
        // Initialise position and velocity
        pos = worldLoc.position;
        v = new Vector3(0, 0, 1);
        a = new Vector3(0, -9.81f, 0);
        radius = Random.value * 5f;
        transform.localScale = new Vector3(radius, radius, radius);
    }

    // Update is called once per frame
    void Update() {
        // Update the object's position
        worldLoc.position = pos;
    }

}
