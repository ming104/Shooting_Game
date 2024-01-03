using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int HP = 4;
    public float Speed = 5;
    public GameObject diepar1;
    public GameObject diepar2;


    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Speed * Time.deltaTime;
        if (HP < 0)
        {
            Instantiate(diepar1, transform.position, Quaternion.identity);
            Instantiate(diepar2, transform.position, Quaternion.identity);

            GameObject smObject = GameObject.Find("ScoreManager");
            Score sm = smObject.GetComponent<Score>();
            sm.SetScore();

            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void OnEnable()
    {
        int randValue = Random.Range(0, 10);
        if (randValue <= 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }
    private void OnDisable()
    {
        HP = 1;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Bullet"))
        {
            HP -= 3;
            collision.gameObject.SetActive(false); // ÃÑ¾Ë »èÁ¦ÀÓ
        }

        else
        {
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("BOOM"))
        {
            HP -= 10000;
        }
    }
}
