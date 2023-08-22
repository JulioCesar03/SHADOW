using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barradevidaboss : MonoBehaviour
{

    boss bs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(bs.vida * 100/bs.vidamax, 5, 1);

    }
}
