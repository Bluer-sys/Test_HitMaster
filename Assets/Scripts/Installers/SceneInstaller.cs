namespace Game.Installers
{
	using Game.Hero;
	using Zenject;

	public sealed class SceneInstaller : MonoInstaller
	{
		[Inject] GameplayConfig _gameplayConfig;
		
		public override void InstallBindings()
		{
			// HeroFacade
			Container
				.BindInterfacesTo<HeroFacade>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// Bullet Pool
			/*
			Container
				.BindMemoryPool< Bullet, Bullet.Pool >()
				.WithInitialSize( 15 )
				.ExpandByOneAtATime()
				.FromComponentInNewPrefab( _gameplayConfig.BulletPrefab )
				.UnderTransformGroup( "Bullet Pool" );*/
		}
	}
}