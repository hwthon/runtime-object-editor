using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SerializableModelEditor
{
	/// <summary>
	/// Viewerを生成するクラス
	/// 
	/// Resolverを登録して表示するクラスを変えることも可能
	/// </summary>
	public class ViewerFactory
	{
		/// <summary>
		/// シングルトンインスタンス
		/// </summary>
		public static ViewerFactory instance;

		/// <summary>
		/// インスタンス
		/// </summary>
		public static ViewerFactory I { get { return instance == null ? instance = new ViewerFactory() : instance; } }

		/// <summary>
		/// 登録されている型解決クラスのリスト
		/// </summary>
		private List<Resolver> _resolvers = new List<Resolver>();

		/// <summary>
		/// 初期化処理
		/// ここではデフォルトの型解決クラスを登録する
		/// </summary>
		private ViewerFactory()
		{
			AddResolver(new TextFieldResolver())
				.AddResolver(new IntFieldResolver())
				.AddResolver(new FloatFieldResolver())
				.AddResolver(new BooleanFieldResolver())
				.AddResolver(new Vector2FieldResolver())
				.AddResolver(new Vector3FieldResolver())
				.AddResolver(new Vector4FieldResolver())
				.AddResolver(new ColorFieldResolver())
				.AddResolver(new ObjectFieldResolver());
		}

		/// <summary>
		/// 型解決クラスの登録
		/// </summary>
		public ViewerFactory AddResolver(Resolver resolver)
		{
			_resolvers.Add(resolver);
			return this;
		}

		/// <summary>
		/// typeの型解決クラスを取得する
		/// </summary>
		public Resolver FindResolver(System.Type type)
		{
			// TODO: 優先順位とか？
			foreach (Resolver resolver in _resolvers)
			{
				if (resolver.Available(type))
				{
					return resolver;
				}
			}
			return null;
		}

		/// <summary>
		/// Viewerを生成する
		/// </summary>
		public Viewer Create(object model)
		{
			Resolver resolver = FindResolver(model.GetType());
			return resolver == null ? null : resolver.Instantiate(model);
		}

		/// <summary>
		/// Viewerを生成する
		/// </summary>
		public Viewer Create(object model, FieldInfo fieldInfo)
		{
			Resolver resolver = FindResolver(fieldInfo.FieldType);
			return resolver == null ? null : resolver.Instantiate(model, fieldInfo);
		}

		/// <summary>
		/// Viewerを生成する
		/// </summary>
		public Viewer Create(Viewer parent, object model, FieldInfo fieldInfo)
		{
			Viewer viewer = Create(model, fieldInfo);
			if (viewer != null)
			{
				viewer.SetParent(parent);
			}
			return viewer;
		}
	}
}