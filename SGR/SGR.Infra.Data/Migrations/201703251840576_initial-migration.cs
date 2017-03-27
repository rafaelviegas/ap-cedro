namespace SGR.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dish",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DishId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dish", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.Dish", new[] { "RestaurantId" });
            DropTable("dbo.Restaurant");
            DropTable("dbo.Dish");
        }
    }
}
