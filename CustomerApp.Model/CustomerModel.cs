namespace CustomerApp.Model
{
    using System.Collections.Generic;
    using System.Data.Entity;

    public class CustomerModel : DbContext
    {
        // Your context has been configured to use a 'CustomerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CustomerApp.Model.CustomerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomerModel' 
        // connection string in the application configuration file.
        public DbSet<Customer> Customers { get; set; }

        public CustomerModel() : base("name=CustomerModel")
        {
            Database.SetInitializer<CustomerModel>(new CustomerModelInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
    }

    public class CustomerModelInitializer : DropCreateDatabaseIfModelChanges<CustomerModel>
    {
        protected override void Seed(CustomerModel context)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Marko",   Surname = "Antonijevic", Address = "Lodz", TelephoneNumber = "733 081 912 "},
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
        }
    }
}