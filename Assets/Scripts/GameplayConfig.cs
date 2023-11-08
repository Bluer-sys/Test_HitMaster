namespace Game
{
	using UnityEngine;

	[CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "Gameplay", order = 0)]
	public class GameplayConfig : ScriptableObject
	{
		[Header( "Bullet" )] 
		public float	BulletSpeed;

		[Header( "Enemy" )] 
		public float	EnemyThrowForce;
	}
}