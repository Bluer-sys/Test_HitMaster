namespace Game.Installers
{
	using Game.UI;
	using Zenject;

	public sealed class UiEnemyInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			// UiEnemyView
			Container
				.BindInterfacesTo<UiEnemyView>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			// UiEnemyController
			Container
				.BindInterfacesTo<UiEnemyController>()
				.AsSingle();
		}
	}
}