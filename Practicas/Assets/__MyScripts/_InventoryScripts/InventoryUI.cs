using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryMenu;

    /*Nuevo*/
    public Inventory inventory;

    /*Camaras*/
    public GameObject gameCamera;
    public GameObject menuCamera;

    /*Luces*/
    public GameObject normalLight;
    public GameObject menuLight;

    /*Button*/
    public GameObject gameButtons;
    public GameObject menuButtons;


    // Start is called before the first frame update
    void Start()
    {
        /*Mio*/
        menuCamera.SetActive(false);
        menuLight.SetActive(false);
        menuButtons.SetActive(false);

        /*Nuevo*/
        // inventory = FindObjectOfType<Inventory>();
        inventory = Inventory.inventoryInstance;

        if (inventory == null)
        {
            return; 
        }

        inventoryMenu.SetActive(false);

        /*Asignamos suscriptor*/
        inventory.onChange += UpdateUI;

    }

    // Update is called once per frame
    void Update()
    {
      //  if (Input.GetKeyDown(KeyCode.M))
      if(CrossPlatformInputManager.GetButtonDown("Fire2") || CrossPlatformInputManager.GetButtonDown("Fire4"))
        {
            //cambio de camara
            gameCamera.SetActive(!gameCamera.activeSelf);
            menuCamera.SetActive(!menuCamera.activeSelf);
          
            //Activamos/desactivamos
            normalLight.SetActive(!normalLight.activeSelf);
            menuLight.SetActive(!menuLight.activeSelf);

            //Cambio de botones
            gameButtons.SetActive(!gameButtons.activeSelf);
            menuButtons.SetActive(!gameButtons.activeSelf);

            //Activamos/desactivamos inventario
            inventoryMenu.SetActive(!inventoryMenu.activeSelf);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();

        for (int i = 0; i < slots.Length; i++)
            if (i < inventory.items.Count && inventory.items.Count <= inventory.space)
            {
               // Debug.LogWarning(inventory.items.Count.ToString() + " items");
                slots[i].setItem(inventory.items[i]);
                slots[i].GetComponent<Button>().enabled = true;
            }
            else
            {
                if(i < slots.Length - 3) //trucazo, tengo 3 slots que son para weapon, por eso hay problemas
                    slots[i].itemCount.text = "0";
                slots[i].clear();
            }
    }
}
