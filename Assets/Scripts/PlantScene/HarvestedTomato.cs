using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestedTomato : MonoBehaviour
{
    public static HarvestedTomato instance;
    public TextMeshProUGUI textMesh;
    public GameObject icon;
    public GameObject achievIcon;
    public int harvestedTomato = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
