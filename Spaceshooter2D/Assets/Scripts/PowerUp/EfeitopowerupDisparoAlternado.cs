using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitopowerupDisparoAlternado : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
