namespace Tartaros.Math
{
	using System.Collections.Generic;
	using UnityEngine;

	public static class CollisionOverlapCalculator
	{
		public static bool DoOverlap(Circle c1, Circle c2)
		{
			float distance = Vector2.Distance(c1.position, c2.position);
			float distanceMin = c1.radius + c2.radius;

			return distance <= distanceMin;
		}

		public static bool DoOverlap(Rectangle rect1, Rectangle rect2)
		{
			return (rect1.X <= rect2.X + rect2.Width && rect1.X + rect1.Width >= rect2.X && rect1.Y <= rect2.Y + rect2.Height && rect1.Height + rect1.Y >= rect2.Y);
		}

		public static bool DoOverlap(Rectangle rect, Circle circle)
		{
			return DoOverlap(circle, rect);
		}

		public static bool DoOverlap(Circle circle, Rectangle rect)
		{
			return circle.ContainsPosition(rect.BottomRight) || circle.ContainsPosition(rect.TopLeft) || circle.ContainsPosition(rect.Min) || circle.ContainsPosition(rect.Max);
		}

		public static bool DoOverlap(ConvexPolygon polygon, Circle circle)
		{
			return DoOverlap(circle, polygon);
		}

		public static bool DoOverlap(ConvexPolygon p1, ConvexPolygon p2)
		{
			throw new System.NotImplementedException();
		}

		// http://www.jeffreythompson.org/collision-detection/poly-circle.php
		public static bool DoOverlap(Circle circle, ConvexPolygon polygon)
		{
			Vector2[] vertices = polygon.vertices.ToArray();

			// go through each of the vertices, plus
			// the next vertex in the list
			int next = 0;
			for (int current = 0; current < vertices.Length; current++)
			{

				// get next vertex in list
				// if we've hit the end, wrap around to 0
				next = current + 1;
				if (next == vertices.Length) next = 0;

				// get the PVectors at our current position
				// this makes our if statement a little cleaner
				Vector2 vc = vertices[current];    // c for "current"
				Vector2 vn = vertices[next];       // n for "next"

				// check for collision between the circle and
				// a line formed between the two vertices
				bool collision = lineCircle(vc.x, vc.y, vn.x, vn.y, circle);
				if (collision) return true;
			}

			// the above algorithm only checks if the circle
			// is touching the edges of the polygon – in most
			// cases this is enough, but you can un-comment the
			// following code to also test if the center of the
			// circle is inside the polygon

			// boolean centerInside = polygonPoint(vertices, cx,cy);
			// if (centerInside) return true;

			// otherwise, after all that, return false
			return false;
		}

		public static bool lineCircle(float x1, float y1, float x2, float y2, Circle circle)
		{
			float cx = circle.X;
			float cy = circle.Y;
			float r = circle.radius;

			// is either end INSIDE the circle?
			// if so, return true immediately
			bool inside1 = pointCircle(x1, y1, cx, cy, r);
			bool inside2 = pointCircle(x2, y2, cx, cy, r);
			if (inside1 || inside2) return true;

			// get length of the line
			float distX = x1 - x2;
			float distY = y1 - y2;
			float len = Mathf.Sqrt((distX * distX) + (distY * distY));

			// get dot product of the line and circle
			float dot = (((cx - x1) * (x2 - x1)) + ((cy - y1) * (y2 - y1))) / Mathf.Pow(len, 2);

			// find the closest point on the line
			float closestX = x1 + (dot * (x2 - x1));
			float closestY = y1 + (dot * (y2 - y1));

			// is this point actually on the line segment?
			// if so keep going, but if not, return false
			bool onSegment = LinePoint(new Vector2(x1, y1), new Vector2(x2, y2), closestX, closestY);
			if (!onSegment) return false;

			// get distance to closest point
			distX = closestX - cx;
			distY = closestY - cy;
			float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

			// is the circle on the line?
			if (distance <= r)
			{
				return true;
			}
			return false;
		}

		public static bool LinePoint(Vector2 p1, Vector2 p2, float px, float py)
		{

			// get distance from the point to the two ends of the line
			float d1 = Vector2.Distance(p1, p2);
			float d2 = Vector2.Distance(p1, p2);

			// get the length of the line
			float lineLen = Vector2.Distance(p1, p2);

			// since floats are so minutely accurate, add
			// a little buffer zone that will give collision
			float buffer = 0.1f;    // higher # = less accurate

			// if the two distances are equal to the line's
			// length, the point is on the line!
			// note we use the buffer here to give a range, rather
			// than one #
			if (d1 + d2 >= lineLen - buffer && d1 + d2 <= lineLen + buffer)
			{
				return true;
			}
			return false;
		}

		public static bool pointCircle(float px, float py, float cx, float cy, float r)
		{

			// get distance between the point and circle's center
			// using the Pythagorean Theorem
			float distX = px - cx;
			float distY = py - cy;
			float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

			// if the distance is less than the circle's 
			// radius the point is inside!
			if (distance <= r)
			{
				return true;
			}
			return false;
		}

		public static bool polygonPoint(Vector2[] vertices, float px, float py)
		{
			bool collision = false;

			// go through each of the vertices, plus the next
			// vertex in the list
			int next = 0;
			for (int current = 0; current < vertices.Length; current++)
			{

				// get next vertex in list
				// if we've hit the end, wrap around to 0
				next = current + 1;
				if (next == vertices.Length) next = 0;

				// get the PVectors at our current position
				// this makes our if statement a little cleaner
				Vector2 vc = vertices[current];    // c for "current"
				Vector2 vn = vertices[next];       // n for "next"

				// compare position, flip 'collision' variable
				// back and forth
				if (((vc.y > py && vn.y < py) || (vc.y < py && vn.y > py)) &&
					 (px < (vn.x - vc.x) * (py - vc.y) / (vn.y - vc.y) + vc.x))
				{
					collision = !collision;
				}
			}
			return collision;
		}
	}
}
