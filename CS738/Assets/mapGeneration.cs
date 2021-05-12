using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mapGeneration : MonoBehaviour
{
    public List<IntersectionSO> intersectionList;
    public int V, E;
    public int y;
    public List<List<RoadSO>> map = new List<List<RoadSO>>();
    public List<List<int>> testList = new List<List<int>>();
    public shortestPath sp;
    // Start is called before the first frame update
    void Start()
    {
        string line;
        string[] subs;
        Application.targetFrameRate = 30;



        StreamReader sr = new StreamReader("Assets/NewYorkCo.txt");
        V = int.Parse(sr.ReadLine());
        for (int i = 0; i < V; i++)
        {
            line = sr.ReadLine();
            subs = line.Split(',');
            int num = int.Parse(subs[0]);
            float xCO = float.Parse(subs[1]) / 100;
            float yCO = float.Parse(subs[2]) / 100;

            IntersectionSO iSO = ScriptableObject.CreateInstance<IntersectionSO>();
            iSO.x = xCO; iSO.y = yCO; iSO.num = i; iSO.pos = new Vector3(xCO,yCO,0);
            intersectionList.Add(iSO);
        }

        for (int i = 0; i < V; i++)
        {
            map.Add(new List<RoadSO>());
        }

        
        sr.Close();

        sr = new StreamReader("Assets/NewYorkLen.txt");
        line = sr.ReadLine();
        subs = line.Split(' ');
        E = int.Parse(subs[1]);
        for (int i = 0; i < E; i++)
        {
            line = sr.ReadLine();
            
            subs = line.Split(' ');
            int s = int.Parse(subs[0]);
            int d = int.Parse(subs[1]);
            float distane = float.Parse(subs[2]);
            RoadSO rSO = ScriptableObject.CreateInstance<RoadSO>();
            rSO.dest = d; rSO.src = s; rSO.speedLimit = 30; rSO.distance = distane; 
            rSO.destNode = intersectionList[d]; rSO.srcNode = intersectionList[s];
            map[s].Add(rSO);
        }

        print("done");

    }

        // Update is called once per frame


    

}
