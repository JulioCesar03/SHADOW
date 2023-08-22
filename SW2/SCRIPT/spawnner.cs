using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour
{
    public GameObject inimigo;
    public float spawnrate;

    private float proxspawn;

    // Update is called once per frame
    void Update()
    {

        spm();

    }

    public void spm()
    {
        if (Time.time > proxspawn)
        {
            proxspawn = Time.time + spawnrate;

            Instantiate(inimigo, transform.position, inimigo.transform.rotation);
        }
    }
}
