namespace Game.Installers
{
	using Game.Hero;
	using UnityEngine.AI;
	using Zenject;

	public sealed class HeroInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
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