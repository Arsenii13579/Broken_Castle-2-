using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic = false;
    public float offset = 0;
    private int sortingOrderBase = 0;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        GetComponent<Renderer>().sortingOrder = (int)(sortingOrderBase - transform.position.y + offset);

        if(isStatic)
            Destroy(this);
    }
}
