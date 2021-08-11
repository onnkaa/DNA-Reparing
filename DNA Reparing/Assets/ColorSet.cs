using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet : MonoBehaviour
{
    public List<MeshRenderer> spheres; 

    public List<Material> colors;

    private List<Material> colorPool;

    // Start is called before the first frame update
    void Start()
    {
        colorPool = new List<Material>();
        var countPerColor = spheres.Count / colors.Count;

        for (var i = 0; i < countPerColor; i++)
        {
            for (var j = 0; j < colors.Count; j++)
            {
                colorPool.Add(colors[j]);//mor mavi sarı turuncu mor mavi sarı turuncu ...
            }
        }

        //sDebug.Log("Pool Count : " + colorPool.Count);

        var colorCount = colorPool.Count;
        var sphereIndex = 0;
        while (colorPool.Count >= 1)
        {
            //0,1
            var index = Random.Range(0, colorPool.Count);
            var color = colorPool[index];
            spheres[sphereIndex].material = color;
            //Debug.Log( "    " + spheres[sphereIndex].material.name);
            colorPool.RemoveAt(index);
            sphereIndex++;
        }



        //for (int i = 0; i < spheres.Count; i++)
        //{
        //    Debug.Log(i + "    " +spheres[i].material.name);
        //}

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endRotate()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
