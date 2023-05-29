
using NUnit.Framework;
using Xunit;

[TestFixture]
public class SupermarketCheckoutTests
{
    private Checkout checkout;

    [SetUp]
    public void Setup()
    {
        checkout = new Checkout();
    }

    [Test]
    public void CalculateTotalPrice_NoItemsScanned_ReturnsZero()
    {
        decimal totalPrice = checkout.CalculateTotalPrice();

        Assert.AreEqual(0, totalPrice);
    }

    [Test]
    public void CalculateTotalPrice_ScannedItemsWithoutOffers_CalculatesCorrectTotal()
    {
        checkout.Scan('A');
        checkout.Scan('B');
        checkout.Scan('C');

        decimal totalPrice = checkout.CalculateTotalPrice();

        Assert.AreEqual(100, totalPrice);
    }

    [Test]
    public void CalculateTotalPrice_ScannedItemsWithOffers_CalculatesCorrectTotal()
    {
        // Scanning 3 'A' items should trigger the offer
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('B');
        checkout.Scan('C');
        checkout.Scan('D');

        decimal totalPrice = checkout.CalculateTotalPrice();

        Assert.AreEqual(195, totalPrice);
    }

    [Test]
    public void CalculateTotalPrice_ScannedItemsWithRemainingItems_CalculatesCorrectTotal()
    {
        // Scanning 4 'A' items should trigger the offer for 3 items and price for the remaining 1
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('B');
        checkout.Scan('C');
        checkout.Scan('D');

        decimal totalPrice = checkout.CalculateTotalPrice();

        Assert.AreEqual(245, totalPrice);
    }
}
