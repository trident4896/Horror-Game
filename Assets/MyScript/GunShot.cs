using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] GameObject InventoryObject;
    private Inventory InventoryScript;

    private AudioSource MyPlayer;
    [SerializeField] AudioClip GunShotSound;
    // Start is called before the first frame update
    void Start()
    {
        InventoryScript = InventoryObject.GetComponent<Inventory>();

        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.HaveGun == true && InventoryScript.InventoryActive == false)
        {
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (SaveScript.Bullets > 0)
                {
                    MyPlayer.clip = GunShotSound;
                    MyPlayer.Play();

                    if (Physics.Raycast(transform.position, transform.forward, out hit, 3000))
                    {
                        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                        Debug.DrawRay(transform.position, forward, Color.blue);

                        if (hit.transform.Find("Body"))
                        {

                            hit.transform.gameObject.GetComponentInChildren<EnemyDamage>().EnemyHealth -= Random.Range(20, 51);
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("BigReact");
                        }
                    }
                }
            }
        }
    }
}
