using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    //Utilizada na Fisica
    public Rigidbody2D CorpoBala;
    //Velocidade
    public float velBala;
    public SpriteRenderer imgmagia;

    void Start()
    {
        CorpoBala = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOve a Bala nO Jogo
        CorpoBala.velocity = new Vector2(velBala, CorpoBala.velocity.y);
        apontar();
    }

    //Muda a Dire��o da Balha
    //CHamada no Personagem
    public void DirecaoBala(float dirBala)
    {
        velBala = dirBala;
    }
    void apontar()
    {
        if (velBala > 0)
        {
            imgmagia.flipX = false;
        }
        if (velBala < 0)
        {
            imgmagia.flipX = true;
        }

        Destroy(CorpoBala, 1f);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if(gatilho.gameObject.tag =="Inimigo")
        {
            //Destroy(gameObject);
        }

    }
}
