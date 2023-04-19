using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterCheck : MonoBehaviour
{
    public GameObject placePlant1;
    public GameObject placePlant1Prefab;
    public GameObject placePlant2;
    public GameObject placePlant2Prefab;
    public GameObject placePlant3;
    public GameObject placePlant3Prefab;
    public GameObject placeDeadPlant;
    public GameObject placeDeadPlantPrefab;
    public GameObject placeWater;
    public GameObject placeWaterPrefab;
    public GameObject happyEmote;
    public GameObject happyEmotePrefab;
    public GameObject deadEmote;
    public GameObject deadEmotePrefab;
    public GameObject happy2Emote;
    public GameObject happy2EmotePrefab;

    //private GameObject currentEmote;
    //private GameObject replaceEmote;

    private int plant = 0;
    private float lastWaterTime;
    private int waterCount = 0;
    public float waterDuration = 2f;
    private const float MIN_WATER_INTERVAL = 30f; // 2 hours in seconds 7200
    private int isDead = 0;
    public float emoteDuration = 30f;

    //private ContainerCheck containerCheck; //Uncomment

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

        if (plant == 1)
        {
            if (Time.time - lastWaterTime >= 180f) // 3 hours in seconds
            {
                if (waterCount >= 0)
                {
                    placeDeadPlant = Instantiate(placeDeadPlantPrefab, this.transform);
                    deadEmote = Instantiate(deadEmotePrefab, this.transform);
                    Debug.Log("Plant has died!");
                    isDead = 1;

                    Destroy(happyEmote);
                    Destroy(placePlant1);
                    Destroy(placePlant2);
                    Destroy(placePlant3);
                }
            }
        }
    }


    public void ButtonSelected()
    {
        //containerCheck = GameObject.FindObjectOfType<ContainerCheck>(); //Uncomment
        //int countPlantValue = containerCheck.countPlant; //Uncomment

        if (PlantSelection.plantSelect && plant == 0)
        {
            HarvestedPlants.instance.harvestedPlants--; //Uncomment when UI fixed for SeedScene

            HarvestedPlants.instance.textMesh.text = HarvestedPlants.instance.harvestedPlants.ToString();
            HarvestedPlants.instance.icon.SetActive(HarvestedPlants.instance.harvestedPlants != 0);
            placePlant1 = Instantiate(placePlant1Prefab, this.transform);
            happyEmote = Instantiate(happyEmotePrefab, this.transform);
            plant = 1;
            waterCount++;
            //Debug.Log("Number of plants planted: " + countPlantValue);
        }
        else if (plant == 1 && WaterSelection.waterSelect && CanWater())
        {
            Debug.Log("Click watered");
            waterCount++;
            lastWaterTime = Time.time;
            if (waterCount == 2 && plant == 1)
            {
                Destroy(placePlant1);

                Destroy(happyEmote);
                happy2Emote = Instantiate(happy2EmotePrefab, this.transform);
                //Destroy(happy2Emote, emoteDuration);

                StartCoroutine(Delay());

                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                placePlant2 = Instantiate(placePlant2Prefab, this.transform);
                Debug.Log("1");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 3 && plant == 1)
            {
                Destroy(placePlant2);
                Destroy(happyEmote);
                placePlant3 = Instantiate(placePlant3Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);

                happy2Emote = Instantiate(happy2EmotePrefab, this.transform);
                //Destroy(happy2Emote, emoteDuration);
                StartCoroutine(Delay());


                Debug.Log("Click watered2");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
        }
    }


    /*public void PlacePlant(int subPlant)
    {
        containerCheck = GetComponent<ContainerCheck>();

        //for (int i = 0; i < containerCheckScript.countPlant[i].Length; i++) 
        //{
        //    containerCheckScript.countPlant[i] -= subPlant;
        //}
    }*/

    IEnumerator Delay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(30);
        happyEmote = Instantiate(happyEmotePrefab, this.transform);
        Destroy(happy2Emote, emoteDuration);

        // Code to execute after the delay
        Debug.Log("Delayed code executed!");
    }
}
