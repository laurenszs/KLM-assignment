using UnityEngine;

[CreateAssetMenu(fileName = "Airplane", menuName = "ScriptableObjects/Airplane", order = 1)]
public class AirPlaneScriptable : ScriptableObject
{
    public enum Type
    {
        Private,
        Airbus, 
    }


    public string type;

    public enum Brand
    {
        KLM,
        Spirit,
        United
    };

    public Brand brand;
}