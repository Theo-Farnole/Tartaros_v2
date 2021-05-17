using System.Numerics;

namespace Tartaros.Entities.Attack
{
    public interface IHitEffect
    {
        void ExecuteHitEffect(UnityEngine.Vector3 positionToInstanciate, UnityEngine.Quaternion rotationoInstanciate);
		
	}
}