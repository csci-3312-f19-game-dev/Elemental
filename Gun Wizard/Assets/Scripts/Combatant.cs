using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract int health;
    public abstract int[] elementLevels;
    public abstract void takeDamage(int damage);

}
