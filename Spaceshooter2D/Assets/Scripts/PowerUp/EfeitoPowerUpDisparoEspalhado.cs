using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpDisparoEspalhado : EfeitoPowerUp
{
    public EfeitoPowerUpDisparoEspalhado(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {
    }

    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoEspalhado();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
