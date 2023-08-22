using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cenas : MonoBehaviour
{
    //public Animator anim;
    public GameObject carrega;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chamarfase0()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }    
    public void chamarfase1()
    {
        SceneManager.LoadScene(1);
    }
    public void chamarfase2()
    {
        SceneManager.LoadScene(2);
    }

    public void chamarfase3()
    {
        SceneManager.LoadScene(3);
    }

    public void chamarfase4()
    {
        SceneManager.LoadScene(4);
    }
    public void chamarfase5()
    {
        SceneManager.LoadScene(5);
    }
    public void Fechar()
    {
        Application.Quit();
    }

    public void carregar()
    {
        carrega.SetActive(true);

    }

}
