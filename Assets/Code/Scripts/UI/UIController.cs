using UnityEngine;

/// <summary>
/// By Mads:
/// Handles the display of UI elements.
/// Includes static references to all UI elements as well as a method to reset the UI to its default state.
/// </summary>

public class UIController : MonoBehaviour
{
    public bool showInventory;
    public bool showMap;
    public bool inventoryToggleEnabled;
    public bool mapOpen;
    //public bool roomTextEnabled;

    public static GameObject textDisplay;
    public static GameObject inventory;
    public static GameObject interactPrompt;
    public static GameObject interactionMenu;
    public static GameObject sizeChangeWarning;
    public static GameObject map;

    

    private void Awake()
    {
        textDisplay = transform.GetChild(0).gameObject;
        inventory = transform.GetChild(1).gameObject;
        interactPrompt = transform.GetChild(2).gameObject;
        interactionMenu = transform.GetChild(3).gameObject;
        sizeChangeWarning = transform.GetChild(4).gameObject;
        map = transform.GetChild(5).gameObject;
        

        ResetToDefault();
    }

    private void Start()
    {
        //inventory and actions are hidden at the start
        inventory.SetActive(false);
        interactPrompt.SetActive(false);
        interactionMenu.SetActive(false);
       
    }
    private void Update()
    {
        showInventory = !inventory.activeSelf; //should return the opposite of activeSelf I hope
        showMap = !map.activeSelf;
        inventoryToggleEnabled = !interactionMenu.activeSelf;

        if (InputManager.ToggledInventory() && inventoryToggleEnabled)
        {
            inventory.SetActive(showInventory);

            RectTransform textTransform = textDisplay.GetComponent<RectTransform>();
            if (inventory.activeSelf)
            {
                //Move the text display up
                textTransform.anchoredPosition = new Vector3(0, 100, 0);
            }
            else
            {
                //Move the text display down
                textTransform.anchoredPosition = Vector3.zero;
            }
        }

        if (GameManager.instance.firstMapCollected && InputManager.ToggledMap())
        {
            //show map on the screen
            map.SetActive(showMap);
            mapOpen = showMap;
        }

        if (mapOpen && GameManager.instance.secondMapCollected)
        {
            if (InputManager.SwitchedMap())
            {
                if (map.transform.GetChild(0).gameObject.activeSelf)
                {
                    map.transform.GetChild(0).gameObject.SetActive(false);
                    map.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    map.transform.GetChild(0).gameObject.SetActive(true);
                    map.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public static void ResetToDefault()
    {
        inventory.SetActive(false);
        textDisplay.SetActive(true);
        interactionMenu.SetActive(false);

        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
