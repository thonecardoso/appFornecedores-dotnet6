namespace DevIO.Business.Models;

public class Provider : Entity
{
    public string Name { get; set; }
    public string Document { get; set; }
    public ProviderType TypeProvider { get; set; }
    public Address Address { get; set; }
    public bool Enabled { get; set; }

    /* EF Relation */
    public IEnumerable<Product> Products { get; set; }

}
