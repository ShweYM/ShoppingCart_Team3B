using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using ShoppingCart.DB;
using Team3B_ShoppingCart.DB;
using Team3B_ShoppingCart.Models;

namespace Team3B_ShoppingCart.DB
{
    public class DBSeeder
    {
        //comment
        public DBSeeder(ShoppingCartContext dbcontext)
        {
            Product product1 = new Product();
            product1.ProductID = "PIDSOFTWARE1-1";
            product1.ProductName = "MICROSOFT OFFICE 365";
            product1.ProductPrice = 300;
            product1.InventoryQuantity = 100;
            product1.ImageURL = "microsoft-office-365-logo.png";
            product1.Description = "Microsoft Office is the most well-known software suite for productivity. For a fairly low monthly subscription fee, Microsoft 365 offers its software bundled together with access to the cloud.";
            dbcontext.Add(product1);

            Product product2 = new Product();
            product2.ProductID = "PIDSOFTWARE2-2";
            product2.ProductName = "MICROSOFT OFFICE 2019 STUDENT";
            product2.ProductPrice = 300;
            product2.InventoryQuantity = 100;
            product2.ImageURL = "Mac2019hs.png";
            product2.Description = "Microsoft Office Home & Student 2019 use is one of the best productivity suites available on the market. Thanks to advanced software solutions used in the program, it offers unparalleled adaptability and functionality, making work easy and intuitive. Home & Student versions of the 2019 suite offer the essential components: Word, Excel, and PowerPoint. These three will help you organize your work at home and study time with a variety of useful features.Create shopping lists, school essays, and more using Word; calculate house budget and create formulas in Excel; commemorate the most important family events or impress teachers with excellent presentations in PowerPoint.Microsoft Office Home and Student 2019 was recognized by the users and received favorable reviews for its convenience and usefulness.";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.ProductID = "PIDSOFTWARE3-3";
            product3.ProductName = "MICROSOFT OFFICE 2019 PRO";
            product3.ProductPrice = 300;
            product3.InventoryQuantity = 100;
            product3.ImageURL = "MSPro2019.jpg";
            product3.Description = "Get one of the most complete editions of the Microsoft Office package, that includes all of the Microsoft office software, with all of the classic features and many improved functions. The package includes 2019 versions of Word, Excel, PowerPoint, Outlook and additionally Publisher and Access, as well as Skype for Business, all with a one-buy lifetime license for one computer.";
            dbcontext.Add(product3);

            Product product4 = new Product();
            product4.ProductID = "PIDSOFTWARE4-4";
            product4.ProductName = "WPS OFFICE";
            product4.ProductPrice = 300;
            product4.InventoryQuantity = 100;
            product4.ImageURL = "wps.jpg";
            product4.Description = "WPS Office - Free Office Suite for Word, PDF, Excel is an all-in-one office suite integrates Word, PDF, Excel, PowerPoint, Forms, as well as Cloud Storage, Template Gallery, and Online Editing & Sharing. Also, WPS Office can perfectly work with Google Classroom, Zoom, Slack & Google Drive, makes your online work and study more efficient & stable.";
            dbcontext.Add(product4);

            Product product5 = new Product();
            product5.ProductID = "PIDSOFTWARE5-5";
            product5.ProductName = "APPLE IWORK";
            product5.ProductPrice = 300;
            product5.InventoryQuantity = 100;
            product5.ImageURL = "iWork.jpg";
            product5.Description = "Documents, spreadsheets and presentations. With everybody’s best thinking. Pages, Numbers and Keynote are the best ways to create amazing work.Templates and design tools make it easy to get started. You can even add illustrations and notations using Apple Pencil on your iPad.And with real‑time collaboration, your team can work together, whether they’re on Mac, iPad or iPhone, or using a PC.";
            dbcontext.Add(product5);

            Product product6 = new Product();
            product6.ProductID = "PIDSOFTWARE6-6";
            product6.ProductName = "ADOBE PREMIERE";
            product6.ProductPrice = 300;
            product6.InventoryQuantity = 100;
            product6.ImageURL = "adobepremier.png";
            product6.Description = "Premiere Pro is the industry-leading video editing software for film, TV, and the web. Creative tools, integration with other apps and services, and the power of Adobe Sensei help you craft footage into polished films and videos. With Premiere Rush you can create and edit new projects from any device.";
            dbcontext.Add(product6);

            Product product7 = new Product();
            product7.ProductID = "PIDSOFTWARE7-7";
            product7.ProductName = "APPLE FINAL CUT PRO X";
            product7.ProductPrice = 300;
            product7.InventoryQuantity = 100;
            product7.ImageURL = "finalcutx-vl.jpg";
            product7.Description = "Final Cut Pro X is a whole range of video editing software, and FCPX is the latest version of these series. It helps you in editing videos by cutting and pasting different texts or images in your video. This video editing software is used all over the world among various professional persons and studios as well. The latest version of Final Cut Pro has all the new features that a video editor must-have. The users of this software can transfer the video after editing and processing it to a hard drive into a wide variety of formats. ";
            dbcontext.Add(product7);

            Product product8 = new Product();
            product8.ProductID = "PIDSOFTWARE8-8";
            product8.ProductName = "SONY VEGAS PRO 16";
            product8.ProductPrice = 300;
            product8.InventoryQuantity = 100;
            product8.ImageURL = "vegas-pro.png";
            product8.Description = "VEGAS Movie Studio 16 offers our most user-friendly approach ever to creating beautiful videos. Work fast with interactive storyboards. Work confidently with automatic saves. Work smoothly with GPU and hardware acceleration. Powerful and intuitive – nothing helps you create like VEGAS Movie Studio 16!";
            dbcontext.Add(product8);

            Product product9 = new Product();
            product9.ProductID = "PIDSOFTWARE9-9";
            product9.ProductName = "AUTODESK AUTOCAD 2020";
            product9.ProductPrice = 300;
            product9.InventoryQuantity = 100;
            product9.ImageURL = "revit-2020.jpg";
            product9.Description = "AutoCAD is a 3D computer-assisted design software by Autodesk that’s created for manufacturing planning, product designing, building designing, construction, and civil engineering. More than making 3D models, AutoCAD is also used for drafts, documents, and 2D drawings. The 2D drawing, annotation features, and drafting allow users to customize texts, add dimension styles, tie in data from Microsoft Excel tables and spreadsheets to the drawings, and use dynamic blocks. On the side of 3D modeling and drawing, users can apply lighting and add materials to the models to produce real-life renditions and appearances. Edges, shading, and lighting can also be controlled for the models in AutoCAD. The app also allows users to look into the interior of their 3D creations. AutoCAD allows them to take data from PDF files to work with teammates as drawings and models are reviewed. Lastly, interface customization is also possible to make model editing faster and to organize the AutoCAD tools for easier access.";
            dbcontext.Add(product9);

            Product product10 = new Product();
            product10.ProductID = "PIDSOFTWARE10-10";
            product10.ProductName = "BENTLEY MICROSTATION V8i";
            product10.ProductPrice = 300;
            product10.InventoryQuantity = 100;
            product10.ImageURL = "bently.jpeg";
            product10.Description = "MicroStation's advanced engineering design, modeling, visualization and drawing production capabilities allow infrastructure professionals of any discipline to deliver projects of any scale or complexity. Your team can aggregate their work on MicroStation, including designs and models created with Bentley's discipline specific BIM applications (OpenRoads, Open Buildings, etc.) As a result, you can create comprehensive, multi-discipline models, documentation, and other deliverables.";
            dbcontext.Add(product10);

            Product product11 = new Product();
            product11.ProductID = "PIDSOFTWARE11-11";
            product11.ProductName = "AUTODESK REVIT 2020";
            product11.ProductPrice = 300;
            product11.InventoryQuantity = 100;
            product11.ImageURL = "autodesk.jpg";
            product11.Description = "Autodesk® Revit® 2020 software offers new and enhanced features that support multi-discipline teams throughout the project lifecycle. Autodesk Revit includes features for architectural design, mechanical, electrical, and plumbing, structural engineering, and construction and is available as part of the Autodesk architecture, engineering and construction industry collection, providing a comprehensive solution for the entire building project team.In the one box of Revit you'll find tools to help you with MEP, architecture and structural design.";
            dbcontext.Add(product11);

            Product product12 = new Product();
            product12.ProductID = "PIDSOFTWARE12-12";
            product12.ProductName = "AUTODESK REVIT 2019";
            product12.ProductPrice = 300;
            product12.InventoryQuantity = 100;
            product12.ImageURL = "revit2019.jpg";
            product12.Description = "Autodesk® Revit® is a Building Information Modeling (BIM) tool, which can be used by more than one person working on a new project. This is an important feature in collaboration within a project, between projects, and with other users, firms, and disciplines. The objective of the Autodesk® Revit® 2019: Collaboration Tools learning guide is to enable users, who have a basic knowledge of Autodesk Revit, to increase their productivity while working with other people on a team, either in the same firm or other firms as well as with other disciplines. It also covers linking Autodesk Revit files and linking or importing other CAD files. Practices are available for each of the primary disciplines covered by Autodesk Revit: Architecture, MEP, and Structure.";
            dbcontext.Add(product12);

            var key = "E546C8DF278CD5931069B522E695D4F2";

            Customer customer1 = new Customer();
            customer1.CustomerID = "SilentX1";
            customer1.Password = Utils.Crypto.Encrypt("1234", key);
            customer1.EmailAddress = "silentxtwilight@gmail.com";
            customer1.PhoneNumber = "12345678";
            customer1.FirstName = "Twilight";
            customer1.LastName = "SilentX";
            customer1.Address = "GhimMoh, Singapore";
            dbcontext.Add(customer1);

            Customer customer2 = new Customer();
            customer2.CustomerID = "SilentX2";
            customer2.Password = Utils.Crypto.Encrypt("5678", key);
            customer2.EmailAddress = "silentxtwilight@gmail.com";
            customer2.PhoneNumber = "12345678";
            customer2.FirstName = "Twilight";
            customer2.LastName = "SilentX";
            customer2.Address = "GhimMoh, Singapore";
            dbcontext.Add(customer2);

            Customer customer3 = new Customer();
            customer3.CustomerID = "SilentX3";
            customer3.Password = Utils.Crypto.Encrypt("1234", key);
            customer3.EmailAddress = "silentxtwilight@gmail.com";
            customer3.PhoneNumber = "12345678";
            customer3.FirstName = "Twilight";
            customer3.LastName = "SilentX";
            customer3.Address = "GhimMoh, Singapore";
            dbcontext.Add(customer3);

            Customer customer4 = new Customer();
            customer4.CustomerID = "SilentX4";
            customer4.Password = Utils.Crypto.Encrypt("1234", key);
            customer4.EmailAddress = "silentxtwilight@gmail.com";
            customer4.PhoneNumber = "12345678";
            customer4.FirstName = "Twilight";
            dbcontext.Add(customer4);

            dbcontext.SaveChanges();
        }  
    }
}