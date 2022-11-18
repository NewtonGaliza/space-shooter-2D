using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;

    private float velocidadeY;

    public ParticleSystem particulaExplosaoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima);
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
}
