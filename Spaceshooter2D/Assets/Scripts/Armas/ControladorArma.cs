using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] private ArmaDisparoAlternado armaDisparoAlternado;
    [SerializeField] private ArmaDisparoDuplo armaDisparoDuplo;
    [SerializeField] private ArmaDisparoEspalhado armaDisparoEspalhado;
    private ArmaBasica armaAtual;

    private void Awake()
    {
        this.armaDisparoAlternado.Desativar();
        this.armaDisparoDuplo.Desativar();
        this.armaDisparoEspalhado.Desativar();
    }


    private ArmaBasica ArmaAtual
    {
        set
        {
            if (this.armaAtual != null)
            {
                this.armaAtual.Desativar();
            }
            this.armaAtual = value;
            this.armaAtual.Ativar();
        } 
    }

    public void EquiparArmaDisparoAlternado()
    {
        this.ArmaAtual = this.armaDisparoAlternado;
    }

    public void EquiparArmaDisparoDuplo()
    {
        this.ArmaAtual = this.armaDisparoDuplo;
    }

    public void EquiparArmaDisparoEspalhado()
    {
        this.ArmaAtual = this.armaDisparoEspalhado;
    }
}