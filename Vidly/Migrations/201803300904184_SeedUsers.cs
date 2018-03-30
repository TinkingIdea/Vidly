namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5bfb341c-e26e-4dc8-a572-c75cad8435d0', N'guest@TK.com', 0, N'AAQXE/a6lHgeKnARQbc81CJ7NAAO2j84Z3MYHYmXdBKr5HLYfpzuLBdQ5D+856QL5A==', N'ad5e2b4f-7ed2-4823-b165-1bc48ba9cccf', NULL, 0, 0, NULL, 1, 0, N'guest@TK.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec6703ba-c672-4e85-9d7f-8ceb2790a276', N'admin@Tk.com', 0, N'AKPEEaFSLRFUglGkbCtujWZi7278MEF95EiTnNzrM83Z2waXyPEEhnMGo14WpUBoOA==', N'0c9a5ebc-1bfb-4a23-8322-a1e61e583a6c', NULL, 0, 0, NULL, 1, 0, N'admin@Tk.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9aa0c7df-0456-4b38-807c-30b29049ce19', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec6703ba-c672-4e85-9d7f-8ceb2790a276', N'9aa0c7df-0456-4b38-807c-30b29049ce19')
               ");
        }

        public override void Down()
        {
        }
    }
}
