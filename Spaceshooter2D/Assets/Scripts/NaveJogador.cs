using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    private const int QuantidadeMaximaVidas = 5; 
    [SerializeField] private Rigidbody2D rigidbody;
    public float velocidadeMovimento;

    [SerializeField] private int vidas;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private FimJogo telaFimJogo;

    [SerializeField] private ControladorArma controladorArma;
    [SerializeField] private Escudo escudo;



    // Start is called before the first frame update
    void Start()
    {
        this.vidas = QuantidadeMaximaVidas;
        
        ControladorPontuacao.Pontuacao = 0;
        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();

        EquiparArmaDisparoAlternado();

        this.escudo.Desativar();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector2(horizontal * velocidadeMovimento, vertical * velocidadeMovimento);
        VerificarLimiteTela();   
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
            if (this.vidas > QuantidadeMaximaVidas)
            {
                this.vidas = QuantidadeMaximaVidas;
            } else if (this.vidas <= 0)
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
            Inimigo inimigo = collider.GetComponent<Inimigo>();
            ColidirInimigo(inimigo);
        } else if (collider.CompareTag("ItemVida")) 
        {
            ItemVida itemVida = collider.GetComponent<ItemVida>();
            ColetarVida(itemVida);
        } else if (collider.CompareTag("PowerUp"))
        {
            PowerUpColetavel powerUp = collider.GetComponent<PowerUpColetavel>();
            ColetarPowerUp(powerUp);
        }
    }

    private void ColidirInimigo(Inimigo inimigo)
    {
        if(this.escudo.Ativo)
        {
            this.escudo.DanoNoEscudo();
        }
        else
        {
            Vida--;
        }
        inimigo.ReceberDano();
    }
    
    private void ColetarVida(ItemVida itemVida)
    {
        Vida += itemVida.QuantidadeVidas;
        itemVida.Coletar();
    }

    private void ColetarPowerUp(PowerUpColetavel powerUp)
    {
        EfeitoPowerUp efeitoPowerUp = powerUp.EfeitoPowerUp;
        efeitoPowerUp.Aplicar(this);
        powerUp.Coletar();
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

    public void EquiparArmaDisparoAlternado()
    {
        this.controladorArma.EquiparArmaDisparoAlternado();
    }

    public void EquiparArmaDisparoDuplo()
    {
        this.controladorArma.EquiparArmaDisparoDuplo();
    }

    public void AtivarEscudo()
    {
        this.escudo.Ativar();
    }
}
