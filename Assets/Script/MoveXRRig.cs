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

        // Mendapatkan posisi avatar saat ini (asumsi avatar adalah child dari xrOrigin)
        Transform avatarTransform = xrOrigin.GetChild(0);
        Vector3 avatarPosition = avatarTransform.position;

        // Hitung perbedaan antara posisi avatar dan posisi spawn point
        Vector3 positionOffset = spawnPosition - avatarPosition;

        // Pindahkan XR Origin ke spawn point tanpa mengubah tinggi karakter
        xrOrigin.position += new Vector3(positionOffset.x, 0f, positionOffset.z);
        xrOrigin.rotation = spawnRotation;
    }
}
