using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    [SerializeField] 
    Text BulletAmount;

    [SerializeField] GameObject InventoryObject;
    private Inventory InventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        BulletAmount.text = SaveScript.Bullets.ToString();

        InventoryScript = InventoryObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletAmount.text = SaveScript.Bullets.ToString();

        if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(SaveScript.Bullets > 0 && InventoryScript.InventoryActive == false)
            {
                SaveScript.Bullets -= 1;
               
            }
        }
    }
}
