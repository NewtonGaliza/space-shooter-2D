 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    public float velocidadeMovimento;

    [SerializeField] private Laser laserPrefab;
    private float intervaloTiro;

    [SerializeField] private float tempoEsperaTiro;

    public Transform[] posicoesArmas;
    private Transform armaAtual;

    // Start is called before the first frame update
    void Start()
    {
        this.intervaloTiro = 0;  
        this.armaAtual = this.posicoesArmas[0];
        ControladorPontuacao.Pontuacao = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector2(horizontal * velocidadeMovimento, vertical * velocidadeMovimento);

        this.intervaloTiro += Time.deltaTime;

        //atira a cada 1 segundo
        if(this.intervaloTiro >= this.tempoEsperaTiro)
        {
            //reseta a contgem de tempo
            this.intervaloTiro = 0;
            Atirar();

        }
    }

    private void Atirar()
    {
        //criando o tio na mesma posição da nave
        Instantiate(this.laserPrefab, this.armaAtual.position, Quaternion.identity);
        if(this.armaAtual == this.posicoesArmas[0])
        {
            this.armaAtual = this.posicoesArmas[1];
        } 
        else
        {
            this.armaAtual = this.posicoesArmas[0];
        }

    }
}
