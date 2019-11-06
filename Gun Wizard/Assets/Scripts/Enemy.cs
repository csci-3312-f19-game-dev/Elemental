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
        EnemyCombatant.health = 3;
        EnemyCombatant.elementLevels = new int[]{ 1, 0, 1, 0, 0 };
        EnemyCombatant.ammo = 1;
        EnemyCombatant.shields = 1;
    }

    public int getElement(){
        int[] possibleElems = Enumerable.Range(0, 5).Where(i => EnemyCombatant.elementLevels[i] > 0).ToArray();
        int elementChoice = Random.Range(0, possibleElems.Length);
        return possibleElems[elementChoice];
    }
    public int getAction(){
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
