using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetSQLSchemaAPI.Models
{
    public partial class azwideworldimportersdataDBContext : DbContext
    {
        public azwideworldimportersdataDBContext()
        {
        }

        public azwideworldimportersdataDBContext(DbContextOptions<azwideworldimportersdataDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<CityStaging> CityStagings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerStaging> CustomerStagings { get; set; } = null!;
        public virtual DbSet<Date> Dates { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeStaging> EmployeeStagings { get; set; } = null!;
        public virtual DbSet<EtlCutoff> EtlCutoffs { get; set; } = null!;
        public virtual DbSet<Lineage> Lineages { get; set; } = null!;
        public virtual DbSet<Movement> Movements { get; set; } = null!;
        public virtual DbSet<MovementStaging> MovementStagings { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStaging> OrderStagings { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PaymentMethodStaging> PaymentMethodStagings { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<PurchaseStaging> PurchaseStagings { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleStaging> SaleStagings { get; set; } = null!;
        public virtual DbSet<StockHolding> StockHoldings { get; set; } = null!;
        public virtual DbSet<StockHoldingStaging> StockHoldingStagings { get; set; } = null!;
        public virtual DbSet<StockItem> StockItems { get; set; } = null!;
        public virtual DbSet<StockItemStaging> StockItemStagings { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierStaging> SupplierStagings { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionStaging> TransactionStagings { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<TransactionTypeStaging> TransactionTypeStagings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:WorldWideImpoters");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_100_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityKey)
                    .HasName("PK_Dimension_City");

                entity.ToTable("City", "Dimension");

                entity.HasIndex(e => new { e.WwiCityId, e.ValidFrom, e.ValidTo }, "IX_Dimension_City_WWICityID");

                entity.Property(e => e.CityKey)
                    .HasColumnName("City Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CityKey])");

                entity.Property(e => e.City1)
                    .HasMaxLength(50)
                    .HasColumnName("City");

                entity.Property(e => e.Continent).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.LatestRecordedPopulation).HasColumnName("Latest Recorded Population");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.Region).HasMaxLength(30);

                entity.Property(e => e.SalesTerritory)
                    .HasMaxLength(50)
                    .HasColumnName("Sales Territory");

                entity.Property(e => e.StateProvince)
                    .HasMaxLength(50)
                    .HasColumnName("State Province");

                entity.Property(e => e.Subregion).HasMaxLength(30);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");
            });

            modelBuilder.Entity<CityStaging>(entity =>
            {
                entity.HasKey(e => e.CityStagingKey)
                    .HasName("PK_Integration_City_Staging");

                entity.ToTable("City_Staging", "Integration");

                entity.HasIndex(e => e.WwiCityId, "IX_Integration_City_Staging_WWI_City_ID");

                entity.Property(e => e.CityStagingKey).HasColumnName("City Staging Key");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Continent).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.LatestRecordedPopulation).HasColumnName("Latest Recorded Population");

                entity.Property(e => e.Region).HasMaxLength(30);

                entity.Property(e => e.SalesTerritory)
                    .HasMaxLength(50)
                    .HasColumnName("Sales Territory");

                entity.Property(e => e.StateProvince)
                    .HasMaxLength(50)
                    .HasColumnName("State Province");

                entity.Property(e => e.Subregion).HasMaxLength(30);

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerKey)
                    .HasName("PK_Dimension_Customer");

                entity.ToTable("Customer", "Dimension");

                entity.HasIndex(e => new { e.WwiCustomerId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Customer_WWICustomerID");

                entity.Property(e => e.CustomerKey)
                    .HasColumnName("Customer Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[CustomerKey])");

                entity.Property(e => e.BillToCustomer)
                    .HasMaxLength(100)
                    .HasColumnName("Bill To Customer");

                entity.Property(e => e.BuyingGroup)
                    .HasMaxLength(50)
                    .HasColumnName("Buying Group");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Customer1)
                    .HasMaxLength(100)
                    .HasColumnName("Customer");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("Postal Code");

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(50)
                    .HasColumnName("Primary Contact");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");
            });

            modelBuilder.Entity<CustomerStaging>(entity =>
            {
                entity.HasKey(e => e.CustomerStagingKey)
                    .HasName("PK_Integration_Customer_Staging");

                entity.ToTable("Customer_Staging", "Integration");

                entity.HasIndex(e => e.WwiCustomerId, "IX_Integration_Customer_Staging_WWI_Customer_ID");

                entity.Property(e => e.CustomerStagingKey).HasColumnName("Customer Staging Key");

                entity.Property(e => e.BillToCustomer)
                    .HasMaxLength(100)
                    .HasColumnName("Bill To Customer");

                entity.Property(e => e.BuyingGroup)
                    .HasMaxLength(50)
                    .HasColumnName("Buying Group");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Customer).HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("Postal Code");

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(50)
                    .HasColumnName("Primary Contact");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.Date1)
                    .HasName("PK_Dimension_Date");

                entity.ToTable("Date", "Dimension");

                entity.Property(e => e.Date1)
                    .HasColumnType("date")
                    .HasColumnName("Date");

                entity.Property(e => e.CalendarMonthLabel)
                    .HasMaxLength(20)
                    .HasColumnName("Calendar Month Label");

                entity.Property(e => e.CalendarMonthNumber).HasColumnName("Calendar Month Number");

                entity.Property(e => e.CalendarYear).HasColumnName("Calendar Year");

                entity.Property(e => e.CalendarYearLabel)
                    .HasMaxLength(10)
                    .HasColumnName("Calendar Year Label");

                entity.Property(e => e.Day).HasMaxLength(10);

                entity.Property(e => e.DayNumber).HasColumnName("Day Number");

                entity.Property(e => e.FiscalMonthLabel)
                    .HasMaxLength(20)
                    .HasColumnName("Fiscal Month Label");

                entity.Property(e => e.FiscalMonthNumber).HasColumnName("Fiscal Month Number");

                entity.Property(e => e.FiscalYear).HasColumnName("Fiscal Year");

                entity.Property(e => e.FiscalYearLabel)
                    .HasMaxLength(10)
                    .HasColumnName("Fiscal Year Label");

                entity.Property(e => e.IsoWeekNumber).HasColumnName("ISO Week Number");

                entity.Property(e => e.Month).HasMaxLength(10);

                entity.Property(e => e.ShortMonth)
                    .HasMaxLength(3)
                    .HasColumnName("Short Month");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK_Dimension_Employee");

                entity.ToTable("Employee", "Dimension");

                entity.HasIndex(e => new { e.WwiEmployeeId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Employee_WWIEmployeeID");

                entity.Property(e => e.EmployeeKey)
                    .HasColumnName("Employee Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[EmployeeKey])");

                entity.Property(e => e.Employee1)
                    .HasMaxLength(50)
                    .HasColumnName("Employee");

                entity.Property(e => e.IsSalesperson).HasColumnName("Is Salesperson");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(50)
                    .HasColumnName("Preferred Name");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiEmployeeId).HasColumnName("WWI Employee ID");
            });

            modelBuilder.Entity<EmployeeStaging>(entity =>
            {
                entity.HasKey(e => e.EmployeeStagingKey)
                    .HasName("PK_Integration_Employee_Staging");

                entity.ToTable("Employee_Staging", "Integration");

                entity.HasIndex(e => e.WwiEmployeeId, "IX_Integration_Employee_Staging_WWI_Employee_ID");

                entity.Property(e => e.EmployeeStagingKey).HasColumnName("Employee Staging Key");

                entity.Property(e => e.Employee).HasMaxLength(50);

                entity.Property(e => e.IsSalesperson).HasColumnName("Is Salesperson");

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(50)
                    .HasColumnName("Preferred Name");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiEmployeeId).HasColumnName("WWI Employee ID");
            });

            modelBuilder.Entity<EtlCutoff>(entity =>
            {
                entity.HasKey(e => e.TableName)
                    .HasName("PK_Integration_ETL_Cutoff");

                entity.ToTable("ETL Cutoff", "Integration");

                entity.Property(e => e.TableName)
                    .HasMaxLength(128)
                    .HasColumnName("Table Name");

                entity.Property(e => e.CutoffTime).HasColumnName("Cutoff Time");
            });

            modelBuilder.Entity<Lineage>(entity =>
            {
                entity.HasKey(e => e.LineageKey)
                    .HasName("PK_Integration_Lineage");

                entity.ToTable("Lineage", "Integration");

                entity.Property(e => e.LineageKey)
                    .HasColumnName("Lineage Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[LineageKey])");

                entity.Property(e => e.DataLoadCompleted).HasColumnName("Data Load Completed");

                entity.Property(e => e.DataLoadStarted).HasColumnName("Data Load Started");

                entity.Property(e => e.SourceSystemCutoffTime).HasColumnName("Source System Cutoff Time");

                entity.Property(e => e.TableName)
                    .HasMaxLength(128)
                    .HasColumnName("Table Name");

                entity.Property(e => e.WasSuccessful).HasColumnName("Was Successful");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasKey(e => e.MovementKey)
                    .HasName("PK_Fact_Movement");

                entity.ToTable("Movement", "Fact");

                entity.HasIndex(e => e.CustomerKey, "FK_Fact_Movement_Customer_Key");

                entity.HasIndex(e => e.DateKey, "FK_Fact_Movement_Date_Key");

                entity.HasIndex(e => e.StockItemKey, "FK_Fact_Movement_Stock_Item_Key");

                entity.HasIndex(e => e.SupplierKey, "FK_Fact_Movement_Supplier_Key");

                entity.HasIndex(e => e.TransactionTypeKey, "FK_Fact_Movement_Transaction_Type_Key");

                entity.HasIndex(e => e.WwiStockItemTransactionId, "IX_Integration_Movement_WWI_Stock_Item_Transaction_ID");

                entity.Property(e => e.MovementKey).HasColumnName("Movement Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemTransactionId).HasColumnName("WWI Stock Item Transaction ID");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.CustomerKey)
                    .HasConstraintName("FK_Fact_Movement_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Date_Key_Dimension_Date");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Stock_Item_Key_Dimension_Stock Item");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.SupplierKey)
                    .HasConstraintName("FK_Fact_Movement_Supplier_Key_Dimension_Supplier");

                entity.HasOne(d => d.TransactionTypeKeyNavigation)
                    .WithMany(p => p.Movements)
                    .HasForeignKey(d => d.TransactionTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Movement_Transaction_Type_Key_Dimension_Transaction Type");
            });

            modelBuilder.Entity<MovementStaging>(entity =>
            {
                entity.HasKey(e => e.MovementStagingKey)
                    .HasName("PK_Integration_Movement_Staging");

                entity.ToTable("Movement_Staging", "Integration");

                entity.Property(e => e.MovementStagingKey).HasColumnName("Movement Staging Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.LastModifedWhen).HasColumnName("Last Modifed When");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");

                entity.Property(e => e.WwiStockItemTransactionId).HasColumnName("WWI Stock Item Transaction ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderKey)
                    .HasName("PK_Fact_Order");

                entity.ToTable("Order", "Fact");

                entity.HasIndex(e => e.CityKey, "FK_Fact_Order_City_Key");

                entity.HasIndex(e => e.CustomerKey, "FK_Fact_Order_Customer_Key");

                entity.HasIndex(e => e.OrderDateKey, "FK_Fact_Order_Order_Date_Key");

                entity.HasIndex(e => e.PickedDateKey, "FK_Fact_Order_Picked_Date_Key");

                entity.HasIndex(e => e.PickerKey, "FK_Fact_Order_Picker_Key");

                entity.HasIndex(e => e.SalespersonKey, "FK_Fact_Order_Salesperson_Key");

                entity.HasIndex(e => e.StockItemKey, "FK_Fact_Order_Stock_Item_Key");

                entity.HasIndex(e => e.WwiOrderId, "IX_Integration_Order_WWI_Order_ID");

                entity.Property(e => e.OrderKey).HasColumnName("Order Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OrderDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Order Date Key");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.PickedDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Picked Date Key");

                entity.Property(e => e.PickerKey).HasColumnName("Picker Key");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.WwiBackorderId).HasColumnName("WWI Backorder ID");

                entity.Property(e => e.WwiOrderId).HasColumnName("WWI Order ID");

                entity.HasOne(d => d.CityKeyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_City_Key_Dimension_City");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.OrderDateKeyNavigation)
                    .WithMany(p => p.OrderOrderDateKeyNavigations)
                    .HasForeignKey(d => d.OrderDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Order_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PickedDateKeyNavigation)
                    .WithMany(p => p.OrderPickedDateKeyNavigations)
                    .HasForeignKey(d => d.PickedDateKey)
                    .HasConstraintName("FK_Fact_Order_Picked_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PickerKeyNavigation)
                    .WithMany(p => p.OrderPickerKeyNavigations)
                    .HasForeignKey(d => d.PickerKey)
                    .HasConstraintName("FK_Fact_Order_Picker_Key_Dimension_Employee");

                entity.HasOne(d => d.SalespersonKeyNavigation)
                    .WithMany(p => p.OrderSalespersonKeyNavigations)
                    .HasForeignKey(d => d.SalespersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Salesperson_Key_Dimension_Employee");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Order_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<OrderStaging>(entity =>
            {
                entity.HasKey(e => e.OrderStagingKey)
                    .HasName("PK_Integration_Order_Staging");

                entity.ToTable("Order_Staging", "Integration");

                entity.Property(e => e.OrderStagingKey).HasColumnName("Order Staging Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OrderDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Order Date Key");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.PickedDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Picked Date Key");

                entity.Property(e => e.PickerKey).HasColumnName("Picker Key");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.WwiBackorderId).HasColumnName("WWI Backorder ID");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiOrderId).HasColumnName("WWI Order ID");

                entity.Property(e => e.WwiPickerId).HasColumnName("WWI Picker ID");

                entity.Property(e => e.WwiSalespersonId).HasColumnName("WWI Salesperson ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodKey)
                    .HasName("PK_Dimension_Payment_Method");

                entity.ToTable("Payment Method", "Dimension");

                entity.HasIndex(e => new { e.WwiPaymentMethodId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Payment_Method_WWIPaymentMethodID");

                entity.Property(e => e.PaymentMethodKey)
                    .HasColumnName("Payment Method Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[PaymentMethodKey])");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PaymentMethod1)
                    .HasMaxLength(50)
                    .HasColumnName("Payment Method");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");
            });

            modelBuilder.Entity<PaymentMethodStaging>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodStagingKey)
                    .HasName("PK_Integration_PaymentMethod_Staging");

                entity.ToTable("PaymentMethod_Staging", "Integration");

                entity.HasIndex(e => e.WwiPaymentMethodId, "IX_Integration_PaymentMethod_Staging_WWI_Payment_Method_ID");

                entity.Property(e => e.PaymentMethodStagingKey).HasColumnName("Payment Method Staging Key");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("Payment Method");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.PurchaseKey)
                    .HasName("PK_Fact_Purchase");

                entity.ToTable("Purchase", "Fact");

                entity.HasIndex(e => e.DateKey, "FK_Fact_Purchase_Date_Key");

                entity.HasIndex(e => e.StockItemKey, "FK_Fact_Purchase_Stock_Item_Key");

                entity.HasIndex(e => e.SupplierKey, "FK_Fact_Purchase_Supplier_Key");

                entity.Property(e => e.PurchaseKey).HasColumnName("Purchase Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.IsOrderFinalized).HasColumnName("Is Order Finalized");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OrderedOuters).HasColumnName("Ordered Outers");

                entity.Property(e => e.OrderedQuantity).HasColumnName("Ordered Quantity");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.ReceivedOuters).HasColumnName("Received Outers");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Date_Key_Dimension_Date");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Stock_Item_Key_Dimension_Stock Item");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.SupplierKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Purchase_Supplier_Key_Dimension_Supplier");
            });

            modelBuilder.Entity<PurchaseStaging>(entity =>
            {
                entity.HasKey(e => e.PurchaseStagingKey)
                    .HasName("PK_Integration_Purchase_Staging");

                entity.ToTable("Purchase_Staging", "Integration");

                entity.Property(e => e.PurchaseStagingKey).HasColumnName("Purchase Staging Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.IsOrderFinalized).HasColumnName("Is Order Finalized");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.OrderedOuters).HasColumnName("Ordered Outers");

                entity.Property(e => e.OrderedQuantity).HasColumnName("Ordered Quantity");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.ReceivedOuters).HasColumnName("Received Outers");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleKey)
                    .HasName("PK_Fact_Sale");

                entity.ToTable("Sale", "Fact");

                entity.HasIndex(e => e.BillToCustomerKey, "FK_Fact_Sale_Bill_To_Customer_Key");

                entity.HasIndex(e => e.CityKey, "FK_Fact_Sale_City_Key");

                entity.HasIndex(e => e.CustomerKey, "FK_Fact_Sale_Customer_Key");

                entity.HasIndex(e => e.DeliveryDateKey, "FK_Fact_Sale_Delivery_Date_Key");

                entity.HasIndex(e => e.InvoiceDateKey, "FK_Fact_Sale_Invoice_Date_Key");

                entity.HasIndex(e => e.SalespersonKey, "FK_Fact_Sale_Salesperson_Key");

                entity.HasIndex(e => e.StockItemKey, "FK_Fact_Sale_Stock_Item_Key");

                entity.Property(e => e.SaleKey).HasColumnName("Sale Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DeliveryDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Delivery Date Key");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.InvoiceDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Invoice Date Key");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TotalChillerItems).HasColumnName("Total Chiller Items");

                entity.Property(e => e.TotalDryItems).HasColumnName("Total Dry Items");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.HasOne(d => d.BillToCustomerKeyNavigation)
                    .WithMany(p => p.SaleBillToCustomerKeyNavigations)
                    .HasForeignKey(d => d.BillToCustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Bill_To_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.CityKeyNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_City_Key_Dimension_City");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.SaleCustomerKeyNavigations)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DeliveryDateKeyNavigation)
                    .WithMany(p => p.SaleDeliveryDateKeyNavigations)
                    .HasForeignKey(d => d.DeliveryDateKey)
                    .HasConstraintName("FK_Fact_Sale_Delivery_Date_Key_Dimension_Date");

                entity.HasOne(d => d.InvoiceDateKeyNavigation)
                    .WithMany(p => p.SaleInvoiceDateKeyNavigations)
                    .HasForeignKey(d => d.InvoiceDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Invoice_Date_Key_Dimension_Date");

                entity.HasOne(d => d.SalespersonKeyNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SalespersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Salesperson_Key_Dimension_Employee");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Sale_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<SaleStaging>(entity =>
            {
                entity.HasKey(e => e.SaleStagingKey)
                    .HasName("PK_Integration_Sale_Staging");

                entity.ToTable("Sale_Staging", "Integration");

                entity.Property(e => e.SaleStagingKey).HasColumnName("Sale Staging Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CityKey).HasColumnName("City Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DeliveryDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Delivery Date Key");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.InvoiceDateKey)
                    .HasColumnType("date")
                    .HasColumnName("Invoice Date Key");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.Package).HasMaxLength(50);

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalespersonKey).HasColumnName("Salesperson Key");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TotalChillerItems).HasColumnName("Total Chiller Items");

                entity.Property(e => e.TotalDryItems).HasColumnName("Total Dry Items");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.WwiBillToCustomerId).HasColumnName("WWI Bill To Customer ID");

                entity.Property(e => e.WwiCityId).HasColumnName("WWI City ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiSalespersonId).HasColumnName("WWI Salesperson ID");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockHolding>(entity =>
            {
                entity.HasKey(e => e.StockHoldingKey)
                    .HasName("PK_Fact_Stock_Holding");

                entity.ToTable("Stock Holding", "Fact");

                entity.HasIndex(e => e.StockItemKey, "FK_Fact_Stock_Holding_Stock_Item_Key");

                entity.Property(e => e.StockHoldingKey).HasColumnName("Stock Holding Key");

                entity.Property(e => e.BinLocation)
                    .HasMaxLength(20)
                    .HasColumnName("Bin Location");

                entity.Property(e => e.LastCostPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Last Cost Price");

                entity.Property(e => e.LastStocktakeQuantity).HasColumnName("Last Stocktake Quantity");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity On Hand");

                entity.Property(e => e.ReorderLevel).HasColumnName("Reorder Level");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TargetStockLevel).HasColumnName("Target Stock Level");

                entity.HasOne(d => d.StockItemKeyNavigation)
                    .WithMany(p => p.StockHoldings)
                    .HasForeignKey(d => d.StockItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Stock_Holding_Stock_Item_Key_Dimension_Stock Item");
            });

            modelBuilder.Entity<StockHoldingStaging>(entity =>
            {
                entity.HasKey(e => e.StockHoldingStagingKey)
                    .HasName("PK_Integration_StockHolding_Staging");

                entity.ToTable("StockHolding_Staging", "Integration");

                entity.Property(e => e.StockHoldingStagingKey).HasColumnName("Stock Holding Staging Key");

                entity.Property(e => e.BinLocation)
                    .HasMaxLength(20)
                    .HasColumnName("Bin Location");

                entity.Property(e => e.LastCostPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Last Cost Price");

                entity.Property(e => e.LastStocktakeQuantity).HasColumnName("Last Stocktake Quantity");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity On Hand");

                entity.Property(e => e.ReorderLevel).HasColumnName("Reorder Level");

                entity.Property(e => e.StockItemKey).HasColumnName("Stock Item Key");

                entity.Property(e => e.TargetStockLevel).HasColumnName("Target Stock Level");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockItem>(entity =>
            {
                entity.HasKey(e => e.StockItemKey)
                    .HasName("PK_Dimension_Stock_Item");

                entity.ToTable("Stock Item", "Dimension");

                entity.HasIndex(e => new { e.WwiStockItemId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Stock_Item_WWIStockItemID");

                entity.Property(e => e.StockItemKey)
                    .HasColumnName("Stock Item Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[StockItemKey])");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.BuyingPackage)
                    .HasMaxLength(50)
                    .HasColumnName("Buying Package");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.IsChillerStock).HasColumnName("Is Chiller Stock");

                entity.Property(e => e.LeadTimeDays).HasColumnName("Lead Time Days");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.QuantityPerOuter).HasColumnName("Quantity Per Outer");

                entity.Property(e => e.RecommendedRetailPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Recommended Retail Price");

                entity.Property(e => e.SellingPackage)
                    .HasMaxLength(50)
                    .HasColumnName("Selling Package");

                entity.Property(e => e.Size).HasMaxLength(20);

                entity.Property(e => e.StockItem1)
                    .HasMaxLength(100)
                    .HasColumnName("Stock Item");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TypicalWeightPerUnit)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Typical Weight Per Unit");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<StockItemStaging>(entity =>
            {
                entity.HasKey(e => e.StockItemStagingKey)
                    .HasName("PK_Integration_StockItem_Staging");

                entity.ToTable("StockItem_Staging", "Integration");

                entity.HasIndex(e => e.WwiStockItemId, "IX_Integration_StockItem_Staging_WWI_Stock_Item_ID");

                entity.Property(e => e.StockItemStagingKey).HasColumnName("Stock Item Staging Key");

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.BuyingPackage)
                    .HasMaxLength(50)
                    .HasColumnName("Buying Package");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.IsChillerStock).HasColumnName("Is Chiller Stock");

                entity.Property(e => e.LeadTimeDays).HasColumnName("Lead Time Days");

                entity.Property(e => e.QuantityPerOuter).HasColumnName("Quantity Per Outer");

                entity.Property(e => e.RecommendedRetailPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Recommended Retail Price");

                entity.Property(e => e.SellingPackage)
                    .HasMaxLength(50)
                    .HasColumnName("Selling Package");

                entity.Property(e => e.Size).HasMaxLength(20);

                entity.Property(e => e.StockItem)
                    .HasMaxLength(100)
                    .HasColumnName("Stock Item");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax Rate");

                entity.Property(e => e.TypicalWeightPerUnit)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Typical Weight Per Unit");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Unit Price");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiStockItemId).HasColumnName("WWI Stock Item ID");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierKey)
                    .HasName("PK_Dimension_Supplier");

                entity.ToTable("Supplier", "Dimension");

                entity.HasIndex(e => new { e.WwiSupplierId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Supplier_WWISupplierID");

                entity.Property(e => e.SupplierKey)
                    .HasColumnName("Supplier Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[SupplierKey])");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.PaymentDays).HasColumnName("Payment Days");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("Postal Code");

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(50)
                    .HasColumnName("Primary Contact");

                entity.Property(e => e.Supplier1)
                    .HasMaxLength(100)
                    .HasColumnName("Supplier");

                entity.Property(e => e.SupplierReference)
                    .HasMaxLength(20)
                    .HasColumnName("Supplier Reference");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<SupplierStaging>(entity =>
            {
                entity.HasKey(e => e.SupplierStagingKey)
                    .HasName("PK_Integration_Supplier_Staging");

                entity.ToTable("Supplier_Staging", "Integration");

                entity.HasIndex(e => e.WwiSupplierId, "IX_Integration_Supplier_Staging_WWI_Supplier_ID");

                entity.Property(e => e.SupplierStagingKey).HasColumnName("Supplier Staging Key");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.PaymentDays).HasColumnName("Payment Days");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("Postal Code");

                entity.Property(e => e.PrimaryContact)
                    .HasMaxLength(50)
                    .HasColumnName("Primary Contact");

                entity.Property(e => e.Supplier).HasMaxLength(100);

                entity.Property(e => e.SupplierReference)
                    .HasMaxLength(20)
                    .HasColumnName("Supplier Reference");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionKey)
                    .HasName("PK_Fact_Transaction");

                entity.ToTable("Transaction", "Fact");

                entity.HasIndex(e => e.BillToCustomerKey, "FK_Fact_Transaction_Bill_To_Customer_Key");

                entity.HasIndex(e => e.CustomerKey, "FK_Fact_Transaction_Customer_Key");

                entity.HasIndex(e => e.DateKey, "FK_Fact_Transaction_Date_Key");

                entity.HasIndex(e => e.PaymentMethodKey, "FK_Fact_Transaction_Payment_Method_Key");

                entity.HasIndex(e => e.SupplierKey, "FK_Fact_Transaction_Supplier_Key");

                entity.HasIndex(e => e.TransactionTypeKey, "FK_Fact_Transaction_Transaction_Type_Key");

                entity.Property(e => e.TransactionKey).HasColumnName("Transaction Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.IsFinalized).HasColumnName("Is Finalized");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.OutstandingBalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Outstanding Balance");

                entity.Property(e => e.PaymentMethodKey).HasColumnName("Payment Method Key");

                entity.Property(e => e.SupplierInvoiceNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Supplier Invoice Number");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiCustomerTransactionId).HasColumnName("WWI Customer Transaction ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiSupplierTransactionId).HasColumnName("WWI Supplier Transaction ID");

                entity.HasOne(d => d.BillToCustomerKeyNavigation)
                    .WithMany(p => p.TransactionBillToCustomerKeyNavigations)
                    .HasForeignKey(d => d.BillToCustomerKey)
                    .HasConstraintName("FK_Fact_Transaction_Bill_To_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.TransactionCustomerKeyNavigations)
                    .HasForeignKey(d => d.CustomerKey)
                    .HasConstraintName("FK_Fact_Transaction_Customer_Key_Dimension_Customer");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Transaction_Date_Key_Dimension_Date");

                entity.HasOne(d => d.PaymentMethodKeyNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentMethodKey)
                    .HasConstraintName("FK_Fact_Transaction_Payment_Method_Key_Dimension_Payment Method");

                entity.HasOne(d => d.SupplierKeyNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SupplierKey)
                    .HasConstraintName("FK_Fact_Transaction_Supplier_Key_Dimension_Supplier");

                entity.HasOne(d => d.TransactionTypeKeyNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fact_Transaction_Transaction_Type_Key_Dimension_Transaction Type");
            });

            modelBuilder.Entity<TransactionStaging>(entity =>
            {
                entity.HasKey(e => e.TransactionStagingKey)
                    .HasName("PK_Integration_Transaction_Staging");

                entity.ToTable("Transaction_Staging", "Integration");

                entity.Property(e => e.TransactionStagingKey).HasColumnName("Transaction Staging Key");

                entity.Property(e => e.BillToCustomerKey).HasColumnName("Bill To Customer Key");

                entity.Property(e => e.CustomerKey).HasColumnName("Customer Key");

                entity.Property(e => e.DateKey)
                    .HasColumnType("date")
                    .HasColumnName("Date Key");

                entity.Property(e => e.IsFinalized).HasColumnName("Is Finalized");

                entity.Property(e => e.LastModifiedWhen).HasColumnName("Last Modified When");

                entity.Property(e => e.OutstandingBalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Outstanding Balance");

                entity.Property(e => e.PaymentMethodKey).HasColumnName("Payment Method Key");

                entity.Property(e => e.SupplierInvoiceNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Supplier Invoice Number");

                entity.Property(e => e.SupplierKey).HasColumnName("Supplier Key");

                entity.Property(e => e.TaxAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Tax Amount");

                entity.Property(e => e.TotalExcludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Excluding Tax");

                entity.Property(e => e.TotalIncludingTax)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total Including Tax");

                entity.Property(e => e.TransactionTypeKey).HasColumnName("Transaction Type Key");

                entity.Property(e => e.WwiBillToCustomerId).HasColumnName("WWI Bill To Customer ID");

                entity.Property(e => e.WwiCustomerId).HasColumnName("WWI Customer ID");

                entity.Property(e => e.WwiCustomerTransactionId).HasColumnName("WWI Customer Transaction ID");

                entity.Property(e => e.WwiInvoiceId).HasColumnName("WWI Invoice ID");

                entity.Property(e => e.WwiPaymentMethodId).HasColumnName("WWI Payment Method ID");

                entity.Property(e => e.WwiPurchaseOrderId).HasColumnName("WWI Purchase Order ID");

                entity.Property(e => e.WwiSupplierId).HasColumnName("WWI Supplier ID");

                entity.Property(e => e.WwiSupplierTransactionId).HasColumnName("WWI Supplier Transaction ID");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeKey)
                    .HasName("PK_Dimension_Transaction_Type");

                entity.ToTable("Transaction Type", "Dimension");

                entity.HasIndex(e => new { e.WwiTransactionTypeId, e.ValidFrom, e.ValidTo }, "IX_Dimension_Transaction_Type_WWITransactionTypeID");

                entity.Property(e => e.TransactionTypeKey)
                    .HasColumnName("Transaction Type Key")
                    .HasDefaultValueSql("(NEXT VALUE FOR [Sequences].[TransactionTypeKey])");

                entity.Property(e => e.LineageKey).HasColumnName("Lineage Key");

                entity.Property(e => e.TransactionType1)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction Type");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.Entity<TransactionTypeStaging>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeStagingKey)
                    .HasName("PK_Integration_TransactionType_Staging");

                entity.ToTable("TransactionType_Staging", "Integration");

                entity.Property(e => e.TransactionTypeStagingKey).HasColumnName("Transaction Type Staging Key");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction Type");

                entity.Property(e => e.ValidFrom).HasColumnName("Valid From");

                entity.Property(e => e.ValidTo).HasColumnName("Valid To");

                entity.Property(e => e.WwiTransactionTypeId).HasColumnName("WWI Transaction Type ID");
            });

            modelBuilder.HasSequence<int>("CityKey", "Sequences");

            modelBuilder.HasSequence<int>("CustomerKey", "Sequences");

            modelBuilder.HasSequence<int>("EmployeeKey", "Sequences");

            modelBuilder.HasSequence<int>("LineageKey", "Sequences");

            modelBuilder.HasSequence<int>("PaymentMethodKey", "Sequences");

            modelBuilder.HasSequence<int>("StockItemKey", "Sequences");

            modelBuilder.HasSequence<int>("SupplierKey", "Sequences");

            modelBuilder.HasSequence<int>("TransactionTypeKey", "Sequences");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
