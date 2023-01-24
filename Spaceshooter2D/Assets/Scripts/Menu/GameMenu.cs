using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Fase01");
    }

    public void TelaInfo()
    {
        SceneManager.LoadScene("Info");
    }

    public void BotaoVoltar()
    {
        SceneManager.LoadScene("Start");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
