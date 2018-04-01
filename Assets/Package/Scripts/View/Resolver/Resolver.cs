using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RuntimeObjectEditor
{
	/// <summary>
	/// タイプの生成するクラスを解決するクラス
	/// </summary>
	public abstract class Resolver
	{
		/// <summary>
		/// 有効なタイプか
		/// </summary>
		public abstract bool Available(System.Type type);

		/// <summary>
		/// Viewerを生成する
		/// </summary>
		public abstract Viewer Instantiate(object model, FieldInfo fieldInfo = null);
	}
}