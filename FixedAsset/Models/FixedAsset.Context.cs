//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FixedAsset.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FixedAssetEntities : DbContext
    {
        public FixedAssetEntities()
            : base("name=FixedAssetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_userprofile> tbl_userprofile { get; set; }
        public virtual DbSet<tbl_amortise> tbl_amortise { get; set; }
        public virtual DbSet<tbl_Branch> tbl_Branch { get; set; }
        public virtual DbSet<tbl_Department> tbl_Department { get; set; }
        public virtual DbSet<tbl_FAAncilaryAmortSchedule> tbl_FAAncilaryAmortSchedule { get; set; }
        public virtual DbSet<tbl_FAAncilaryClass> tbl_FAAncilaryClass { get; set; }
        public virtual DbSet<tbl_FAAncilaryCost> tbl_FAAncilaryCost { get; set; }
        public virtual DbSet<tbl_FAAncilaryCostTrans> tbl_FAAncilaryCostTrans { get; set; }
        public virtual DbSet<tbl_FACategory> tbl_FACategory { get; set; }
        public virtual DbSet<tbl_FAClass> tbl_FAClass { get; set; }
        public virtual DbSet<tbl_FADepSchedule> tbl_FADepSchedule { get; set; }
        public virtual DbSet<tbl_FALocation> tbl_FALocation { get; set; }
        public virtual DbSet<tbl_FAMaintenaceHist> tbl_FAMaintenaceHist { get; set; }
        public virtual DbSet<tbl_FARecuringAmortSchedule> tbl_FARecuringAmortSchedule { get; set; }
        public virtual DbSet<tbl_FARecurringClass> tbl_FARecurringClass { get; set; }
        public virtual DbSet<tbl_FARecurringCost> tbl_FARecurringCost { get; set; }
        public virtual DbSet<tbl_FARecurringgCostTrans> tbl_FARecurringgCostTrans { get; set; }
        public virtual DbSet<tbl_FARevaluation> tbl_FARevaluation { get; set; }
        public virtual DbSet<tbl_FASchMaintRecord> tbl_FASchMaintRecord { get; set; }
        public virtual DbSet<tbl_FAWriteOff> tbl_FAWriteOff { get; set; }
        public virtual DbSet<tbl_FixedAsset> tbl_FixedAsset { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }
    }
}
