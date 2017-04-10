namespace CurrencyGraph.Domain
{
    public interface IStatelessVisitor<TVisited, TResult>
    {
        TResult Visit(TVisited @this);
    }
}