using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Animations;

public class Trigger : MonoBehaviour, IInteractable
    {
        string objectName = gameObject.name;
        public void Interact(){
            Debug.Log("test");
        }
        
    }
