using System;
using LMD_Tenis.GameFramewerk.UI.Animations;

namespace LMD_Tenis.GameFramewerk.UI
{
	public class CircleButton : GBaseButton
	{
		public event ButtonEvent onClick;

		public CircleButton(IGame game) : base(game)
		{
		}

		public override void Step(float dt)
		{
			image.Step(dt);

			Animation?.Step(dt);
		}

		public override void Draw()
		{
			image.Draw();
		}

		public override void Dispose()
		{
			image.Dispose();
		}

		public override void SetTouch(float x, float y, TypeTouch type)
		{
			float distance = 0;
			switch (type)
			{
				case TypeTouch.Down:
					distance = (float)Math.Sqrt(Math.Pow(x - GetX(), 2) + Math.Pow(y - GetY(), 2));

					if (distance < GetWidth()/2)
					{
						Animation?.Start();
					}
					break;
				case TypeTouch.Move:  break;
				case TypeTouch.Up:
					if (Animation == null)
						if (onClick != null)
						{
							distance = (float) Math.Sqrt(Math.Pow(x - GetX(), 2) + Math.Pow(y - GetY(), 2));

							if (distance < GetWidth()/2)
							{
								onClick(this);
							}
						}
					break;
			}
		}

		public override void OnStart(IAnimation animation)
		{
		}

		public override void OnStop(IAnimation animation)
		{
			onClick?.Invoke(this);
		}
	}
}