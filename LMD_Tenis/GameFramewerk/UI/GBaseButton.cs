using System;
using System.Drawing;
using LMD_Tenis.GameFramewerk.UI.Animations;

namespace LMD_Tenis.GameFramewerk.UI
{
	public abstract class GBaseButton : BaseUI, IAnimationEvent
	{
		protected GImage image;
		protected Object Tag;
		protected IAnimation Animation;

		protected GBaseButton(IGame game) : base(game)
		{
			image = new GImage(game);
			image.SetScaleX(1f);
			image.SetScaleY(1f);
		}

		public override void SetX(float value)
		{
			image.SetX(value);
		}

		public override void SetY(float value)
		{
			image.SetY(value);
		}

		public override float GetX()
		{
			if (IsCamera)
				return image.GetX() + game.GetCamera().GetX();

			return image.GetX();
		}

		public override float GetY()
		{
			if (IsCamera)
				return image.GetY() + game.GetCamera().GetY();
			
			return image.GetY();
		}

		public override void SetVelocityX(float value)
		{
			image.SetVelocityX(value);
		}

		public override void SetVelocityY(float value)
		{
			image.SetVelocityY(value);
		}

		public override float GetVelocityX()
		{
			return image.GetVelocityX();
		}

		public override float GetVelocityY()
		{
			return image.GetVelocityX();
		}

		public override void SetAndle(float value)
		{
			image.SetAndle(value);
		}

		public override float GetAngle()
		{
			return image.GetAngle();
		}

		public override void SetAngularVelocity(float value)
		{
			image.SetAngularVelocity(value);
		}

		public override float GetAngularVelocity()
		{
			return image.GetAngularVelocity();
		}

		public GImage GetImage()
		{
			return image;
		}

		public void SetImage(GImage image)
		{
			this.image = image;
		}

		public void SetWidth(float value)
		{
			image.SetWidth(value);
		}

		public void SetHeight(float value)
		{
			image.SetHeight(value);
		}

		public float GetWidth()
		{
			return image.GetWidth();
		}

		public float GetHeight()
		{
			return image.GetHeight();
		}

		public void SetTag(Object tag)
		{
			Tag = tag;
		}

		public Object GetTag()
		{
			return Tag;
		}

		public void SetBitmap(Bitmap bitmap)
		{
			image.SetImage(bitmap);
		}

		public override void SetScaleX(float value)
		{
			image.SetScaleX(value);
		}

		public override void SetScaleY(float value)
		{
			image.SetScaleY(value);
		}

		public override float GetScaleX()
		{
			return image.GetScaleX();
		}

		public override float GetScaleY()
		{
			return image.GetScaleY();
		}

		public abstract void SetTouch(float x, float y, TypeTouch type);

		public void SetAnimation(IAnimation animation)
		{
			Animation = animation;
			animation.SetEventAnimation(this);
		}

		public override void SetEnableCamera(bool value)
		{
			IsCamera = value;
		}

		public abstract void OnStart(IAnimation animation);

		public abstract void OnStop(IAnimation animation);
	}
}