namespace Game.Hero
{
	using UnityEngine;

	public interface IHeroFacade
	{
		Transform Transform { get; }
	}

	public sealed class HeroFacade : MonoBehaviour, IHeroFacade
	{
		public Transform Transform	=> transform;
	}
}