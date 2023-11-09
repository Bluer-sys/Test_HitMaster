namespace Game.Hero
{
	using UniRx;
	using UnityEngine;
	using Zenject;

	public interface IHeroFacade
	{
		Transform Transform						{ get; }
		ReactiveCommand OnAllWaypointReached	{ get; }
	}

	public sealed class HeroFacade : MonoBehaviour, IHeroFacade
	{
		[Inject] readonly HeroMotion _heroMotion;
		
		public Transform Transform						=> transform;
		
		public ReactiveCommand OnAllWaypointReached		=> _heroMotion.OnAllWaypointsReached;
	}
}