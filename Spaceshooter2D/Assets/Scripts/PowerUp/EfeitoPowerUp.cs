using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EfeitoPowerUp
{
   private float duracaoEmSegundos;

   public abstract void Aplicar(NaveJogador jogador);

   public abstract void Remover(NaveJogador jogador);  

   public EfeitoPowerUp(float duracaoEmSegundos)
   {
      this.duracaoEmSegundos = duracaoEmSegundos;
   }

   public void Atualizar()
   {
      if(Ativo)
      {
         this.duracaoEmSegundos -= Time.deltaTime;
      }
   }

   public bool Ativo
   {
      get
      {
         return (this.duracaoEmSegundos > 0);
      }
   }






















}
