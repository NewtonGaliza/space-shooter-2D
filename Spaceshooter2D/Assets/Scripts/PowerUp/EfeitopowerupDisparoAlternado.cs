using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitopowerupDisparoAlternado : EfeitoPowerUp
{
    //metodo construtor
    public EfeitopowerupDisparoAlternado(float duracaoEmSegundos) : base(duracaoEmSegundos)
    {

    }


    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }

    public override void Remover(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
