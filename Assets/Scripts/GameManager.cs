using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Transform[] hangarList = new Transform[3];

    [SerializeField] private GameObject[] planesList = new GameObject[3];
    private float _lightIntensity = 25;

    // Start is called before the first frame update
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

        for (var i = 0; i < hangarList.Length; i++)
        {
            hangarList[i].GetComponentInChildren<TextMeshPro>().text = (i + 1).ToString();
        }
    }

    public void ParkPlanes()
    {
        for (var i = 0; i < planesList.Length; i++)
        {
            var navm = planesList[i].GetComponent<NavMeshAgent>();
            planesList[i].GetComponent<PlaneUtils>().park = !planesList[i].GetComponent<PlaneUtils>().park;
            if (planesList[i].GetComponent<PlaneUtils>().park)
            {
                navm.SetDestination(hangarList[i].position);
            }
        }
    }

    public void LightSwitch()
    {
        foreach (var plane in planesList)
        {
            plane.GetComponentInChildren<Light>().intensity = plane.GetComponentInChildren<Light>().intensity switch
            {
                0 => _lightIntensity,
                > 0 => 0,
                _ => plane.GetComponentInChildren<Light>().intensity
            };
        }
    }
}