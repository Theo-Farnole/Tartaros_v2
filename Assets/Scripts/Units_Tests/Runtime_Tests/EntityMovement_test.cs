using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tartaros.Entities;
using UnityEditor.AI;
using UnityEngine.TestTools;

public class EntityMovement_test : MonoBehaviour
{

    private GameObject _capsuleEntity = null;

    [SetUp]
    public void Setup()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = Vector3.zero;
        plane.gameObject.isStatic = true;

        NavMeshBuilder.BuildNavMesh();

        _capsuleEntity = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        _capsuleEntity.transform.position = Vector3.zero;

        EntityMovement entityMovement = _capsuleEntity.AddComponent<EntityMovement>();
        entityMovement.EntityMovementData = new EntityMovementData(3, 0);

        Instantiate(new GameObject()).AddComponent<Camera>();
    }

    [UnityTest]
    public IEnumerator TestMovement()
    {
        EntityMovement entityMovement = _capsuleEntity.GetComponent<EntityMovement>();
        Vector3 targetPoint = new Vector3(3, 0, 0);
        entityMovement.MoveToPoint(targetPoint);

        yield return new WaitForSeconds(2);

        
        Assert.IsTrue(NearlyEquals(targetPoint, AdjustEntityPosition(entityMovement)));
    }

    private Vector3 AdjustEntityPosition(EntityMovement entityMovement)
    {
        Vector3 surfaceNavMeshGap = new Vector3(0, 0.08f, 0);
        return entityMovement.transform.position - Vector3.up - surfaceNavMeshGap;
    }

    private bool NearlyEquals(Vector3 p1, Vector3 p2)
    {
        return Vector3.Distance(p1, p2) < 0.1f;
    }
}
