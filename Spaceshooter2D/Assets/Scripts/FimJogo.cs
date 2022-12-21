using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{
    [SerializeField] private Text textoPontuacao;
    [SerializeField] private Text textMelhorPontuacao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
        this.textMelhorPontuacao.text = ControladorPontuacao.MelhorPontuacao.ToString();

        Debug.Log("Melhor pontucao" + ControladorPontuacao.MelhorPontuacao);

        // pausar o jogo
        Time.timeScale = 0;
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("Fase01");
        // retomar o jogo
        Time.timeScale = 1;
    }

}