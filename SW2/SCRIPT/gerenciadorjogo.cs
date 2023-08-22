using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gerenciadorjogo : MonoBehaviour
{

    //VErf se o jogo esta iniciado
    public bool gamelig = false;

    

    // Start is called before the first frame update
    void Start()
    {
        //Pausa os scripts
        gamelig = false;
        //pausa jogo
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamelig==true)
        {

        }
    }


    public bool estadojogo()
    {
        return gamelig;
    }

    public void ligjogo()
    {
        gamelig = true;
        
    }




}
