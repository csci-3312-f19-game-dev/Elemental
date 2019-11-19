using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Enemy : MonoBehaviour
{
    // Use this for initialization
    public GameObject Player;
    private Combatant EnemyCombatant;



    void Start() {
        EnemyCombatant = gameObject.GetComponent<Combatant>();
        EnemyCombatant.health = GlobalStats.enemy.health;
        EnemyCombatant.elementLevels = GlobalStats.enemy.elementLevels;
        EnemyCombatant.exp = GlobalStats.enemy.exp;
        EnemyCombatant.ammo = 1;
        EnemyCombatant.shields = 1;
        EnemyCombatant.id = GlobalStats.enemy.id;
    }

    public int getElement(){
        int[] possibleElems = Enumerable.Range(0, 5).Where(i => EnemyCombatant.elementLevels[i] > 0).ToArray();
        int elementChoice = Random.Range(0, possibleElems.Length);
        return possibleElems[elementChoice];
    }
    public int getAction(){
        if (EnemyCombatant.ammo > 2) return 0;
        int act =  Random.Range(0, 3);
        if(act == 0)
        {
            if(EnemyCombatant.ammo > 0)
            {
                return act;
            }
            else
            {
                return 2;
            }
        }
        if (act == 1)
        {
            if (EnemyCombatant.shields > 0)
            {
                return act;
            }
            else
            {
                return 3;
            }
        }
        else
        {
            return act;
        }

    }
}
