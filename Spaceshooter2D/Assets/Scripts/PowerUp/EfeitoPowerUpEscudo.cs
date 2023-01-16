using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        jogador.AtivarEscudo();
    }
}
