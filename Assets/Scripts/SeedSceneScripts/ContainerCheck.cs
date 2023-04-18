using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContainerCheck : MonoBehaviour
{
    public GameObject placeDirt;
    public GameObject placeDirtPrefab;
    public GameObject placeSeed;
    public GameObject placeSeedPrefab;
    public GameObject placeWater;
    public GameObject placeWaterPrefab;
    public GameObject placeDeadPlant;
    public GameObject placeDeadPlantPrefab;
    public GameObject placeSapling1;
    public GameObject placeSapling1Prefab;
    public GameObject placeSapling2;
    public GameObject placeSapling2Prefab;
    public GameObject placeSapling3;
    public GameObject placeSapling3Prefab;


    public Canvas canvas;


    private int dirt = 0;
    private int seed = 0;
    private float lastWaterTime;
    private int waterCount = 0;
    private int isDead = 0;
    public float waterDuration = 2f;
    private const float MIN_WATER_INTERVAL = 1f; // 2 hours in seconds 7200
   
    public static int harvestedPlant = 0;
    public int countPlant; //set to 0?
    //private int addPlants = 0;
    //private static int currentPlant = 0;



    private bool CanWater()
    {
        return Time.time - lastWaterTime >= MIN_WATER_INTERVAL && waterCount < 3;
    }

    private void CheckPlantHealth()
    {
        if (isDead == 1)
        {
            Destroy(placeDeadPlant);
            isDead = 0;
        }


        if (dirt == 1 && seed == 1)
        {
            if (Time.time - lastWaterTime >= 10f) // 3 hours in seconds
            {
                if (waterCount > 0)
                {
                    placeDeadPlant = Instantiate(placeDeadPlantPrefab, this.transform);
                    Debug.Log("Plant has died!");
                    isDead = 1;
                    Destroy(placeSapling1);
                    Destroy(placeSapling2);
                    Destroy(placeSapling3);
                }
            }
        }
    }


    public void ButtonClicked()
    {
        Debug.Log(DirtSelection.dirtSelect);
        if (DeadPlantSelection.deadPlantSelect && isDead == 1)
        {
            dirt = 0;
            seed = 0;
            waterCount = 0;
            lastWaterTime = 0f;
            isDead = 2;

            // Destroy all instantiated objects
            Destroy(placeDeadPlant);
            Destroy(placeDirt);
            Destroy(placeSeed);
            Destroy(placeSapling1);
            Destroy(placeSapling2);
            Destroy(placeSapling3);
            Destroy(placeWater);


        }
        else if (DirtSelection.dirtSelect && dirt == 0 && seed == 0)
        {
            placeDirt = Instantiate(placeDirtPrefab, this.transform);
            dirt = 1;
            Debug.Log(dirt);
            Debug.Log(DirtSelection.dirtSelect);
        }
        else if (SeedSelection.seedSelect && dirt == 1 && seed == 0)
        {
            placeSeed = Instantiate(placeSeedPrefab, this.transform);
            seed = 1;
            Debug.Log(seed);
            Debug.Log(DirtSelection.dirtSelect);
        }
        else if (dirt == 1 && seed == 1 && WaterSelection.waterSelect && CanWater())
        {
            Debug.Log("Click watered");
            waterCount++;
            lastWaterTime = Time.time;
            if (waterCount == 1 && dirt == 1 && seed == 1)
            {
                Destroy(placeSeed);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                placeSapling1 = Instantiate(placeSapling1Prefab, this.transform);
                Debug.Log("1");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 2 && dirt == 1 && seed == 1)
            {
                Destroy(placeSapling1);
                placeSapling2 = Instantiate(placeSapling2Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);


                Debug.Log("Click watered2");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 3 && dirt == 1 && seed == 1)
            {
                Destroy(placeSapling2);
                placeSapling3 = Instantiate(placeSapling3Prefab, this.transform);
                Debug.Log("Click watered3");
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }

        }
        else if (RepotSelection.repotSelect && dirt == 1 && seed == 1 && waterCount == 3)
        {
            //AddPlant(harvestedPlant);
            Debug.Log("Plant harvested!");
            Destroy(placeSapling3);
            Destroy(placeDirt);
            waterCount = 0;
            lastWaterTime = 0f;
            isDead = 0;
            seed = 0;
            countPlant++;
            HarvestedPlants.instance.textMesh.text = countPlant.ToString();
            HarvestedPlants.instance.icon.SetActive(true);
            Debug.Log("Number of plants harvested: " + countPlant);

            /*if (countPlant <= 0)
            {
                HarvestedPlants.instance.textMesh.text = countPlant.ToString();
                HarvestedPlants.instance.icon.SetActive(false);
            }
            else if (countPlant >= 1) 
            {
                HarvestedPlants.instance.textMesh.text = countPlant.ToString();
                HarvestedPlants.instance.icon.SetActive(true);
            }*/

        }
    }

    /*public void AddPlant(int harvestedPlant) 
    {
        //harvestedPlant++;

        countPlant = new int[harvestedPlant];
        for (int i = 0; i < countPlant.Length; i++) 
        {
            //instances[i] = Instantiate(placeSapling3Prefab, this.transform);
            //instances[i].SetActive(false);
            countPlant[i] += harvestedPlant;
        }
        Debug.Log("Number of plants harvested: " + countPlant.Length);

    }*/
}

