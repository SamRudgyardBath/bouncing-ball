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
        pos = new Vector3(0, 0, 0);
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

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
        for (int substep = 0; substep < noOfSubsteps; substep++) {
            // Update the ball's position and velocity each frame
            pos += v * substep/noOfSubsteps * Time.deltaTime;
            v += a * substep/noOfSubsteps * Time.deltaTime;
        }

        // Bounce off of sides of the cube
        float halfCubeLength = cubeLength/2f;
        float ballMinX = pos.x - radius;
        float ballMinY = pos.y - radius;
        float ballMinZ = pos.z - radius;
        float ballMaxX = pos.x + radius;
        float ballMaxY = pos.y + radius;
        float ballMaxZ = pos.z + radius;
        if (!isWithinBox) {
            if (ballMinX < -halfCubeLength || ballMaxX > halfCubeLength) {
                v.x *= -1f;
                // v.x *= coeffRestitution;
            }
            if (ballMinY < -halfCubeLength || ballMaxY > halfCubeLength) {
                v.y *= -1f;
                // v.y *= coeffRestitution;
            }
            if (ballMinZ < -halfCubeLength || ballMaxZ > halfCubeLength) {
                v.z *= -1f;
                // v.z *= coeffRestitution;
            }
        }
    }

    bool IsWithinBox() {
        float halfCubeLength = cubeLength/2f;
        float ballMinX = pos.x - radius;
        float ballMinY = pos.y - radius;
        float ballMinZ = pos.z - radius;
        float ballMaxX = pos.x + radius;
        float ballMaxY = pos.y + radius;
        float ballMaxZ = pos.z + radius;
        bool isWithinBox = (ballMinX >= halfCubeLength) && (ballMaxX <= halfCubeLength) && (ballMinY >= halfCubeLength) && (ballMaxY <= halfCubeLength) && (ballMinZ >= halfCubeLength) && (ballMaxZ <= halfCubeLength);
        return isWithinBox;
    }
}
