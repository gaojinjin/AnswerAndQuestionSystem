using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBuliderScript : MonoBehaviour {
    public GameObject obj;
    public Vector3 spawnPoint;
    public void BulidObject(){
        Instantiate(obj,spawnPoint,Quaternion.identity);
    }
}
