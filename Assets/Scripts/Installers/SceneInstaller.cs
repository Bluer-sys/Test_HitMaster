namespace Game.Installers
{
	using Game.Hero;
	using Game.Shooting;
	using Input;
	using Zenject;

	public sealed class SceneInstaller : MonoInstaller
	{
		[Inject] readonly GameplayConfig _gameplayConfig;
		
		public override void InstallBindings()
		{
			// SceneController
			Container
				.BindInterfacesTo<SceneController>()
				.AsSingle();
			
			// HeroFacade
			Container
				.BindInterfacesTo<HeroFacade>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// PlayerInput
			Container
				.BindInterfacesTo<PlayerInput>()
				.AsSingle();
			
			// BulletSpawner
			Container
				.BindInterfacesTo<BulletSpawner>()
				.AsSingle();
			
			// Bullet Pool
			Container
				.BindMemoryPool< Bullet, Bullet.Pool >()
				.WithInitialSize( 15 )
				.ExpandByOneAtATime()
				.FromComponentInNewPrefab( _gameplayConfig.BulletPrefab )
				.UnderTransformGroup( "Bullet Pool" );
		}
	}
}