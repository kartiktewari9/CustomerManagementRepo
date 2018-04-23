using CustomerManagement.Data.DAO;
using System.Data.Entity.ModelConfiguration;

namespace CustomerManagement.Data.Mappings
{
    public class CustomerMap: EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CustomerName).HasColumnName("CustomerName");
            Property(x => x.CustomerAddress).HasColumnName("CustomerAddress");
            Property(x => x.Mobile).HasColumnName("Mobile");
            Property(x => x.Email).HasColumnName("Email");
        }
    }
}
