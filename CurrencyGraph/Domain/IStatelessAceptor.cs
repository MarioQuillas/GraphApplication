namespace CurrencyGraph.Domain
{
    public interface IStatelessAceptor<TVisited>
    {
        TResult Accept<TResult>(IStatelessVisitor<TVisited, TResult> statelessVisitor);
    }
}