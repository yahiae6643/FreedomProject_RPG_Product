using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTarget;
    public float smoothing;
    public Vector2 maxPosition; // 16 , 6.81
    public Vector2 minPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != playerTarget.position){
        	Vector3 playerTargetPosition = new Vector3(playerTarget.position.x,playerTarget.position.y,transform.position.z);
        	playerTargetPosition.x = Mathf.Clamp(playerTargetPosition.x,minPosition.x,maxPosition.x);
        	playerTargetPosition.y = Mathf.Clamp(playerTargetPosition.y,minPosition.y,maxPosition.y);
        	transform.position = Vector3.Lerp(transform.position,playerTargetPosition,smoothing);
        }
    }
}
