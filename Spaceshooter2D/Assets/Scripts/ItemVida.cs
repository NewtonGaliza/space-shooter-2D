using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    [SerializeField] private int quantidadeVidas;

    [SerializeField] private ParticleSystem particulaPrefab;

    public int QuantidadeVidas
    {
        get
        {
            return this.quantidadeVidas;
        }
    }

    public void Coletar()
    {
        //cria, exibe e destroi a particula
        ParticleSystem particula = Instantiate(this.particulaPrefab, this.transform.position, Quaternion.identity);
        Destroy(particula.gameObject, 1f);

        //destroi o item vida
        Destroy(this.gameObject);
    }










}
