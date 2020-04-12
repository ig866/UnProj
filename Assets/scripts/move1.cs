using UnityEngine;

public class move1 : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, -1);

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}