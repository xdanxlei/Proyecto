using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Battler : MonoBehaviour
{
    // Clase que encapsula datos sobre un luchador

    // Stats
    public int HP;
    public int maxHP;
    public int velocidad;

    // Equipo en la batalla
    public string equipo;

    // Acciones que puede realizar
    public List<Action> acciones = new List<Action>();

    // Estados que posee
    public List<State> estados = new List<State>();

    // Decide si el luchador puede combatir
    public bool PuedeLuchar(){
        return HP > 0;
    }

    // El luchador pierde la cantidad de vida indicada
    public void PerderVida(int vida) {
        // Disminuir daño si se está defendiendo
        foreach (State estado in estados)
        {
            if (estado.id.Equals("defendido")){
                vida /= 2;
                break;
            }
        }

        // Perder vida
        HP -= vida;
        if (HP < 0) {
            HP = 0;
        }

        // Obtener slider del combatiente
        Slider slider = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Slider>();
        Text texto = transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<Text>();

        // Modificar slider
        slider.value = HP;
        texto.text = HP.ToString() + "/" + maxHP.ToString();
    }

    // El luchador adquiere el estado
    public void AddEstado(State estadoNuevo) {
        // Comprobar que no se posee ya el estado
        foreach (State estado in estados)
        {
            if (estado.id == estadoNuevo.id){
                // Reiniciar turnos
                estado.turnos = Math.Max(estado.turnos, estadoNuevo.turnos);
                return;
            }
        }
        estados.Add(estadoNuevo);
    }

    // Fin de turno
    public void FinTurno() {
        AvanzarEstados();
    }

    // Disminuir la duración de los estados y borrarlos si procede
    public void AvanzarEstados() {
        List<State> eliminar = new List<State>();
        foreach (State estado in estados)
        {
            estado.turnos--;
            if (estado.turnos <= 0){
                eliminar.Add(estado);
            }
        }
        foreach (State estado in eliminar)
        {
            estados.Remove(estado);
            Destroy(estado);
        }
    }

    // IA básica placeholder

    // Elegir una acción a realizar
    public Action ElegirAccion(BattleManager batalla){
        Action accion = acciones[0];
        accion.usuario = this;
        return accion;
    }

    // Elegir el objetivo de una acción
    public Battler ElegirObjetivo(BattleManager batalla, Action accion){
        if (equipo.Equals("aliados")) {
            return batalla.enemigos[0].GetComponent<Battler>();
        } else {            
            return batalla.aliados[0].GetComponent<Battler>();
        }
    }
}
