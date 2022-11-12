using UnityEngine;

[CreateAssetMenu(fileName = "Airplane", menuName = "ScriptableObjects/Airplane", order = 1)]
public class AirPlaneScriptable : ScriptableObject
{
    public enum Type
    {
        Private,
        Airbus,
    }

    public Type type;

    public enum Brand
    {
        KLM,
        Spirit,
        Emirates
    }

    public Brand brand;
    public Material planeMaterial;
}