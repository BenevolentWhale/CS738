using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shortestPath : MonoBehaviour
{
    public mapGeneration map;
    public int sNode, tNode;
    // Start is called before the first frame update
    public Traveler traveler;
    void Start()
    {
        
    }

    public void pathFinder(int src, int dest)
    {
        //traveler = _traveler;
        IntersectionSO s = map.intersectionList[src];
        IntersectionSO t = map.intersectionList[dest];
        //List<float> distance;
        List<IntersectionSO> openList = new List<IntersectionSO>();
        HashSet<IntersectionSO> closedList = new HashSet<IntersectionSO>();
        openList.Add(s);

        while (openList.Count > 0)
        {
            
            IntersectionSO CurrentNode = openList[0];
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < CurrentNode.fCost || openList[i].fCost == CurrentNode.fCost && openList[i].ihCost < CurrentNode.ihCost)
                {
                    CurrentNode = openList[i];
                }
            }

            openList.Remove(CurrentNode);
            closedList.Add(CurrentNode);

            if (CurrentNode.num == t.num)
            {
               buildPath(s, t);
                return;
            }

            //check every adjacent node/intersection
            for (int i = 0; i < map.map[CurrentNode.num].Count; i++)
            {
                IntersectionSO NeighborNode = map.map[CurrentNode.num][i].destNode;
                if (closedList.Contains(map.map[CurrentNode.num][i].destNode) || NeighborNode.active == false){
                    continue;
                }

                float moveCost = CurrentNode.igCost + getHCost(CurrentNode, NeighborNode);

                if (moveCost < CurrentNode.igCost || !openList.Contains(NeighborNode))
                {
                    NeighborNode.igCost = moveCost;
                    NeighborNode.ihCost = getHCost(NeighborNode, t);
                    NeighborNode.parent = CurrentNode;

                    if (!openList.Contains(NeighborNode))
                    {
                        openList.Add(NeighborNode);
                    }

                }
            }

        }

    }

    void buildPath(IntersectionSO s, IntersectionSO t)
    {
        List<IntersectionSO> bestPath = new List<IntersectionSO>();
        sNode = s.num;  tNode = t.num;
    //bestPath.Clear();
    IntersectionSO CurrentNode = t;
        
        while(CurrentNode != s)
        {
            bestPath.Add(CurrentNode);
            CurrentNode = CurrentNode.parent;
        }

        bestPath.Reverse();
        traveler.path = bestPath;
        return;
    }

    public float getHCost(IntersectionSO currentNode, IntersectionSO NeighborNode)
    {

        currentNode.ihCost = Mathf.Sqrt(Mathf.Pow((currentNode.x - NeighborNode.x), 2) + Mathf.Pow((currentNode.y - NeighborNode.y), 2));
        //return currentNode.ihCost/(map.map[currentNode.num][NeighborNode.num].speedLimit);
        return currentNode.ihCost;
    }

}
