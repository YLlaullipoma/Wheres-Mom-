using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private PlayerModel marcoModel;

    // Start is called before the first frame update
    void Start()
    {
        marcoModel = GetComponent<PlayerModel>();
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    public void Swipe() {

        if (Input.GetMouseButtonDown(0)) {

            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0)) {
            
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            currentSwipe.Normalize();

            //swipe up
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
                marcoModel.Jump();
            }

            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
                Debug.Log("down swipe");
            }

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
                marcoModel.MoveLeft();
            }

            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f){
                marcoModel.MoveRight();
            }
        }
    }
}
