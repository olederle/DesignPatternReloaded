using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatternReloaded.Util
{

    public class Optional
    {

        private sealed class EmptyOptional<T> : Optional<T>
        {

            public override bool HasValue { get { return false; } }

            public override T Value
            {
                get { throw new InvalidOperationException("Optional is empty."); }
            }

        }

        private sealed class ValueOptional<T> : Optional<T>
        {

            private readonly T value;

            public override bool HasValue { get { return true; } }

            public override T Value { get { return value; } }

            internal ValueOptional(T value)
            {
                this.value = value;
            }

        }

        public static Optional<T> Of<T>(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new ValueOptional<T>(value);
        }

        public static Optional<T> OfNullable<T>(T value)
        {
            if (value == null) return Empty<T>();
            return new ValueOptional<T>(value);
        }

        public static Optional<T> OfNullable<T>(T? value) where T : struct
        {
            if (value == null || !value.HasValue) return Empty<T>();
            return new ValueOptional<T>(value.Value);
        }

        public static Optional<T> Empty<T>()
        {
            return new EmptyOptional<T>();
        }

    }

    public abstract class Optional<T> : IEnumerable<T>
    {

        public abstract bool HasValue { get; }

        public abstract T Value { get; }

        internal Optional() { }

        public void IfHasValue(Action<T> consumer)
        {
            if (HasValue) consumer(Value);
        }

        public Optional<T> Filter(Predicate<T> predicate)
        {
            return HasValue && predicate(Value) ? this : Optional.Empty<T>();
        }

        public Optional<U> Select<U>(Func<T, U> selector)
        {
            return HasValue ? Optional.OfNullable(selector(Value)) : Optional.Empty<U>();
        }

        public Optional<U> SelectFlat<U>(Func<T, Optional<U>> selector)
        {
            return HasValue ? selector(Value) : Optional.Empty<U>();
        }

        public T OrElse(T other)
        {
            return HasValue ? Value : other;
        }

        public T OrElse(Func<T> other)
        {
            return HasValue ? Value : other();
        }

        public T OrElseThrow<E>(Func<E> exceptionSupplier) where E : Exception
        {
            if (HasValue) return Value;
            throw exceptionSupplier();
        }


        public override bool Equals(object obj)
        {
            Optional<T> other = obj as Optional<T>;
            if (other == null) return false;

            if (!HasValue && !other.HasValue) return true;

            if (HasValue && other.HasValue)
            {
                return Equals(Value, other.Value);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HasValue ? Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return string.Format("{0}Optional<{1}>({2})",
                HasValue ? string.Empty : "Empty",
                typeof(T).Name,
                HasValue ? Value.ToString() : string.Empty);
        }



        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (HasValue) yield return Value;
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

    }

}