using UnityEngine;

namespace Nokobot.Assets.Crossbow
{
    public class CrossbowShoot : MonoBehaviour
    {
        public GameObject arrowPrefab;
        public Transform arrowLocation;

        public float shotPower = 100f;

        [SerializeField] private float destroy_timer = 10f;

        private AudioSource MyPlayer;
        [SerializeField] AudioClip BowShotSound;

        [SerializeField] GameObject InventoryObject;
        private Inventory InventoryScript;

        void Start()
        {
            if (arrowLocation == null)
            {
                arrowLocation = transform;
            }

            InventoryScript = InventoryObject.GetComponent<Inventory>();

            MyPlayer = GetComponent<AudioSource>();
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (SaveScript.HaveBow == true && InventoryScript.InventoryActive == false)
                {
                    if (SaveScript.Arrows > 0)
                    {
                        MyPlayer.clip = BowShotSound;
                        MyPlayer.Play();

                        GameObject arrow_casing;

                        arrow_casing = Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation) as GameObject;
                        arrow_casing.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);

                        Destroy(arrow_casing, destroy_timer);
                    }
                }
            }
        }
    }
}
