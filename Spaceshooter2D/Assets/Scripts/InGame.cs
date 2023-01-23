using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textoPontuacao;
    public BarraVida barraVida;
    private NaveJogador jogador;
    [SerializeField] private TelaPause telaPause;



    // Start is called before the first frame update
    void Start()
    {
        this.telaPause.Desativar();
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textoPontuacao.text = ControladorPontuacao.Pontuacao + "X";
        this.barraVida.ExibirVida(this.jogador.Vida);
    }

    public void Pausar()
    {
        this.telaPause.Ativar();
    }
}
