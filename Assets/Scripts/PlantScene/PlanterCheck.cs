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
    public GameObject uncomfyEmote;
    public GameObject uncomfyEmotePrefab;
    public GameObject placeWeed;
    public GameObject placeWeedPrefab;



    private int plant = 0;
    private float lastWaterTime;
    private int waterCount = 0;
    public float waterDuration = 2f;
    private const float MIN_WATER_INTERVAL = 10f; // 2 hours in seconds 7200
    private bool isDead = false;
    public static int harvestedTomato = 0;
    private bool firstWater = false;
    private int harvestCount = 0;
    public float switchTime = 5f; //10f
    public float minSpawnTime = 30f;
    public float maxSpawnTime = 60f;

    public bool weedPresent = false; 

    public void Start()
    {
        //InvokeRepeating("SpawnWeeds", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));

    }
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

        Debug.Log("before dead " + isDead);
        Debug.Log(Time.time - lastWaterTime);
        Debug.Log(waterCount);

        if (plant == 1 && lastWaterTime != 0 && Time.time - lastWaterTime >= 30f && waterCount > 0 && isDead == false)
        {
            /*if (Time.time - lastWaterTime >= 5f) // 3 hours in seconds
            {
                if (waterCount > 0 && isDead == false)
                {*/
                    isDead = true;
                    DestroyPlantPrefabs();
                    DestroyEmotionPrefabs();
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
        Debug.Log("ButtonSelected");
        if (DeadPlantSelection.deadPlantSelect && isDead == true)
        {
            Debug.Log("Plant reset");
            plant = 0;
            waterCount = 0;
            lastWaterTime = 0;
            isDead = false;
            Debug.Log("isDead " + isDead);
            Debug.Log("watercount " + waterCount);
            Debug.Log("plant " + plant);
            Debug.Log("last water time " + lastWaterTime);
            CancelInvoke("SpawnWeeds"); //uncomment
            CancelInvoke("CheckPlantHealth");
            // Destroy all instantiated objects
            DestroyPlantPrefabs();
            DestroyEmotionPrefabs();
            Destroy(placeWeed);
        }
        else if (plant == 1 && WeedSelection.weedSelect)
        {
            Destroy(placeWeed);
            Destroy(uncomfyEmote);
            weedPresent = false;
            Debug.Log("Weed clicked");
            happyEmote = Instantiate(happyEmotePrefab, this.transform);
        }

        else if (PlantSelection.plantSelect && plant == 0)
        {

            InvokeRepeating("CheckPlantHealth", 5f, 5f);
            HarvestedPlants.instance.harvestedPlants--;

            HarvestedPlants.instance.textMesh.text = HarvestedPlants.instance.harvestedPlants.ToString();
            HarvestedPlants.instance.icon.SetActive(HarvestedPlants.instance.harvestedPlants != 0);
            DestroyPlantPrefabs();
            DestroyEmotionPrefabs();
            placePlant1 = Instantiate(placePlant1Prefab, this.transform);
            happyEmote = Instantiate(happyEmotePrefab, this.transform);
            plant = 1;
            waterCount++;
            //Debug.Log("Number of plants planted: " + countPlantValue);
        } else if (plant == 1 && WaterSelection.waterSelect && CanWater())
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
                DestroyPlantPrefabs();


                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                placePlant4 = Instantiate(placePlant4Prefab, this.transform);
                Debug.Log("1");
            }
            else if (waterCount == 3 && plant == 1)
            {
                SwitchHappy2Prefab();
                DestroyPlantPrefabs();

                placePlant2 = Instantiate(placePlant2Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                Debug.Log("Click watered2");
                //InvokeRepeating("CheckPlantHealth", 0f, 5f);
            }
            else if (waterCount == 4 && plant == 1)
            {
                SwitchHappy2Prefab();
                DestroyPlantPrefabs();

                placePlant3 = Instantiate(placePlant3Prefab, this.transform);
                placeWater = Instantiate(placeWaterPrefab, this.transform);
                Destroy(placeWater, waterDuration);
                Debug.Log("Click watered2");
                //InvokeRepeating("CheckPlantHealth", 0f, 5f);
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
                DestroyPlantPrefabs();
                //Destroy(happy2Emote);
                //happyEmote = Instantiate(happyEmotePrefab, this.transform);
                placeReplant = Instantiate(placeReplantPrefab, this.transform);
                waterCount = 2;
                harvestCount++;
                if (harvestCount == 3)
                {
                    DestroyPlantPrefabs();
                    DestroyEmotionPrefabs();
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
    }

    private void SpawnWeeds()
    {
        DestroyEmotionPrefabs();
        if(weedPresent == false)
        {
            placeWeed = Instantiate(placeWeedPrefab, this.transform);
            weedPresent = true;
        }
        
        uncomfyEmote = Instantiate(uncomfyEmotePrefab, this.transform);
    }

    private void SwitchHappy2Prefab()
    {
        DestroyEmotionPrefabs();
        happy2Emote = Instantiate(happy2EmotePrefab, this.transform);
        Invoke("SwitchBackHappyPrefab", switchTime);
    }
    private void SwitchBackHappyPrefab()
    {
        DestroyEmotionPrefabs();
        happyEmote = Instantiate(happyEmotePrefab, this.transform);
    }

    public void DestroyEmotionPrefabs() 
    {
        Destroy(happyEmote);
        Destroy(happy2Emote);;
        Destroy(uncomfyEmote);
        Destroy(deadEmote);
    }

    public void DestroyPlantPrefabs()
    {
        Destroy(placePlant1);
        Destroy(placePlant2);
        Destroy(placePlant3);
        Destroy(placePlant4);
        Destroy(placeReplant);
        Destroy(placeWater);
        //Destroy(placeWeed);
    }
}

