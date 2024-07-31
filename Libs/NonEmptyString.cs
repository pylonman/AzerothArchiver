using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public readonly record struct NonEmptyString(string value)
	{
		public NonEmptyString() : this(string.Empty) { }
		public string Value { get; init; } = !string.IsNullOrWhiteSpace(value) ? value.Trim() : throw new ArgumentException("Value cannot be null or empty", nameof(value));
		public static implicit operator string(NonEmptyString value) => value.Value;
	}
}
