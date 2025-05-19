public class Hamster : Pet {
    public Hamster(string id, Color color, int age, int value) : base(id, color, age, value) { }
    public override double Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Finch : Pet {
    public Finch(string id, Color color, int age, int value) : base(id, color, age, value) { }
    public override double Accept(IVisitor visitor) => visitor.Visit(this);
}

public class Tarantula : Pet {
    public Tarantula(string id, Color color, int age, int value) : base(id, color, age, value) { }
    public override double Accept(IVisitor visitor) => visitor.Visit(this);
}