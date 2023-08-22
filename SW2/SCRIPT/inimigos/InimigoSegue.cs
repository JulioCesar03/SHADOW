using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InimigoSegue : MonoBehaviour
{

    public GameObject Heroi;
    public SpriteRenderer Olho;
    public Animator anim;
    public float speed;
    [SerializeField] private GameObject explo;

    private void Start()
    {
        Olho = GetComponent<SpriteRenderer>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, Heroi.transform.position) < 5)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, Heroi.transform.position, step);
        }

        if (transform.position.x > Heroi.transform.position.x)
        {

            Olho.flipX = false;
        }
        if (transform.position.x < Heroi.transform.position.x)
        {

            Olho.flipX = true;
        }


    }
    public void OnCollisionEnter2D(Collision2D colidiu)
    {
        //matar o inimigo
        if (colidiu.gameObject.tag == "Magia")
        {

            Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(colidiu.gameObject);

        }

    }
    public void morte()
    {
        Destroy(this.gameObject);
    }
}