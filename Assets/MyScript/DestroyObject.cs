using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] float DestroyTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTimer);
    }

}
