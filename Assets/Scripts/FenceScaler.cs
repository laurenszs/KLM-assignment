using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScaler : MonoBehaviour
{
    [SerializeField] private Transform fenceContainer;
    [SerializeField] private GameObject fence;

    public int xMax, zMax;

    // Start is called before the first frame update
    void Start()
    {
        var offset = fence.transform.localScale.x / 2;
        for (var i = 0; i < xMax; i++)
        {
            var layout = Instantiate(fence, fenceContainer);
            layout.transform.localPosition = new Vector3(0, 0, i + offset);
            layout.transform.eulerAngles = new Vector3(0, 90, 0);

            var layout2 = Instantiate(fence, fenceContainer);
            layout2.transform.localPosition = new Vector3(zMax, 0, i + offset);
            layout2.transform.eulerAngles = new Vector3(0, 90, 0);
        }

        for (var i = 0; i < zMax; i++)
        {
            var layout = Instantiate(fence, fenceContainer);
            layout.transform.localPosition = new Vector3(i + offset, 0, 0);

            var layout2 = Instantiate(fence, fenceContainer);
            layout2.transform.localPosition = new Vector3(i + offset, 0, xMax);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}