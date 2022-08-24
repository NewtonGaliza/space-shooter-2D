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

    // Start is called before the first frame update
    void Start()
    {
        this.intervaloTiro = 0;   
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
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
}
