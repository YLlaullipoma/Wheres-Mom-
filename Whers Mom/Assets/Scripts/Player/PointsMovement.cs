using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMovement : MonoBehaviour
{
    public GameObject playerObj;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start() {
        currentPos = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(currentPos.x, playerObj.transform.position.y, currentPos.z);
    }
}
