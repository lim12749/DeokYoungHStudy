using System.Collections;
using System.Collections.Generic;
using MainGame;
using UnityEngine;

public class FauxGravitybody : MonoBehaviour
{
    public PlanetFauxGravity attractor;
    public Rigidbody rb;
    private Transform myTransfrom;

    public bool placeOnSurface = false;
    private void Start()
    {
        attractor = FindObjectOfType<PlanetFauxGravity>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransfrom = this.transform;
    }

    private void FixedUpdate()
    {
        if (placeOnSurface) //����ΰ��
            attractor.Attract(myTransfrom, rb);
        else //��ü�ΰ��
            attractor.Attract(rb);

    }
}
