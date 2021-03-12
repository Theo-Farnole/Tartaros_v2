namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;

    public interface IBuildingInputManager
    {
        bool CheckEnterConstructionMode();
        bool CheckLeaveWithoutConstruct();
        bool CheckConstruct();
    }
}