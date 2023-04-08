using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ContainerCheck : MonoBehaviour
{
    public GameObject placeDirt;
    public GameObject placeDirtPrefab;
    public GameObject placeSeed;
    public GameObject placeSeedPrefab;
    public Canvas canvas;

    private int dirt = 0;
    private int seed = 0;*/


/*public void ButtonClicked()
{
    Debug.Log(DirtSelection.dirtSelect);
    if (DirtSelection.dirtSelect == true && dirt == 0 && seed == 0)
    {
        //placeDirt = Instantiate(placeDirt, canvas.transform);
        //placeDirt.transform.parent = gameObject.transform;
        placeDirt = GameObject.FindWithTag("Dirt");
        Instantiate(placeDirtPrefab, this.transform);
        dirt = 1;
        Debug.Log(dirt);
        //seed = 0;
    }

    if (SeedSelection.seedSelect == true && dirt == 1 && seed == 0)
    {
        placeSeed = GameObject.FindWithTag("Seed");
        Instantiate(placeSeedPrefab, this.transform);
        seed = 1;
        Debug.Log(seed);
    }
}
}*/

public class ContainerCheck : MonoBehaviour
{
    public GameObject placeDirt;
    public GameObject placeDirtPrefab;
    public GameObject placeSeed;
    public GameObject placeSeedPrefab;
    public Canvas canvas;

    private int dirt = 0;
    private int seed = 0;

    public void ButtonClicked()
    {
        Debug.Log(DirtSelection.dirtSelect);
        if (DirtSelection.dirtSelect && dirt == 0 && seed == 0)
        {
            placeDirt = GameObject.FindWithTag("Dirt");
            Instantiate(placeDirtPrefab, this.transform);
            dirt = 1;
            Debug.Log(dirt);
            Debug.Log(DirtSelection.dirtSelect);
        }
        else if (SeedSelection.seedSelect && dirt == 1 && seed == 0)
        {
            placeSeed = GameObject.FindWithTag("Seed");
            Instantiate(placeSeedPrefab, this.transform);
            seed = 1;
            Debug.Log(seed);
            Debug.Log(DirtSelection.dirtSelect);
        }

        else
        {
            Debug.Log("Cannot plant seed!");
            Debug.Log(DirtSelection.dirtSelect);
        }
    }
}
