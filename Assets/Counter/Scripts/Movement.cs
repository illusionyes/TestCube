using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float xBound  = 22f;
    [SerializeField] private float zBound = 9f;
    void Update()
    {
        MoveBox();
    }
    private void MoveBox()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        
        var pos = transform.position;
        if (transform.position.z > zBound)
        {
            
            pos = new Vector3(pos.x, pos.y, zBound);
        }
        if (transform.position.z < -zBound)
        {
            
            pos = new Vector3(pos.x, pos.y, -zBound);
        }
        if (transform.position.x < -xBound)
        {
            
            pos = new Vector3(-xBound, pos.y, pos.z);
        }
        if (transform.position.x > xBound)
        {
            
            pos = new Vector3(xBound, pos.y,pos.z);
        }

        transform.position = pos;
    }
}
