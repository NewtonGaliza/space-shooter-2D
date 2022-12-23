using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoDuplo : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        // acessar o script do jogador
        // alterar o arma usada no controlador arma
        jogador.EquiparArmaDisparoDuplo();
    }
}
