﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacumCleanerController : MonoBehaviour
{
    public bool isMoving;

    
    public List<Vector3> positions;


    [SerializeField]
    float speed;

    int targetIndex =0;

    Vector3 target;


    float timer;

    [SerializeField]
    float colliderRange;


    public void EnableMoving() {
        isMoving = true;
    }
    public void DisableMoving() {
        isMoving = false;
    }

    private void Start()
    {
        target = positions[targetIndex];
        timer = 0;
    }


    void Update()
    {
        if (!isMoving) {
            return;
        }
        timer += Time.deltaTime;
        GoTo(target + transform.position);
        if (ReachedTarget()) {
            getNextTarget();
        }
    }

    void GoTo(Vector3 target) {
        Vector3 differece = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(differece, Vector3.up);
        transform.rotation = rotation;
        transform.position += transform.forward * speed;
    }

    bool ReachedTarget() {
        Vector3 vectorDifference = target - transform.position;
        return vectorDifference.sqrMagnitude <= colliderRange;
    }

    void getNextTarget() {
        targetIndex++;
        int arrayIndex = targetIndex % positions.Count;
        target = positions[arrayIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DemoPlayerController>()) {
            Debug.Log("Time to catch the vacum cleaner" + timer);
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
            return;
        }
    }

}