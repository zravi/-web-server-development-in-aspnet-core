﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersEFCodeFirst.Data;

#nullable disable

namespace MovieCharactersEFCodeFirst.Migrations
{
    [DbContext(typeof(MovieManagerDbContext))]
    [Migration("20220930110002_AddInitialDB")]
    partial class AddInitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 4
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 5
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 6
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 7
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 7
                        });
                });

            modelBuilder.Entity("MovieCharactersEFCodeFirst.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Gender")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Picture")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 12,
                            FullName = "Sophie Hatter",
                            Gender = "Female",
                            Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/5/55/Starlight_Sophie.jpg/revision/latest?cb=20210708011122"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Fire Demon",
                            FullName = "Calcifer",
                            Picture = "https://i.pinimg.com/736x/2d/ba/9a/2dba9a559e6b0a04f5086324ca96fe75.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Age = 10,
                            Alias = "Sen",
                            FullName = "Chihiro Ogino",
                            Gender = "Female",
                            Picture = "https://static.wikia.nocookie.net/p__/images/9/90/Chihiro_cropped.jpg/revision/latest?cb=20220309165348&path-prefix=protagonist"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Haku",
                            FullName = "Spirit of the Kohaku River",
                            Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/3/37/Haku_Dragon_form.jpeg/revision/latest/scale-to-width-down/894?cb=20170904233228"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "Kaonashi",
                            FullName = "No-Face"
                        },
                        new
                        {
                            Id = 6,
                            Age = 10,
                            FullName = "Satsuki Kusakabe",
                            Picture = "https://static.wikia.nocookie.net/disney/images/b/b9/Satsuki.jpg/revision/latest?cb=20140725154339"
                        },
                        new
                        {
                            Id = 7,
                            Age = 3000,
                            FullName = "Totoro",
                            Gender = "Male",
                            Picture = "https://static.wikia.nocookie.net/studio-ghibli/images/d/df/Totoro_in_the_rain.png/revision/latest/scale-to-width-down/350?cb=20200831205004"
                        });
                });

            modelBuilder.Entity("MovieCharactersEFCodeFirst.Domain.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Studio Ghibli Inc. is a Japanese animation film studio based in Koganei, Tokyo. The studio is best known for its animated films and has also produced several short films, television commercials, and a television movie.",
                            Name = "Studio Ghibli"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Madhouse Inc. is a Japanese animation studio founded in 1972 by former Mushi Pro animators, including Masao Maruyama, Osamu Dezaki, Rintaro, and Yoshiaki Kawajiri.",
                            Name = "Madhouse"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Toei Animation Co., Ltd. is a Japanese animation studio controlled primarily by its namesake Toei Company. It has created a number of television series and movies and has adapted Japanese comics as animated series, many of which are popular around the world.",
                            Name = "Toei Animation"
                        });
                });

            modelBuilder.Entity("MovieCharactersEFCodeFirst.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Picture")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 1,
                            Genre = "Anime",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a0/Howls-moving-castleposter.jpg/220px-Howls-moving-castleposter.jpg",
                            ReleaseYear = 2004,
                            Title = "Howl's Moving Castle",
                            Trailer = "https://www.youtube.com/watch?v=iwROgK94zcM"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 1,
                            Genre = "Anime",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/d/db/Spirited_Away_Japanese_poster.png/220px-Spirited_Away_Japanese_poster.png",
                            ReleaseYear = 2001,
                            Title = "Spirited Away",
                            Trailer = "https://www.youtube.com/watch?v=ByXuk9QqQkk"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 1,
                            Genre = "Anime",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/thumb/0/02/My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg/220px-My_Neighbor_Totoro_-_Tonari_no_Totoro_%28Movie_Poster%29.jpg",
                            ReleaseYear = 1988,
                            Title = "My Neighbor Totoro",
                            Trailer = "https://www.youtube.com/watch?v=92a7Hj0ijLs"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Hayao Miyazaki",
                            FranchiseId = 1,
                            Genre = "Anime",
                            ReleaseYear = 2002,
                            Title = "Mei and the Kittenbus",
                            Trailer = "https://www.youtube.com/watch?v=92a7Hj0ijLs"
                        },
                        new
                        {
                            Id = 5,
                            Director = "Adam Wingard",
                            FranchiseId = 2,
                            Genre = "Anime",
                            ReleaseYear = 2017,
                            Title = "Death Note"
                        },
                        new
                        {
                            Id = 6,
                            Director = "Mamoru Oshii",
                            Genre = "Anime",
                            ReleaseYear = 1995,
                            Title = "Ghost in the Shell"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("MovieCharactersEFCodeFirst.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersEFCodeFirst.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersEFCodeFirst.Domain.Movie", b =>
                {
                    b.HasOne("MovieCharactersEFCodeFirst.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieCharactersEFCodeFirst.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
