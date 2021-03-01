using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ReturnDateError = "Araç henüz teslim edilmemiş.";
        public static string RentalSuccess = "Araç kiralama listesine eklendi.";
        public static string LimitedExcected = "Bir aracın en fazla 5 resmi olabilir.";

        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş Yapıldı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var.";
        public static string UserRegistered = "Kullanıcı oluştuldu";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz bulunmuyor";
    }
}