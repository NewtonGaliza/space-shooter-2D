using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float velocidadeY;

    // Start is called before the first frame update
    void Start()
    {
        // this.rigidbody.velocity = new Vector2(0, this.velocidadeY);

        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomLaser();
        Direcao = this.transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaoCamera = camera.WorldToViewportPoint(this.transform.position);
        if(posicaoCamera.y > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo"))
        {
            //destroi o inimigo
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano();
            //destroi o tiro
            Destroy(this.gameObject);
        }
    }


    //usado para a rotacao dos tiros o disparo espalhado
    public Vector2 Direcao
    {
        set
        {
            this.transform.up = value;
            
            //usado na aula #27
            this.rigidbody.velocity = this.transform.up * this.velocidadeY;
        }
    }

}
