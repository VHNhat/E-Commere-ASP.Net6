﻿namespace E_Commerce.Models
{
    public class Product : AbstractModel
    {
        private string name;
        private string decription;
        private double price;
        private int quantity;

        private Guid? brandId;
        private ProductBrand brand;
        private ICollection<Product_Size> product_sizes;
        private Guid? typeId;
        private ProductType type;
        private ICollection<Product_Store> product_stores;
        private ICollection<Photo> photos;

        public string Name { get => name; set => name = value; }
        public string Decription { get => decription; set => decription = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public Guid? BrandId { get => brandId; set => brandId = value; }
        public ProductBrand Brand { get => brand; set => brand = value; }
        public ICollection<Product_Size> Product_sizes { get => product_sizes; set => product_sizes = value; }
        public Guid? TypeId { get => typeId; set => typeId = value; }
        public ProductType Type { get => type; set => type = value; }
        public ICollection<Product_Store> Product_stores { get => product_stores; set => product_stores = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
    }
}
