using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Enemies : MonoBehaviour{
    public static Enemies main;
    public Bot[] mobs;
    public Bot[] bosses;
    public void Awake() => Enemies.main = this;
}
