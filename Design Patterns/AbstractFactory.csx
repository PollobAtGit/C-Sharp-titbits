
/*Client knows about the followings */

internal abstract class Package { }
internal abstract class DeliveryDocument { }

/*Developer is ensuring a particular SET of class instances are returned to the client (if asked) */
/*For this example client will get a Package instance for a particular DeliveryDocument & vice versa as the Package & DeliveryDocument classes are abstract */
/*Client is unable to create instances of that class */

internal abstract class PackageDeliveryFactory
{
    internal abstract Package CreatePackage();
    internal abstract DeliveryDocument CreateDocument();
}

internal class StandardFactory : PackageDeliveryFactory
{
    // POI: Use override for both abstract & virtual methods
    internal override DeliveryDocument CreateDocument() => new Postal();
    internal override Package CreatePackage() => new StandardPackage();
}

internal class DelicateFactory : PackageDeliveryFactory
{
    internal override DeliveryDocument CreateDocument() => new Courier();
    internal override Package CreatePackage() => new ShockProofPackage();
}

/*Client */

public class Client
{
    private Package package;
    private DeliveryDocument document;

    public Client(PackageDeliveryFactory factory)
    {
        package = factory.CreatePackage();
        document = factory.CreateDocument();
    }

    public override string ToString() => $"{package} & {document}";
}


/*Client Application */

var client = new Client(new StandardFactory());
var anotherClient = new Client(new DelicateFactory());

System.Console.WriteLine(client);
System.Console.WriteLine(anotherClient);

/*Implementation Details */
internal class StandardPackage : Package { public override string ToString() => "StandardPackage"; }
internal class ShockProofPackage : Package { public override string ToString() => "ShockProofPackage"; }

internal class Postal : DeliveryDocument { public override string ToString() => "Postal"; }
internal class Courier : DeliveryDocument { public override string ToString() => "Courier"; }
