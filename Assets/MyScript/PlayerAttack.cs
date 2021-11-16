using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator Anim;

    public float AttackStamina = 10;
    [SerializeField] float MaxAttackStamina = 10;
    [SerializeField] float StaminaDecay = 1;
    [SerializeField] float StaminaRefill = 1;
    [SerializeField] GameObject Crosshair;
    [SerializeField] GameObject Pointer;

    [SerializeField] GameObject InventoryObject;
    private Inventory InventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        AttackStamina = MaxAttackStamina;

        InventoryScript = InventoryObject.GetComponent<Inventory>();

        Crosshair.gameObject.SetActive(false);
        Pointer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackStamina > 3.0f)
        {
            if (SaveScript.HaveKnife == true && InventoryScript.InventoryActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("KnifeLMB");
                    AttackStamina -= StaminaDecay;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("KnifeRMB");
                    AttackStamina -= StaminaDecay;
                }
            }

            if (SaveScript.HaveBat == true && InventoryScript.InventoryActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("BatLMB");
                    AttackStamina -= StaminaDecay;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("BatRMB");
                    AttackStamina -= StaminaDecay;
                }
            }

            if (SaveScript.HaveAxe == true && InventoryScript.InventoryActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Anim.SetTrigger("AxeLMB");
                    AttackStamina -= StaminaDecay;
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetTrigger("AxeRMB");
                    AttackStamina -= StaminaDecay;
                }
            }

            if (SaveScript.HaveGun == true && InventoryScript.InventoryActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimGun", true);

                    Pointer.gameObject.SetActive(false);
                    Crosshair.gameObject.SetActive(true);
                }

                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimGun", false);

                    Pointer.gameObject.SetActive(true);
                    Crosshair.gameObject.SetActive(false);
                }
            }


            if (SaveScript.HaveBow == true && InventoryScript.InventoryActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimGun", true);

                    Pointer.gameObject.SetActive(false);
                    Crosshair.gameObject.SetActive(true);
                }

                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    Anim.SetBool("AimGun", false);

                    Pointer.gameObject.SetActive(true);
                    Crosshair.gameObject.SetActive(false);
                }
            }
        }

        if(AttackStamina < MaxAttackStamina)
        {
            AttackStamina += StaminaRefill * Time.deltaTime;
        }

        if(AttackStamina <= 0.1)
        {
            AttackStamina = 0.1f;
        }
    }
}
