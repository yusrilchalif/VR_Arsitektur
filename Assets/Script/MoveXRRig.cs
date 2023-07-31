using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveXRRig : MonoBehaviour
{
    public Transform xrOrigin;
    public Transform[] spawnPoints;

    public void SetSpawnPoint(int spawnIndex)
    {
        // Mendapatkan referensi posisi dan rotasi spawn point yang dipilih
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;
        Quaternion spawnRotation = spawnPoints[spawnIndex].rotation;

        // Pindahkan XR Origin ke spawn point
        xrOrigin.position = spawnPosition;
        xrOrigin.rotation = spawnRotation;

        // Pindahkan avatar ke spawn point (asumsi avatar adalah child dari xrOrigin)
        Transform avatarTransform = xrOrigin.GetChild(0);
        avatarTransform.position = spawnPosition;
        avatarTransform.rotation = spawnRotation;
    }    
}
