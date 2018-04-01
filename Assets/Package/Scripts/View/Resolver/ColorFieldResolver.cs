using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuntimeObjectEditor
{
	public class ColorFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return ColorFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new ColorFieldViewer(model, fieldInfo);
		}
	}
}