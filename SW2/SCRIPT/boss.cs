using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public float velocidade = 0.03f;
    public float distInicial = 0.06f;
    public float distFinal = -13f;
    public SpriteRenderer Imagemago;
    public float tempo;
    public Animator anim;
    public int vida=4;
    public int vidamax = 10;
    protected Personagem player;
    protected spawnner spam;
    //disparo do boss
    public GameObject bulletPrefab;
    public bool pode_atirar = true;
    public float temporize_tiro = 0;
    [SerializeField] private GameObject explo;
    bool morri = false;

    //barra de vida
    public Image barrhp;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        anim = GetComponent<Animator>();
        Imagemago = GetComponent<SpriteRenderer>();
        barrhp = GameObject.FindGameObjectWithTag("HPboss").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        float distanciaPlayer = Vector2.Distance(transform.position,player.transform.position);
        
        if (tempo > 0.05f && morri == false )
        {
            if (distanciaPlayer > 10) 
            {
                
                Andar();
            }
            else { 
                Atacar();
            }
        }
        temporitiro();


    }
    void Andar()
    {
        if(anim.GetBool("andando") == false) { 
            anim.SetBool("andando", true);
        }
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
            Imagemago.flipX = true;
        }
        if (velocidade > 0.01)
        {
            Imagemago.flipX = false;
        }
    }

    private void Atacar() {

        if (pode_atirar == true)
        {
            pode_atirar = false;

            if (anim.GetBool("andando") == true)
            {
                anim.SetBool("andando", false);
            }
            anim.SetTrigger("atk");
            GameObject GO;

            if (player.transform.position.x > transform.position.x)
            {
                Imagemago.flipX = false;
                Vector3 posT = new Vector3(transform.position.x + 5, transform.position.y + 0.8f, transform.position.z);
                GO = Instantiate(bulletPrefab, posT, Quaternion.identity);
            }
            else
            {
                Imagemago.flipX = true;
                Vector3 posT = new Vector3(transform.position.x - 5, transform.position.y + 0.8f, transform.position.z);
                GO = Instantiate(bulletPrefab, posT, Quaternion.identity);
            }
  
            bulletcontroller bullet = GO.GetComponent<bulletcontroller>();

            if (Imagemago.flipX == true) {
                bullet.VirarBala();
            }
            
            Vector2 vector = player.transform.position - bullet.transform.position;
            bullet.SetVelocity(vector.normalized * 10);
        }
    }
    void temporitiro()
    {
        if (pode_atirar == false)
        {
            temporize_tiro += Time.deltaTime;
            if (temporize_tiro > 1.5f)
            {
                temporize_tiro = 0;
                pode_atirar = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D colidiu)
    {
        //matar o inimigo
        if (colidiu.gameObject.tag == "Magia")
        {
            vida--;
            perderhp();
            
            if (vida <= 0)
            {
                anim.SetBool("morto", true);    
                morri=true;
                GetComponent<Collider2D>().enabled = false;

            }
        }
    }
    public void morreu()
    {             
        Destroy(gameObject);
    }

    void perderhp()
    {
        barrhp.fillAmount = (float)vida / (float)vidamax;
    }

}
