using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    public Laser laserPrefab;
    private float intervaloTiro;
    public float tempoEsperaTiro;
    public Transform[] posicoesDisparo;

    // Start is called before the first frame update 
    public virtual void Start()
    {
        this.intervaloTiro = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.intervaloTiro += Time.deltaTime;
        if(this.intervaloTiro >= this.tempoEsperaTiro)
        {
            this.intervaloTiro = 0;
            Atirar();
        }
    }

    protected void CriarLaser(Vector2 posicao)
    {
        Instantiate(this.laserPrefab, posicao, Quaternion.identity);
    }    

    protected abstract void Atirar();
}
