 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float intervaloTempoAntesAutodestruir;
    private float contagemTempoAntesUtodestruir;     
    private bool autoDestruindo;
    [SerializeField] private float intervaloTempoEntrePiscadas;
    [SerializeField] private int quantidadeTotalPiscadas;
    [SerializeField] private float reducaoTempoEntrePiscadas;

    [SerializeField] private float duracaoEmSegundos;

    public abstract EfeitoPowerUp EfeitoPowerUp { get; }

    private void Start()
    {
        this.contagemTempoAntesUtodestruir = 0;  
        this.autoDestruindo = false;      
    }

    private void Update()
    {
        if(!this.autoDestruindo)
        {
            this.contagemTempoAntesUtodestruir += Time.deltaTime;        
            if(this.contagemTempoAntesUtodestruir >= this.intervaloTempoAntesAutodestruir)
            {
                IniciarAutoDestricao();
            }
        }
    }

    public void Coletar()
    {
        Destroy(this.gameObject);
    }

    public void IniciarAutoDestricao()
    {
        this.autoDestruindo = true;
       
        StartCoroutine(AutoDestruir());
    }

    private IEnumerator AutoDestruir()
    {
        int contadorPiscadas = 0;
        do
        {
            this.spriteRenderer.enabled = !this.spriteRenderer.enabled;
            contadorPiscadas++;
            yield return new WaitForSeconds(this.intervaloTempoEntrePiscadas);
            this.intervaloTempoEntrePiscadas -= contadorPiscadas * this.reducaoTempoEntrePiscadas;            
        }
        while(contadorPiscadas < this.quantidadeTotalPiscadas);

        Destroy(this.gameObject);
    }

    public float DuracaoEmSegundos
    {
        get
        {
            return this.duracaoEmSegundos;
        }
    }



}
