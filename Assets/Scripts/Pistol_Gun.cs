using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Gun : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    public float offset;

    private float timeBtwShorts;
    public float startTimeBtwShorts;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(bullet, shotPoint.position, Quaternion.identity);
        //}

        if(timeBtwShorts <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shotPoint.position, Quaternion.identity);
                timeBtwShorts = startTimeBtwShorts;
            }
        }

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 LocalScale = Vector3.one;

        if(rotateZ > 90 || rotateZ < -90)
        {
            LocalScale.y = -1f;
        }
        else
        {
            LocalScale.y = +1f;
        }

        transform.localScale = LocalScale;
    }

}
