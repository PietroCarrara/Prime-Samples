using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

		public override void Update()
		{
			base.Update();

			if(Input.IsKeyDown(Keys.Enter))
			{
				Add(new Player());
			}

			if (Input.IsKeyDown(Keys.Escape))
			{
				Game.Exit();
			}
		}
	}

	class Player : Entity
	{
		public override void Initialize()
		{
			base.Initialize();

			var tx = Scene.Content.Load<Texture2D>("player");
				
			Add(new Sprite(tx));
		}

		public override void Update()
		{
			base.Update();

			var pos = this.Position;
	
			if(Input.IsKeyDown(Keys.L))
			{
				pos.X += 1280 * Time.DetlaTime;
			}
			else if(Input.IsKeyDown(Keys.H))
			{
				pos.X -= 1280 * Time.DetlaTime;
			}

			if(Input.IsKeyPressed(Keys.J))
			{
				pos.Y += 720 * Time.DetlaTime;
			}
			else if(Input.IsKeyReleased(Keys.K))
			{
				pos.Y -= 720 * Time.DetlaTime;
			}

			this.Position = pos;

			if(Input.IsKeyPressed(Keys.X))
			{
				this.Destroy();
			}
		}

		public override void OnDestroy()
		{
			GetComponent<Sprite>().Tex.Dispose();
		}
	}
}

