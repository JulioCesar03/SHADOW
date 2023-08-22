using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAUSEMENU : MonoBehaviour
{
    public GameObject pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (pausemenu.activeSelf)
            {
                pausemenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pausemenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame()
    {
        pausemenu.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
