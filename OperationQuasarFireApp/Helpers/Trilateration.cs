using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//https://github.com/hyunbum-2/Trilateration/blob/master/Trilateration/Program.cs
namespace OperationQuasarFireApp.Helpers
{
	using System;

	public class Trilateration
	{
		public static Point2D getTrilateration(Point2D position1, Point2D position2, Point2D position3)
        {

			double x1 = position1.X;
			double y1 = position1.Y;
			double x2 = position2.X;
			double y2 = position2.Y;
			double x3 = position3.X;
			double y3 = position3.Y;

			double r1 = position1.Distance;
			double r2 = position2.Distance;
			double r3 = position3.Distance;

			double S = (Math.Pow(x3, 2) - Math.Pow(x2, 2) + Math.Pow(y3, 2) - Math.Pow(y2, 2) + Math.Pow(r2, 2) - Math.Pow(r3, 2)) / 2;
			double T = (Math.Pow(x1, 2) - Math.Pow(x2, 2) + Math.Pow(y1, 2) - Math.Pow(y2, 2) + Math.Pow(r2, 2) - Math.Pow(r1, 2)) / 2;

			double y = ((T * (x2 - x3)) - (S * (x2 - x1))) / (((y1 - y2) * (x2 - x3)) - ((y3 - y2) * (x2 - x1)));
			double x = ((y * (y1 - y2)) - T) / (x2 - x1);

			Point2D userLocation = new Point2D(x, y, 0);
			return userLocation;
		}
	
	}

	public class Point2D
	{
		public double X;
		public double Y;
		public double Distance;

		public Point2D(double x, double y, double distance)
		{
			this.X = x;
			this.Y = y;
			this.Distance = distance;
		}
	}
}
