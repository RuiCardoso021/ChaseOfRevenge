using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDissolve : MonoBehaviour
{
    public Material portalMaterial;
    public float dissolveDuration = 1f;

    private Renderer portalRenderer;
    private Vector3 dissolveStartPoint;
    private bool isDissolving;
    private float dissolveTimer;

    private void Start()
    {
        portalRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isDissolving)
        {
            dissolveTimer += Time.deltaTime;
            float dissolveProgress = dissolveTimer / dissolveDuration;
            float dissolveAmount = Mathf.Clamp01(dissolveProgress);

            // Update the dissolve amount property
            portalMaterial.SetFloat("_DissolveAmount", dissolveAmount);

            if (dissolveAmount >= 1f)
            {
                isDissolving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the collision point in local space
            Vector3 collisionPoint = transform.InverseTransformPoint(other.ClosestPoint(transform.position));

            // Update the dissolve start point
            dissolveStartPoint = collisionPoint;

            // Enable the dissolve effect
            EnableDissolve();
        }
    }

    private void EnableDissolve()
    {
        isDissolving = true;
        dissolveTimer = 0f;
    }
}
