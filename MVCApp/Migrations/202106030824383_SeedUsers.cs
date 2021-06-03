namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6879d7ba-feae-4d25-bc68-8894934189b1', N'dummy@gmail.com', 0, N'AEzAXjfNBGgVLN3CsYnwLMDGWUbLN12ZXpLWENfRjtRG7fMDdfIiy1OTFtjiQFrYgA==', N'4a5c7c6c-5471-4088-b058-ee0b83870cca', NULL, 0, 0, NULL, 1, 0, N'dummy@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'731bc7c2-6fe8-453c-a56c-052a432719ce', N'admin@host.com', 0, N'AIQAAgv+tZzXDv27z63nRAvQf+uKcBYWvc+6DE56Na50rs0pzqkHjsD80J+ncHMcLg==', N'f1833f61-4d0c-4920-a660-898dfd867e61', NULL, 0, 0, NULL, 1, 0, N'admin@host.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e3e1afca-f27a-4abc-b601-5e9acc20b798', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'731bc7c2-6fe8-453c-a56c-052a432719ce', N'e3e1afca-f27a-4abc-b601-5e9acc20b798')


");
        }
        
        public override void Down()
        {
        }
    }
}
