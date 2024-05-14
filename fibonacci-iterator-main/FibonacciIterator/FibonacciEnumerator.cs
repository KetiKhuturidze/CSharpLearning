using System.Collections;

namespace FibonacciIterator
{
    /// <summary>
    /// Represents an enumerator object to iterate over the Fibonacci sequence numbers.
    /// </summary>
    public sealed class FibonacciEnumerator : IEnumerator<int>
    {
        private readonly int count;
        private int current;
        private int position;
        private int previous;

        public FibonacciEnumerator(int count, int skipCount)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (skipCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skipCount));
            }

            this.count = count;
            this.position = -1;
            this.current = 0;
            this.previous = 1;
            while (skipCount > 0)
            {
                this.MoveNext();
                skipCount--;
            }
        }

        public int Current
        {
            get
            {
                if (this.position == -1)
                {
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext first.");
                }

                return this.current;
            }
        }

        object IEnumerator.Current => this.current;

        public void Dispose()
        {
            // The method is empty, because there are no additional resources to dispose.
            // See "Notes to Implementers" - https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1?view=net-6.0#notes-to-implementers
        }

        public bool MoveNext()
        {
            if (this.position == -1 && this.count > 0)
            {
                this.position++;
                return true;
            }

            if (this.position < this.count)
            {
                var temp = this.current;
                this.current = temp + this.previous;
                this.previous = temp;
                this.position++;
                return this.position < this.count;
            }

            return false;
        }

        public void Reset()
        {
            this.current = 0;
            this.previous = 1;
            this.position = -1;
        }
    }
}
