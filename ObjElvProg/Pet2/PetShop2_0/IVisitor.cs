namespace PetShop2_0
{
    public interface IVisitor
    {
        double Visit(Hamster h);
        double Visit(Finch f);
        double Visit(Tarantula t);
    }
}
