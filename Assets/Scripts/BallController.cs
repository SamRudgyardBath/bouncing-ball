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
        radius = 1f;
        transform.localScale = new Vector3(2*radius, 2*radius, 2*radius);
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
            pos += v * substep/noOfSubsteps * Time.fixedDeltaTime;
            v += a * substep/noOfSubsteps * Time.fixedDeltaTime;
        }

        // Bounce off of sides of the cube
        float halfCubeLength = cubeLength/2f;
        float ballMinX = pos.x - radius;
        float ballMinY = pos.y - radius;
        float ballMinZ = pos.z - radius;
        float ballMaxX = pos.x + radius;
        float ballMaxY = pos.y + radius;
        float ballMaxZ = pos.z + radius;
        if (ballMinX < -halfCubeLength) {
            pos.x = -halfCubeLength + radius;
            v.x *= -1f;
        } 
        else if (ballMaxX > halfCubeLength) {
            pos.x = halfCubeLength - radius;
            v.x *= -1f;
            // v.x *= coeffRestitution;
        }
        if (ballMinY < -halfCubeLength) {
            pos.y = -halfCubeLength + radius;
            v.y *= -1f;
        }
        else if (ballMaxY > halfCubeLength) {
            pos.y = halfCubeLength - radius;
            v.y *= -1f;
            // v.y *= coeffRestitution;
        }
        if (ballMinZ < -halfCubeLength) {
            pos.z = -halfCubeLength + radius;
            v.z *= -1f;
        }
        else if (ballMaxZ > halfCubeLength) {
            pos.z = halfCubeLength - radius;
            v.z *= -1f;
            // v.z *= coeffRestitution;
        }
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos() {
        float halfCubeLength = cubeLength/2f;
        Vector3 frontLeftDownPoint = new Vector3(halfCubeLength, -halfCubeLength, halfCubeLength);
        Vector3 backLeftDownPoint = new Vector3(halfCubeLength, -halfCubeLength, -halfCubeLength);
        Vector3 frontRightDownPoint = new Vector3(-halfCubeLength, -halfCubeLength, halfCubeLength);
        Vector3 backRightDownPoint = new Vector3(-halfCubeLength, -halfCubeLength, -halfCubeLength);
        Vector3 frontLeftUpPoint = new Vector3(halfCubeLength, halfCubeLength, halfCubeLength);
        Vector3 backLeftUpPoint = new Vector3(halfCubeLength, halfCubeLength, -halfCubeLength);
        Vector3 frontRightUpPoint = new Vector3(-halfCubeLength, halfCubeLength, halfCubeLength);
        Vector3 backRightUpPoint = new Vector3(-halfCubeLength, halfCubeLength, -halfCubeLength);
        
        Gizmos.DrawLine(frontLeftDownPoint, backLeftDownPoint);
        Gizmos.DrawLine(frontLeftDownPoint, frontLeftUpPoint);
        Gizmos.DrawLine(frontLeftDownPoint, frontRightDownPoint);
        Gizmos.DrawLine(frontLeftUpPoint, backLeftUpPoint);
        Gizmos.DrawLine(backLeftDownPoint, backLeftUpPoint);
        Gizmos.DrawLine(backLeftDownPoint, backRightDownPoint);
        Gizmos.DrawLine(frontRightDownPoint, backRightDownPoint);
        Gizmos.DrawLine(backRightDownPoint, backRightUpPoint);
        Gizmos.DrawLine(frontRightDownPoint, frontRightUpPoint);
        Gizmos.DrawLine(frontLeftUpPoint, frontRightUpPoint);
        Gizmos.DrawLine(frontLeftUpPoint, frontRightUpPoint);
        Gizmos.DrawLine(frontRightUpPoint, backRightUpPoint);
        Gizmos.DrawLine(backLeftUpPoint, backRightUpPoint);
    }

}
