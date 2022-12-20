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

    [SerializeField] private int vidas;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public Transform[] posicoesArmas;
    private Transform armaAtual;

    private FimJogo telaFimJogo;

    // Start is called before the first frame update
    void Start()
    {
        this.vidas = 5;
        this.intervaloTiro = 0;  
        this.armaAtual = this.posicoesArmas[0];
        ControladorPontuacao.Pontuacao = 0;

        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();
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

        VerificarLimiteTela();   
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

    public int Vida
    {
        get
        {
            return this.vidas;
        }

        set
        {
            this.vidas = value;
            if (this.vidas <= 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                telaFimJogo.Exibir();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Inimigo"))
        {
            Vida--;
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            inimigo.ReceberDano();
        }
    }

    private void VerificarLimiteTela()
    {
        Vector2 posicaoAtual = this.transform.position;

        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // (0, 0) no plano cartesiano
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // (1, 1) no plano cartesiano

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;

        //saindo pela esquerda
        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
        {
            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);
        } else if (pontoReferenciaDireito > limiteSuperiorDireito.x) //saindo pela direita
        {
            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);
        }

        // nao permitir que o jogador saia da tela pelos cantos diagonais
        posicaoAtual = this.transform.position;

        float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;

        //saindo por cima
        if (pontoReferenciaSuperior > limiteSuperiorDireito.y)
        {
            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);
        } else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y) //saindo por baixo
        {
            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);
        }
    }

    private float Largura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }

    private float Altura
    {
        get
        {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;
        }
    }
}
