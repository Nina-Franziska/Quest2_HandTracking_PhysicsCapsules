using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSky : MonoBehaviour
{
    [SerializeField]
    GameObject cubeS;

    [SerializeField]
    GameObject cubeL;

    [SerializeField]
    GameObject table;

    Renderer tableRend;

    float xCubeS;
    float zCubeS;
    float heightL;

    float xMappedCubeS;
    float zMappedCubeS;
    float mappedheightL;
    Color hsvCol;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", .4f);
        tableRend = table.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        heightL = cubeL.transform.position.y;

        mappedheightL = Mathf.SmoothStep(0.5f, 2f, heightL);
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", mappedheightL*.5f);

        xCubeS = Mathf.Abs(cubeS.transform.position.x);
        xMappedCubeS = Mathf.SmoothStep(0, 1, xCubeS);
        zCubeS = Mathf.Abs(cubeS.transform.position.z) +0.5f;
        zMappedCubeS = Mathf.SmoothStep(0, .5f, zCubeS);

        hsvCol = Color.HSVToRGB(xMappedCubeS, zMappedCubeS, 1);
        RenderSettings.skybox.SetColor("_SkyTint", hsvCol);

        table.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.HSVToRGB(xMappedCubeS, zMappedCubeS, 1));
    }
}
