using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    //corpo personagem
    public Rigidbody2D corpo;
    //velocidade
    public float velocidade;
    //spritepersonagem
    public SpriteRenderer imgpers;
    //animacao
    public Animator anim;
    //vida
    public int vidaMax = 10;
    public int vida = 10;
    private Image barrahp;
    //pulo
    public int qtdpuloo = 0;
    private float temporizdano = 0;
    //dan
    public bool pode_dano = true;
    public GameObject Arma;
    //ataque
    public SpriteRenderer imgmagia;
    
    [Header("Sons")]
    public AudioSource Morte;
    public AudioSource jump;
    public AudioSource soundmagic;
    public AudioSource damage;

    public int municao = 5;
    //regenera a vida por tempo
    private float vidam;
    //temporizador de tiro
    public float temporize_tiro=0;
    public bool pode_tiro = true;

    [Header("Tempo Regenera")]
    public float tempoRegenerarVida;
    private float contadorRegeneraVida;



    void Start()
    {
        barrahp = GameObject.FindGameObjectWithTag("HP").GetComponent<Image>();
        //moeda_texto = GameObject.FindGameObjectWithTag("moedas-text-tag").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        apontar();
        pular();
        dano();
        Ataque();
        temporitiro();
        RegeneraVida();


    }

    void Ataque()
    {
        if(pode_tiro == true)
        { if (Input.GetButton("RT"))
            {
                GameObject novoAtaque = Instantiate(Arma, transform.position, Quaternion.identity);
                pode_tiro = false;
                Destroy(novoAtaque, 1f);    
                if (imgpers.flipX == true)
                {
                    novoAtaque.GetComponent<Bala>().DirecaoBala(-9);
                    soundmagic.Play();                   
                }
                else
                {
                    novoAtaque.GetComponent<Bala>().DirecaoBala(9);
                    soundmagic.Play();
                }
            }                       
        }
    }
    void Mover()
    {
        if (velocidade != 0)
        {
            anim.SetBool("Andando", true);
        }
        if (velocidade == 0)
        {
            anim.SetBool("Andando", false);
        }

        velocidade = Input.GetAxis("Horizontal") * 6;
        corpo.velocity = new Vector2(velocidade, corpo.velocity.y);

    }

    void apontar()
    {
        if(velocidade> 0)
        {
            imgpers.flipX = false;
        }
        if(velocidade<0)
        {
            imgpers.flipX = true;
        }
    }
    void pular()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            qtdpuloo++;
            if(qtdpuloo<=1)
            {
                jump.Play();
                Acaopulo();
                
            }            
        }
    }

    void Acaopulo()
    {
        corpo.AddForce(transform.up * 350f);
    }

    void  OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag =="pisavel")
        {
           Debug.Log("Chao");
           qtdpuloo = 0;
        }

        if (gatilho.gameObject.tag == "limbo")
        {
            perderhp();
            morrer();            
            vida = vida - 20;
        }
        if (gatilho.gameObject.tag == "passfase")
        {
            //vai para a fase principal
                SceneManager.LoadScene(2);           
        }
        if(gatilho.gameObject.tag =="fase02")
        {
            //tutorial 2
            SceneManager.LoadScene(3);
        }
        if(gatilho.gameObject.tag == "barreira")
        {
            //addgravidade
        }
        if (gatilho.gameObject.tag == "passfasecred")
        {
            //fase boss
            fasefinal();
        }
        if (gatilho.gameObject.tag == "creditos")
        {
            SceneManager.LoadScene (7);
        }
        if (gatilho.gameObject.tag == "magiaboss")
        {

            if (pode_dano == true)
            {
                vida-=4;                
                perderhp();
                pode_dano = false;
            }
            imgpers.color = UnityEngine.Color.red;
            if (vida <= 0)
            {
                morrer();
            }
        }
    }

    void OnCollisionStay2D(Collision2D toque)
    {
        if (toque.gameObject.tag == "Inimigo")
        {
            if(pode_dano == true)
            {
                vida--;
                
                perderhp();
                pode_dano = false;
            }
            imgpers.color = UnityEngine.Color.red;
            if (vida <=0)
            {
                morrer();
            }

        }
        if (toque.gameObject.tag == "magiaboss")
        {

            if (pode_dano == true)
            {
                
                vida--;                
                perderhp();
                pode_dano = false;
            }
            imgpers.color = UnityEngine.Color.red;
        }
    }
    void temporidano()
    {
        temporizdano += Time.deltaTime;
        if (temporizdano > 0.5f)
        {
            pode_dano = true;
            temporizdano = 0;
            imgpers.color = UnityEngine.Color.white;
        }
        Ataque();
    }

    void RegeneraVida() 
    {
        contadorRegeneraVida += Time.deltaTime;
        if (contadorRegeneraVida > tempoRegenerarVida && pode_dano == true && vida <= vidaMax) {
            contadorRegeneraVida = 0f;
            vida++;
            barrahp.fillAmount = (float)vida / (float)vidaMax;
        }
    }

    void temporitiro()
    {       
        if(pode_tiro == false)
        {
            temporize_tiro += Time.deltaTime;
            if (temporize_tiro > 0.5f)
            {
                temporize_tiro = 0;
                pode_tiro = true;
            }
        }
       
    }
    void dano()
    {
        if(pode_dano ==false)
        {
            temporidano();
        }
    }
             
    void perderhp()
    {
        barrahp.rectTransform.sizeDelta = new Vector2(155, 15);
        barrahp.fillAmount = (float)vida / (float)vidaMax;
    }
    void morrer()
    {
        if(vida<=0)
        {            
            anim.SetBool("morte", true);           
        }

    }
    void reiniciar()
    {
        //tela de agradecimento
        SceneManager.LoadScene(7);
    }
    void fasefinal()
    {
        SceneManager.LoadScene(6);
    }
    public void sommorte()
    {
      Morte.Play();
    }


         
}
