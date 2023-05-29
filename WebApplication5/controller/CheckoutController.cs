using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication5.models;

public class Checkout
{
    private readonly List<Item> items;
    private readonly List<char>
        scannedItems;
    public Checkout()
    {
        items = new List<Item>
        { new Item{SKU='A',Price=50,Offer=new Offer{Quantity=3,OfferPrice=130 }  } ,
             new Item { SKU = 'A', Price = 30, Offer = new Offer { Quantity = 2, OfferPrice = 45 } },
             new Item { SKU = 'A', Price = 20 },
               new Item{SKU='A',Price=15}
            };
        scannedItems = new List<char>();
    }
    public void Scan(char itemSKU)
    {
        scannedItems.Add(itemSKU);
    }
    public int CalculateTotalPrice()
    {
        int totalPrice = 0;
        foreach(var item in items)
        {
            var itemCount = scannedItems.Count(i => i == item.SKU);
            if(item.Offer!=null&& itemCount >=item.Offer.Quantity)
            {
                int OfferCount = itemCount / item.Offer.Quantity;
                int remainingCount=itemCount% item.Offer.Quantity;
                totalPrice += OfferCount*item.Offer.OfferPrice;
                totalPrice += remainingCount * item.Price;
            }
            else
            {
                totalPrice += itemCount * item.Price;
            }
        }
        return totalPrice;
    }
            
}