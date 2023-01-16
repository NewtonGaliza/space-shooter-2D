using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField] private int protecaoTotal;
    private int protecaoAtual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Ativar()
    {
        this.protecaoAtual = this.protecaoTotal;
        this.gameObject.SetActive(true);
    }

    public void Desativar()
    {
        this.gameObject.SetActive(false);
    }

    //verifica se o escudo está ativo
    public bool Ativo
    {
        get { return this.gameObject.activeSelf; }
    }

    //ReceberDano no original do video
    public void DanoNoEscudo()
    {
        this.protecaoAtual--;
        if(this.protecaoAtual <= 0)
        {
            Desativar();
        }
    }

}

