namespace Game.Installers
{
	using Game.Hero;
	using Zenject;

	public sealed class SceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// HeroFacade
			Container
				.BindInterfacesTo<HeroFacade>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}