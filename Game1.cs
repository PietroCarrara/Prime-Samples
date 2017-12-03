using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prime;
using Prime.Graphics;
using System.Collections.Generic;
using MonoGame.Extended.TextureAtlases;

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

			var sprite = Scene.Content.Load<Texture2D>("spritesheet");
			var atlas = Scene.Content.Load<TextureAtlas>("map");

			var anim = new SpriteSheet(sprite, atlas);
	
			anim.Add("walk", 20, 30, 0.15f);

			anim.Play("walk");
				
			anim.Width = 720;
			anim.Height = 720;

			Add(anim);
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
			// We are gonna use it again, but it's here just for demonstration purposes.
			// If you plan on using the texture again, don't dispose of it!
			// The effects of doing so can be seen by running this example
			GetComponent<Sprite>().Tex.Dispose();
		}
	}
}

