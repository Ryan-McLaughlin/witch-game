using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("Destroying " + name);
        Destroy(gameObject);
    }
}
