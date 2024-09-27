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

}
