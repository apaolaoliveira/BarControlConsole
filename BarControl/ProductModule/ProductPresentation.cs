﻿using BarControl.Shared;
using System.Collections;

namespace BarControl.ProductModule
{
    internal class ProductPresentation : PresentationBase
    {
        public ProductPresentation(ProductRepository ProductRepository)
        {
            repository = ProductRepository;
            entityName = "Product";
        }

        protected override EntityBase GetRecordProperties()
        {
            string name = SetField<string>("Name:", ConsoleColor.Cyan);

            decimal price = SetField<decimal>("Price:", ConsoleColor.Cyan);

            string description = SetField<string>("Description:", ConsoleColor.Cyan);

            Product newProduct = new Product(repository.idCounter, name, description, price);

            return newProduct;
        }

        protected override void DisplayTable()
        {
            string[] columnNames = { "id", "name", "price", "description" };
            int[] columnWidths = { 4, 15, 15, 30 };

            List<object> data = new List<object>();

            ArrayList records = repository.GetRecords();

            foreach (Product product in records)
            {
                data.Add(new object[] { product.id, product.Name, product.Price.ToString("C2"), product.Description });
            }

            SetTable(columnNames, columnWidths, data);

            SetFooter();
        }
    }
}