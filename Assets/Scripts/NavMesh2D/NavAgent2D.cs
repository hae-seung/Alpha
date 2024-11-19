using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent2D : MonoBehaviour
{
   private NavMeshAgent agent;

   private void Awake()
   {
      agent = GetComponent<NavMeshAgent>();
      agent.updateRotation = false;
      agent.updateUpAxis = false;
   }
}
