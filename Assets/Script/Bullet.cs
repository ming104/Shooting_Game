using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;

        transform.position += dir * Speed * Time.deltaTime;
    }

}
