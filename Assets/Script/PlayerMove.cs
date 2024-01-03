using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 dir = Vector3.right * h + Vector3.up * v;

        Vector3 dir = new Vector3(h, v, 0);

        transform.Translate(dir * Speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(dir * Speed * 2 * Time.deltaTime);
        }   
    }
}
