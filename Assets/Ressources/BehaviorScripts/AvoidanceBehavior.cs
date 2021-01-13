using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock){
        //if no neighbors, maintain current alignement
        if(context.Count ==0)
            return agent.transform.forward;//up ou forward??

        //add all points together and avrage
        Vector3 avoidancetMove = Vector3.zero;
        int nbAvoid = 0;
        foreach (Transform item in context)
        {
            if(Vector3.SqrMagnitude(item.position - agent.transform.position)<flock.SquareAvoidanceRadius){
                nbAvoid++;
                avoidancetMove+=agent.transform.position-item.position;
            }
        }
        if(nbAvoid > 0)
            avoidancetMove/=nbAvoid;

        return avoidancetMove;
    }
}
