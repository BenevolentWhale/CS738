using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiFunctions : MonoBehaviour
{
    public Traveler traveler;
    public mapGeneration map;
    public shortestPath shortestPath;
    public Text pathText, sourceText, destText, openText, closeText;
    public Road road;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newTraveler()
    {
        traveler.path.Clear();
        shortestPath.pathFinder(int.Parse(sourceText.text), int.Parse(destText.text));
        for (int i = 0; i < traveler.path.Count-1; i++)
        {
           
            //pathText.text += traveler.path[i].num + " ";
             Road r = Instantiate(road, traveler.transform.position, Quaternion.identity);
             r.set(traveler.path[i], traveler.path[i + 1]);
        }
        traveler.transform.position = traveler.path[0].pos;
        traveler.startTime = Time.time;
        traveler.tripLength = Vector3.Distance(traveler.path[int.Parse(sourceText.text)].pos, traveler.path[int.Parse(destText.text)].pos);
        traveler.go = true;
    }

    public void closeNode()
    {
        if (map.intersectionList[int.Parse(closeText.text)].active)
        {
            map.intersectionList[int.Parse(closeText.text)].active = false;
        }
    }

    public void openNode()
    {
        if (!map.intersectionList[int.Parse(closeText.text)].active)
        {
            map.intersectionList[int.Parse(closeText.text)].active = true;
        }
    }


}
