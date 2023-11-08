namespace Game.Installers
{
	using Game.Hero;
	using UnityEngine;
	using UnityEngine.AI;
	using Zenject;

	public sealed class HeroInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// Animator
			Container
				.Bind<Animator>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// NavMeshAgent
			Container
				.Bind<NavMeshAgent>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// HeroMotion
			Container
				.Bind<HeroMotion>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// HeroAnimationController
			Container
				.BindInterfacesTo<HeroAnimationController>()
				.AsSingle();
		}
	}
}