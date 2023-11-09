namespace Game.Installers
{
	using Game.Enemy;
	using UnityEngine;
	using Zenject;

	public sealed class EnemyInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// Animator
			Container
				.Bind<Animator>()
				.FromComponentInHierarchy()
				.AsSingle();

			// EnemyHealth
			Container
				.Bind<EnemyHealth>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}