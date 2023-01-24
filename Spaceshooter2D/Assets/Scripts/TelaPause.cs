using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaPause : MonoBehaviour
{
    public void Ativar()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void Desativar()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
