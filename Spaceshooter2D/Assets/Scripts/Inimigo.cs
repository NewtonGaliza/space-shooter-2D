using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;
    public int vidas; //quantidade de vida do inimigo

    private float velocidadeY;

    public ParticleSystem particulaExplosaoPrefab;

    [SerializeField] private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima);

        Vector2 posicaoAtual = this.transform.position;
        float metadeLargura = Largura / 2f;

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoRefereciaDireito = posicaoAtual.x + metadeLargura;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); //(0, 0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); //(0, 1)

        //saindo pela esquerda
        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
        {
            float posicaoX = limiteInferiorEsquerdo.x + metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        } else if (pontoRefereciaDireito > limiteSuperiorDireito.x)
        {
            float posicaoX = limiteSuperiorDireito.x - metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //como inimigo só se movimenta de cima para baixo, o valor X é zerado
        //negativando a velocidadeY para o inimiog se moverr para baixo
        this.rigidbody.velocity = new Vector2(0, -this.velocidadeY);

        //Camera.main retorna a camera principal do jogo
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if(posicaoNaCamera.y < 0)
        {
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--;
            Destruir(false);
        }
    }

    public void ReceberDano()
    {
        this.vidas--;
        if(this.vidas <= 0)
        {
            Destruir(true);
        }
    }

    public void Destruir(bool derrotado)
    {
        if(derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }

        ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); //destroi a particula aops 1 segundo

        Destroy(this.gameObject);
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
}
