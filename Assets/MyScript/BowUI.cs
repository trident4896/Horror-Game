using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowUI : MonoBehaviour
{
    [SerializeField] 
    Text ArrowAmount;

    [SerializeField] GameObject InventoryObject;
    private Inventory InventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        ArrowAmount.text = SaveScript.Arrows.ToString();

        InventoryScript = InventoryObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
       ArrowAmount.text = SaveScript.Arrows.ToString();

        if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (SaveScript.Arrows > 0 && InventoryScript.InventoryActive == false)
            {
                SaveScript.Arrows -= 1;

            }
        }
    }
}
