﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Copiosis_Application.DB_Data;

namespace Copiosis_Application.Models
{
    /*public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {s
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    */
    /* This model may need to change once we have the db schema and seed script */
    public class AccountManagerModel
    {
        
        public bool isValidatedUser { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string currentPassword { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        public string confirmPassword { get; set; }

        [Display(Name = "User name")]
        public string userName { get; set; }

        public string currentUserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string emailAddress { get; set; }

        public string currentEmail { get; set; }

        [Display(Name = "First name")]
        public string firstName { get; set; }

        public string currentFirstName { get; set; }

        [Display(Name = "Last name")]
        public string lastName { get; set; }

        public string currentLastName { get; set; }

        public Dictionary<string, string> errorList { get; set; }

        //Constructor
        //For certainty
        public AccountManagerModel()
        {
            this.isValidatedUser = false;
        }

    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    /* Will likely need to add a token field to this so that only users with the Kenton token can register.
     * The mockup for Signup has the fields that will need to be here */
    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Signup Token")]
        public string Token { get; set; }
    }

    /*  */
    public class ItemsModel
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Gateway { get; set; }

        public string ItemClass { get; set; }

        public Guid ItemGuid { get; set; }

        public string ItemType { get; set; }
    }
    
    public class AddItemModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Class")]
        [Required(ErrorMessage = "Class is required")]
        public string ItemClass { get; set; }

        [Required(ErrorMessage = "Gateway is required")]
        public int Gateway { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Item must be a Product or Service")]
        public string ItemType { get; set; }

        //This is needed for the get portion of AddItem
        public Dictionary<string, int> ItemClassTemplates { get; set; }
    }

    public class TransactionOverviewModel
    {
        public List<TransactionModel> pendingUser { get; set; }
        public List<TransactionModel> pendingOther { get; set; }
        public List<TransactionModel> completed { get; set; }
    }

    public class TransactionModel
    {
        // Things expected to be used on the Overview page.
        public Guid transactionID { get; set; }
        public bool newSinceLogin { get; set; }       
        public string date { get; set; }
        public string status { get; set; }
        public DateTime dateAdded { get; set; }
        public DateTime? dateClosed { get; set; }           
        public double? nbr { get; set; }        
        public string otherParty { get; set; }
        public Guid productGuid { get; set; }
        public string productName { get; set; }
        public int productGateway { get; set; }
        public bool isProducer { get; set; }

        // Additional things expected to be used on the Transaction View page.
        public string productDesc { get; set; }
        public int? satisfaction { get; set; }
        public string providerNotes { get; set; }
        public string providerFirstName { get; set; }
        public string providerLastName { get; set; }
        public string providerUsername { get; set; }
        public string receiverNotes { get; set; }
        public string receiverFirstName { get; set; }
        public string receiverLastName { get; set; }
        public string receiverUsername { get; set; }
        public bool isPendingUser { get; set; }
        public string result { get; set; }

        // Things used in our backend logic
        public int providerID { get; set; }
        public int receiverID { get; set; }
       
    }

    public class NewTransactionModel
    {
        /*GET*/
        public bool IsProducer { get; set; }
        public List<string> Consumers { get; set; }
        public List<string> Producers { get; set; }
        public List<string> Products { get; set; }
        public List<string> Usernames { get; set; }
        /*POST*/

        [Display(Name = "Consumer:")]
        public string Consumer { get; set; }

        [Display(Name = "Producer:")]
        public string Producer { get; set; }

        [Display(Name = "Product Provided:")]
        public string ProductProvided { get; set; }

        [Display(Name = "Notes:")]
        public string Notes { get; set; }

        [Display(Name = "Satisfaction Rating:")]
        public int SatisfactionRating { get; set; }
    }
}
