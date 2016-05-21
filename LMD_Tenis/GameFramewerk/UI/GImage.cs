using System.Drawing;
using System.Drawing.Drawing2D;

namespace LMD_Tenis.GameFramewerk.UI
{
	public class GImage : BaseUI
	{
		private Bitmap image;
		private Matrix matrix;

		public GImage(IGame game) : base(game)
		{
			matrix = new Matrix();
			scaleX = 1f;
			scaleY = 1f;
		}

		public override void SetX(float value)
		{
			x = value;
		}

		public override void SetY(float value)
		{
			y = value;
		}

		public override float GetX()
		{
			return x;
		}

		public override float GetY()
		{
			return y;
		}

		public override void SetVelocityX(float value)
		{
			velocity_x = value;
		}

		public override void SetVelocityY(float value)
		{
			velocity_y = value;
		}

		public override float GetVelocityX()
		{
			return velocity_x;
		}

		public override float GetVelocityY()
		{
			return velocity_y;
		}

		public override void SetAndle(float value)
		{
			angle = value;
		}

		public override float GetAngle()
		{
			return angle;
		}

		public override void SetAngularVelocity(float value)
		{
			angularVelocity = value;
		}

		public override float GetAngularVelocity()
		{
			return angularVelocity;
		}

		public override void Step(float dt)
		{
			x += velocity_x;
			y += velocity_y;

			angle += angularVelocity;
		}

		public override void Draw()
		{
			if (image != null)
			{
				matrix = new Matrix();
				matrix.Translate(x - width/2, y - height/2);
				matrix.Scale(scaleX, scaleY);
				matrix.RotateAt(angle*180/(float) System.Math.PI, new PointF(width/2, height/2));

				game.GetGraphics().GetGraphics().Transform = matrix;
				game.GetGraphics().GetGraphics().DrawImage(image, 0, 0, width, height);
			}
		}

		public override void Dispose()
		{
			image.Dispose();
			image = null;
			matrix.Dispose();
		}

		public Bitmap GetImage()
		{
			return image;
		}

		public void SetImage(Bitmap image)
		{
			this.image = image;
		}

		public void SetWidth(float value)
		{
			width = value;
		}

		public void SetHeight(float value)
		{
			height = value;
		}

		public float GetWidth()
		{
			return width;
		}

		public float GetHeight()
		{
			return height;
		}

		public Matrix GetMatrix()
		{
			return matrix;
		}

		public override void SetScaleX(float value)
		{
			scaleX = value;
		}

		public override void SetScaleY(float value)
		{
			scaleY = value;
		}

		public override float GetScaleX()
		{
			return scaleX;
		}

		public override float GetScaleY()
		{
			return scaleY;
		}
	}
}