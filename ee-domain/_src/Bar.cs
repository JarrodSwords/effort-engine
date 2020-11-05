namespace Effort.Domain
{
    public class Bar : ValueObject<Bar>
    {
        #region Core

        public Bar(int size)
        {
            Size = size;
        }

        #endregion

        #region Public Interface

        public int Size { get; }

        #endregion

        #region Equality, Operators

        public override bool Equals(Bar other) => Size == other.Size;

        #endregion
    }
}
