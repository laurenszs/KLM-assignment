using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int hangarReadiness;

    [SerializeField] private Transform[] hangarList = new Transform[3];
    [SerializeField] private GameObject[] planesList = new GameObject[3];
    [SerializeField] private Image trafficLight;

    private float _lightIntensity = 25;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        for (var i = 0; i < hangarList.Length; i++) //adds number to hangar TMP
        {
            hangarList[i].GetComponentInChildren<TextMeshPro>().text = (i + 1).ToString();
        }
    }

    private void Update()
    {
        UpdateTrafficLight();
    }

    public void ParkPlanes()
    {
        for (var i = 0; i < planesList.Length; i++)
        {
            planesList[i].GetComponent<PlaneUtils>().park = !planesList[i].GetComponent<PlaneUtils>().park;

            if (planesList[i].GetComponent<PlaneUtils>().park)
            {
                planesList[i].GetComponent<NavMeshAgent>().SetDestination(hangarList[i].position);
            }
        }
    }

    public void LightSwitch()
    {
        foreach (var plane in planesList) //turn on/off depending on current state
        {
            plane.GetComponentInChildren<Light>().intensity = plane.GetComponentInChildren<Light>().intensity switch
            {
                0 => _lightIntensity,
                > 0 => 0,
                _ => plane.GetComponentInChildren<Light>().intensity
            };
        }
    }

    private void UpdateTrafficLight() //updates traffic light UI image
    {
        foreach (var plane in planesList)
        {
            if (hangarReadiness == hangarList.Length && plane.GetComponent<PlaneUtils>().park)
            {
                trafficLight.color = Color.red;
            }
            else if (hangarReadiness != hangarList.Length && plane.GetComponent<PlaneUtils>().park)
            {
                trafficLight.color = Color.yellow;
            }
            else
            {
                trafficLight.color = Color.green;
            }
        }
    }
}