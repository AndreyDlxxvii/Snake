using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;

    public Transform vertical_left;
    public Transform vertical_right;
    public Transform horisontal_up;
    public Transform horisontal_down;
    void Start()
    {
        InvokeRepeating("Spawn", 0, 10);
    }

   void Spawn ()
    {
        var x = Random.Range(vertical_left.position.x, vertical_right.position.x);
        var y = Random.Range(horisontal_down.position.y, horisontal_up.position.y);
        Vector2 vector = new Vector2(x, y);
        GameObject temp = Instantiate(foodPrefab, vector, Quaternion.identity);
    }


}
