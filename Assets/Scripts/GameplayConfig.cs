namespace Game
{
	using UnityEngine;

	[CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "Gameplay", order = 0)]
	public class GameplayConfig : ScriptableObject
	{
		[Header( "Bullet" )] 
		public Bullet	BulletPrefab;
		public float	BulletSpeed;
		public int		BulletDamage;

		[Header( "Enemy" )] 
		public float	EnemyThrowForce;
	}
}