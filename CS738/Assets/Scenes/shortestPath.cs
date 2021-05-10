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

        while (openList.Count > 0)//Whilst there is something in the open list
        {
            
            IntersectionSO CurrentNode = openList[0];//Create a node and set it to the first item in the open list
            for (int i = 1; i < openList.Count; i++)//Loop through the open list starting from the second object
            {
                if (openList[i].fCost < CurrentNode.fCost || openList[i].fCost == CurrentNode.fCost && openList[i].ihCost < CurrentNode.ihCost)//If the f cost of that object is less than or equal to the f cost of the current node
                {
                    CurrentNode = openList[i];//Set the current node to that object
                }
            }

            openList.Remove(CurrentNode);//Remove that from the open list
            closedList.Add(CurrentNode);//And add it to the closed list

            if (CurrentNode.num == t.num)
            {
               buildPath(s, t);
                return;
            }

            for (int i = 0; i < map.map[CurrentNode.num].Count; i++)
            {
                IntersectionSO NeighborNode = map.map[CurrentNode.num][i].destNode;
                if (closedList.Contains(map.map[CurrentNode.num][i].destNode)){
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
        return currentNode.ihCost;
    }

}
