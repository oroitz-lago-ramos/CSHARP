using System.Linq;
using UnityEngine;
public class Team : MonoBehaviour{
    public static Team main;
    public Entity[] members;

    private void Awake()
    {
        main = this;
        this.members.ToList().ForEach(x=>x.ResetStats(true));
    }

    public void Swap(int index)
    {
        if (index < members.Length)
        {
            Entity temp = members[0];
            members[0] = members[index];
            members[index] = temp;
        }
    }
}
