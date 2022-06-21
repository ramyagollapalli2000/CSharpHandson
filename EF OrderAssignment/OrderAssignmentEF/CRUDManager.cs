﻿using Microsoft.EntityFrameworkCore;
using OrderAssignmentEF.MasterAllData;
using System.Net.Mail;

namespace OrderAssignmentEF
{
    public class CRUDManager : DbContext
    {
        private DemoDBContext demoDBContext;
        public CRUDManager()
        {
            demoDBContext = new DemoDBContext();
        }
        public void InsertItem()
        {
            Item itemsObj = new Item();
            Console.Write("Enter Item Name - ");
            itemsObj.ItemName = Console.ReadLine();
            Console.Write("Enter Item Quantity - ");
            itemsObj.ItemQTY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Item Price - ");
            itemsObj.ItemRate = Convert.ToInt32(Console.ReadLine());
            demoDBContext.item.Add(itemsObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Inserted");
        }
        public void UpdateItem()
        {
            ShowAllItems();
            Console.Write("Enter Item Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var itemObj = demoDBContext.item.Where(x => x.ID == id).FirstOrDefault();
            if (itemObj == null)
            {
                Console.WriteLine("Enter Item Id Doesn't Exists,Please Try Again - ");
                return;
            }
            Console.Write("Enter New Item Name - ");
            itemObj.ItemName = Console.ReadLine();
            Console.Write("Enter New Item Quantity - ");
            itemObj.ItemQTY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Item Price - ");
            itemObj.ItemRate = Convert.ToInt32(Console.ReadLine());
            demoDBContext.item.Update(itemObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Updated");
        }
        public void DeleteItem()
        {
            ShowAllItems();
            Console.Write("Enter Item Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var itemObj = demoDBContext.item.Where(x => x.ID == id).FirstOrDefault();
            if (itemObj == null)
            {
                Console.WriteLine("Enter Item Id Doesn't Exists,Please Try Again - ");
                return;
            }
            demoDBContext.item.Remove(itemObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Deleted");
        }
        public void ShowAllItems()
        {
            var listObj = demoDBContext.item.ToList();
            foreach (var item in listObj)
            {
                Console.WriteLine($"Item Id - {item.ID},Item Name - {item.ItemName},Item Quantity - {item.ItemQTY},Item Price - {item.ItemRate}");
            }
        }
        public void ShowOneItem()
        {
            Console.WriteLine("All Item Id's Present Are :");
            var listObj = demoDBContext.item.ToList();
            foreach (var item in listObj)
            {
                Console.Write($"{item.ID}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Please Choose 1 From This Of Which U Want To See Details - ");
            Console.Write("Enter Item Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var itemObj = demoDBContext.item.Where(x => x.ID == id).FirstOrDefault();
            if (itemObj == null)
            {
                Console.WriteLine("Enter Item Id Doesn't Exists,Please Try Again - ");
                return;
            }
            Console.WriteLine($"Item Name - {itemObj.ItemName},Item Quantity - {itemObj.ItemQTY},Item Price - {itemObj.ItemRate}");
        }
        public void InsertCustomer()
        {
            Customer customersObj = new Customer();
            Console.Write("Enter Customer First Name - ");
            customersObj.FirstName = Console.ReadLine();
            Console.Write("Enter Customer Last Name - ");
            customersObj.LastName = Console.ReadLine();
            Console.Write("Enter Customer Phone - ");
            customersObj.Phone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Email - ");
            customersObj.Email = Console.ReadLine();
            demoDBContext.customer.Add(customersObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Inserted");

        }
        public void UpdateCustomer()
        {
            ShowAllCustomers();
            Console.Write("Enter Customer Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var customersObj = demoDBContext.customer.Where(x => x.ID == id).FirstOrDefault();
            if (customersObj == null)
            {
                Console.WriteLine("Enter Customer Id Doesn't Exists,Please Try Again - ");
                return;
            }
            Console.Write("Enter Customer First Name - ");
            customersObj.FirstName = Console.ReadLine();
            Console.Write("Enter Customer Last Name - ");
            customersObj.LastName = Console.ReadLine();
            Console.Write("Enter Customer Phone - ");
            customersObj.Phone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Email - ");
            customersObj.Email = Console.ReadLine();
            demoDBContext.customer.Update(customersObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Updated");
        }
        public void DeleteCustomer()
        {
            ShowAllCustomers();
            Console.Write("Enter Customer Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var customersObj = demoDBContext.customer.Where(x => x.ID == id).FirstOrDefault();
            if (customersObj == null)
            {
                Console.WriteLine("Enter Item Id Doesn't Exists,Please Try Again - ");
                return;
            }
            demoDBContext.customer.Remove(customersObj);
            demoDBContext.SaveChanges();
            Console.WriteLine("Record Deleted");
        }
        public void ShowAllCustomers()
        {
            var listObj = demoDBContext.customer.ToList();
            foreach (var item in listObj)
            {
                Console.WriteLine($"Customer FName - {item.FirstName},Customer LName - {item.LastName},Customer Phone - {item.Phone},Customer Email - {item.Email}");
            }
        }
        public void ShowOneCustomer()
        {
            Console.WriteLine("All Customer Id's Present Are :");
            var listObj = demoDBContext.customer.ToList();
            foreach (var item in listObj)
            {
                Console.Write($"{item.ID}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Please Choose 1 From These Of Which U Want To See Details - ");
            Console.Write("Enter Customer Id - ");
            int id = Convert.ToInt32(Console.ReadLine());
            var customersObj = demoDBContext.customer.Where(x => x.ID == id).FirstOrDefault();
            if (customersObj == null)
            {
                Console.WriteLine("Enter Item Id Doesn't Exists,Please Try Again - ");
                return;
            }
            Console.WriteLine($"Customer FName - {customersObj.FirstName},Customer LName - {customersObj.LastName},Customer Phone - {customersObj.Phone},Customer Email - {customersObj.Email}");
        }
        public void Verify()
        {
            Console.Write("Enter Your Email Id - ");
            string email = Console.ReadLine();
            var customersObj = demoDBContext.customer.Where(x => x.Email == email).FirstOrDefault();
            if (customersObj == null)
            {
                Console.WriteLine("You Are Not A Valid Customer, 1st Register Yourself In Our Shop Then Only U Can Book Items From Us - ");
                return;
            }
            ShowAllItems();
            Console.WriteLine("Which Item Do U Want To Book, Enter It's Id - ");
            int checkId = Convert.ToInt32(Console.ReadLine());
            var checkItem = demoDBContext.item.Where(x => x.ID == checkId).FirstOrDefault();
            if (checkItem == null)
            {
                Console.WriteLine("Item With Entered Id Doesn't Exists,Please Try Again - ");
                return;
            }
            SendEmail(customersObj.Email, customersObj.FirstName);
        }
        private void SendEmail(string email, string firstName)
        {
            MailMessage mailMessageObj = new MailMessage("gopal.banger@kelltontech.com", email);
            mailMessageObj.Subject = "Welcome";
            mailMessageObj.Body = $"Dear {firstName}, Thanks for ordering item from us.";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "gopal.banger@kelltontech.com",
                Password = "123"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessageObj);
        }
    }
}
