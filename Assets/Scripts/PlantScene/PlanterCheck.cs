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
    public GameObject placePlant4;
    public GameObject placePlant4Prefab;
    public GameObject placeReplant;
    public GameObject placeReplantPrefab;
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
    public GameObject placeWeed;
    public GameObject placeWeedPrefab;



    private int plant = 0;
    private float lastWaterTime;
    private int waterCount = 0;
    public float waterDuration = 2f;
    private const float MIN_WATER_INTERVAL = 30f; // 2 hours in seconds 7200
    private bool isDead = false;
    public static int harvestedTomato = 0;
    private bool firstWater = false;
    private int harvestCount = 0;
    public float switchTime = 10f;
    public float minSpawnTime = 60f;
    public float maxSpawnTime = 300f;

    /*public void Start()
    {
        InvokeRepeating("SpawnWeeds", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));
    }*/
    private bool CanWater()
    {
        if (firstWater == true)
        {
            return Time.time - lastWaterTime >= MIN_WATER_INTERVAL && waterCount < 4 && isDead == false;
        }

        return true;
    }


    private void CheckPlantHealth()
    {
        isDead = false;
        if (isDead == true)
        {
            //Destroy(placeDeadPlant);
            isDead = false;
        }

        Debug.Log("before dead " + isDead);
        if (plant == 1 && Time.time - lastWaterTime >= 5f && waterCount > 0 && isDead == false)
        {
            /*if (Time.time - lastWaterTime >= 5f) // 3 hours in seconds
            {
                if (waterCount > 0 && isDead == false)
                {*/
                    isDead = true;
                    Destroy(happyEmote);
                    Destroy(happy2Emote);
                    Destroy(placePlant1);
                    Destroy(placePlant2);
                    Destroy(placePlant3);
                    Destroy(placePlant4);
                    Destroy(placeReplant);
                    Destroy(placeWeed);

                    

                    //placeDeadPlant = Instantiate(placeDeadPlantPrefab, this.transform);
                    deadEmote = Instantiate(deadEmotePrefab, this.transform);
                    Debug.Log("Plant has died!");
                    //isDead = true;
                    //lastWaterTime = 0f;
                //}
            //}
        }
    }




    public void ButtonSelected()
    {

        if (DeadPlantSelection.deadPlantSelect && isDead == true)
        {
            Debug.Log("Plant reset");
            plant = 0;
            waterCount = 0;
            lastWaterTime = Time.time;
            isDead = false;
            Debug.Log("isDead " + isDead);
            Debug.Log("watercount " + waterCount);
            Debug.Log("plant " + plant);
            Debug.Log("last water time " + lastWaterTime);
            CancelInvoke("SpawnWeeds"); //uncomment

            // Destroy all instantiated objects
            Destroy(deadEmote);
            //Destroy(placeDeadPlant);
            Destroy(placePlant1);
            Destroy(placePlant2);
            Destroy(placePlant3);
            Destroy(placePlant4);
            Destroy(placeReplant);
            Destroy(happyEmote);
            Destroy(happy2Emote);
            Destroy(placeWater);
            Destroy(placeWeed);
        }

        if (PlantSelection.plantSelect && plant == 0)
        {
            HarvestedPlants.instance.harvestedPlants--;


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
            InvokeRepeating("SpawnWeeds", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime)); //uncomment
            Debug.Log("Click watered");
            waterCount++;
            lastWaterTime = Time.time;
            firstWater = true;
            isDead = false;
            if (waterCount == 2 && plant == 1)
            {
                SwitchHappy2Prefab();
                Destroy(placePlant1);


                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                placePlant4 = Instantiate(placePlant4Prefab, this.transform);
                Debug.Log("1");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 3 && plant == 1)
            {
                SwitchHappy2Prefab();
                Destroy(placePlant4);
                Destroy(placeReplant);

                placePlant2 = Instantiate(placePlant2Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                Debug.Log("Click watered2");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 4 && plant == 1)
            {
                SwitchHappy2Prefab();
                Destroy(placePlant2);

                placePlant3 = Instantiate(placePlant3Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                Debug.Log("Click watered2");
                InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
        }

        else if (plant == 1 && RepotSelection.repotSelect && waterCount == 4)
        {
            Debug.Log("Harvested tomatoes");

            if (placePlant3 != null)
            {

                HarvestedTomato.instance.harvestedTomato += Random.Range(3, 7);
                HarvestedTomato.instance.textMesh.text = HarvestedTomato.instance.harvestedTomato.ToString();
                HarvestedTomato.instance.icon.SetActive(true);
                Debug.Log("Number of Tomato harvested: " + HarvestedTomato.instance.harvestedTomato);
                Destroy(placePlant3);
                //Destroy(happy2Emote);
                //happyEmote = Instantiate(happyEmotePrefab, this.transform);
                placeReplant = Instantiate(placeReplantPrefab, this.transform);
                waterCount = 2;
                harvestCount++;
                if (harvestCount == 3)
                {
                    Destroy(placePlant3);
                    Destroy(placeReplant);
                    Destroy(happyEmote);
                    Destroy(happy2Emote);
                    Destroy(deadEmote);
                    harvestCount = 0;
                    waterCount = 0;
                    plant = 0;
                }
                if (HarvestedTomato.instance.harvestedTomato >= 10)
                {
                    HarvestedTomato.instance.achievIcon.SetActive(true);
                    Debug.Log("Achievement");
                }


            }
            // Store harvestedTomatoes variable for global use
        }

        else if (plant == 1 && WeedSelection.weedSelect)
        {
            Destroy(placeWeed);
            Debug.Log("Weed clicked");
        }
    }

    private void SpawnWeeds()
    {
        placeWeed = Instantiate(placeWeedPrefab, this.transform);
    }

    void SwitchHappy2Prefab()
    {
        Destroy(happyEmote);
        happy2Emote = Instantiate(happy2EmotePrefab, this.transform);
        Invoke("SwitchBackHappyPrefab", switchTime);
    }

    void SwitchBackHappyPrefab()
    {
        Destroy(happy2Emote);
        happyEmote = Instantiate(happyEmotePrefab, this.transform);
    }
}

