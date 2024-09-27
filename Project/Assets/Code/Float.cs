using UnityEngine;
using UnityEngine.UIElements;

public class Float : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (speed != 0.0f)
        {
            transform.position = startPos + Vector3.up * Mathf.Cos(Time.time * speed) * amplitude;
        }
    }
}