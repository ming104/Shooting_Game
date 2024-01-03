using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyZone_U : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if(other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        
        {
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.name.Contains("Skill"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
