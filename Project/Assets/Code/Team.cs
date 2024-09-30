using UnityEngine;
public class Team : MonoBehaviour{
    public Entity[] members;
    public static Team main;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else if (main != this)
        {
            Destroy(gameObject);
        }
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
