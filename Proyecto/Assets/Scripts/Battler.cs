using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : Object
{
    // Clase que encapsula datos sobre un luchador

    // Stats
    public int HP;
    public int maxHP;
    public int speed;

    // Constructor
    public Battler(int HP, int maxHP, int speed) {
        this.HP = HP;
        this.maxHP = maxHP;
        this.speed = speed;
    }
}
