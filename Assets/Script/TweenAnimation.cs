using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenAnimation : MonoBehaviour
{
    public float duration = 2.0f; // Durasi animasi
    public float targetY = 0.0f; // Koordinat Y tujuan

    private Vector3 startPosition;

    void Start()
    {
        // Simpan posisi awal GameObject
        startPosition = transform.position;

        // Geser posisi Y ke bawah di luar layar
        Vector3 offScreenPos = startPosition;
        offScreenPos.y = 0.0f;
        transform.position = offScreenPos;

        // Mulai animasi
        StartAppearAnimation();
    }

    void StartAppearAnimation()
    {
        // Menggunakan DoTween untuk menganimasikan pergerakan dari bawah ke atas
        transform.DOMoveY(targetY, duration)
            .SetEase(Ease.OutFlash) // Anda dapat mengganti Ease sesuai keinginan
            .OnComplete(AnimationComplete); // Panggil method ini saat animasi selesai
    }

    void AnimationComplete()
    {
        // Method yang dipanggil saat animasi selesai
        Debug.Log("Animasi selesai!");
    }
}
