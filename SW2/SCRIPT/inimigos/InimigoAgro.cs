using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InimigoAgro : MonoBehaviour
{
    public float velocidade = 0.03f;
    public float distInicial;
    public float distFinal;
    public GameObject Heroi;
    public SpriteRenderer IAEnimy;
    public int vida =2;
    public Animator anim;
    public Rigidbody2D Rb;
    public int dir;
    public bool spriteEsquerda = true;

    public bool seguirPlayer = false;
    public bool voltarposini = false;
    Vector3 posInicial;

    public float speed;

    private void Start()
    {
        IAEnimy = GetComponent<SpriteRenderer>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
        posInicial = transform.position;
        anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        flipini();
        float step = speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, Heroi.transform.position) < 5)
        {            
            transform.position = Vector3.MoveTowards(transform.position, Heroi.transform.position, step);
            seguirPlayer = true;
        }
        else
        {
            if(seguirPlayer==false && voltarposini == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, posInicial, step);
                if (Vector2.Distance(transform.position, posInicial) < 0.1)
                    voltarposini = false;
            }else if (seguirPlayer == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, posInicial, step);

                    seguirPlayer = false;
                voltarposini=true;
            }
            else if(seguirPlayer == false) {

                transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
            
                if (transform.position.x >= distFinal)
                {
                    velocidade = velocidade * -1; 
                    spriteEsquerda = false;
                } else if (transform.position.x <= distInicial)
                {
                    velocidade = velocidade * -1;
                    spriteEsquerda = true;
                }

            }
            

        }

    }
    void flipini()
    {
        if(seguirPlayer == false) { 
            if(velocidade > 0)
            {
                IAEnimy.flipX = true;
            }
            if(velocidade < 0)
            {
                IAEnimy.flipX = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D colidiu)
    {
        //matar o inimigo
        if (colidiu.gameObject.tag == "Magia")
        {
            vida--;
            if (vida <= 0)
            {
                anim.SetBool("morte", true);
                velocidade = 0f;
                Destroy(colidiu.gameObject);
            }
        }
    }


    public void Morri()
    {
        Destroy(this.gameObject);
    }
}
