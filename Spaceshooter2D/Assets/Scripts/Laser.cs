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
        this.rigidbody.velocity = new Vector2(0, this.velocidadeY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo"))
        {
            //destroi o inimigo
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.Destruir(true);
            //destroi o tiro
            Destroy(this.gameObject);
        }
    }
}
