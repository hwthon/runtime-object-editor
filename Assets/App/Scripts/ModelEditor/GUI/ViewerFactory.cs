using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	public class ViewerFactory
	{
		public static ViewerFactory instance;

		public static ViewerFactory I { get { return instance == null ? instance = new ViewerFactory() : instance; } }

		private List<Resolver> _resolvers = new List<Resolver>();

		private ViewerFactory()
		{
			AddResolver(new TextFieldResolver());
		}

		public ViewerFactory AddResolver(Resolver resolver)
		{
			_resolvers.Add(resolver);
			return this;
		}

		public Resolver FindResolver(System.Type type)
		{
			foreach (Resolver resolver in _resolvers)
			{
				if (resolver.Available(type))
				{
					return resolver;
				}
			}
			return null;
		}

		public Viewer Create(object model, FieldInfo fieldInfo)
		{
			Resolver resolver = FindResolver(fieldInfo.FieldType);
			if (resolver == null)
			{
				return null;
			}
			
			return resolver.Instantiate(model, fieldInfo);
		}
	}

	public abstract class Resolver
	{
		public abstract bool Available(System.Type type);

		public abstract Viewer Instantiate(object model, FieldInfo fieldInfo);
	}

	public class TextFieldResolver : Resolver
	{
		public override bool Available(System.Type type)
		{
			return TextFieldViewer.Available(type);
		}

		public override Viewer Instantiate(object model, FieldInfo fieldInfo)
		{
			return new TextFieldViewer(model, fieldInfo);
		}
	}
}