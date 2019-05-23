using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Options : MonoBehaviour
{
    //Attach me to a canvas!

    public GameObject optionsPrefab;
    private GameObject optionsMenu;

    public GameObject cameraScene;

    private bool isInUse = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Escape) && isInUse == false)
        {
            isInUse = true;
            optionsMenu = Instantiate(optionsPrefab);
            optionsMenu.transform.SetParent(cameraScene.transform);
            Button menuCloseButton = GameObject.FindGameObjectWithTag("OptionsCloseButton").GetComponent<Button>();
            menuCloseButton.onClick.AddListener(() => OnMenuCloseButtonClick());
        }
    }

    public void OnMenuCloseButtonClick()
    {
        Destroy(optionsMenu);
        isInUse = false;
    }
}
