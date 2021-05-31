namespace Tartaros.Entities
{
	using DG.Tweening;
	using DG.Tweening.Core;
	using System.Runtime.InteropServices;
	using UnityEngine.AI;

	public class NavMeshCollisionMoving
	{

		#region Enums
		public enum Size
		{
			Normal,
			Reduced,
			Growing,
			Reducing
		}
		#endregion Enums

		#region Fields
		private Size _size = Size.Normal;
		private TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> _tweener = null;

		private readonly float _normalRadius = -1;
		private readonly float _reducedRadius = -1;

		private readonly float _growingTime = -1;
		private readonly float _reducingTime = -1;

		private readonly NavMeshAgent _agent = null;
		#endregion Fields

		#region Ctor
		public NavMeshCollisionMoving(NavMeshAgent agent, AgentCollisionMovingData data)
		{
			_agent = agent != null ? agent : throw new System.ArgumentNullException(nameof(agent));

			_normalRadius = agent.radius;
			_reducedRadius = data.ReducedRadius;

			_growingTime = data.GrowingTime;
			_reducingTime = data.ReducingTime;
		}
		#endregion Ctor

		#region Methods
		public void ReduceCollision()
		{
			_size = Size.Reducing;
			_agent.radius = _normalRadius;

			if (_tweener != null) _tweener.Kill();

			_tweener = _agent.DORadius(_reducedRadius, _reducingTime)
							.OnComplete(SetSizeToReduced)
							.OnKill(SetSizeToReduced);

			void SetSizeToReduced()
			{
				_size = Size.Reduced;
			}
		}

		public void GrowCollisionToNormal()
		{
			_size = Size.Growing;
			_agent.radius = _reducingTime;

			if (_tweener != null) _tweener.Kill();

			_tweener = _agent.DORadius(_normalRadius, _growingTime)
				.OnComplete(SetSizeToGrowing)
				.OnKill(SetSizeToGrowing);

			void SetSizeToGrowing()
			{
				_size = Size.Growing;
			}
		}
		#endregion Methods
	}
}
