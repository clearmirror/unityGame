using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GameObject rb;
    private GameObject commandMenu;

    
    private bool isMoving;
    private Vector3 moveDiff;
    private Vector3 targetPos;


    // Use this for initialization
    void Start () {
        rb = GameObject.FindWithTag("Player");
        commandMenu = GameObject.FindWithTag("commandMenu");
        isMoving = false;
    }

    public void MoveTo(Vector3 pos)
    {
        isMoving = true;
        targetPos = pos;
        Vector3 currentPos = rb.transform.position;
        float speed = 10.0f;
        float timeNeeded = Vector3.Distance(pos, currentPos) / speed;
        float secPerFrame = 1.0f / 60;

        Vector3 diffVector = pos - currentPos;
        Vector3 vectorPerFrame = diffVector / timeNeeded * secPerFrame;
        moveDiff = vectorPerFrame;
        Debug.Log(moveDiff);
        Debug.Log(diffVector);
        Debug.Log(timeNeeded);
        Debug.Log(diffVector / timeNeeded);
    }

    bool AlmostToDestination()
    {
        Vector3 currentPos = rb.transform.position;
        return Vector3.Distance(currentPos, targetPos) < 1.0f;
    }
	// Update is called once per frame
	void Update () {
        
        if(isMoving)
        {
            rb.transform.Translate(moveDiff);
            if (AlmostToDestination())
            {
                isMoving = false;
            }
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertial = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertial);

        Vector3 distance = new Vector3(-6.0f, 0.0f, -4.0f);
        commandMenu.transform.position = rb.transform.position + distance;

        if (moveHorizontal == 0.0f && moveVertial == 0.0f)
        {
            return;
        }
        rb.transform.Translate(movement);
    }
}
