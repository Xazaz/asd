using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    public float maxdistance;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }


    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;
        
    }


    void Update()
    {
        Debug.DrawLine(target.position, myTransform.position, Color.red);


        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
        {
            //Move towards target
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

        }
    }
}
