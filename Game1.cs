using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Prime;
using Prime.Graphics;

namespace PrimeSamples
{
    public class Game1 : PrimeGame
    {
		public Game1() : base(new MainScene())
		{

		}
    }

	class MainScene : Scene
	{
		public override void Initialize()
		{
			base.Initialize();

			Add(new Player());
		}
	}

	class Player : Entity
	{
		public override void Initialize()
		{
			var tx = Scene.Content.Load<Texture2D>("player");
				
			Add(new Sprite(tx));
		}

		public override void Update()
		{

		}
	}
}

