using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoEspalhado : ArmaBasica
{
    [SerializeField, Range(1, 30)] private int quantidadeDisparos;
    [SerializeField, Range(0f, 30f)] private float anguloEntreDisparos;


    protected override void Atirar()
    {
        Vector2 posicaoDisparo = this.posicoesDisparo[0].position;

        for (int i = 0; i < this.quantidadeDisparos; i++)
        {
            Laser laser = CriarLaser(posicaoDisparo);
            laser.Direcao = CalcularDirecaoDisparo(i);
        }
    }

    private Vector2 CalcularDirecaoDisparo(int indiceDisparo)
    {
        int indiceDisparoArco;

        if((this.quantidadeDisparos % 2) == 0)
        {
            //nao utilizar o valor zero no calculo do angulo, para nao ter tiro dispardo no meio
            indiceDisparoArco = indiceDisparo + 1;
        }
        else
        {
            indiceDisparoArco = indiceDisparo;
        }

        /*
        
        #referencia para os indices

        indices divididos por dois e arredondados para cima, tendo assim dois indicies iguais
        1 / 2 = 0.5  => 1
        2 / 2 = 1    => 1
        3 / 2 = 1.5  => 2
        4 / 2 = 2    => 2
        5 / 2 = 2.5  => 3
        6 / 2 = 3    => 3        
        
        */

        indiceDisparoArco = Mathf.CeilToInt(indiceDisparoArco / 2f);

        float angulo = (this.anguloEntreDisparos * indiceDisparoArco);

        //invertendo o angulo caso o indice do disparo seja impar
        if((indiceDisparo % 2) != 0)
        {
            angulo *= -1;
        }

        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);

        Vector2 direcao = rotacao * Vector3.up;

        return direcao;
    }



}
 