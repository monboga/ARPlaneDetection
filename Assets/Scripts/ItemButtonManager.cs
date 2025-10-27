using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;
    private ARInteractionManager interactionManager;
    public string ItemName
    {
        set
        {
            itemName = value;
        }
    }

    public string ItemDescription { set => itemDescription = value; }
    public Sprite ItemImage { set => itemImage = value; }
    public GameObject Item3DModel { set => item3DModel = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;
        transform.GetChild(2).GetComponent<TMP_Text>().text = itemDescription;

        // componente button
        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition); // cuando elija un item llama al evento ARPosition
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindAnyObjectByType<ARInteractionManager>();
    }

    private void Create3DModel()
    {
        interactionManager.Item3DModel = Instantiate(item3DModel);
    }
}
