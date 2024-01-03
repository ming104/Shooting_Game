using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject skillPrefab;
    public GameObject FirePosition;
    public GameObject FireParticle;

    int poolSize = 10;
    GameObject[] bulletObjectPool;

    public bool isFire;
    public bool isSkill;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletObjectPool[i] = bullet;
        }
        isFire = false;

#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isFire == false || Input.GetKey(KeyCode.Space) && isFire == false)
        {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.E) && isSkill == false) 
        {
            Eskill();
        }
    }

    IEnumerator EskillCoolTime()
    {
        isSkill = true;
        yield return new WaitForSeconds(30f);
        isSkill = false;
    }
    public void Eskill()
    {
        Instantiate(skillPrefab, transform.position, Quaternion.identity);
        StartCoroutine("EskillCoolTime");
    }

    IEnumerator FireCoolTime()
    {
        isFire = true;
        yield return new WaitForSeconds(0.2f);//0.08
        isFire = false;
    }
    public void Fire()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = bulletObjectPool[i];
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);

                bullet.transform.position = transform.position;
                break;
            }
        }
        StartCoroutine("FireCoolTime");
    }
}
