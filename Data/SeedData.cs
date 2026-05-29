namespace GraphQLProductApp.Data;

public static class SeedData
{
    public static void Seed(this ProductDbContext context)
    {
        // Seed only if empty
        if (context.Products.Any())
            return;

        var now = DateTime.Now;

        // =======================
        // PRODUCTS
        // =======================
        var keyboard = new Product
        {
            Name = "Keyboard",
            Description = "Gaming Keyboard with lights",
            Price = 150,
            ProductType = ProductType.PERIPHARALS,
            SystemCreatedDate = now,
            UserCreatedDate = now
        };

        var monitor = new Product
        {
            Name = "Monitor",
            Description = "HD monitor",
            Price = 400,
            ProductType = ProductType.MONITOR,
            SystemCreatedDate = now,
            UserCreatedDate = now
        };

        var mouse = new Product
        {
            Name = "Mouse",
            Description = "Gaming Mouse",
            Price = 50,
            ProductType = ProductType.PERIPHARALS,
            SystemCreatedDate = now,
            UserCreatedDate = now
        };

        var cpu = new Product
        {
            Name = "CPU",
            Description = "Intel Core i7",
            Price = 500,
            ProductType = ProductType.PROCESSOR,
            SystemCreatedDate = now,
            UserCreatedDate = now
        };

        var ram = new Product
        {
            Name = "RAM",
            Description = "16GB",
            Price = 100,
            ProductType = ProductType.MEMORY,
            SystemCreatedDate = now,
            UserCreatedDate = now
        };

        // ✅ STEP 1: SAVE PRODUCTS FIRST
        context.Products.AddRange(keyboard, monitor, mouse, cpu, ram);
        context.SaveChanges();

        // =======================
        // COMPONENTS
        // =======================
        var components = new List<Components>
        {
            new() { Name = "Keys", Description = "Glowing Keys", ProductId = keyboard.ProductId },
            new() { Name = "Stickers", Description = "Key stickers", ProductId = keyboard.ProductId },
            new() { Name = "Power cord", Description = "Power cables", ProductId = keyboard.ProductId },

            new() { Name = "Monitor Cover", Description = "Monitor Cover", ProductId = monitor.ProductId },
            new() { Name = "Power cord", Description = "Power cables", ProductId = monitor.ProductId },

            new() { Name = "Mouse Pad", Description = "Mouse Pad high quality", ProductId = mouse.ProductId },

            new() { Name = "Mouse Dust cover", Description = "Mouse dust cover high quality", ProductId = cpu.ProductId },
            new() { Name = "Thermal Paste", Description = "Thermal", ProductId = cpu.ProductId },
            new() { Name = "Thermal Fan", Description = "Thermal Fan", ProductId = cpu.ProductId },

            new() { Name = "RAM Heat Sink", Description = "RAM heat sink with fan", ProductId = ram.ProductId }
        };

        // ✅ STEP 2: SAVE COMPONENTS
        context.Components.AddRange(components);
        context.SaveChanges();

        // =======================
        // MANUFACTURERS
        // =======================
        var manufacturers = new List<Manufacturers>
        {
            new()
            {
                Name = "Foxconn",
                Description = "Supplier of keyboards",
                ComponentsId = components.First(c => c.Name == "Keys").Id,
                Addresses = new List<Address>
                {
                    new() { Country = "Italy", City = "Fr", Street = "New place", State = "LI" }
                }
            },
            new()
            {
                Name = "Foxconn",
                Description = "Supplier of keyboards",
                ComponentsId = components.First(c => c.Name == "Stickers").Id,
                Addresses = new List<Address>
                {
                    new() { Country = "Germany", City = "Berlin", Street = "Main Street", State = "KI" }
                }
            },
            new()
            {
                Name = "Finolex",
                Description = "Supplier of power cables",
                ComponentsId = components.First(c => c.Name == "Power cord" && c.ProductId == keyboard.ProductId).Id,
                Addresses = new List<Address>
                {
                    new() { Country = "India", City = "Delhi", Street = "Main Street", State = "UP" }
                }
            },
            new()
            {
                Name = "Foxconn",
                Description = "Supplier of monitors",
                ComponentsId = components.First(c => c.Name == "Monitor Cover").Id,
                Addresses = new List<Address>
                {
                    new() { Country = "Germany", City = "Berlin", Street = "Main Street", State = "KI" }
                }
            }
        };

        // ✅ STEP 3: SAVE MANUFACTURERS
        context.Manufacturers.AddRange(manufacturers);
        context.SaveChanges();
    }
}