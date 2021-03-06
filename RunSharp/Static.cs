/*
 * Copyright (c) 2009, Stefan Simek
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TriAxis.RunSharp
{
	using Operands;

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "There is no better name for this.")]
	public static class Static
	{
		public static Operand Field<T>(string name)
		{
			return Field(typeof(T), name);
		}

		public static Operand Field(Type type, string name)
		{
			return new Field((FieldInfo)TypeInfo.FindField(type, name, true).Member, null);
		}

		public static Operand Property<T>(string name)
		{
			return Property(typeof(T), name);
		}

		public static Operand Property(Type type, string name)
		{
			return Property(type, name, Operand.EmptyArray);
		}

		public static Operand Property<T>(string name, params Operand[] indexes)
		{
			return Property(typeof(T), name, indexes);
		}

		public static Operand Property(Type type, string name, params Operand[] indexes)
		{
			return new Property(TypeInfo.FindProperty(type, name, indexes, true), null, indexes);
		}

		public static Operand Invoke<T>(string name)
		{
			return Invoke(typeof(T), name);
		}

		public static Operand Invoke(Type type, string name)
		{
			return Invoke(type, name, Operand.EmptyArray);
		}

		public static Operand Invoke<T>(string name, params Operand[] args)
		{
			return Invoke(typeof(T), name, args);
		}

		public static Operand Invoke(Type type, string name, params Operand[] args)
		{
			return new Invocation(TypeInfo.FindMethod(type, name, args, true), null, args);
		}
	}
}
