using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Vector2
{
    public double X;
    public double Y;

    public Vector2(Point p) : this(p.X, p.Y)
    {
    }

    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }
    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2(b.X - a.X, b.Y - a.Y);
    }
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(b.X + a.X, b.Y + a.Y);
    }
    public static Vector2 operator *(Vector2 a, double d)
    {
        return new Vector2(a.X * d, a.Y * d);
    }
    public static Vector2 operator /(Vector2 a, double d)
    {
        return new Vector2(a.X / d, a.Y / d);
    }

    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return (int)a.X == (int)b.X && (int)a.Y == (int)b.Y;
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !((int)a.X == (int)b.X && (int)a.Y == (int)b.Y);
    }

    public static implicit operator Point(Vector2 a)
    {
        return new Point((int)a.X, (int)a.Y);
    }

    public static Vector2 rotate(Vector2 v, double angle)
    {
        double cs = Math.Cos(angle);
        double sn = Math.Sin(angle);
        double px = v.X * cs - v.Y * sn;
        double py = v.X * sn + v.Y * cs;
        return new Vector2(px, py);
    }

    public Vector2 UnitVector
    {
        get
        {
            double l = Length;
            if (l > 0)
                return this / l;
            else
                return this;
        }
    }

    public double Length
    {
        get
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }
    }

    public double distanceTo(Vector2 v)
    {
        return (this - v).Length;
    }

    public static Vector2 Zero
    {
        get { return new Vector2(0, 0); }
    }

    public override string ToString()
    {
        return string.Format("[{0}, {1}]", X, Y);
    }
}
