using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestedPlants : MonoBehaviour
{
    public static HarvestedPlants instance;
    public TextMeshProUGUI textMesh;
    public GameObject icon;
    public int harvestedPlants;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
            icon = transform.GetComponentInChildren<Image>().gameObject;
            textMesh = transform.GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
