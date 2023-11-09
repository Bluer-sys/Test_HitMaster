namespace Game.Hero
{
	using UniRx;
	using UnityEngine;
	using Zenject;

	public interface IHeroFacade
	{
		Transform Transform						{ get; }
		bool IsMoving							{ get; }
		ReactiveCommand OnAllWaypointReached	{ get; }
	}

	public sealed class HeroFacade : MonoBehaviour, IHeroFacade
	{
		[Inject] readonly HeroMotion	_heroMotion;

#region IHeroFacade

		public Transform Transform						=> transform;

		public bool IsMoving							=> _heroMotion.IsMoving.Value;

		public ReactiveCommand OnAllWaypointReached		=> _heroMotion.OnAllWaypointsReached;

#endregion
	}
}