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
        public static string CarImagesCountExceded = "Bir aracın en fazla 5 resmi olabilir.";
        public static string added = "Eklendi";
        public static string deleted = "Silindi";
        public static string updated = "Güncellendi";
        public static string error = "Hata";
        public static string listed = "Listelendi";
        public static string succeed = "İşlem Başarılı";

        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordSame = "Eski şifre ile yeni şifre aynı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Giriş Yapıldı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var.";
        public static string UserRegistered = "Kayıt Oluşturuldu";
        public static string AccessTokenCreated = "Giriş Başarılı";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz bulunmuyor";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };


        public static string InsufficientBalance = "Yetersiz bakiye";
        public static string CardInfoSuccess = "Kart Bilgileri Doğrulandı";
        public static string PaymentCompleted = "Ödeme Başarılı";
        public static string cardInfoError = "Kart Bilgileri Hatalı";
        public static string CardExist = "Kart Zaten Kayıtlı";
        public static string findexPointAdd = "Tebrikler 50 Findex Puan'ı kazandınız";
        public static string findexPointMax = "Findex Puanınız Zaten En Yüksek Değerde";
    }
}