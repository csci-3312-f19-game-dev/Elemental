using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStats
{
    public static int health, level, exp;
    public static int[] elements;
    public static Vector3 playerPosition;
    public static ArrayList killedEnemies = new ArrayList { };
    public static int perkPoints;
    public static int score;
    public static int maxHealth;
    public static int lastScene;

    public static Combatant enemy;

    public static int enemyID;

    public static bool init = false;

    public static bool justLoaded = true;

}
