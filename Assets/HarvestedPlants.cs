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
    public int harvestedPlants =0;
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
