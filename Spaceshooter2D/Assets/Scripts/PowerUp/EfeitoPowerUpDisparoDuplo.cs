using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoDuplo : EfeitoPowerUp
{
    //metodo construtor
    public EfeitoPowerUpDisparoDuplo(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
        
    }


    public override void Aplicar(NaveJogador jogador)
    {
        // acessar o script do jogador
        // alterar o arma usada no controlador arma
        jogador.EquiparArmaDisparoDuplo();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
