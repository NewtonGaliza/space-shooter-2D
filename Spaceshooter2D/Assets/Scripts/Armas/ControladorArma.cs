using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] private ArmaDisparoAlternado armaDisparoAlternado;
    [SerializeField] private ArmaDisparoDuplo armaDisparoDuplo;
    private ArmaBasica armaAtual;

    private void Awake()
    {
        this.armaDisparoAlternado.Desativar();
        this.armaDisparoDuplo.Desativar();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}