using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Range(-1,1)] [SerializeField] int rows;
    [SerializeField] public float playerSpeed;
    public float jumpForce;

    public bool grounded;
    public bool invulnerable;

    public Material blindedPU;

    Vector3 originalPos;
    Vector3 destiny;
    Rigidbody playerRB;

    private void Start() {
        playerRB = GetComponent<Rigidbody>();
        rows = 0;
        originalPos = new Vector3(0, 1, -2);
        transform.position = originalPos;
        destiny = originalPos;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, destiny, playerSpeed * Time.deltaTime);
    }

    public void MoveRight() {

        if (rows < 1) {

            destiny = new Vector3(transform.position.x + 1.5f, originalPos.y, originalPos.z);
            rows++;
            Debug.Log("right swipe");
        }
        else {
            Debug.Log("can't move");
        }
    }

    public void MoveLeft() {

        if (rows > -1) {

            destiny = new Vector3(transform.position.x - 1.5f, originalPos.y, originalPos.z);
            rows--;
            Debug.Log("right swipe");
        }
        else {
            Debug.Log("can't move");
        }
        Debug.Log("left swipe");
    }

    public void Jump() {
        Debug.Log("up swipe");
    }

    public void EatAplee() {

    }

    public void BecomeInvulnerable() {
        
    }

    public void Paused() {

    }
}
