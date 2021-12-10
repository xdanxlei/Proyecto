using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    // Objetivo
    public Battler objetivo;

    // Damage dealt
    public int damage;
    
    public override void Efecto(BattleManager batalla){
        // Comprobar que haya un objetivo seleccionado
        if (objetivo is null) {
            objetivo = usuario.ElegirObjetivo(batalla, this);
        }

        usuario.Animacion("Action");
        objetivo.PerderVida(damage);
    }
}
