using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Action : MonoBehaviour, IComparable
{
    // Usuario
    public Battler usuario;

    // Prioridad
    public int prioridad;

    // Efecto de la acción
    public abstract void Efecto(BattleManager batalla);

    // Compara dos acciones en función de su prioridad y la velocidad de sus usuarios
    public int CompareTo (System.Object objeto) {
        if (objeto is Action) {
            Action accion = (Action) objeto;
            // Comparar prioridades
            int compare = accion.prioridad - prioridad;

            // Igualdad de prioriades
            if (compare == 0) {
                // Comparar velocidades
                compare = accion.usuario.velocidad - usuario.velocidad;
            }

            return compare;
        } else {
            return 0;
        }
    }
}
