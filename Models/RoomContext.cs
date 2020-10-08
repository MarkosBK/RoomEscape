using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASP_ComplexEx.Models
{
    public class RoomContext:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ImageForRoom> Images { get; set; }
        public RoomContext(string name): base(name){}
        public RoomContext() { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageForRoom>().HasOptional(i => i.Room).WithMany(i => i.Images).HasForeignKey(i => i.RoomId).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Room>().HasOptional(i => i.Logo).WithMany().HasForeignKey(i => i.LogoId).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class myInitializer : DropCreateDatabaseAlways<RoomContext>
    {
        protected override void Seed(RoomContext context)
        {
            string desc = "Description Description DescriptionDe scriptionDescription" +
                "Description Descripti onDescriptionDesc riptionDescription" +
                "Descript ionDescrip tionDescr iptio nDescriptionDe scription" +
                "DescriptionDescriptio nDescripti onD escriptionDescription" +
                "Des cri ptionDescriptionDesc ription Descriptio nDescription" +
                "Descripti onDe scripti onDe scriptionDescriptionDescription" +
                "DescriptionDescriptio nD escript ionDe scriptionDes cription" +
                "DescriptionDescriptionDescriptionDescriptionDescription" +
                "Descripti onDesc ri ptionDe scription Desc rip tionDescription" +
                "DescriptionDescrip tionDes cript ionDescriptio nDescription" +
                "Descripti onDescriptionDescri ptionDe s criptionD escription" +
                "Descr ptionDescripti onDescr iptionDescriptionDescription" +
                "Descr iptionDescri ptionDescript ionDescri ptionDe scription";


            ImageForRoom img1 = new ImageForRoom() { Path = "/Images/1920.jpg", Title = "BUNKER", RoomId = 1, IsLogo = true };
            ImageForRoom img2 = new ImageForRoom() { Path = "/Images/wallpaper-1639.jpg", Title = "BUNKER", RoomId = 1, IsLogo = false };
            ImageForRoom img3 = new ImageForRoom() { Path = "/Images/джизус.png", Title = "BUNKER", RoomId = 1, IsLogo = false };
            ImageForRoom img4 = new ImageForRoom() { Path = "/Images/1.png", Title = "BUNKER", RoomId = 1, IsLogo = false };
            ImageForRoom img5 = new ImageForRoom() { Path = "/Images/джизус.png", Title = "BUNKER", RoomId = 2, IsLogo = true };
            ImageForRoom img6 = new ImageForRoom() { Path = "/Images/wallpaper-1639.png", Title = "BUNKER", RoomId = 2, IsLogo = false };
            ImageForRoom img7 = new ImageForRoom() { Path = "/Images/1920.jpg", Title = "BUNKER", RoomId = 2, IsLogo = false };
            ImageForRoom img8 = new ImageForRoom() { Path = "/Images/wallpaper-1639.jpg", Title = "BUNKER", RoomId = 3, IsLogo = true };
            ImageForRoom img9 = new ImageForRoom() { Path = "/Images/джизус.png", Title = "BUNKER", RoomId = 3, IsLogo = false };
            ImageForRoom img10 = new ImageForRoom() { Path = "/Images/1920.jpg", Title = "BUNKER", RoomId = 3, IsLogo = false };

            context.Rooms.Add(new Room()
            {
                Title = "BUNKER",
                Duration = 60,
                MinPlayers = 2,
                MaxPlayers = 6,
                Address = "AddressAddress",
                PhoneNumber = "+380960288929",
                Email = "markosbasilio17@gmail.com",
                Rating = 55,
                FearLevel = Level.EasierThanEasy,
                DifficultyLevel = Level.EasierThanEasy,
                Description = desc           
            }) ; 
            context.SaveChanges();
            context.Images.Add(img1);
            context.Images.Add(img2);
            context.Images.Add(img3);
            context.Images.Add(img4);
            context.SaveChanges();         
            
            context.Rooms.Add(new Room()
            {
                Title = "SUPERNATURAL",
                Duration = 60,
                MinPlayers = 2,
                MaxPlayers = 6,
                Address = "AddressAddress",
                PhoneNumber = "+380960288929",
                Email = "markosbasilio17@gmail.com",
                Rating = 55,
                FearLevel = Level.Hard,
                DifficultyLevel = Level.Hard,
                Description = desc           
            }) ; 
            context.SaveChanges();
            context.Images.Add(img5);
            context.Images.Add(img6);
            context.Images.Add(img7);
            context.SaveChanges();        
            
            context.Rooms.Add(new Room()
            {
                Title = "FRIDAY 13",
                Duration = 60,
                MinPlayers = 2,
                MaxPlayers = 6,
                Address = "AddressAddress",
                PhoneNumber = "+380960288929",
                Email = "markosbasilio17@gmail.com",
                Rating = 55,
                FearLevel = Level.Normal,
                DifficultyLevel = Level.Normal,
                Description = desc           
            }) ; 
            context.SaveChanges();
            context.Images.Add(img8);
            context.Images.Add(img9);
            context.Images.Add(img10);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}