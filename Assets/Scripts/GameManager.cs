using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public HashSet<Circle> innocentCircles = new HashSet<Circle>();

    public Circle pInnocentCircle;

    public float spawnDelay = 6f;
    public float spawnTime;
    public int maxSpawn = 5;

    public int mapWidth = 30;
    public int mapHeight = 20;

    public int killCounter = 0;
    public TextMeshProUGUI killCounterText;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0.0f) {
            ResetSpawnTime();

            if (innocentCircles.Count < maxSpawn)
            {
                GenerateInnocentCircle();
            }
        }
    }

    public void ResetSpawnTime()
    {
        spawnTime += spawnDelay * Random.Range(0.8f, 1.2f);
    }

    public void GenerateInnocentCircle()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-1.0f, 1.0f) * (mapWidth - 1.0f) * 0.5f,
            Random.Range(-1.0f, 1.0f) * (mapHeight - 1.0f) * 0.5f,
            0.0f
        );

        Circle spawnCircle = Instantiate(
            pInnocentCircle,
            spawnPos,
            Quaternion.identity
        );
        spawnCircle.sprite.color = Color.HSVToRGB(Random.value, 0.9f, 0.5f);
        innocentCircles.Add(spawnCircle);
    }

    public void IncrementKillCounter()
    {
        killCounter++;
        killCounterText.text = "Kills: " + killCounter;
    }

    public void KillCircle(Circle circle)
    {
        IncrementKillCounter();

        if (innocentCircles.Contains(circle))
        {
            innocentCircles.Remove(circle);
        }

        Destroy(circle.gameObject);
    }
}
