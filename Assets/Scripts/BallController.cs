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
}
