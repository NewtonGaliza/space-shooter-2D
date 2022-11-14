using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;

    private float velocidadeY;

    // Start is called before the first frame update
    void Start()
    {
        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        //como inimigo sé se movimenta de cima para baixo, o valor X é zerado
        //negativando a velocidadeY para o inimiog se moverr para baixo
        this.rigidbody.velocity = new Vector2(0, -this.velocidadeY);
    }

    public void Destruir(bool derrotado)
    {
        if(derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }
        Destroy(this.gameObject);
    }
}
