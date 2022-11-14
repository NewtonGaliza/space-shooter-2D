using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private GameObject[] barrasVermelhas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExibirVida(int vidas)
    {
        for(int i = 0; i < this.barrasVermelhas.Length; i++)
        {
            if(i < vidas)
            {
                this.barrasVermelhas[i].SetActive(true);
            }
            else
            {
                this.barrasVermelhas[i].SetActive(false);
            }
        }
    }
}
