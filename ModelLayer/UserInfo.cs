using ModelLayer.UIModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    [Table("UserInfo", Schema = "Admin")]
    public class UserInfo : BaseEntity
    {
        public UserInfo()
        {
            ContactInfo = new Contact();
            IsLoginEnabled = false;
        }
        [Required]
        public long ContactId { get; set; }
        [NotMapped]
        public Contact ContactInfo { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public bool IsLoginEnabled { get; set; }

        public static explicit operator UserInfo(UserInfoModel entity)
        {
            UserInfo model = new();
            model.ID = entity.ID;
            model.ContactId = entity.ContactInfo.ID;
            model.ContactInfo = (Contact)entity.ContactInfo;
            model.UserName = model.ContactInfo.Email;
            model.Password = CreateRandomPassword();
            model.IsLoginEnabled = entity.IsLoginEnabled;
            model.CreatedBy = entity.CreatedBy;
            model.CreatedDate = DateTime.Now;
            model.ModifiedBy = entity.CreatedBy;
            model.ModifiedDate = DateTime.Now;
            return model;
        }
        private static string CreateRandomPassword(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
