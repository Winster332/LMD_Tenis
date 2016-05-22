using LMD_Tenis.GameFramewerk.UI.Animations;

namespace LMD_Tenis.GameFramewerk.UI
{
	public class RectButton : GBaseButton
	{
		public event ButtonEvent onClick;

		public RectButton(IGame game) : base(game)
		{
		}

		public override void SetTouch(float x, float y, TypeTouch type)
		{
			if (IsVisible)
			{
				switch (type)
				{
					case TypeTouch.Down:
						if (x > GetX() - GetWidth()/2 && x < GetX() + GetWidth()/2 &&
						    y > GetY() - GetHeight()/2 && y < GetY() + GetHeight())
						{
							Animation?.Start();
						}
						break;
					case TypeTouch.Move:
						break;
					case TypeTouch.Up:
						if (Animation == null)
							if (onClick != null)
							{
								if (x > GetX() - GetWidth()/2 && x < GetX() + GetWidth()/2 &&
								    y > GetY() - GetHeight()/2 && y < GetY() + GetHeight())
								{
									onClick(this);
								}
							}
						break;
				}
			}
		}

		public override void OnStart(IAnimation animation)
		{
			
		}

		public override void OnStop(IAnimation animation)
		{
			onClick?.Invoke(this);
		}

		public override void Step(float dt)
		{
			if (IsVisible)
			{
				image.Step(dt);

				Animation?.Step(dt);
			}
		}

		public override void Draw()
		{
			if (IsVisible)
			{
				image.Draw();
			}
		}

		public override void Dispose()
		{
			image.Dispose();
		}
	}
}