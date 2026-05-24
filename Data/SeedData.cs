using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProductApp.Data;

public static class SeedData
{
    public static void Seed(this ProductDbContext productDbContext)
    {
        // ========== PHASE 1: Seed Products ==========
        var products = new List<Product>
        {
            new()
            {
                Name = "Keyboard",
                Description = "Gaming Keyboard with lights",
                Price = 150,
                ProductType = ProductType.PERIPHARALS,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "Monitor",
                Description = "HD monitor",
                Price = 400,
                ProductType = ProductType.MONITOR,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>()
            },
            new()
            {
                Name = "Mouse",
                Description = "Gaming Mouse",
                Price = 50,
                ProductType = ProductType.PERIPHARALS,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "CPU",
                Description = "Intel Core i7",
                Price = 500,
                ProductType = ProductType.PROCESSOR,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            },
            new()
            {
                Name = "RAM",
                Description = "16GB",
                Price = 100,
                ProductType = ProductType.MEMORY,
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Components = new List<Components>(),
            }
        };

        productDbContext.Products.AddRange(products);
        productDbContext.SaveChanges();

        // ========== PHASE 2: Seed Components (WITHOUT Manufacturers) ==========
        var components = new List<Components>
        {
            new()
            {
                Name = "Keys",
                Description = "Glowing Keys",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Stickers",
                Description = "Key stickers",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Power cord",
                Description = "Power cables",
                Product = products.FirstOrDefault(p => p.ProductId == 1),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Monitor Cover",
                Description = "Monitor Cover",
                Product = products.FirstOrDefault(p => p.ProductId == 2),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Power cord",
                Description = "Power cables",
                Product = products.FirstOrDefault(p => p.ProductId == 2),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Mouse Pad",
                Description = "Mouse Pad high quality",
                Product = products.FirstOrDefault(p => p.ProductId == 3),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Mouse Dust cover",
                Description = "Mouse dust cover high quality",
                Product = products.FirstOrDefault(p => p.ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Thermal Paste",
                Description = "Thermal",
                Product = products.FirstOrDefault(p => p.ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "Thermal Fan",
                Description = "Thermal Fan",
                Product = products.FirstOrDefault(p => p                .ProductId == 4),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            },
            new()
            {
                Name = "RAM Heat Sink",
                Description = "RAM heat sink with fan",
                Product = products.FirstOrDefault(p => p.ProductId == 5),
                SystemCreatedDate = DateTime.Now,
                UserCreatedDate = DateTime.Now,
                Manufacturers = new List<Manufacturers>(),
            }
        };

        productDbContext.Components.AddRange(components);
        productDbContext.SaveChanges();

        // ========== PHASE 3: Seed Manufacturers (NOW with proper ComponentsId) ==========
        var manufacturers = new List<Manufacturers>
        {
            new()
            {
                Name = "Foxconn",
                Description = "supplier of keyboards",
                ComponentsId = components.First(c => c.Name == "Keys").Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "Italy",
                        City = "Fr",
                        Street = "New place",
                        State = "LI"
                    },
                    new()
                    {
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Main Street",
                        State = "KI"
                    }
                }
            },
            new()
            {
                Name = "Foxconn",
                Description = "supplier of keyboards",
                ComponentsId = components.First(c => c.Name == "Stickers").Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Main Street",
                        State = "KI"
                    },
                    new()
                    {
                        Country = "Italy",
                        City = "Fr",
                        Street = "New place",
                        State = "LI"
                    }
                }
            },
            new()
            {
                Name = "Finolex",
                Description = "supplier of power cables",
                ComponentsId = components.First(c => c.Name == "Power cord" && c.ProductId == 1).Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "India",
                        City = "Delhi",
                        Street = "Main Street",
                        State = "UP"
                    },
                    new()
                    {
                        Country = "India",
                        City = "Chennai",
                        Street = "Ritchi street",
                        State = "TN"
                    }
                }
            },
            new()
            {
                Name = "Foxconn",
                Description = "supplier of keyboards",
                ComponentsId = components.First(c => c.Name == "Monitor Cover").Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Main Street",
                        State = "KI"
                    },
                    new()
                    {
                        Country = "Italy",
                        City = "Fr",
                        Street = "New place",
                        State = "LI"
                    }
                }
            },
            new()
            {
                Name = "Finolex",
                Description = "supplier of power cables",
                ComponentsId = components.First(c => c.Name == "Power cord" && c.ProductId == 2).Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "India",
                        City = "Delhi",
                        Street = "Main Street",
                        State = "UP"
                    },
                    new()
                    {
                        Country = "India",
                        City = "Chennai",
                        Street = "Ritchi street",
                        State = "TN"
                    }
                }
            },
            new()
            {
                Name = "Flextronics",
                Description = "supplier of Mouse",
                ComponentsId = components.First(c => c.Name == "Mouse Pad").Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "India",
                        City = "Chennai",
                        Street = "Sholinganallore",
                        State = "TN"
                    },
                    new()
                    {
                        Country = "China",
                        City = "Beijing",
                        Street = "Xi Lu Streets",
                        State = "CH"
                    }
                }
            },
            new()
            {
                Name = "Syntel",
                Description = "supplier of Monitors",
                ComponentsId = components.First(c => c.Name == "Mouse Dust cover").Id,
                Addresses = new List<Address>
                {
                    new()
                    {
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Main Street",
                        State = "KI"
                    },
                    new()
                    {
                        Country = "Italy",
                        City = "Fr",
                        Street = "New place",
                        State = "LI"
                    }
                }
            }
        };

        productDbContext.Manufacturers.AddRange(manufacturers);
        productDbContext.SaveChanges();
    }
}