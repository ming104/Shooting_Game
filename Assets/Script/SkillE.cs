using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillE : MonoBehaviour
{
    public float Speed = 2f;
    public GameObject BOOM;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Instantiate(BOOM, transform.position, Quaternion.identity);
        }
    }
}
