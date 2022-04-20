using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iman : MonoBehaviour
{
    [SerializeField] private float rotationspeed = 90f;
    void Update() => transform.Rotate(0, rotationspeed, 0 * Time.deltaTime);
}
