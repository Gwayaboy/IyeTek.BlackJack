using System;

namespace IyeTek.BlackJack.TestLibrary.Specification
{
    public interface ISpecification
    {
        Type Story { get; }
        string Title { get; }
    }
}