using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfStateAction : Action
{
    // Estado
    public State estado;
    
    public override void Efecto(BattleManager batalla){
        // Añadir el estado
        usuario.AddEstado(estado);
    }

}
