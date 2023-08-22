using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mago : MonoBehaviour   
{
    public float velocidade = 0.03f;
    public float distInicial = 0.06f;
    public float distFinal = -13f;
    public SpriteRenderer Imagemago;
    public float tempo;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Imagemago = GetComponent<SpriteRenderer>();
        tempo += Time.deltaTime;
        if(tempo>0.05f)
        {
            Andar();
            tempo = 0;
        }
    }
    void Andar()
    {
        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
        
        if (transform.position.x > distFinal)
        {
            velocidade = velocidade * -1;


        }
        if (transform.position.x < distInicial)
        {
            velocidade = velocidade * -1;

        }
        //mudar direção
        if (velocidade < -0.01)
        {
            Imagemago.flipX = false;
        }
        if (velocidade > 0.01)
        {
            Imagemago.flipX = true;
        }
    }
        private void OnCollisionEnter2D(Collision2D colidiu)
        {
            //matar o inimigo
            if (colidiu.gameObject.tag == "Magia")
            {
                anim.SetBool("morte", true);
               
            }
            
        } 

    public void Morri()
    {
        Destroy(this.gameObject);
    }


    

}
