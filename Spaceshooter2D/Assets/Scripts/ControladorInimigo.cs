using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    //inimigo original que será usado para copiar/criar um novo inimigo
    public Inimigo inimigoPequenoPrefab;
    public Inimigo inimigoGrandePrefab;
    private float tempoDecorrido;


    // Start is called before the first frame update
    void Start()
    {
        this.tempoDecorrido = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.tempoDecorrido += Time.deltaTime;
        
        //após 1 segundo, cria um inimigo
        if(this.tempoDecorrido >= 1f)
        {
            //calcular a posição de spawn do inimigo
            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            
            float posicaoX =Random.Range(posicaoMinima.x, posicaoMaxima.x);

            //cposicionar o inimigo no limite superior da tela
            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y);

            Inimigo prefabInimigo;

            //chance entre 0 e 100%
            float chance = Random.Range(0f, 100f);
            //chance de 25% de criar o inimigo grande
            if (chance <= 25)
            {
                prefabInimigo = this.inimigoGrandePrefab;
            }
            else
            {
                prefabInimigo = this.inimigoPequenoPrefab;
            }

            //criar uma copia do prefab inimigo, na posiciao dele e sem rotação
            Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
            this.tempoDecorrido = 0;
        }
    }
}
