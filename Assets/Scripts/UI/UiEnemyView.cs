namespace Game.UI
{
	using UnityEngine;
	using UnityEngine.UI;

	public interface IUiEnemyView
	{
		void SetHealthBarFill(float value01);
	}

	public sealed class UiEnemyView : MonoBehaviour, IUiEnemyView
	{
		[SerializeField] Image _hpBar;

		
#region IUiEnemyView

		public void SetHealthBarFill(float value01)		=> _hpBar.fillAmount = value01;

#endregion
	}
}