using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour{
    public Transform[] destiny;
    public int currentTarget;

    public float playerSpeed;
    public int applePoints;
    public float jumpForce;
    public bool grounded;
    public bool jump;

    public Material blindedPU;
    public LayerMask Ground;
    public float groundDistance;

    /*[HideInInspector]*/ public bool canSwipe;
    /*[HideInInspector]*/ public bool canMove;
    Rigidbody playerRB;
    Animator animPlayer;

    private void Start() {
        playerRB = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();
        canSwipe = true;
        canMove = true;
        currentTarget = 1;
    }

    private void Update() {
        grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, Ground);

        if (canMove) {
            transform.position = Vector3.MoveTowards(transform.position, destiny[currentTarget].position, playerSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate() {
        if (grounded && jump) {
            animPlayer.SetTrigger("Jump");
            Jump();
        }
    }

    public int SwipeRight() {
        currentTarget++;
        if (currentTarget > 2) {
            currentTarget = 2;
        }
        animPlayer.SetTrigger("SwipeRight");
        return currentTarget;
    }

    public int SwipeLeft() {
        currentTarget--;
        if (currentTarget < 0) {
            currentTarget = 0;
        }
        animPlayer.SetTrigger("SwipeLeft");
        return currentTarget;
    }

    public void Jump() {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jump = false;
    }

    public void Rolling() {
        if (grounded) {

        }
    }

    public int EatAplee() {
        applePoints += 1;
        return applePoints;
    }

    public void BecomeInvulnerable() {
        
    }

    public void Paused() {

    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            //grounded = true;
            //canMove = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            //grounded = false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position, Vector3.down * groundDistance);
    }
}
