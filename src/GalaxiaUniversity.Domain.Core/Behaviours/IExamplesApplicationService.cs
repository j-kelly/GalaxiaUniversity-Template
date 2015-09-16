namespace GalaxiaUniversity.Domain.Core.Behaviours
{
    using GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService;

    public interface IExamplesApplicationService
    {
        AddToShoppingCart.Response AddToShoppingCart(AddToShoppingCart.Request request);
    }
}
