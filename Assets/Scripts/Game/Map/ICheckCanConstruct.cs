namespace Tartaros.Map
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.Utilities;
    using UnityEngine;

    public interface ICheckCanConstruct 
    {
        bool IsInBoundsMap(Bounds2D bounds, Vector3 position);

        bool IsNotOnABuilding(Vector3 BuildingPosition, Vector3 mousePosition);
    }

}