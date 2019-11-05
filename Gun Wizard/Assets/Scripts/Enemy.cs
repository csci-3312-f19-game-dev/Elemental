using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Enemy : MonoBehaviour
{
    // Use this for initialization
    public GameObject Player;
    public Combatant EnemyCombatant;


    void Start() {
        EnemyCombatant.health = 20;
        EnemyCombatant.elementLevels = new int[]{ 1, 0, 1, 0, 0 };
        EnemyCombatant.numAttacks = 1;
        EnemyCombatant.numShields = 1;

    }

    public int getElement(){
        int[] possibleElems = Enumerable.Range(0, 5).Where(i => EnemyCombatant.elementLevels[i] > 0).ToArray();
        int elementChoice = Random.Range(0, possibleElems.Length);
        return possibleElems[elementChoice];
    }
    public int getAction(){
        return Random.Range(0, 3);
    }
}
