using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorMouse : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;
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
        Vector2 posicaoMouse = Input.mousePosition;
        Vector2 posicaoMundo = this.camera.ScreenToWorldPoint(posicaoMouse);

        Vector2 novaPosicao = Vector2.Lerp(this.transform.position, posicaoMundo, (this.velocidadeMovimento * Time.deltaTime));
        this.rigidbody2d.position = novaPosicao;
    }
}
