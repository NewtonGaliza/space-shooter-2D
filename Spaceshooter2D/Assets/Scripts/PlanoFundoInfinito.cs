using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoFundoInfinito : MonoBehaviour
{
    //por ser um objeto 3d vai ser usado o Renderer
    [SerializeField] private Renderer renderer;

    //velocidade que o plano de fundo vai ficar passando
    [SerializeField] private float velocidade;

    private Material material;
    private Vector2 offsetMaterial;


    // Start is called before the first frame update
    void Start()
    {
        //pegando o material que esta no renderer
        this.material = this.renderer.material;
        this.offsetMaterial = this.material.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        this.offsetMaterial.y -= this.velocidade * Time.deltaTime;
        this.material.SetTextureOffset("_MainTex", this.offsetMaterial);
    }
}
