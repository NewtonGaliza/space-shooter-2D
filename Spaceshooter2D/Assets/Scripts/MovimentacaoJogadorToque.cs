using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorToque : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocidadeMovimento;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            Vector2 posicaoToque = toque.position;
            Vector2 posicaoNoMundo = this.camera.ScreenToViewportPoint(posicaoToque);

            Vector2 novaPosicao = Vector2.Lerp(this.transform.position, posicaoNoMundo, (this.velocidadeMovimento * Time.deltaTime));
            this.rigidbody2D.position = novaPosicao;
        }
    }
}
